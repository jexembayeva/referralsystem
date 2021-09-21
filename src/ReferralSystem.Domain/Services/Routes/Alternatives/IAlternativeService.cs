using System.Collections.Generic;
using System.Threading.Tasks;
using ReferralSystem.Domain.Dtos.Routes;
using ReferralSystem.Models.Domain.Routes;

namespace ReferralSystem.Domain.Services.Routes.Alternatives
{
    public interface IAlternativeService
    {
        Task<IEnumerable<Alternative>> GetAllAsync();

        Task DeleteAsync(long id);

        Task<Alternative> GetByIdAsync(long id);

        Task UpdateAsync(AlternativeDto stop);

        Task InsertAsync(AlternativeDto stop);
    }
}