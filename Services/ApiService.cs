using GamingApi.Models.APICall;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Linq;
using WebApplication2.Models.APICall;

namespace WebApplication2.Services
{
    public class ApiService : IApiService
    {
        public List<ApiRoot> GetGames<ApiRoot>()
        {
            var client = new RestClient("https://api-v3.igdb.com/games");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("user-key", "fe22475530846f8a6934bdd84ea679ae");
            request.AddHeader("Content-Type", "application/json; charset=utf-8");
            request.AddHeader("Cookie", "__cfduid=d1f77e23764258e7eee5d78378b9457901594024789");
            // get all future dated xbox games
            request.AddParameter("text/plain", "fields *, release_dates.*, screenshots.*, cover.*; \r\nwhere release_dates.platform = (49) & release_dates.date > 1594204300;\r\nsort release_dates.date desc;", ParameterType.RequestBody); 
            IRestResponse response = client.Execute(request);

            // needs to be list<> so we can use ienumerable in the view to itarate over
            var myDeserializedClass = JsonConvert.DeserializeObject<List<ApiRoot>>(response.Content);

                
                return myDeserializedClass;
        }

        public string QueryIntArray()
        {
            var nums = new List<ApiRoot>();
            var rums = new List<ReleaseDate>();

            var gt20 = from num in nums
                       join rum in rums on num.id equals rum.game
                       where rum.platform == 49
                       select rum.human;

            return gt20.ToString();

        }

    }
}
