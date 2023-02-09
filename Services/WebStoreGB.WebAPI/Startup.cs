using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Logger;
using WebStoreGB.DAL.Context;
using WebStoreGB.Domain.Entities.Identity;
using WebStoreGB.Interfaces.Services;
using WebStoreGB.Services.Data;
using WebStoreGB.Services.Services.InCookies;
using WebStoreGB.Services.Services.InMemory;
using WebStoreGB.Services.Services.InSQL;

namespace WebStoreGB.WebAPI
{
    public record Startup(IConfiguration configuration)
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var config = configuration["ConnectionStrings:SqlServer"];
            services.AddDbContext<WebStoreGBDB>(opt
                     => opt.UseSqlServer(config));

            services.AddScoped<DbInitializer>();

            services.AddIdentity<User, Role>()
                    .AddEntityFrameworkStores<WebStoreGBDB>()
                    .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(opt =>
            {
#if DEBUG
                opt.Password.RequireDigit = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequiredLength = 3;
                opt.Password.RequiredUniqueChars = 3;
#endif
                opt.User.RequireUniqueEmail = false;
                opt.User.AllowedUserNameCharacters =
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

                opt.Lockout.AllowedForNewUsers = false;
                opt.Lockout.MaxFailedAccessAttempts = 10;
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
            });

            services.AddSingleton<IEmployeesData, InMemoryEmployeesData>();
            services.AddScoped<IProductData, SqlProductData>();
            services.AddScoped<ICartService, InCookiesCartService>();
            services.AddScoped<IOrderService, SqlOrderService>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebStoreGB.WebAPI", Version = "v1" });

                //c.IncludeXmlComments("obj\\Debug\\net5.0\\WebStoreGB.Domain.xml");  ÎØÈÁÊÀ
                //c.IncludeXmlComments("obj\\Debug\\net5.0\\WebStoreGB.WebAPI.xml");

                //const string webstore_api_xml = "obj\\Debug\\net5.0\\WebStoreGB.WebAPI.xml";
                //const string webstore_domain_xml = "obj\\Debug\\net5.0\\WebStoreGB.Domain.xml";

                const string webstore_api_xml = "WebStoreGB.WebAPI.xml";
                const string webstore_domain_xml = "WebStoreGB.Domain.xml";
                const string debug_path = "bin/debug/net5.0";

                if (File.Exists(webstore_api_xml))
                    c.IncludeXmlComments(webstore_api_xml);
                else if (File.Exists(Path.Combine(debug_path, webstore_api_xml)))
                    c.IncludeXmlComments(Path.Combine(debug_path, webstore_api_xml));

                if (File.Exists(webstore_domain_xml))
                    c.IncludeXmlComments(webstore_domain_xml);
                else if (File.Exists(Path.Combine(debug_path, webstore_domain_xml)))
                    c.IncludeXmlComments(Path.Combine(debug_path, webstore_domain_xml));

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory log)
        {
            log.AddLog4Net();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebStoreGB.WebAPI v1"));
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
