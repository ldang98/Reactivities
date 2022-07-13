using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Persistence;
using MediatR;
using Application.Activities;
using AutoMapper;
using Application.Interfaces;
using Infastructure.Security;

namespace API.Extensions
{
    public static class ApplicationsServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPIv5", Version = "v1" });
            });
            services.AddDbContext<DataContext>(Opt =>
            {
                Opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });

            //Add a CORS policy to allow react app to fetch api response
            services.AddCors(opt => {
                opt.AddPolicy("CorsPolicy", policy =>{
                    //chain any policies we want to add
                   policy.AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:3000"); 
                });
            });
            services.AddMediatR(typeof(List.Handler).Assembly);
            services.AddAutoMapper(typeof(Application.Core.MappingProfiles).Assembly);
            services.AddScoped<IUserAccessor, UserAccessor>(); 

            return services;
        }
    }
}