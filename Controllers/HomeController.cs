using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication2.Models;
using WebApplication2.Models.APICall;
using WebApplication2.Models.CSharp;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly FirstClass _secondClass;
        private readonly IApiService _apiService;
       
        

        public HomeController(ILogger<HomeController> logger, IApiService apiService)
        {
            _logger = logger;
            _apiService = apiService;
        }
 

        public IActionResult Index()
        {
            var response = _apiService.GetGames<ApiRoot>();
            return View(response);
        }


        public IActionResult FirstView()
        {
            var myModel = new List<FirstClass>();
            myModel.Add(new FirstClass { Name = "Dave", Id = 1 });
            myModel.Add(new FirstClass { Name = "Chris", Id = 2 });
            return View(myModel);
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
