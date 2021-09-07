using System.Collections.Generic;
using System.Threading.Tasks;
using ReferralSystem.Database.Repositories.Routes;
using ReferralSystem.Models.Domain.Routes;

namespace ReferralSystem.Domain.Services.Routes
{
    public class RouteService : IRouteService
    {
        private readonly IRouteRepository _routeRepository;

        public RouteService(IRouteRepository routeRepository)
        {
            _routeRepository = routeRepository;
        }

        public async Task<IEnumerable<Route>> GetAllAsync()
        {
            return await _routeRepository.GetAllAsync();
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