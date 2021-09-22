using System.Collections.Generic;
using System.Threading.Tasks;
using ReferralSystem.Database.Repositories.Routes;
using ReferralSystem.Database.Repositories.Routes.Alternatives;
using ReferralSystem.Domain.Dtos.Routes;
using ReferralSystem.Models.Domain.Routes;
using Utils.Dates;
using Utils.Validators;

namespace ReferralSystem.Domain.Services.Routes.Alternatives
{
    public class AlternativeService : IAlternativeService
    {
        private readonly IAlternativeRepository _alternativeRepository;
        private readonly IRouteRepository _routeRepository;

        public AlternativeService(IAlternativeRepository alternativeRepository, IRouteRepository routeRepository)
        {
            _alternativeRepository = alternativeRepository;
            _routeRepository = routeRepository;
        }

        public async Task<IEnumerable<Alternative>> GetAllAsync()
        {
            return await _alternativeRepository.GetAllAsync();
        }

        public async Task DeleteAsync(long id)
        {
            await _alternativeRepository.DeleteAsync(id);
        }

        public async Task<Alternative> GetByIdAsync(long id)
        {
            return await _alternativeRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(AlternativeDto data)
        {
            var alternative = await _alternativeRepository.GetByIdAsync(data.Id);

            alternative.UpdateOrFail(data.NameRu, data.NameEn, data.NameKk);
            await _alternativeRepository.UpdateAsync(alternative);
        }

        public async Task InsertAsync(AlternativeDto data)
        {
            var route = await _routeRepository.GetRouteAsync(data.RouteId);

            var alternativeToMakeOutdated = route.ActiveAlternativeOrNull();

            data.CorrectDates();

            var alternativeToInsert = data.NewAlternative();

            alternativeToInsert.ThrowIfDateRangeIsNotValid(false);
            alternativeToInsert.ThrowIfDateRangeIsOutOfAllowedLimits();

            var validTo = new Date(data.ValidFrom).EndOfTheDay();
            alternativeToMakeOutdated?.UpdateToMakeOutdatedOrFail(validTo);

            await _alternativeRepository.InsertAsync(alternativeToInsert, alternativeToMakeOutdated);
        }
    }
}