using System;
using ReferralSystem.Models.Domain.Vehicles;
using Utils.Attributes;
using Utils.Enums;
using Utils.Interfaces;

namespace ReferralSystem.Domain.Dtos.Vehicles
{
    public class VehicleDto : BaseModelDto, IHasFromToDates
    {
        public string Model { get; set; }

        public int Year { get; set; }

        public long DeviceId { get; set; }

        public long ProviderId { get; set; }

        public bool IsOwned { get; set; }

        public long ManufacturerId { get; set; }

        public long VehicleTypeId { get; set; }

        [NotDefaultValue]
        public TransportMode TransportMode { get; set; }

        public string Comment { get; set; }

        public string PhoneNumber { get; set; }

        public string LicencePlate { get; set; }

        public long BaseId { get; set; }

        public int FuelConsumptionRate { get; set; }

        public int FuelConsumptionRateWinter { get; set; }

        public DateTimeOffset ValidFrom { get; set; }

        public DateTimeOffset? ValidTo { get; set; }

        public Vehicle NewVehicle()
        {
            return new Vehicle(
                model: Model,
                year: Year,
                deviceId: DeviceId,
                isOwned: IsOwned,
                manufacturerId: ManufacturerId,
                comment: Comment,
                phoneNumber: PhoneNumber,
                licencePlate: LicencePlate,
                baseId: BaseId,
                fuelConsumptionRate: FuelConsumptionRate,
                fuelConsumptionRateWinter: FuelConsumptionRateWinter,
                validFrom: ValidFrom,
                validTo: ValidTo,
                providerId: ProviderId,
                vehicleTypeId: VehicleTypeId,
                transportMode: TransportMode);
        }
    }
}