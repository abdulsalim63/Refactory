using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
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

using PaymentServices.Infrastructure;
using PaymentServices.Application.Models;
using PaymentServices.Application.UseCases.Payments;
using FluentValidation.AspNetCore;
using FluentValidation;

namespace PaymentServices
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

            services.AddDbContext<PaymentContext>(opt => opt.UseNpgsql(Configuration.GetConnectionString("PostgreSQLServer")));

            services.AddMediatR(typeof(CreatePaymentCommand).GetTypeInfo().Assembly);

            services.AddMvc().AddFluentValidation();

            services.AddTransient<IValidator<CreatePaymentCommand>, CreatePaymentCommandValidation>()
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

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
