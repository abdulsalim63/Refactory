using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Week5Decorator.Models;
using Week5Decorator.Validator;
using Week5Decorator.Controllers;

namespace Week5Decorator
{
    public class Startup
    {
        private readonly string connectionString;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            connectionString = "Host=localhost;Username=postgres;Password=docker;Database=decorator";
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<CustomerContext>(opt => opt.UseNpgsql(connectionString));
            services.AddDbContext<MerchantProductContext>(opt => opt.UseNpgsql(connectionString));

            services.AddMvc()
                    .AddFluentValidation();

            services.AddTransient<IValidator<Request<Customer>>, CustomerValidator>()
                    .AddTransient<IValidator<Request<CustomerCard>>, CustomerPaymentValidation>()
                    .AddTransient<IValidator<Request<Product>>, ProductValidation>()
                    .AddTransient<IValidator<Request<Merchant>>, MerchantValidation>();

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidator<,>));

            services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("this is some secret shit")),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
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
