using System.Collections.Generic;
using System.Threading.Tasks;
using ReferralSystem.Domain.Dtos.Vehicles;
using ReferralSystem.Models.Domain.Vehicles;

namespace ReferralSystem.Domain.Services.Vehicles
{
    public interface IVehicleService
    {
        Task<IEnumerable<Vehicle>> GetAllAsync();

        Task DeleteAsync(long id);

        Task<Vehicle> GetByIdAsync(long id);

        Task UpdateAsync(VehicleDto vehicle);

        Task InsertAsync(VehicleDto vehicle);
    }
}