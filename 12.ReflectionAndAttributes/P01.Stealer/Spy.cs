using System;
using System.Collections.Generic;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public void StealFieldInfo(string className, params string[] fieldToIvestigate)
        {
            Type? classType = className.GetType();
           // StealFieldInfo[] fields = classType.GetFields(System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags, bindingAttr.nonpublic);
        }
    }
}
