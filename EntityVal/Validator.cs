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
                Console.WriteLine($"Validating property {pi.Name}...");

                foreach (var attr in pi.GetCustomAttributes(typeof(ValidationAttribute), true))
                {
                    Console.WriteLine($"Attribute {attr.GetType().Name}...");
                }
            }

            return errors;
        }
    }
}