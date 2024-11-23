using Domain.Entities.Location;

namespace Application.Services_Interface
{
    public interface ILocationService
    {
        Task<City> LoadDataCityAsync(string key);
        Task<List<City>> LoadAllCitysAsync();
    }
}
