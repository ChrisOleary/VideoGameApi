using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;
using System.IO;
using System.Net;

namespace WebApplication2.Models.APICall
{
    public class IgdbApiCall
    {
        public IRestResponse response;
        public string name { get; set; }

        public string GetGamingRequest()
        {
            try
            {
                var client = new RestClient("https://api-v3.igdb.com/games");
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("user-key", "fe22475530846f8a6934bdd84ea679ae");
                request.AddHeader("Content-Type", "text/plain");
                request.AddHeader("Cookie", "__cfduid=d1f77e23764258e7eee5d78378b9457901594024789");
                request.AddParameter("text/plain", "fields *; limit 10;", ParameterType.RequestBody);
                response = client.Execute(request);
                Console.WriteLine(response.Content);

            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
            return response.Content;
        }

    }
}
