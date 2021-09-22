using ReferralSystem.Models.Domain.BaseModels;
using Utils.Validators;

namespace ReferralSystem.Models.Domain.Devices
{
    public class FirmWare : BaseModel
    {
        protected FirmWare()
        {
        }

        public FirmWare(string name, string comment, string config)
        {
            Name = name;
            Comment = comment;
            Config = config;
        }

        public string Name { get; protected set; }

        public string Config { get; protected set; }

        public string Comment { get; protected set; }

        public void UpdateOrFail(string name, string comment, string config)
        {
            Name = name;
            Comment = comment;
            Config = config;

            this.ThrowIfInvalid();
        }
    }
}