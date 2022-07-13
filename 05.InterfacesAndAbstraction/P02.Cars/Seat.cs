using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Seat : Car
    {
        public Seat(string model, string color) 
            : base(model, color)
        {
        }

        public override void Run()
        {
            throw new NotImplementedException();
        }
        public override string ToString()
        {
            var result = new StringBuilder();

            result
                .AppendLine(base.ToString())
                .AppendLine(this.Start())
                .AppendLine(this.Stop());

            return result.ToString().TrimEnd();
        }
    }
}
