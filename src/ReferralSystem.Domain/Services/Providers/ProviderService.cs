using System.Collections.Generic;
using System.Threading.Tasks;
using ReferralSystem.Database.Repositories.Providers;
using ReferralSystem.Domain.Dtos.Providers;
using ReferralSystem.Models.Domain.Providers;

namespace ReferralSystem.Domain.Services.Providers.Segments
{
    public class ProviderService : IProviderService
    {
        private readonly IProviderRepository _providerRepository;

        public ProviderService(IProviderRepository providerRepository)
        {
            _providerRepository = providerRepository;
        }

        public async Task<IEnumerable<Provider>> GetAllAsync()
        {
            return await _providerRepository.GetAllAsync();
        }

        public async Task DeleteAsync(long id)
        {
            await _providerRepository.DeleteAsync(id);
        }

        public async Task<Provider> GetByIdAsync(long id)
        {
            return await _providerRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(ProviderDto data)
        {
            var provider = await _providerRepository.GetByIdAsync(data.Id);

            provider.UpdateOrFail(
                            data.NameRu,
                            data.NameEn,
                            data.NameKk,
                            data.Address,
                            data.Head,
                            data.PhoneNumber,
                            data.Email,
                            data.Bank,
                            data.BIN,
                            data.BIK,
                            data.DispatcherPhoneNumber,
                            data.TechServicePhoneNumber,
                            data.Comment,
                            data.RegionId,
                            data.ValidTo);

            await _providerRepository.UpdateAsync(provider);
        }

        public async Task InsertAsync(ProviderDto data)
        {
            var provider = data.NewProvider();
            await _providerRepository.InsertAsync(provider);
        }
    }
}