using System.Threading.Tasks;
using ReferralSystem.Database.Repositories.Base;
using ReferralSystem.Models.Domain.Routes;

namespace ReferralSystem.Database.Repositories.Routes.Alternatives
{
    public interface IAlternativeRepository : IRepository<Alternative>
    {
        Task<Alternative> GetAlternativeAsync(long id);
    }
}