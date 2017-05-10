using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using AssetManagementWebApp.Models;
using Newtonsoft.Json.Serialization;
using AutoMapper;
using AssetManagementWebApp.ViewModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.Internal;
using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace AssetManagement_WebApp
{
    public class Startup
    {
        private IHostingEnvironment _env;
        private IConfigurationRoot _config;

        public Startup(IHostingEnvironment env)
        {
            _env = env;

            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddJsonFile("config.json")
                .AddEnvironmentVariables();
            _config = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // default access requires admin access
            var isAdminUserPolicy = new AuthorizationPolicyBuilder().RequireRole("Domain Admins").Build();
            services.AddMvc(options =>
            {
                options.Filters.Add(new ApplyPolicyOrAuthorizeFilter(isAdminUserPolicy));
            });

            services.AddSingleton(_config);
            services.Configure<LdapConfig>(_config.GetSection("Ldap"));
            services.AddScoped<IAuthenticationService, LdapAuthenticationService>();

           if (_env.IsEnvironment("Development") || _env.IsEnvironment("Testing"))
            {
                //services.AddScoped<IMailService, DebugMailService>();
            }
            else
            {
                //Implement a real Mail Service
            }

            services.AddDbContext<AssetContext>();
            services.AddScoped<IAssetRepository, AssetRepository>();
            services.AddLogging();
            // Add framework services.
            services.AddMvc()
                .AddJsonOptions(config =>
                {
                    config.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            //loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            //loggerFactory.AddDebug();

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                Events = new CookieAuthenticationEvents
                {
                    // You will need this only if you use Ajax calls with a library not compatible with IsAjaxRequest
                    // More info here: https://github.com/aspnet/Security/issues/1056
                    OnRedirectToAccessDenied = context =>
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                        return TaskCache.CompletedTask;
                    }
                },
                AuthenticationScheme = "app",
                LoginPath = new PathString("/Authentication/Login"),
                AutomaticAuthenticate = true,
                AutomaticChallenge = true
            });

            Mapper.Initialize(config =>
            {
                config.CreateMap<AssetViewModel, Asset>().ReverseMap();
                config.CreateMap<AssetCountViewModel, AssetCount>().ReverseMap();
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                loggerFactory.AddDebug(LogLevel.Information);
                app.UseBrowserLink();
            }
            else
            {
                loggerFactory.AddDebug(LogLevel.Error);
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseMvc();

            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller=Home}/{action=Index}/{id?}");
            //});

            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "login",
            //        template: "authentication/login",
            //        defaults: new { controller = "Account", action = "Login" }
            //    );
            //    routes.MapRoute(
            //        name: "logout",
            //        template: "authentication/logout",
            //        defaults: new { controller = "Account", action = "Logout" }
            //    );
            //});
        }
    }
}
