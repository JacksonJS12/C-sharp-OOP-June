using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes.Utilities.Attributes
{
    public abstract class MyValidationAttributes : Attribute
    {
        public abstract bool IsValid(object obj);
    }
}
