using System.Collections.Generic;
using System.Threading.Tasks;
using ReferralSystem.Database.Repositories.Providers.Cities;
using ReferralSystem.Domain.Dtos.Providers;
using ReferralSystem.Models.Domain.Providers;

namespace ReferralSystem.Domain.Services.Providers.Cities
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;

        public CityService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task<IEnumerable<City>> GetAllAsync()
        {
            return await _cityRepository.GetAllAsync();
        }

        public async Task DeleteAsync(long id)
        {
            await _cityRepository.DeleteAsync(id);
        }

        public async Task<City> GetByIdAsync(long id)
        {
            return await _cityRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(CityDto data)
        {
            var city = await _cityRepository.GetByIdAsync(data.Id);

            city.UpdateOrFail(
                data.NameEn,
                data.NameKk,
                data.NameRu,
                data.RegionId,
                data.Comment);

            await _cityRepository.UpdateAsync(city);
        }

        public async Task InsertAsync(CityDto data)
        {
            var city = data.NewCity();
            await _cityRepository.InsertAsync(city);
        }
    }
}