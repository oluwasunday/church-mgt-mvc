﻿using church_mgt_services.implementations;
using church_mgt_services.interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace HotelMgt.API.Extensions
{
    public static class ServicesExtension
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {

            // Add Repository Injections Here 
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IContactUsService, ContactUsService>();
            services.AddScoped<ITestimonyService, TestimonyService>();

        }
    }
}
