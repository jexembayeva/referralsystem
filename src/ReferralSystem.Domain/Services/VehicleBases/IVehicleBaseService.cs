﻿using System.Collections.Generic;
using System.Threading.Tasks;
using ReferralSystem.Domain.Dtos.Bases;
using ReferralSystem.Models.Domain.Bases;

namespace ReferralSystem.Domain.Services.Bases
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