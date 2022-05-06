using TechShop.DataAccess;
using TechShop.DataAccess.Entities;
using TechShop.DataAccess.Repositories;
using TechShop.DTO;
using TechShop.Extensions;
using TechShop.Filters;
using TechShop.Helpers;
using TechShop.Middlewares;
using TechShop.Services.Abstract;
using TechShop.Services.Concrete;
using TechShop.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechShop
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
            services.AddSingleton(Log.Logger);

            services.AddSingleton<IConfigurationManager, ConfigurationManager>();

            services.AddControllers(config => config.Filters.Add(new RequestValidationFilter())).ConfigureApiBehaviour();
            services.AddCustomCors("CustomCors");
            services.AddTransient<ExceptionHandlingMiddleware>();

            services.AddDbContext<TechShopDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("mssql")));


            services.AddFluentValidation(s =>
             {
                 s.RegisterValidatorsFromAssemblyContaining<Startup>();
                 s.DisableDataAnnotationsValidation = true;
                 s.AutomaticValidationEnabled = true;
             });

            services.AddScoped<IRepository<Category>, CategoryRepository>();
            services.AddScoped<IRepository<Product>, ProductRepository>();

            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<IProductService, ProductManager>();


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TechShop", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TechShop v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseCors(x =>
            {
                x.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });

            app.Use(async (context, next) =>
            {
                //enable buffering of the request
                context.Request.EnableBuffering();
                await next();
            });
            app.UseMiddleware<ExceptionHandlingMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
