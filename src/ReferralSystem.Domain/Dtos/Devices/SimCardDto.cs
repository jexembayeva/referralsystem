﻿using ReferralSystem.Models.Domain.Devices;

namespace ReferralSystem.Domain.Dtos.Devices
{
    public class SimCardDto : BaseModelDto
    {
        public string SerialNumber { get; set; }

        public string PhoneNumber { get; set; }

        public string PIN1 { get; set; }

        public string PIN2 { get; set; }

        public string PUK1 { get; set; }

        public string PUK2 { get; set; }

        public string Comment { get; set; }

        public SimCard NewSimCard()
        {
            return new SimCard(
                serialNumber: SerialNumber,
                comment: Comment,
                phoneNumber: PhoneNumber);
        }
    }
}