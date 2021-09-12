using System;
using ReferralSystem.Models.Domain.BaseModels;
using Utils.Validators;

namespace ReferralSystem.Models.Domain.Vehicles
{
    public class Vehicle : BaseModel
    {
        protected Vehicle()
        {
        }

        public Vehicle(string model, int year, bool isOwned, string comment, string phoneNumber, string licencePlate, int fuelConsumptionRate, int fuelConsumptionRateWinter, string token)
        {
            Model = model;
            Year = year;
            IsOwned = isOwned;
            Comment = comment;
            PhoneNumber = phoneNumber;
            LicencePlate = licencePlate;
            FuelConsumptionRate = fuelConsumptionRate;
            FuelConsumptionRateWinter = fuelConsumptionRateWinter;
            UpdateToken = token;
        }

        public string Model { get; set; }

        public int Year { get; set; }

        public long DeviceId { get; set; }

        public long ProviderId { get; set; }

        public bool IsOwned { get; set; }

        public long ManufacturerId { get; set; }

        public long VehicleTypeId { get; set; }

        public string Comment { get; set; }

        public string PhoneNumber { get; set; }

        public string LicencePlate { get; set; }

        public long BaseId { get; set; }

        public int FuelConsumptionRate { get; set; }

        public int FuelConsumptionRateWinter { get; set; }

        public DateTimeOffset ValidFrom { get; set; }

        public DateTimeOffset ValidTo { get; set; }

        public void UpdateOrFail(string licencePlate, string phoneNumber, int fuelConsumptionRate)
        {
            LicencePlate = licencePlate;
            PhoneNumber = phoneNumber;
            FuelConsumptionRate = fuelConsumptionRate;

            this.ThrowIfInvalid();
        }
    }
}