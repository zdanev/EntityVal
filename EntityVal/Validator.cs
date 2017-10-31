using System;
using System.Collections.Generic;

namespace EntityVal
{
    public class Validator
    {
        public IEnumerable<ValidationError> Validate(object o)
        {
            var errors = new List<ValidationError>();

            var type = o.GetType();

            foreach (var pi in type.GetProperties())
            {
                var value = pi.GetValue(o);
                var fieldName = pi.Name;
                var displayName = fieldName.PascalCaseToTitleCase();

                var displayNameAttr = pi.GetCustomAttributes(typeof(DisplayNameAttribute), true);
                if (displayNameAttr.Length > 0)
                {
                    displayName = ((DisplayNameAttribute)displayNameAttr[0]).DisplayName;
                }

                foreach (var attr in pi.GetCustomAttributes(typeof(ValidationAttribute), true))
                {
                    var error = ((ValidationAttribute)attr).Execute(fieldName, displayName, value);
                    
                    if (error != null)
                    {
                        errors.Add(error);
                    }
                }
            }

            return errors;
        }
    }
}