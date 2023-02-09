using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Polly;
using Polly.Extensions.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebStore.Logger;
using WebStoreGB.DAL.Context;
using WebStoreGB.Domain.Entities.Identity;
using WebStoreGB.Hubs;
using WebStoreGB.Infrastructure.Conventions;
using WebStoreGB.Infrastructure.Middleware;
using WebStoreGB.Interfaces.Services;
using WebStoreGB.Interfaces.Services.Identity;
using WebStoreGB.Interfaces.TestAPI;
using WebStoreGB.Services;
using WebStoreGB.Services.Data;
using WebStoreGB.Services.Services;
using WebStoreGB.Services.Services.InCookies;
using WebStoreGB.Services.Services.InMemory;
using WebStoreGB.Services.Services.InSQL;
using WebStoreGB.WebAPI.Clients.Employees;
using WebStoreGB.WebAPI.Clients.Identity;
using WebStoreGB.WebAPI.Clients.Orders;
using WebStoreGB.WebAPI.Clients.Products;
using WebStoreGB.WebAPI.Clients.Values;

namespace WebStoreGB
{
    public record Startup(IConfiguration configuration)
    {
        //public IConfiguration Configuration { get; set; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<WebStoreGBDB>(opt
            //         => opt.UseSqlServer(configuration["ConnectionStrings:SqlServer"]));

            services.AddIdentity<User, Role>()
                .AddIdentityWebStoreWebAPIClients()
                //.AddEntityFrameworkStores<WebStoreGBDB>()
                .AddDefaultTokenProviders();

            //services.AddIdentityWebStoreWebAPIClients();
            //services.AddHttpClient("WebStoreGBWebAPIIdentity", client => client.BaseAddress = new(configuration["WebAPI"]))
            //    .AddTypedClient<IUserStore<User>, UsersClient>()
            //    .AddTypedClient<IUserRoleStore<User>, UsersClient>()
            //    .AddTypedClient<IUserPasswordStore<User>, UsersClient>()
            //    .AddTypedClient<IUserEmailStore<User>, UsersClient>()
            //    .AddTypedClient<IUserPhoneNumberStore<User>,UsersClient>()
            //    .AddTypedClient<IUserTwoFactorStore<User>, UsersClient>()
            //    .AddTypedClient<IUserClaimStore<User>,UsersClient>()
            //    .AddTypedClient<IUserLoginStore<User>,UsersClient>()
            //    .AddTypedClient<IRoleStore<Role>,RolesClient>();

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

            services.ConfigureApplicationCookie(opt =>
            {
                opt.Cookie.Name = "GB.WebStore";
                opt.Cookie.HttpOnly = true;
                opt.ExpireTimeSpan = TimeSpan.FromDays(10);
                opt.LoginPath = "/Account/Login";
                opt.LogoutPath = "/Account/Logout";
                opt.AccessDeniedPath = "/Account/AccessDenied";
                opt.SlidingExpiration = true;
            });

            //services.AddTransient<DbInitializer>();

            //services.AddSingleton<IEmployeesData, InMemoryEmployeesData>();
            //services.AddScoped<IProductData, SqlProductData>();

            services.AddScoped<ICartStore, InCookiesCartStore>();
            services.AddScoped<ICartService, CartService>();

            //services.AddScoped<ICartService, CartService>();
            //services.AddScoped<IOrderService, SqlOrderService>();

            //Нам передают объект HttpClient и мы назначаем ему аддрес из appsettings.json
            //services.AddHttpClient<IValuesService, ValuesClient>(client => 
            //    client.BaseAddress = new(Configuration["WebAPI"]));

            services.AddHttpClient("WebStoreGBWebAPI", client =>
                client.BaseAddress = new(configuration["WebAPI"]))
                   .AddTypedClient<IValuesService, ValuesClient>()
                   .AddTypedClient<IEmployeesData, EmployeesClient>()
                   .AddTypedClient<IProductData, ProductsClient>()
                   .AddTypedClient<IOrderService, OrdersClient>()
                   .SetHandlerLifetime(TimeSpan.FromMinutes(5)) // Создать кэш HttpClient объектов с очисткой его по времени ,объект IHttpClientBuilder сразу не умирает 
                   .AddPolicyHandler(GetRetryPolicy()) // Политика повторных запросов в случае если WebAPI не отвечает
                   .AddPolicyHandler(GetCircuitBreakerPolicy()); // Разрушение потенциальных циклических запросов в большой распределённой системе
            
            static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy(int MaxRetryCount = 5, int MaxJitterTime = 1000) // правило повтора реконекта
            {
                var jitter = new Random(); // вводим переменную чтобы расинхронизировать запросы если их поступает много от разных клиентов
                return HttpPolicyExtensions
                    .HandleTransientHttpError() // Если возникают ошибки 404 и другие то просто ничего не делать
                    .WaitAndRetryAsync(5, RetryAttempt => 
                    TimeSpan.FromSeconds(Math.Pow(2, RetryAttempt)) + 
                    TimeSpan.FromMilliseconds(jitter.Next(0,MaxJitterTime)));
            }

            static IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPolicy() =>
                HttpPolicyExtensions
                    .HandleTransientHttpError()
                    .CircuitBreakerAsync(handledEventsAllowedBeforeBreaking: 5, TimeSpan.FromSeconds(30)); // каждому запросу присваиватся идентификатор и проверяет что по этим идентификаторам отсутствует цикл между запросами

            services.AddControllersWithViews(opt => opt.Conventions.Add(new TestControllerConvention()))
                .AddRazorRuntimeCompilation();

            services.AddSignalR();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory log)
        {
            log.AddLog4Net();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }


            app.UseStatusCodePagesWithRedirects("~/home/status/{0}");

            app.UseBlazorFrameworkFiles();

            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            //app.UseMiddleware<TestMiddleware>();

            app.UseMiddleware<ExceptionHandlingMiddleware>();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<ChatHub>("/chat");

                endpoints.MapGet("/greetings", async context =>
                {
                    await context.Response.WriteAsync(configuration["Greetings"]);
                });

                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                //Маршрут по умолчанию
                endpoints.MapControllerRoute(
                    "default",
                    "{controller}/{action=Index}/{id?}");

                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
