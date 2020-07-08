﻿using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;

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
            request.AddParameter("text/plain", "fields *; limit 10;", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            // needs to be list<> so square brackets are removed from json
            var myDeserializedClass = JsonConvert.DeserializeObject<List<ApiRoot>>(response.Content);

            return myDeserializedClass;

        }
    }
}