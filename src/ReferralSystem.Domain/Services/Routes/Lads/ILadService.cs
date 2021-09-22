using System.Collections.Generic;
using System.Threading.Tasks;
using ReferralSystem.Domain.Dtos.Routes;
using ReferralSystem.Models.Domain.Routes;

namespace ReferralSystem.Domain.Services.Routes.Lads
{
    public interface ILadService
    {
        Task<IEnumerable<Lad>> GetAllAsync();

        Task DeleteAsync(long id);

        Task<Lad> GetByIdAsync(long id);

        Task UpdateAsync(LadDto lad);

        Task InsertAsync(LadDto lad);
    }
}