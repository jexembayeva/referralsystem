using ReferralSystem.Models.Domain.BaseModels;
using Utils.Validators;

namespace ReferralSystem.Models.Domain.Devices
{
    public class Stabilizer : BaseModel
    {
        protected Stabilizer()
        {
        }

        public Stabilizer(string name, string comment)
        {
            Name = name;
            Comment = comment;
        }

        public string Name { get; protected set; }

        public string Comment { get; protected set; }

        public void UpdateOrFail(string name, string comment)
        {
            Name = name;
            Comment = comment;

            this.ThrowIfInvalid();
        }
    }
}
