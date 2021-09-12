using System.Collections.Generic;
using System.Threading.Tasks;
using ReferralSystem.Database.Repositories.Routes;
using ReferralSystem.Domain.Dtos.Routes;
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

        public async Task DeleteAsync(long id)
        {
            await _routeRepository.DeleteAsync(id);
        }

        public async Task<Route> GetByIdAsync(long id)
        {
            return await _routeRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(RouteDto route)
        {
            await _routeRepository.UpdateAsync(null);
        }

        public async Task InsertAsync(RouteDto data)
        {
            var route = data.NewRoute("token");
            await _routeRepository.InsertAsync(route);
        }
    }
}