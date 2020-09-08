﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection;

namespace ARX.UI.Site
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.AreaPageViewLocationFormats.Clear();
                options.AreaPageViewLocationFormats.Add("/Modulos/{2}/Views/{1}/{0}.cshtml");
                options.AreaPageViewLocationFormats.Add("/Modulos/{2}/Views/Shared/{0}.cshtml");
                options.AreaPageViewLocationFormats.Add("/Views/Shared/{0}.cshtml");
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if(env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseMvc(routes => 
            {
                routes.MapRoute(
                   "default","{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                   "areas", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
