using GamingApi.Models.APICall;
using System.Collections.Generic;

namespace WebApplication2.Models.APICall
{
    // ApiRoot myDeserializedClass = JsonConvert.DeserializeObject<ApiRoot>(myJsonResponse); 
    public class ApiRoot
    {
        public int id { get; set; }
        public List<int> age_ratings { get; set; }
        public int category { get; set; }
        public Cover cover { get; set; }
        public int created_at { get; set; }
        public List<int> external_games { get; set; }
        public string name { get; set; }
        public double popularity { get; set; }
        public double rating { get; set; }
        public int rating_count { get; set; }
        public List<int> similar_games { get; set; }
        public string slug { get; set; }
        public string summary { get; set; }
        public List<int> tags { get; set; }
        public List<int> themes { get; set; }
        public double total_rating { get; set; }
        public int total_rating_count { get; set; }
        public int updated_at { get; set; }
        public string url { get; set; }
        public List<int> websites { get; set; }
        public string checksum { get; set; }

    }
}
