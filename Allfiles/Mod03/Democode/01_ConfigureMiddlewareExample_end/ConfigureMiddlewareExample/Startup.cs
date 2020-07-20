﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace ConfigureMiddlewareExample
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app)
        {

			app.Use(async (context, next) =>
			{
				await context.Response.WriteAsync("First middleware => ");
				await next.Invoke();
			});

			app.Use(async (context, next) =>
			{
				await context.Response.WriteAsync("Second middleware => ");
				await next.Invoke();
			});

			//app.Run(async (context) =>
			//{
			//	await context.Response.WriteAsync("Final middleware.");
			//});


			app.Map("/there", map =>
			{
				map.Run(async (context) =>
			   {
				   await context.Response.WriteAsync("Mapping hit!!!");
			   });
			});
			app.Map("/gary", map =>
			{
				map.Use(async (context, next) =>
			   {
				   await context.Response.WriteAsync("Gary encountered !!!");
				   await next.Invoke();
				   await context.Response.WriteAsync(" Finished.");
			
			   });
			});
            app.Use(async (context, next) =>
            {
				string path = context.Request.Path.Value;
			
                await context.Response.WriteAsync(
                    "This text was generated by the app.Use middleware. Request path is: " + 
                    path + "<br />");
			
				if (path.ToLower() != "/hello")
				{
					await next.Invoke();
				}
				await context.Response.WriteAsync(" ... more");
			
            });
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("This text was generated by the app.run middleware.");
            });
        }
    }
}
