﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PeopleSearchAPI.Models;

namespace PeopleSearchAPI
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
            services.AddMvc();
            services.AddCors();
            services.AddCors(options =>
            {
                options.AddPolicy("cors-policy",
                    builder => builder.WithOrigins("http://localhost:64833"));
            });
            var connection = @"Server=(localdb)\mssqllocaldb;Database=HealthCatalystPeople;Trusted_Connection=True;ConnectRetryCount=0";
            services.AddDbContext<PeopleContext>(options => options.UseSqlServer(connection));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, PeopleContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc();
            app.UseCors("cors-policy");
         
            //Make sure the database gets created on first time use (for Health Catalyst folks)
            context.Database.EnsureCreated();
        }
    }
}
