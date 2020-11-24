using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryWebApi.Databases;
using LibraryWebApi.Services;
using LibraryWebApi.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LibraryWebApi
{
    public class Startup
    {

        public IConfiguration Configuration;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            var connection = Environment.GetEnvironmentVariable("CONNECTION_STRING");
            //"Data Source=(localdb)\\MSSQLLocalDB;Database=LibraryBookingSystemDB;Trusted_Connection=True"
            services.AddDbContext<ApplicationDbContext>
              (builder =>
                   builder.UseSqlServer(connection)
              );

            services.AddTransient<IAccount, AccountService>();
            services.AddTransient<IAuthorizationLevel, AuthorizationLevelService>();
            services.AddTransient<IBook, BookService>();
            services.AddTransient<ICategorizationEvent, CategorizationEventSevice>();
            services.AddTransient<ICategory, CategoryService>();
        }


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
