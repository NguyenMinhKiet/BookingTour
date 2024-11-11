using Application.Services_Interface;
using Domain.Entities.Location;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class LocationService : ILocationService
    {
        private string PATH = "../Infrastructure/Data/Location/";
        public async Task<City> LoadLocationDataAsync(string key)
        {
            var CityCollection = await LoadAllCityPathAsyncs();
            var data =  CityCollection[key];
            var jsonData = await File.ReadAllTextAsync(PATH + data.file_path);
            var city = JsonConvert.DeserializeObject<City>(jsonData);
            return city;
        }

        public async Task<Dictionary<string, CityCollection>> LoadAllCityPathAsyncs()
        {
            var JsonDatas = await File.ReadAllTextAsync(PATH + "Index.json");
            var CityCollection = JsonConvert.DeserializeObject<Dictionary<string, CityCollection>>(JsonDatas);
            return CityCollection;
        }

    }
}
