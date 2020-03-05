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
using Microsoft.EntityFrameworkCore;
using MediatR;
using FluentValidation;
using FluentValidation.AspNetCore;
using Week5Mediator.Domain.Models;
using Week5Mediator.Application.Interfaces;
using Week5Mediator.Application.UseCases.Customers.Queries.GetCustomer;
using Week5Mediator.Application.UseCases.Customers.Command.CreateCustomer;
using Week5Mediator.Application.UseCases.CustomerCards.Queries.GetCustomerCard;
using Week5Mediator.Application.UseCases.CustomerCards.Command.CreateCustomerCard;
using Week5Mediator.Application.UseCases.Merchants.Queries.GetMerchant;
using Week5Mediator.Application.UseCases.Merchants.Command.CreateMerchant;
using Week5Mediator.Application.UseCases.Products.Queries.GetProduct;
using Week5Mediator.Application.UseCases.Products.Command.CreateProduct;
using Week5Mediator.Infrastructure;
using System.Reflection;

namespace Week5Mediator
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
            services.AddControllers();

            services.AddDbContext<AllContext>(opt => opt.UseNpgsql("Host=localhost;Username=postgres;Password=docker;Database=mediator"));

            //services.AddMediatR(typeof(GetCustomerQueryHandler).GetTypeInfo().Assembly);

            services.AddMvc().AddFluentValidation();

            services.AddTransient<IValidator<CreateCustomerCommand>, CreateCustomerCommandValidation>();
            services.AddTransient<IValidator<CreateCustomerCardCommand>, CreateCustomerCardCommandValidation>();
            services.AddTransient<IValidator<CreateMerchantCommand>, CreateMerchantCommandValidation>();
            services.AddTransient<IValidator<CreateProductCommand>, CreateProductCommandValidation>();

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidatorBehaviour<,>));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
