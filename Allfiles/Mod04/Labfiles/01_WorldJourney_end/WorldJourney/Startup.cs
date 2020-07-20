using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing.Template;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileSystemGlobbing.Internal.Patterns;
using WorldJourney.Filters;
using WorldJourney.Models;

namespace WorldJourney
{
	public class Startup
	{
		public void ConfigureServices(IServiceCollection services)
		{
			//services.AddMvc();
			services.AddControllersWithViews();
			services.AddSingleton<IData, Data>();
			services.AddScoped<LogActionFilterAttribute>();
		}

		public void Configure(IApplicationBuilder app)
		{
			app.UseStaticFiles();

			app.UseRouting();

			app.UseEndpoints(endpoints =>
			{
			endpoints.MapControllerRoute(
				name: "TravelerRoute",
				constraints: new { name = "[A-Za-z ]+" },
				pattern: "{controller=Traveler}/{action=Index}/{name=Katie Bruce}");

			endpoints.MapControllerRoute(
				name: "defaultRoute",
				constraints: new { id = "[0-9]+" },
				pattern: "{controller=Home}/{action=Index}/{id?}");
			});

			//app.UseMvc(routes =>
			//{
			//    routes.MapRoute(
			//         name: "TravelerRoute",
			//         template: "{controller}/{action}/{name}",
			//         constraints: new { name = "[A-Za-z ]+" },
			//         defaults: new { controller = "Traveler", action = "Index", name = "Katie Bruce" });
			//
			//    routes.MapRoute(
			//        name: "defaultRoute",
			//        template: "{controller}/{action}/{id?}",
			//        defaults: new { controller = "Home", action = "Index" },
			//        constraints: new { id = "[0-9]+" });
			//});
		}
	}
}
