using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GamingApi.Models.APICall;
using GamingApi.ViewModels;
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
        // dependancy injection
        private readonly ILogger<HomeController> _logger;
        private readonly IApiService _apiService;


        ReleaseDate rd = new ReleaseDate();

        public HomeController(ILogger<HomeController> logger, IApiService apiService)
        {
            _logger = logger;
            _apiService = apiService;
        }
 

        public IActionResult Index()
        {
            var response = _apiService.GetGames<ApiRoot>();
            

            

            return View(new APIViewModel
            {
                apiRoot = response
            });
        }

       
        

        public IActionResult FirstView()
        {
            var response = _apiService.GetGames<ApiRoot>();

            return View(new APIViewModel
            {
                apiRoot = response
            }
            );
        }

        // for devwebs tutorial
        private async Task<IApiService> Getsomething()
        {
            return await Task.FromResult(_apiService);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
