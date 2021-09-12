using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ReferralSystem.Database.Repositories.Vehicles;
using ReferralSystem.Domain.Dtos.Vehicles;
using ReferralSystem.Models.Domain.Vehicles;

namespace ReferralSystem.Domain.Services.Vehicles
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleService(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public async Task<IEnumerable<Vehicle>> GetAllAsync()
        {
            return await _vehicleRepository.GetAllAsync();
        }

        public async Task DeleteAsync(long id)
        {
            await _vehicleRepository.DeleteAsync(id);
        }

        public async Task<Vehicle> GetByIdAsync(long id)
        {
            return await _vehicleRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(VehicleDto data, CancellationToken cancellationToken)
        {
            var vehicle = await _vehicleRepository.GetByIdAsync(data.Id);

            vehicle.UpdateOrFail(data.LicencePlate, data.PhoneNumber, data.FuelConsumptionRate);
            await _vehicleRepository.UpdateAsync(vehicle);
        }

        public async Task InsertAsync(VehicleDto data, CancellationToken cancellationToken)
        {
            var vehicle = data.NewVehicle(cancellationToken);
            await _vehicleRepository.InsertAsync(vehicle);
        }
    }
}