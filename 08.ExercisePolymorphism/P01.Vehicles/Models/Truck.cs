namespace Vehicle.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Interfaces;
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsuption)
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
                this.FuelConsumption = value + this.FuelConsumptionIncrement;
            }
        }

        public override double FuelConsumptionIncrement
            => 1.6;
        public override void Refuel(double liters)
        {
            base.Refuel(liters * 0.95);
        }
    }
}
