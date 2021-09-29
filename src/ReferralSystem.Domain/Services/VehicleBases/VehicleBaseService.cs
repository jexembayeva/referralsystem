using System.Collections.Generic;
using System.Threading.Tasks;
using ReferralSystem.Database.Repositories.VehicleBases;
using ReferralSystem.Domain.Dtos.VehicleBases;
using ReferralSystem.Models.Domain.VehicleBases;

namespace ReferralSystem.Domain.Services.VehicleBases
{
    public class VehicleBaseService : IVehicleBaseService
    {
        private readonly IVehicleBaseRepository _vehicleBaseRepository;

        public VehicleBaseService(IVehicleBaseRepository vehicleBaseRepository)
        {
            _vehicleBaseRepository = vehicleBaseRepository;
        }

        public async Task<IEnumerable<VehicleBase>> GetAllAsync()
        {
            return await _vehicleBaseRepository.GetAllAsync();
        }

        public async Task DeleteAsync(long id)
        {
            await _vehicleBaseRepository.DeleteAsync(id);
        }

        public async Task<VehicleBase> GetByIdAsync(long id)
        {
            return await _vehicleBaseRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(VehicleBaseDto data)
        {
            var basePlatform = await _vehicleBaseRepository.GetByIdAsync(data.Id);

            basePlatform.UpdateOrFail(
                data.NameRu,
                data.NameKk,
                data.NameEn,
                data.Polygon,
                data.ProviderId,
                data.Comment,
                data.ValidTo);

            await _vehicleBaseRepository.UpdateAsync(basePlatform);
        }

        public async Task InsertAsync(VehicleBaseDto data)
        {
            var basePlatform = data.NewBasePlatform();
            await _vehicleBaseRepository.InsertAsync(basePlatform);
        }
    }
}