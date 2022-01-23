using System;
using System.Collections.Generic;
using System.Text;

namespace Weatherappmobile.Models
{
    public class WeatherInfoDbModel
    {
        public string lon { get; set; }
        public string lat { get; set; }
        public string name { get; set; }
        public string country { get; set; }
        public string temp { get; set; }
        public string feels_like { get; set; }
        public int pressure { get; set; }
        public int humidity { get; set; }
        public string speed { get; set; }
        public int visibility { get; set; }
        public string createdOn { get; set; }
    }

}
