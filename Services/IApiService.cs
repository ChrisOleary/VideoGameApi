using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models.APICall;

namespace WebApplication2.Services
{
    public interface IApiService
    {
        public List<ApiRoot> GetGames<ApiRoot>();
    }
}
