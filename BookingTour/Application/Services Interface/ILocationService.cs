using Domain.Entities.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services_Interface
{
    public interface ILocationService
    {
        Task<City> LoadLocationDataAsync(string key);
        Task<Dictionary<string, CityCollection>> LoadAllCityPathAsyncs();
    }
}
