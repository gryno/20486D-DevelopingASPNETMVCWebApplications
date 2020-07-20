using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mvc.Models;

namespace Mvc.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IRandomService _rService;
		private readonly IRandomWrapper _rWrapper;
		public HomeController(ILogger<HomeController> logger, IRandomService randomService, IRandomWrapper randomWrapper)
		{
			_logger = logger;
			_rService = randomService;
			_rWrapper = randomWrapper;
		}

		public IActionResult Index()
		{
			string result = 
				$"The number from service in controller: { _rService.GetNumber()}, the number from wrapper service: { _rWrapper.GetNumber()}";

			return Content($"Hello from controller\nNext Line\n{result}");

		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
