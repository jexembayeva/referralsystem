using System.Collections.Generic;
using System.Threading.Tasks;
using ReferralSystem.Database.Repositories.Routes.Lads;
using ReferralSystem.Domain.Dtos.Routes;
using ReferralSystem.Models.Domain.Routes;

namespace ReferralSystem.Domain.Services.Routes.Lads
{
    public class LadService : ILadService
    {
        private readonly ILadRepository _ladRepository;

        public LadService(ILadRepository ladRepository)
        {
            _ladRepository = ladRepository;
        }

        public async Task<IEnumerable<Lad>> GetAllAsync()
        {
            return await _ladRepository.GetAllAsync();
        }

        public async Task DeleteAsync(long id)
        {
            await _ladRepository.DeleteAsync(id);
        }

        public async Task<Lad> GetByIdAsync(long id)
        {
            return await _ladRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(LadDto data)
        {
            var lad = await _ladRepository.GetByIdAsync(data.Id);

            lad.UpdateOrFail(data.Name, data.Direction, data.Comment);
            await _ladRepository.UpdateAsync(lad);
        }

        public async Task InsertAsync(LadDto data)
        {
            var lad = data.NewLad();
            await _ladRepository.InsertAsync(lad);
        }
    }
}