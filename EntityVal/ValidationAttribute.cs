using System;

namespace EntityVal
{
    public abstract class ValidationAttribute : Attribute
    {
        public abstract ValidationError Execute(string fieldName, string displayName, object value);
    }
}