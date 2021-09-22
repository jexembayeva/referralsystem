using System.Collections.Generic;
using System.Threading.Tasks;
using ReferralSystem.Domain.Dtos.Routes;
using ReferralSystem.Models.Domain.Routes;

namespace ReferralSystem.Domain.Services.Routes.DayPeriodTypes
{
    public interface IDayPeriodTypeService
    {
        Task<IEnumerable<DayPeriodType>> GetAllAsync();

        Task DeleteAsync(long id);

        Task<DayPeriodType> GetByIdAsync(long id);

        Task UpdateAsync(DayPeriodTypeDto dayPeriodType);

        Task InsertAsync(DayPeriodTypeDto dayPeriodType);
    }
}