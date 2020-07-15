using System.Collections.Generic;

namespace WebApplication2.Services
{
    public interface IApiService
    {
        public List<ApiRoot> GetGames<ApiRoot>();
    }
}
