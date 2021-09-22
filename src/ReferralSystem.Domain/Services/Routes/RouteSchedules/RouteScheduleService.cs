using System.Collections.Generic;
using System.Threading.Tasks;
using ReferralSystem.Database.Repositories.Routes.RouteSchedules;
using ReferralSystem.Domain.Dtos.Routes;
using ReferralSystem.Models.Domain.Routes;

namespace ReferralSystem.Domain.Services.Routes.RoutePlans
{
    public class RouteScheduleService : IRouteScheduleService
    {
        private readonly IRouteScheduleRepository _routeScheduleRepository;

        public RouteScheduleService(IRouteScheduleRepository routePlanRepository)
        {
            _routeScheduleRepository = routePlanRepository;
        }

        public async Task<IEnumerable<RouteSchedule>> GetAllAsync()
        {
            return await _routeScheduleRepository.GetAllAsync();
        }

        public async Task DeleteAsync(long id)
        {
            await _routeScheduleRepository.DeleteAsync(id);
        }

        public async Task<RouteSchedule> GetByIdAsync(long id)
        {
            return await _routeScheduleRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(RouteScheduleDto data)
        {
            var routeSchedule = await _routeScheduleRepository.GetByIdAsync(data.Id);

            routeSchedule.UpdateOrFail(data.Name, data.Comment, data.TimeLineCount);
            await _routeScheduleRepository.UpdateAsync(routeSchedule);
        }

        public async Task InsertAsync(RouteScheduleDto data)
        {
            var routeSchedule = data.NewRouteSchedule();
            await _routeScheduleRepository.InsertAsync(routeSchedule);
        }
    }
}