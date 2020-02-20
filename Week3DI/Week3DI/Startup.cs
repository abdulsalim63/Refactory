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
using Npgsql;
using Week3DI.Models;

namespace Week3DI
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
            var connection = new NpgsqlConnection("Host=127.0.0.1;Username=postgres;Password=password;Database=ContactDb");
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = "INSERT INTO ContactDb (username, password, email, full_name) VALUES (@username, @password, @email, @full_name) RETURNING id";
            var user = new Contact
            {
                Username = "likeABlindManToldDrivingACar",
                Password = "Confidential",
                Email = "Confidential",
                Full_Name = "Also Confidential"
            };
            command.Parameters.AddWithValue("@username", user.Username);
            command.Parameters.AddWithValue("@password", user.Password);
            command.Parameters.AddWithValue("@email", user.Email);
            command.Parameters.AddWithValue("@full_name", user.Full_Name);
            command.Prepare();
            command.ExecuteScalar();
            connection.Close();

            services.AddDbContext<ContactContext>(opt => opt.UseNpgsql("ContactDb"));

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
