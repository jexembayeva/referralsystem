using System.Threading;
using ReferralSystem.Models.Domain.Vehicles;
using Utils.Attributes;
using Utils.Enums;

namespace ReferralSystem.Domain.Dtos.Vehicles
{
    public class VehicleDto : BaseModelDto
    {
        public string Model { get; set; }

        public int Year { get; set; }

        public long DeviceId { get; set; }

        public long ProviderId { get; set; }

        public bool IsOwned { get; set; }

        public bool ManufacturerId { get; set; }

        public bool VehicleTypeId { get; set; }

        [NotDefaultValue]
        public TransportMode TransportMode { get; set; }

        public string Comment { get; set; }

        public string PhoneNumber { get; set; }

        public string LicencePlate { get; set; }

        public long BaseId { get; set; }

        public int FuelConsumptionRate { get; set; }

        public int FuelConsumptionRateWinter { get; set; }

        public Vehicle NewVehicle()
        {
            return new Vehicle(
                model: Model,
                year: Year,
                isOwned: IsOwned,
                comment: Comment,
                phoneNumber: PhoneNumber,
                licencePlate: LicencePlate,
                fuelConsumptionRate: FuelConsumptionRate,
                fuelConsumptionRateWinter: FuelConsumptionRateWinter);
        }
    }
}