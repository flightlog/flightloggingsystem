using System.ComponentModel.DataAnnotations;

namespace FLS.Common.Validators
{
    /// <summary>
    /// Validates a Guid for not been empty.
    /// <seealso cref="https://stackoverflow.com/questions/7187576/validation-of-guid"/>
    /// </summary>
    public class IsNotEmptyAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null) return false;

            var valueType = value.GetType();
            var emptyField = valueType.GetField("Empty");

            if (emptyField == null) return true;

            var emptyValue = emptyField.GetValue(null);

            return !value.Equals(emptyValue);
        }
    }
}
