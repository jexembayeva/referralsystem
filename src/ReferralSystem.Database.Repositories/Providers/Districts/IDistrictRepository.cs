using System.Threading.Tasks;
using ReferralSystem.Database.Repositories.Base;
using ReferralSystem.Models.Domain.Providers;

namespace ReferralSystem.Database.Repositories.Providers.Districts
{
    public interface IDistrictRepository : IRepository<District>
    {
        Task<District> GetRouteAsync(long id);
    }
}