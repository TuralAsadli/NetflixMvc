using BusinesLogic.Utilites.ApiModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLogic.Utilites
{
    public class ImdbApi
    {
        static string key = "5c112bb7";
        public static async Task<string> GetRating(string query)
        {
            using(var http = new HttpClient())
            {
                using(var response = await http.GetAsync($"https://www.omdbapi.com/?apikey={key}&t={query}"))
                {
                    string ApiResponse = await response.Content.ReadAsStringAsync();
                    var movieData = JsonConvert.DeserializeObject<Root>(ApiResponse);
                    if (movieData.Ratings == null)
                    {
                        return null;
                    }
                    //if (movieData.Ratings.Exists(x => x.Source == "Internet Movie Database"))
                    //{
                    //    return movieData.Ratings.FirstOrDefault(x => x.Source == "Internet Movie Database").Value;
                    //}
                    return movieData.Ratings.FirstOrDefault().Value;
                }
            }
        }
    }
}
