using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using ValidationAttributes.Utilities.Attributes;

namespace ValidationAttributes.Utilities
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            // var validationContext = new ValidationContext(obj);
            // ICollection<ValidationResult> errors = new List<ValidationResult>();

            //return System.ComponentModel.DataAnnotations.Validator.TryValidateObject(obj, validationContext, errors);

            Type objType = obj.GetType();
            PropertyInfo[] properties = objType
                .GetProperties()
                .Where(pi => pi.CustomAttributes.Any(a => a.AttributeType.BaseType == typeof(MyValidationAttributes)))
                .ToArray();

            foreach (PropertyInfo property in properties)
            {
                object propValue = property.GetValue(obj);

                foreach (CustomAttributeData customAttributeData in property.CustomAttributes)
                {
                    Type customeAttributeType = customAttributeData.AttributeType;
                    object attributeInstance = property
                        .GetCustomAttribute(customeAttributeType);

                    MethodInfo validationMethod = customeAttributeType
                        .GetMethods()
                        .First(m => m.Name == "IsValid");
                    bool result = (bool)validationMethod
                        .Invoke(attributeInstance, new object[] { propValue });
                    if (!result)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
