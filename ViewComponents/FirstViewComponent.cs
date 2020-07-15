using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication2.Services;

namespace GamingApi.ViewComponents
{
    public class FirstViewComponent : ViewComponent
    {
        // dependancy injection
        private IApiService _apiService;

        public FirstViewComponent(IApiService service)
        {
            _apiService = service;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var myItem = await Getsomething();
            return View("Default", myItem);
        }

        private async Task<IApiService> Getsomething()
        {
            return await Task.FromResult(_apiService);
        }

    }
}
