using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace mvcApp2.Models
{
    public class RequiredAttribute : System.ComponentModel.DataAnnotations.RequiredAttribute
    {
        private string displayName;

        public RequiredAttribute()
        {
            ErrorMessage = "{0} is required";
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            object[]? attributes = validationContext.ObjectType.GetProperty(validationContext.MemberName)
                                                    .GetCustomAttributes(typeof(DisplayNameAttribute), true);
            if (attributes != null)
            {
                displayName = (attributes[0] as DisplayNameAttribute).DisplayName;
            }
            else
            {
                displayName = validationContext.DisplayName;
            }

            return base.IsValid(value, validationContext);
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(ErrorMessageString, displayName);
        }
    }
}
