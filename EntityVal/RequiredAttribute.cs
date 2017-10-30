using System;

namespace EntityVal
{
    [AttributeUsage(AttributeTargets.Property)]
    public class RequiredAttribute : Attribute
    {
        const string DefaultMessage = "{0} is required.";

        public string Message { get; }

        public RequiredAttribute(string message = null)
        {
            Message = message ?? DefaultMessage;
        }
    }
}