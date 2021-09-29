using System.Collections.Generic;
using System.Threading.Tasks;
using ReferralSystem.Database.Repositories.Routes;
using ReferralSystem.Database.Repositories.Routes.RouteSchedules;
using ReferralSystem.Domain.Dtos.Routes;
using ReferralSystem.Models.Domain.Routes;
using Utils.Dates;
using Utils.Validators;

namespace ReferralSystem.Domain.Services.Routes.RoutePlans
{
    public class RouteScheduleService : IRouteScheduleService
    {
        private readonly IRouteScheduleRepository _routeScheduleRepository;
        private readonly IRouteRepository _routeRepository;

        public RouteScheduleService(IRouteScheduleRepository routePlanRepository, IRouteRepository routeRepository)
        {
            _routeScheduleRepository = routePlanRepository;
            _routeRepository = routeRepository;
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

            routeSchedule.UpdateOrFail(
                data.Name,
                data.RouteId,
                data.Comment,
                data.StartTime,
                data.EndTime,
                data.Interval,
                data.TimeLineCount,
                data.DayType,
                data.ValidFrom,
                data.ValidTo);

            await _routeScheduleRepository.UpdateAsync(routeSchedule);
        }

        public async Task InsertAsync(RouteScheduleDto data)
        {
            var route = await _routeRepository.GetRouteAsync(data.RouteId);

            var routeScheduleToMakeOutdated = route.ActiveRouteScheduleOrNull();

            data.CorrectDates();

            var routeScheduleToInsert = data.NewRouteSchedule();

            routeScheduleToInsert.ThrowIfDateRangeIsNotValid(false);
            routeScheduleToInsert.ThrowIfDateRangeIsOutOfAllowedLimits();
            routeScheduleToInsert.ThrowIfDateRangeIsNotIntersect(route);

            var validTo = new Date(data.ValidFrom).EndOfTheDay();
            routeScheduleToMakeOutdated?.UpdateToMakeOutdatedOrFail(validTo);

            await _routeScheduleRepository.InsertAsync(routeScheduleToInsert, routeScheduleToMakeOutdated);
        }
    }
}