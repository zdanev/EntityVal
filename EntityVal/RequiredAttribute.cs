using System;

namespace EntityVal
{
    [AttributeUsage(AttributeTargets.Property)]
    public class RequiredAttribute : ValidationAttribute
    {
        const string DefaultMessage = "{0} is required.";

        public string Message { get; }

        public RequiredAttribute(string message = null)
        {
            Message = message ?? DefaultMessage;
        }

        public override ValidationError Execute(string fieldName, string displayName, object value, object entity)
        {
            if (value is string)
            {
                if (string.IsNullOrEmpty(value as string))
                {
                    return new ValidationError(fieldName, Message.FormatWith(displayName, value));
                }
            }
            else
            {
                if (value == null)
                {
                    return new ValidationError(fieldName, Message.FormatWith(displayName, value));
                }
            }

            // TODO: check for default value

            return null;
        }
    }
}