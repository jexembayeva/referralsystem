using System;
using ReferralSystem.Models.Domain.BaseModels;
using Utils.Interfaces;
using Utils.Validators;

namespace ReferralSystem.Models.Domain.Providers
{
    public class Provider : BaseModel, IHasFromToDates
    {
        protected Provider()
        {
        }

        public Provider(
            string nameRu,
            string nameEn,
            string nameKk,
            string address,
            string head,
            string phoneNumber,
            string email,
            string bank,
            string bin,
            string bik,
            string dispatcherPhoneNumber,
            string techServicePhoneNumber,
            string comment,
            long regionId,
            DateTimeOffset validFrom,
            DateTimeOffset? validTo)
        {
            NameEn = nameEn;
            NameRu = nameRu;
            NameKk = nameKk;
            Address = address;
            Head = head;
            PhoneNumber = phoneNumber;
            Email = email;
            Bank = bank;
            BIN = bin;
            BIK = bik;
            DispatcherPhoneNumber = dispatcherPhoneNumber;
            TechServicePhoneNumber = techServicePhoneNumber;
            Comment = comment;
            RegionId = regionId;
            ValidFrom = validFrom;
            ValidTo = validTo;
        }

        public string NameRu { get; protected set; }

        public string NameEn { get; protected set; }

        public string NameKk { get; protected set; }

        public string Address { get; protected set; }

        public string Head { get; protected set; }

        public string PhoneNumber { get; protected set; }

        public string Email { get; protected set; }

        public string Bank { get; protected set; }

        public string BIN { get; protected set; }

        public string BIK { get; protected set; }

        public string DispatcherPhoneNumber { get; protected set; }

        public string TechServicePhoneNumber { get; protected set; }

        public string Comment { get; protected set; }

        public long RegionId { get; protected set; }

        public DateTimeOffset ValidFrom { get; protected set; }

        public DateTimeOffset? ValidTo { get; protected set; }

        public void UpdateOrFail(
            string nameRu,
            string nameEn,
            string nameKk,
            string address,
            string head,
            string phoneNumber,
            string email,
            string bank,
            string bin,
            string bik,
            string dispatcherPhoneNumber,
            string techServicePhoneNumber,
            string comment,
            long regionId,
            DateTimeOffset? validTo)
        {
            NameRu = nameRu;
            NameKk = nameKk;
            NameEn = nameEn;
            Address = address;
            Head = head;
            PhoneNumber = phoneNumber;
            Email = email;
            Bank = bank;
            BIN = bin;
            BIK = bik;
            DispatcherPhoneNumber = dispatcherPhoneNumber;
            TechServicePhoneNumber = techServicePhoneNumber;
            Comment = comment;
            RegionId = regionId;
            ValidTo = validTo;

            this.ThrowIfInvalid();
        }
    }
}