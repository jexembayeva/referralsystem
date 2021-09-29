using System.Collections.Generic;
using System.Threading.Tasks;
using ReferralSystem.Database.Repositories.Devices.SimCards;
using ReferralSystem.Domain.Dtos.Devices;
using ReferralSystem.Domain.Services.SimCards;
using ReferralSystem.Models.Domain.Devices;

namespace ReferralSystem.Domain.Services.Devices.SimCards
{
    public class SimCardService : ISimCardService
    {
        private readonly ISimCardRepository _simCardRepository;

        public SimCardService(ISimCardRepository simCardRepository)
        {
            _simCardRepository = simCardRepository;
        }

        public async Task<IEnumerable<SimCard>> GetAllAsync()
        {
            return await _simCardRepository.GetAllAsync();
        }

        public async Task DeleteAsync(long id)
        {
            await _simCardRepository.DeleteAsync(id);
        }

        public async Task<SimCard> GetByIdAsync(long id)
        {
            return await _simCardRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(SimCardDto data)
        {
            var simCard = await _simCardRepository.GetByIdAsync(data.Id);

            simCard.UpdateOrFail(
                data.SerialNumber,
                data.PhoneNumber,
                data.PIN1,
                data.PIN2,
                data.PUK1,
                data.PUK2,
                data.Comment);

            await _simCardRepository.UpdateAsync(simCard);
        }

        public async Task InsertAsync(SimCardDto data)
        {
            var simCard = data.NewSimCard();
            await _simCardRepository.InsertAsync(simCard);
        }
    }
}