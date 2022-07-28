using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes.Utilities.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class MyRequiredAttribute : MyValidationAttributes
    {
        public override bool IsValid(object obj)
        {
            if (obj is string str)
            {
                return !string.IsNullOrEmpty(str);
            }
            return obj != null;        }
    }
}
