﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using G1GLK1_HFT_2021221.Logic;
using G1GLK1_HFT_2021221.Models;
using G1GLK1_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using G1GLK1_HFT_2021221.Data;
using G1GLK1_SGUI_2023_23_2.Services;

namespace G1GLK1_SGUI_2023_23_2.Endpoint
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<Delivery_service_context>();

            services.AddTransient<IConsumerLogic, ConsumerLogic>();
            services.AddTransient<IOrderLogic, OrderLogic>();
            services.AddTransient<IRestaurantLogic, RestaurantLogic>();
            services.AddTransient<IConsumerRepository, ConsumerRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IRestaurantRepository, RestaurantRepository>();
            services.AddTransient<Delivery_service_context, Delivery_service_context>();

            services.AddSignalR();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "G1GLK1_SGUI_2023_23_2.Endpoint", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "G1GLK1_SGUI_2023_23_2.Endpoint v1"));
            }

            //app.UseExceptionHandler(c => c.Run(async context =>
            //{
            //    var exception = context.Features
            //        .Get<IExceptionHandlerPathFeature>()
            //        .Error;
            //    var response = new { Msg = exception.Message };
            //    await context.Response.WriteAsJsonAsync(response);
            //}));

            app.UseCors(x => x
                    .AllowCredentials()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .WithOrigins("http://localhost:5145"));

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<SignalR>("/hub");
            });
        }
    }
}