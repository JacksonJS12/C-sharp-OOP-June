using System;
using System.Collections.Generic;
using System.Text;

namespace P04.WildFarm
{
    public class InvalidFactoryTypeException : Exception
    {
        private const string DefaultMessage = "Invalid type!";

        public InvalidFactoryTypeException()
            : base(DefaultMessage)
        {

        }

        public InvalidFactoryTypeException(string message)
            : base(message)
        {

        }
    }
}

