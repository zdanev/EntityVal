using System;
using System.Collections.Generic;
using System.Linq;

namespace EntityVal
{
    public static class ExtMethods
    {
        public static bool IsValid(this object o)
        {
            var errors = o.Validate();

            return errors.Count() == 0;
        }

        public static IEnumerable<ValidationError> Validate(this object o)
        {
            var validator = new Validator();
            
            return validator.Validate(o);
        }
    }
}