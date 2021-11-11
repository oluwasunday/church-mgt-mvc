using church_mgt_model;
using church_mgt_model.Dtos;
using church_mgt_services.interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace church_mgt_services.implementations
{
    public class TestimonyService : ITestimonyService
    {
        private string _baseUrl;
        public TestimonyService(IWebHostEnvironment env, IConfiguration configuration)
        {
            _baseUrl = env.IsProduction() ? configuration["HerokuUrl"] : configuration["BaseUrl"];
        }

        public async Task<Response<AddTestimonyDto>> AddTestimonyAsync(AddTestimonyDto model)
        {
            var testimonyJson = JsonConvert.SerializeObject(model);
            var testimonyPayload = new StringContent(testimonyJson, Encoding.UTF8, "application/json");

            var testimony = new AddTestimonyDto();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseUrl);

                var request = await client.PostAsync("api/Testimonies", testimonyPayload);
                if (request.IsSuccessStatusCode)
                {
                    var result = request.Content.ReadAsStringAsync().Result;
                    testimony = JsonConvert.DeserializeObject<AddTestimonyDto>(result);

                    if (testimony != null)
                        return new Response<AddTestimonyDto> { StatusCode = StatusCodes.Status201Created, Data = testimony, Message = "Success", Succeeded = true };
                }
            }

            return new Response<AddTestimonyDto> { StatusCode = StatusCodes.Status500InternalServerError, Data = null, Message = "Failed", Succeeded = false };
        }
    }
}
