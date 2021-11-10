using church_mgt_model.ViewModels;
using church_mgt_services.interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace church_mgt_services.implementations
{
    public class PaymentService : IPaymentService
    {
        private readonly IWebHostEnvironment _env;
        private string _baseUrl { get; set; }
        private readonly IConfiguration _configuration;
        public PaymentService(IWebHostEnvironment env, IConfiguration configuration)
        {
            _env = env;
            _configuration = configuration;
            _baseUrl = env.IsProduction() ? _configuration["HerokuUrl"] : _configuration["BaseUrl"];
        }


        public async Task<OnlineGivingResponseViewModel> MakePaymentAsync(OnlineGivingViewModel model)
        {
            var paymentJson = JsonConvert.SerializeObject(model);
            var paymentPayload = new StringContent(paymentJson, Encoding.UTF8, "application/json");

            var payment = new OnlineGivingResponseViewModel();


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseUrl);
                                
                var response = await client.PostAsync("api/Payments", paymentPayload);
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    payment = JsonConvert.DeserializeObject<OnlineGivingResponseViewModel>(result);

                    if (payment != null)
                        return payment;
                }
            }

            return payment;
        }
    }
}
