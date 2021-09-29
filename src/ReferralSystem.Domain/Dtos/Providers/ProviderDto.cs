using System;
using System.Threading;
using ReferralSystem.Models.Domain.Providers;
using Utils.Interfaces;

namespace ReferralSystem.Domain.Dtos.Providers
{
    public class ProviderDto : BaseModelDto, IHasFromToDates
    {
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

        public DateTimeOffset? ValidTo { get; set; }

        public Provider NewProvider()
        {
            return new Provider(
                nameEn: NameEn,
                nameKk: NameKk,
                nameRu: NameRu,
                address: Address,
                head: Head,
                phoneNumber: PhoneNumber,
                email: Email,
                bank: Bank,
                bin: BIN,
                bik: BIK,
                dispatcherPhoneNumber: DispatcherPhoneNumber,
                techServicePhoneNumber: TechServicePhoneNumber,
                regionId: RegionId,
                comment: Comment,
                validFrom: ValidFrom,
                validTo: ValidTo);
        }
    }
}