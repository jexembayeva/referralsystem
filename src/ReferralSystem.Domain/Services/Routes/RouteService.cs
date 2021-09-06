using System.Collections.Generic;
using System.Threading.Tasks;
using ReferralSystem.Models.Domain.Routes;

namespace ReferralSystem.Domain.Services.Routes
{
    public class RouteService : IRouteService
    {
        public Task<IEnumerable<Route>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(long id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Route> GetByIdAsync(long id)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(Route data)
        {
            throw new System.NotImplementedException();
        }

        public Task InsertAsync(Route entity)
        {
            throw new System.NotImplementedException();
        }
    }
}