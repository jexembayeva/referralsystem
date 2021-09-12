using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ReferralSystem.Database.Repositories.Bases;
using ReferralSystem.Database.Repositories.Routes;
using ReferralSystem.Database.Repositories.Stops;
using ReferralSystem.Domain.Dtos.Bases;
using ReferralSystem.Domain.Dtos.Routes;
using ReferralSystem.Domain.Dtos.Stops;
using ReferralSystem.Models.Domain.Bases;
using ReferralSystem.Models.Domain.Stop;

namespace ReferralSystem.Domain.Services.Bases
{
    public class BaseService : IBaseService
    {
        private readonly IBaseRepository _baseRepository;

        public BaseService(IBaseRepository baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<IEnumerable<BasePlatform>> GetAllAsync()
        {
            return await _baseRepository.GetAllAsync();
        }

        public async Task DeleteAsync(long id)
        {
            await _baseRepository.DeleteAsync(id);
        }

        public async Task<BasePlatform> GetByIdAsync(long id)
        {
            return await _baseRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(BasePlatformDto data, CancellationToken cancellationToken)
        {
            var basePlatform = await _baseRepository.GetByIdAsync(data.Id);

            basePlatform.UpdateOrFail(data.NameEn, data.NameKk, data.NameRu);
            await _baseRepository.UpdateAsync(basePlatform);
        }

        public async Task InsertAsync(BasePlatformDto data, CancellationToken cancellationToken)
        {
            var basePlatform = data.NewBasePlatform(cancellationToken);
            await _baseRepository.InsertAsync(basePlatform);
        }
    }
}