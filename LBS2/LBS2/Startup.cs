using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LBS2.Databases;
using LBS2.DTOs.Mappings;
using LBS2.Services;
using LBS2.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace LBS2
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
            services.AddControllersWithViews().AddNewtonsoftJson(
                    x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                  );

            services.AddTransient<IAccount, DbAccountService>();
            services.AddTransient<IAuthorizationLevel, DbAuthorizationLevelService>();
            services.AddTransient<IBook, DbBookService>();
            services.AddTransient<IBookCategories, DbBookCategoriesService>();
            services.AddTransient<IBorrowing, DbBorrowingService>();
            services.AddTransient<ICategory, DbCategoryServices>();

            //BEGIN Database registration - In case of the "In memory" database

            services.AddDbContext<ApplicationDbContext>
                (options => options.UseInMemoryDatabase("InMemoryDB"));

            //END Database registration - In case of the "In memory" database

            //BEGIN Database registration - In case of the SQL database + no migration

            //services.AddDbContext<ApplicationDbContext>
            //  (builder =>
            //       builder.UseSqlServer(Environment.GetEnvironmentVariable("CONNECTION_STRING"))
            //  );

            //END Database registration - In case of the SQL database + no migration

            //BEGIN Database registration - In case of the SQL Database + during migration

            //services.AddDbContext<ApplicationDbContext>
            //    (builder =>
            //        builder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Database=LBS2DB;Trusted_Connection=True")
            //    );

            //END Database registration - In case of the SQL Database + during migration

            services.AddAuthentication("CookieAuth")
                .AddCookie("CookieAuth",
                            options =>
                            {
                                options.Cookie.Name = "MyLBS2Cookie";
                                options.LoginPath = "/home/login";
                        });

            var config = new AutoMapper.MapperConfiguration(
                cfg => { cfg.AddProfile(new AutoMappersDef()); }
                );
            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);
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
