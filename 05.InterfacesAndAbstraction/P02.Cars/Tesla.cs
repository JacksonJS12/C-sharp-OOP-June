using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class 
        Tesla : Car, IElectricCar
    {
        public Tesla(string model, string color, int battery)
            : base(model, color)
        {
            this.Battery = battery;
        }

        public int Battery { get; private set; }

        public void Crarge()
        {
            this.Battery++;
        }

        public override void Run()
        {
            this.Battery--;
        }

        public override string Start()
        {
            return "Engine start";
        }
        public override string ToString()
        {
            var result = new StringBuilder();

            result
                .AppendLine($"{base.ToString()} with {this.Battery} batteries")
                .AppendLine(this.Start())
                .AppendLine(this.Stop());

            return result.ToString().TrimEnd();
        }
    }
}
