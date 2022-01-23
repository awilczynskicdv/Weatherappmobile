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
        string URL = "https://weatherappfn.azurewebsites.net/api/CurrentweatherTrigger?";
        string URLADD = "https://weatherappfn.azurewebsites.net/api/AddWeatherInfoToDbTrigger?";
        public async Task<Root> getweatherinfo(string city, double lon, double lat)
        {
            if(lon == 0 && lat == 0)
            {
                URL += $"city={city}";
                URLADD += $"city={city}";
            }
            else
            {
                URL += $"lon={lon}&lat={lat}";
                URLADD += $"lon={lon}&lat={lat}";
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
