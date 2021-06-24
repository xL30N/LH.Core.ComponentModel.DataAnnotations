using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LH.Core.ComponentModel.DataAnnotations
{
    public abstract class BaseValidationAttribute : ValidationAttribute
    {
        protected static bool MergeAttribute(IDictionary<string, string> attributes, string key, string value)
        {
            if (attributes.ContainsKey(key))
            {
                return false;
            }

            attributes.Add(key, value);

            return true;
        }
    }
}
