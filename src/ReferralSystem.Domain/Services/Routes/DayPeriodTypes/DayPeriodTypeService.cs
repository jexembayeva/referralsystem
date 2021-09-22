using System.Collections.Generic;
using System.Threading.Tasks;
using ReferralSystem.Database.Repositories.Routes.DayPeriodTypes;
using ReferralSystem.Domain.Dtos.Routes;
using ReferralSystem.Models.Domain.Routes;

namespace ReferralSystem.Domain.Services.Routes.DayPeriodTypes
{
    public class DayPeriodTypeService : IDayPeriodTypeService
    {
        private readonly IDayPeriodTypeRepository _dayPeriodTypeRepository;

        public DayPeriodTypeService(IDayPeriodTypeRepository dayPeriodTypeRepository)
        {
            _dayPeriodTypeRepository = dayPeriodTypeRepository;
        }

        public async Task<IEnumerable<DayPeriodType>> GetAllAsync()
        {
            return await _dayPeriodTypeRepository.GetAllAsync();
        }

        public async Task DeleteAsync(long id)
        {
            await _dayPeriodTypeRepository.DeleteAsync(id);
        }

        public async Task<DayPeriodType> GetByIdAsync(long id)
        {
            return await _dayPeriodTypeRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(DayPeriodTypeDto data)
        {
            var dayPeriodType = await _dayPeriodTypeRepository.GetByIdAsync(data.Id);

            dayPeriodType.UpdateOrFail(data.Name, data.Direction, data.AlternativeId);
            await _dayPeriodTypeRepository.UpdateAsync(dayPeriodType);
        }

        public async Task InsertAsync(DayPeriodTypeDto data)
        {
            var dayPeriodType = data.NewDayPeriodType();
            await _dayPeriodTypeRepository.InsertAsync(dayPeriodType);
        }
    }
}