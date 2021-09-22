using System.Collections.Generic;
using System.Threading.Tasks;
using ReferralSystem.Database.Repositories.Routes.RoutePlans;
using ReferralSystem.Domain.Dtos.Routes;
using ReferralSystem.Models.Domain.Routes;

namespace ReferralSystem.Domain.Services.Routes.RoutePlans
{
    public class RoutePlanService : IRoutePlanService
    {
        private readonly IRoutePlanRepository _routePlanRepository;

        public RoutePlanService(IRoutePlanRepository routePlanRepository)
        {
            _routePlanRepository = routePlanRepository;
        }

        public async Task<IEnumerable<RoutePlan>> GetAllAsync()
        {
            return await _routePlanRepository.GetAllAsync();
        }

        public async Task DeleteAsync(long id)
        {
            await _routePlanRepository.DeleteAsync(id);
        }

        public async Task<RoutePlan> GetByIdAsync(long id)
        {
            return await _routePlanRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(RoutePlanDto data)
        {
            var routePlan = await _routePlanRepository.GetByIdAsync(data.Id);

            routePlan.UpdateOrFail(data.Name, data.Comment, data.RouteId);
            await _routePlanRepository.UpdateAsync(routePlan);
        }

        public async Task InsertAsync(RoutePlanDto data)
        {
            var routePlan = data.NewRoutePlan();
            await _routePlanRepository.InsertAsync(routePlan);
        }
    }
}