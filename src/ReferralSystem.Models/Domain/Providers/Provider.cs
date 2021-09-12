using System;
using ReferralSystem.Models.Domain.BaseModels;
using Utils.Validators;

namespace ReferralSystem.Models.Domain.Providers
{
    public class Provider : BaseModel
    {
        protected Provider()
        {
        }

        public Provider(string nameRu, string nameEn, string nameKk, string address, string head, string phoneNumber, string email, string bank, string bin, string bik, string dispatcherPhoneNumber, string techServicePhoneNumber, string comment, string token)
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
            UpdateToken = token;
        }

        public string NameRu { get; set; }

        public string NameEn { get; set; }

        public string NameKk { get; set; }

        public string Address { get; set; }

        public string Head { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Bank { get; set; }

        public string BIN { get; set; }

        public string BIK { get; set; }

        public string DispatcherPhoneNumber { get; set; }

        public string TechServicePhoneNumber { get; set; }

        public string Comment { get; set; }

        public long RegionId { get; set; }

        public DateTimeOffset ValidFrom { get; set; }

        public DateTimeOffset ValidTo { get; set; }

        public void UpdateOrFail(string nameEn, string nameKk, string nameRu)
        {
            NameRu = nameRu;
            NameKk = nameKk;
            NameEn = nameEn;

            this.ThrowIfInvalid();
        }
    }
}