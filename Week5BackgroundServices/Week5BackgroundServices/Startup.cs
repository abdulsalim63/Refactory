using System;
using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using FluentValidation;
using FluentValidation.AspNetCore;
using Week5BackgroundServices.Application.Models.Query;
using Week5BackgroundServices.Application.Interfaces;
using Week5BackgroundServices.Application.UseCases.CustomerCards;
using Week5BackgroundServices.Application.UseCases.Customers;
using Week5BackgroundServices.Application.UseCases.Merchants;
using Week5BackgroundServices.Application.UseCases.Products;
using Week5BackgroundServices.Infrastructure;
using MediatR;
using Hangfire;
using Hangfire.PostgreSql;

namespace Week5BackgroundServices
{
    public class Startup
    {
        private readonly string connectionString = "Host=localhost;Username=postgres;Password=docker;Database=backgroundservices";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddHangfire(option =>
                option.UsePostgreSqlStorage(connectionString));

            services.AddDbContext<ProjectContext>(opt => opt.UseNpgsql(connectionString));

            services.AddMediatR(typeof(CreateCustomerCommandHandler).GetTypeInfo().Assembly)
                    .AddMediatR(typeof(CreateCustomerCardCommandHandler).GetTypeInfo().Assembly)
                    .AddMediatR(typeof(CreateMerchantCommandHandler).GetTypeInfo().Assembly)
                    .AddMediatR(typeof(CreateProductCommandHandler).GetTypeInfo().Assembly);

            services.AddMvc().AddFluentValidation();

            services.AddTransient<IValidator<BaseRequest<CustomerInput>>, CreateCustomerCommandValidation>()
                    .AddTransient<IValidator<BaseRequest<CustomerCardInput>>, CreateCustomerCardCommandValidation>()
                    .AddTransient<IValidator<BaseRequest<MerchantInput>>, CreateMerchantCommandValidation>()
                    .AddTransient<IValidator<BaseRequest<ProductInput>>, CreateProductCommandValidation>()
                    .AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidatorBehaviour<,>));

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
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("this is encryption key")),
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

            app.UseHangfireServer();
            app.UseHangfireDashboard();

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
