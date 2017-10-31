using System;

namespace EntityVal
{
    public class CustomValidationAttribute : ValidationAttribute
    {
        string DefaultMessage = "{0} is invalid.";

        public string FunctionName { get; }

        public string Message { get; }

        public CustomValidationAttribute(string functionName, string message = null)
        {
            FunctionName = functionName;
            Message = message ?? DefaultMessage;
        }

        public override ValidationError Execute(string fieldName, string displayName, object value, object entity)
        {
            var type = entity.GetType();
            
            var func = type.GetMethod(FunctionName);
            if (func == null)
            {
                throw new InvalidOperationException("Method not found.");
            }

            var result = (bool)func.Invoke(entity, new [] { value });

            if (!result)
            {
                return new ValidationError(fieldName, Message.FormatWith(displayName, value));
            }
            else
            {
                return null;
            }
        }
    }
}