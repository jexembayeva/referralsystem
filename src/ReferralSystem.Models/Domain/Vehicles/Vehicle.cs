using System;
using ReferralSystem.Models.Domain.BaseModels;
using Utils.Attributes;
using Utils.Enums;
using Utils.Interfaces;
using Utils.Validators;

namespace ReferralSystem.Models.Domain.Vehicles
{
    public class Vehicle : BaseModel, IHasFromToDates
    {
        protected Vehicle()
        {
        }

        public Vehicle(
            string model,
            int year,
            long deviceId,
            long providerId,
            bool isOwned,
            long manufacturerId,
            long vehicleTypeId,
            TransportMode transportMode,
            string comment,
            string phoneNumber,
            string licencePlate,
            long baseId,
            int fuelConsumptionRate,
            int fuelConsumptionRateWinter,
            DateTimeOffset validFrom,
            DateTimeOffset? validTo)
        {
            Model = model;
            Year = year;
            DeviceId = deviceId;
            ProviderId = providerId;
            IsOwned = isOwned;
            ManufacturerId = manufacturerId;
            VehicleTypeId = vehicleTypeId;
            TransportMode = transportMode;
            Comment = comment;
            PhoneNumber = phoneNumber;
            LicencePlate = licencePlate;
            BaseId = baseId;
            FuelConsumptionRate = fuelConsumptionRate;
            FuelConsumptionRateWinter = fuelConsumptionRateWinter;
            ValidFrom = validFrom;
            ValidTo = validTo;
        }

        public string Model { get; protected set; }

        public int Year { get; protected set; }

        public long DeviceId { get; protected set; }

        public long ProviderId { get; protected set; }

        public bool IsOwned { get; protected set; }

        public long ManufacturerId { get; protected set; }

        public long VehicleTypeId { get; protected set; }

        [NotDefaultValue]
        public TransportMode TransportMode { get; protected set; }

        public string Comment { get; protected set; }

        public string PhoneNumber { get; protected set; }

        public string LicencePlate { get; protected set; }

        public long BaseId { get; protected set; }

        public int FuelConsumptionRate { get; protected set; }

        public int FuelConsumptionRateWinter { get; protected set; }

        public DateTimeOffset ValidFrom { get; protected set; }

        public DateTimeOffset? ValidTo { get; protected set; }

        public void UpdateOrFail(
            string model,
            int year,
            long deviceId,
            long providerId,
            bool isOwned,
            long manufacturerId,
            long vehicleTypeId,
            TransportMode transportMode,
            string comment,
            string phoneNumber,
            string licencePlate,
            long baseId,
            int fuelConsumptionRate,
            int fuelConsumptionRateWinter,
            DateTimeOffset? validTo)
        {
            Model = model;
            Year = year;
            DeviceId = deviceId;
            ProviderId = providerId;
            IsOwned = isOwned;
            ManufacturerId = manufacturerId;
            VehicleTypeId = vehicleTypeId;
            TransportMode = transportMode;
            Comment = comment;
            PhoneNumber = phoneNumber;
            LicencePlate = licencePlate;
            BaseId = baseId;
            FuelConsumptionRate = fuelConsumptionRate;
            FuelConsumptionRateWinter = fuelConsumptionRateWinter;
            ValidTo = validTo;

            this.ThrowIfInvalid();
        }
    }
}