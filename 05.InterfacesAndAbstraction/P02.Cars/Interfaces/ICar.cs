using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public interface ICar
    {
        public string Start();
        public string Stop();
        public void Run();
    }
}
