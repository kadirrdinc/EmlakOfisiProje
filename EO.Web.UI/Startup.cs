using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EO.Core.Repository;
using EO.Data.Context;
using EO.Data.Entities;
using EO.Service;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace EO.Web.UI
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
            services.AddControllersWithViews().AddRazorRuntimeCompilation()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie("AdminCookieAuthentication", config =>
                {
                    config.Cookie.Name = "AdminCookie";
                    config.LoginPath = "/Admin/Home/Login";
                    config.AccessDeniedPath = "/Home/AccessDenied";
                    config.ExpireTimeSpan = TimeSpan.FromMinutes(10);
                })
                .AddCookie("AgentCookieAuthentication", config =>
                {
                    config.Cookie.Name = "AgentCookie";
                    config.LoginPath = "/Home/Login";
                    config.AccessDeniedPath = "/Home/AccessDenied";
                    config.ExpireTimeSpan = TimeSpan.FromMinutes(10);
                });

            services.AddSession();
            services.AddDbContext<EOContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("connectionString")));


            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            #region AdminDI
            services.AddTransient<IRepository<AdminUser>, Repository<AdminUser>>();
            services.AddTransient<IAdminService, AdminService>();

            services.AddTransient<IRepository<Agent>, Repository<Agent>>();
            services.AddTransient<IAgentService, AgentService>();
            #endregion

            services.AddTransient<IRepository<Notice>, Repository<Notice>>();
            services.AddTransient<INoticeService, NoticeService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapAreaControllerRoute(
               name: "Areas",
               areaName: "Admin",
               pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
