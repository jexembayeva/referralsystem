using System.Collections.Generic;
using System.Threading.Tasks;
using ReferralSystem.Database.Repositories.Providers.Districts;
using ReferralSystem.Database.Repositories.Routes;
using ReferralSystem.Database.Repositories.Segments;
using ReferralSystem.Domain.Dtos.Segments;
using ReferralSystem.Models.Domain.Segments;
using Utils.Dates;
using Utils.Validators;

namespace ReferralSystem.Domain.Services.Segments
{
    public class SegmentService : ISegmentService
    {
        private readonly ISegmentRepository _segmentRepository;
        private readonly IDistrictRepository _districtRepository;

        public SegmentService(ISegmentRepository segmentRepository, IDistrictRepository districtRepository)
        {
            _segmentRepository = segmentRepository;
            _districtRepository = districtRepository;
        }

        public async Task<IEnumerable<Segment>> GetAllAsync()
        {
            return await _segmentRepository.GetAllAsync();
        }

        public async Task DeleteAsync(long id)
        {
            await _segmentRepository.DeleteAsync(id);
        }

        public async Task<Segment> GetByIdAsync(long id)
        {
            return await _segmentRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(SegmentDto data)
        {
            var segment = await _segmentRepository.GetByIdAsync(data.Id);

            segment.UpdateOrFail(data.Comment, data.MaxSpeed, data.TurnRestrictions);
            await _segmentRepository.UpdateAsync(segment);
        }

        public async Task InsertAsync(SegmentDto data)
        {
            var district = await _districtRepository.GetRouteAsync(data.DistrictId);

            var segmentToMakeOutdated = district.ActiveSegmentOrNull();

            data.CorrectDates();

            var segmentToInsert = data.NewSegment();

            segmentToInsert.ThrowIfDateRangeIsNotValid(false);
            segmentToInsert.ThrowIfDateRangeIsOutOfAllowedLimits();

            var validTo = new Date(data.ValidFrom).EndOfTheDay();
            segmentToMakeOutdated?.UpdateToMakeOutdatedOrFail(validTo);
        }
    }
}