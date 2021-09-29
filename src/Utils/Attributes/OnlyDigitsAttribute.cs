using System.ComponentModel.DataAnnotations;

namespace ReferralSystem.Models.Attributes
{
    public class OnlyDigitsAttribute : RegularExpressionAttribute
    {
        public OnlyDigitsAttribute(int length)
            : base($@"^([0-9]{{{length}}})$")
        {
        }
    }
}
