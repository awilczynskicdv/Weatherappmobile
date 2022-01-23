using System;
using System.Collections.Generic;
using System.Text;
using System.Device.Location;
using System.Net.Http;
using Newtonsoft.Json;
using WeatherApp.Model;
using System.Threading.Tasks;

namespace Weatherappmobile.Services
{
    public class CoordWeatherInfo : ICoordWeatherInfo
    {
        string URLtemplate = "https://weatherappfn.azurewebsites.net/api/CurrentweatherTrigger?lon={}&lat={1}";
        string URLADDtemplate = "https://weatherappfn.azurewebsites.net/api/AddWeatherInfoToDbTrigger?lon={0}&lat={1}";

        public async Task<Root> getcoordweatherinfo(double Lon, double Lat)
        {
            GeoCoordinateWatcher watcher = new GeoCoordinateWatcher();

            watcher.TryStart(false, TimeSpan.FromMilliseconds(1000));

            GeoCoordinate coord = watcher.Position.Location;
        
            Lon = coord.Longitude;
            Lat = coord.Latitude;
            string URL = string.Format(URLtemplate, Lon, Lat);
            string URLADD = string.Format(URLADDtemplate, Lon, Lat);

            //Getting and posting data with azure functions
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("x-functions-key", "QVxgZ4lzpkmc5x1AXCZOwdn3VadGSX6sRhzQEl7BhuDObdYJbi75pA==");
            HttpResponseMessage response = await client.GetAsync(URL);
            HttpResponseMessage responseAdd = await client.PostAsync(URLADD, null);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var json = JsonConvert.DeserializeObject<Root>(result);
                return json;
            }
            return null;
        }
    }
}

