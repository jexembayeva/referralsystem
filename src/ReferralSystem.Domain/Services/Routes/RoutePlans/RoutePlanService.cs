using System.Collections.Generic;
using System.Threading.Tasks;
using ReferralSystem.Database.Repositories.Routes;
using ReferralSystem.Database.Repositories.Routes.RoutePlans;
using ReferralSystem.Domain.Dtos.Routes;
using ReferralSystem.Models.Domain.Routes;
using Utils.Dates;
using Utils.Validators;

namespace ReferralSystem.Domain.Services.Routes.RoutePlans
{
    public class RoutePlanService : IRoutePlanService
    {
        private readonly IRoutePlanRepository _routePlanRepository;
        private readonly IRouteRepository _routeRepository;

        public RoutePlanService(IRoutePlanRepository routePlanRepository, IRouteRepository routeRepository)
        {
            _routePlanRepository = routePlanRepository;
            _routeRepository = routeRepository;
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

            routePlan.UpdateOrFail(
                data.Name,
                data.RouteId,
                data.RoundCount,
                data.StartTime,
                data.EndTime,
                data.Interval,
                data.Comment,
                data.DurationAB,
                data.DurationBA,
                data.Capacity,
                data.MaxStopTime,
                data.ValidTo);

            await _routePlanRepository.UpdateAsync(routePlan);
        }

        public async Task InsertAsync(RoutePlanDto data)
        {
            var route = await _routeRepository.GetRouteAsync(data.RouteId);

            var routePlanToMakeOutdated = route.ActiveRoutePlanOrNull();

            data.CorrectDates();

            var routePlanToInsert = data.NewRoutePlan();

            routePlanToInsert.ThrowIfDateRangeIsNotValid(false);
            routePlanToInsert.ThrowIfDateRangeIsOutOfAllowedLimits();
            routePlanToInsert.ThrowIfDateRangeIsNotIntersect(route);

            var validTo = new Date(data.ValidFrom).EndOfTheDay();
            routePlanToMakeOutdated?.UpdateToMakeOutdatedOrFail(validTo);

            await _routePlanRepository.InsertAsync(routePlanToInsert, routePlanToMakeOutdated);
        }
    }
}