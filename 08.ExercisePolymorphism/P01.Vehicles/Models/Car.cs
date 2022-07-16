namespace Vehicle.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Interfaces;
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsuption)
            : base(fuelQuantity, fuelConsuption)
        {
        }

        public override double FuelConsumption
        {
            get
            {
                return base.FuelConsumption;
            }
            protected set
            {
                base.FuelConsumption = value + this.FuelConsumptionIncrement;
            }
        }

        public override double FuelConsumptionIncrement
            => 0.9;
    }
}
