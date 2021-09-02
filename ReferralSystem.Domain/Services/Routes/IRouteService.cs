using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ReferralSystem.Models.Domain.Routes;

namespace ReferralSystem.Domain.Services.Routes
{
    public interface IRouteService
    {
        Task<IEnumerable<Route>> GetAllAsync();

        Task DeleteAsync(long id);

        Task<Route> GetByIdAsync(long id);

        Task UpdateAsync(Route data);

        Task InsertAsync(Route entity);
    }
}