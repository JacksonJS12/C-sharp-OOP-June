using System;
using System.Collections.Generic;
using System.Text;

namespace AuthorProblem
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class AuthorAttribute : Attribute
    {
        private string _name;
        public AuthorAttribute(string name)
        {

        }
        public string Department { get; set; }
    }
}
