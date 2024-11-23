using Application.Services_Interface;
using Domain.Entities.Location;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.Services
{
    public class LocationService : ILocationService
    {
        private string PATH = "../Infrastructure/Data/Location/";
        private ILogger<LocationService> _logger;
        public LocationService (ILogger<LocationService> logger)
        {
            _logger = logger;
        }
        public async Task<Dictionary<string, CityCollection>> LoadAllCityPathAsyncs()
        {
            var JsonDatas = await File.ReadAllTextAsync(PATH + "Index.json", Encoding.UTF8);
            var CityCollection = JsonConvert.DeserializeObject<Dictionary<string, CityCollection>>(JsonDatas);
            return CityCollection;
        }

        public async Task<List<string>> GetListKeys(string PATH)
        {
            var jsonData = await File.ReadAllTextAsync(PATH + "Index.json", Encoding.UTF8);
            var collection = JsonConvert.DeserializeObject<Dictionary<string, CityCollection>>(jsonData);

            var listCode = new List<string>();
            foreach ( var city in collection.Keys)
            {
                listCode.Add(city);
            }
            return listCode;
        }

        public async Task<City> LoadDataCityAsync(string key)
        {
            var CityCollection = await LoadAllCityPathAsyncs();
            var data = CityCollection[key];

            var dataPath = data.file_path.TrimStart('.');
            dataPath = dataPath.TrimStart('/');


            var jsonData = await File.ReadAllTextAsync(PATH + dataPath, Encoding.UTF8);
            var city = JsonConvert.DeserializeObject<City>(jsonData);
            return city;
        }

        public async Task<List<City>> LoadAllCitysAsync()
        {
            var cityKeys = await GetListKeys(PATH);
            var cityList = new List<City>();
            foreach (var key in cityKeys)
            {
                var cityData = await LoadDataCityAsync(key);
                cityList.Add(cityData);
            }
            return cityList;
        }
    }
}
