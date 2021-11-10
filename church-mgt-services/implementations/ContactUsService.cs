using church_mgt_model;
using church_mgt_model.ViewModels;
using church_mgt_services.interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace church_mgt_services.implementations
{
    public class ContactUsService : IContactUsService
    {
        private string _baseUrl;
        public ContactUsService(IWebHostEnvironment env, IConfiguration configuration)
        {
            _baseUrl = env.IsProduction() ? configuration["HerokuUrl"] : configuration["BaseUrl"];
        }

        public async Task<Response<ContactUsViewModel>> AddContactUsAsync(ContactUsViewModel model)
        {
            var contactJson = JsonConvert.SerializeObject(model);
            var contactPayload = new StringContent(contactJson, Encoding.UTF8, "application/json");

            var contact = new ContactUsViewModel();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseUrl);

                var request = await client.PostAsync("api/ContactUs", contactPayload);
                if (request.IsSuccessStatusCode)
                {
                    var result = request.Content.ReadAsStringAsync().Result;
                    contact = JsonConvert.DeserializeObject<ContactUsViewModel>(result);

                    if (contact != null)
                        return new Response<ContactUsViewModel> { StatusCode = StatusCodes.Status201Created, Data = contact, Message = "Success", Succeeded = true };
                }
            }

            return new Response<ContactUsViewModel> { StatusCode = StatusCodes.Status500InternalServerError, Data = null, Message = "Failed", Succeeded = false };
        }
    }
}
