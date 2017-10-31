using System;

namespace EntityVal
{
    public class MinAttribute : ValidationAttribute
    {
        string DefaultMessage = "{0} must be more than {1}.";

        public int? MinValue { get; }

        public double? MinValueDouble { get; }

        public string Message { get; }

        public MinAttribute(int minValue, string message = null)
        {
            MinValue = minValue;
            Message = message ?? DefaultMessage;
        }

        public MinAttribute(double minValue, string message = null)
        {
            MinValueDouble = minValue;
            Message = message ?? DefaultMessage;
        }

        public override ValidationError Execute(string fieldName, string displayName, object value, object entity)
        {
            if (value is int)
            {
                if (!MinValue.HasValue)
                {
                    throw new InvalidOperationException();
                }

                if ((int)value < MinValue)
                {
                    return new ValidationError(fieldName, Message.FormatWith(displayName, MinValue));
                }
            }

            // TODO: float

            return null;
        }
    }
}