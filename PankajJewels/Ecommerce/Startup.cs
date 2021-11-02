using Ecommerce.Models.BAL;
using Ecommerce.Models.Entity;
using Ecommerce.Models.InterfacesBAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.FileProviders;
using System.IO;

namespace Ecommerce
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
            services.AddDbContext<MyDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("MyConnection")));
            services.AddControllersWithViews().AddRazorRuntimeCompilation(); 
            services.AddRazorPages();
            services.AddScoped<IUserMgmtService, UserMgmtService>();
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<ICommonService, CommonService>();
            services.AddScoped<IMasterDataMgmtService, MasterDataMgmtService>();
            services.AddScoped<ILogApplicationErrorService,LogApplicationErrorService>();
            services.AddScoped<IOtherMgmtService, OtherMgmtService>();
            services.AddScoped<IProductManagementService, ProductManagementService>();
            services.AddScoped<ISMSService, SMSService>();
            services.AddScoped<IOrderMgmtService, OrderMgmtService>();

            services.AddMvc().AddNewtonsoftJson(o =>
            {
                o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(10);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
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
            }
            app.UseStaticFiles();
            //app.UseStaticFiles(new StaticFileOptions
            //{
            //    FileProvider = new PhysicalFileProvider(
            //      Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\icons")),
            //    RequestPath = "/icons"
            //});
            app.UseRouting();
            app.UseCors(opts =>
            {
                opts.WithOrigins(new string[]
                {
            "http://localhost:4200",
            "http://localhost:3001",
            "http://localhost:3000",
            "http://admin.heeranyam.com"
                });

                opts.AllowAnyHeader();
                opts.AllowAnyMethod();
                opts.AllowCredentials();
            });
            //     app.UseCors(x => x
            //.AllowAnyOrigin()
            //.AllowAnyMethod()
            //.AllowAnyHeader());
            app.UseSession();
            app.UseAuthorization();
           

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
