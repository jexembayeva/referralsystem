using System.Collections.Generic;
using System.Threading.Tasks;
using ReferralSystem.Database.Repositories.Routes.Alternatives;
using ReferralSystem.Database.Repositories.Routes.Lads;
using ReferralSystem.Domain.Dtos.Routes;
using ReferralSystem.Models.Domain.Routes;
using Utils.Dates;
using Utils.Validators;

namespace ReferralSystem.Domain.Services.Routes.Lads
{
    public class LadService : ILadService
    {
        private readonly ILadRepository _ladRepository;
        private readonly IAlternativeRepository _alternativeRepository;

        public LadService(ILadRepository ladRepository, IAlternativeRepository alternativeRepository)
        {
            _ladRepository = ladRepository;
            _alternativeRepository = alternativeRepository;
        }

        public async Task<IEnumerable<Lad>> GetAllAsync()
        {
            return await _ladRepository.GetAllAsync();
        }

        public async Task DeleteAsync(long id)
        {
            await _ladRepository.DeleteAsync(id);
        }

        public async Task<Lad> GetByIdAsync(long id)
        {
            return await _ladRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(LadDto data)
        {
            var lad = await _ladRepository.GetByIdAsync(data.Id);

            lad.UpdateOrFail(data.Name, data.Direction, data.Comment);
            await _ladRepository.UpdateAsync(lad);
        }

        public async Task InsertAsync(LadDto data)
        {
            var alternative = await _alternativeRepository.GetAlternativeAsync(data.AlternativeId);

            var ladToMakeOutdated = alternative.ActiveLadOrNull(data.Direction);

            data.CorrectDates();

            var ladToInsert = data.NewLad();

            ladToInsert.ThrowIfDateRangeIsNotValid(false);
            ladToInsert.ThrowIfDateRangeIsOutOfAllowedLimits();
            ladToInsert.ThrowIfDateRangeIsNotIntersect(alternative);

            var validTo = new Date(data.ValidFrom).EndOfTheDay();
            ladToMakeOutdated?.UpdateToMakeOutdatedOrFail(validTo);

            await _ladRepository.InsertAsync(ladToInsert, ladToMakeOutdated);
        }
    }
}