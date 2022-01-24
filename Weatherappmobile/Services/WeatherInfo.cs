using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Model;
using Newtonsoft.Json;

namespace Weatherappmobile.Services
{
    public class WeatherInfo : IWeatherInfo
    {
        string baseURL = "https://weatherappfn.azurewebsites.net/api/CurrentweatherTrigger?";
        string baseURLADD = "https://weatherappfn.azurewebsites.net/api/AddWeatherInfoToDbTrigger?";

        string URL = "";
        string URLADD = "";
        public async Task<Root> getweatherinfo(string city, double lon, double lat)
        {
            if(lon == 0 && lat == 0)
            {
                URL = $"{baseURL}city={city}";
                URLADD = $"{baseURLADD}city ={city}";
            }
            else
            {
                URL = $"{baseURL}lon={lon}&lat={lat}";
                URLADD = $"{baseURLADD}lon={lon}&lat={lat}";
            }
            
            //Getting and posting data with azure functions
            
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("x-functions-key", "QVxgZ4lzpkmc5x1AXCZOwdn3VadGSX6sRhzQEl7BhuDObdYJbi75pA==");
            HttpResponseMessage response = await client.GetAsync(URL);

            if (response.IsSuccessStatusCode)
            {
                HttpResponseMessage responseAdd = await client.PostAsync(URLADD, null);
                var result = await response.Content.ReadAsStringAsync();
                var json = JsonConvert.DeserializeObject<Root>(result);
                return json;
            }
            return null;
        }
    }
}
