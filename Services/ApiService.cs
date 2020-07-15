using GamingApi.Models.APICall;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication2.Models.APICall;

namespace WebApplication2.Services
{
    public class ApiService : IApiService
    {
        public List<ApiRoot> GetGames<ApiRoot>()
        {
            // get todays date in epoch
            TimeSpan t = DateTime.UtcNow - new DateTime(1970, 1, 1);
            int secondsSinceEpoch = (int)t.TotalSeconds;
            var type = "text/plain";
            var param = $"fields *, release_dates.*, screenshots.*, cover.*; where release_dates.platform = (49) & release_dates.date > {secondsSinceEpoch}; sort release_dates.date desc;";

            var client = new RestClient("https://api-v3.igdb.com/games");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("user-key", "fe22475530846f8a6934bdd84ea679ae");
            request.AddHeader("Content-Type", "application/json; charset=utf-8");
            request.AddHeader("Cookie", "__cfduid=d1f77e23764258e7eee5d78378b9457901594024789");
            // get all future dated xbox games
            request.AddParameter("text/plain", "fields *, release_dates.*, screenshots.*, cover.*; \r\nwhere release_dates.platform = (49) & release_dates.date > 1594204300;\r\nsort release_dates.date desc;", ParameterType.RequestBody);
                              // "text/plain", "fields *, release_dates.*, screenshots.*, cover.*;     where release_dates.platform = (49) & release_dates.date > 1594655467;    sort release_dates.date desc;"
            request.AddParameter(type, param, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            // needs to be list<> so we can use ienumerable in the view to itarate over
            var myDeserializedClass = JsonConvert.DeserializeObject<List<ApiRoot>>(response.Content);

            return myDeserializedClass;
        }


    }
}
