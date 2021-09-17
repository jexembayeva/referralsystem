using System;
using ReferralSystem.Models.Domain.BaseModels;
using Utils.Interfaces;
using Utils.Validators;

namespace ReferralSystem.Models.Domain.Vehicles
{
    public class Vehicle : BaseModel, IHasFromToDates
    {
        protected Vehicle()
        {
        }

        public Vehicle(string model, int year, bool isOwned, string comment, string phoneNumber, string licencePlate, int fuelConsumptionRate, int fuelConsumptionRateWinter)
        {
            Model = model;
            Year = year;
            IsOwned = isOwned;
            Comment = comment;
            PhoneNumber = phoneNumber;
            LicencePlate = licencePlate;
            FuelConsumptionRate = fuelConsumptionRate;
            FuelConsumptionRateWinter = fuelConsumptionRateWinter;
        }

        public string Model { get; protected set; }

        public int Year { get; protected set; }

        public long DeviceId { get; protected set; }

        public long ProviderId { get; protected set; }

        public bool IsOwned { get; protected set; }

        public long ManufacturerId { get; protected set; }

        public long VehicleTypeId { get; protected set; }

        public string Comment { get; protected set; }

        public string PhoneNumber { get; protected set; }

        public string LicencePlate { get; protected set; }

        public long BaseId { get; protected set; }

        public int FuelConsumptionRate { get; protected set; }

        public int FuelConsumptionRateWinter { get; protected set; }

        public DateTimeOffset ValidFrom { get; protected set; }

        public DateTimeOffset? ValidTo { get; protected set; }

        public void UpdateOrFail(string licencePlate, string phoneNumber, int fuelConsumptionRate)
        {
            LicencePlate = licencePlate;
            PhoneNumber = phoneNumber;
            FuelConsumptionRate = fuelConsumptionRate;

            this.ThrowIfInvalid();
        }
    }
}