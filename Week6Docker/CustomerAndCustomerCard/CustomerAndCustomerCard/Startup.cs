using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CustomerAndCustomerCard.Application.Interfaces;
using CustomerAndCustomerCard.Application.Models.Query;
using CustomerAndCustomerCard.Application.UseCases.CustomerCards;
using CustomerAndCustomerCard.Application.UseCases.Customers;
using CustomerAndCustomerCard.Infrastructure;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CustomerAndCustomerCard
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

            services.AddDbContext<ProjectContext>(opt => opt.UseNpgsql(Configuration.GetConnectionString("PostgreSQLServer")));

            services.AddMediatR(typeof(CreateCustomerCommandHandler).GetTypeInfo().Assembly)
                    .AddMediatR(typeof(CreateCustomerCardCommandHandler).GetTypeInfo().Assembly);

            services.AddMvc().AddFluentValidation();

            services.AddTransient<IValidator<BaseRequest<CustomerInput>>, CreateCustomerCommandValidation>()
                    .AddTransient<IValidator<BaseRequest<CustomerCardInput>>, CreateCustomerCardCommandValidation>()
                    .AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidatorBehaviour<,>));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
