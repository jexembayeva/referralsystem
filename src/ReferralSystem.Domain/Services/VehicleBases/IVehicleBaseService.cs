using System.Collections.Generic;
using System.Threading.Tasks;
using ReferralSystem.Domain.Dtos.VehicleBases;
using ReferralSystem.Models.Domain.VehicleBases;

namespace ReferralSystem.Domain.Services.VehicleBases
{
    public interface IVehicleBaseService
    {
        Task<IEnumerable<VehicleBase>> GetAllAsync();

        Task DeleteAsync(long id);

        Task<VehicleBase> GetByIdAsync(long id);

        Task UpdateAsync(VehicleBaseDto basePlatform);

        Task InsertAsync(VehicleBaseDto basePlatform);
    }
}