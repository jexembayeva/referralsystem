using System.Threading.Tasks;
using ReferralSystem.Database.Repositories.Base;
using ReferralSystem.Models.Domain.Routes;

namespace ReferralSystem.Database.Repositories.Routes
{
    public interface IRouteRepository : IRepository<Route>
    {
        Task<Route> GetRouteAsync(long id);
    }
}