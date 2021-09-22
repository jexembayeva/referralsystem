using System.Collections.Generic;
using System.Threading.Tasks;
using ReferralSystem.Database.Repositories.Providers.Streets;
using ReferralSystem.Domain.Dtos.Providers;
using ReferralSystem.Models.Domain.Providers;

namespace ReferralSystem.Domain.Services.Providers.Streets
{
    public class StreetService : IStreetService
    {
        private readonly IStreetRepository _streetRepository;

        public StreetService(IStreetRepository streetRepository)
        {
            _streetRepository = streetRepository;
        }

        public async Task<IEnumerable<Street>> GetAllAsync()
        {
            return await _streetRepository.GetAllAsync();
        }

        public async Task DeleteAsync(long id)
        {
            await _streetRepository.DeleteAsync(id);
        }

        public async Task<Street> GetByIdAsync(long id)
        {
            return await _streetRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(StreetDto data)
        {
            var street = await _streetRepository.GetByIdAsync(data.Id);

            street.UpdateOrFail(data.NameEn, data.NameKk, data.NameRu);
            await _streetRepository.UpdateAsync(street);
        }

        public async Task InsertAsync(StreetDto data)
        {
            var street = data.NewStreet();
            await _streetRepository.InsertAsync(street);
        }
    }
}