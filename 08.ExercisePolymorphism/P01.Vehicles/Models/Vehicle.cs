namespace Vehicle.Models.Interfaces
{

    public abstract class Vehicle : IVehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;
        protected Vehicle(double fuelQuantity, double fuelConsuption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsuption;
        }
        public double FuelQuantity
        {
            get
            {
                return this.fuelQuantity;
            }
            private set
            {
                this.fuelQuantity = value;
            }
        }
        public abstract double FuelConsumptionIncrement { get; }

        public virtual double FuelConsumption
        {
            get
            {
                return this.fuelConsumption;
            }
            protected set
            {
                this.fuelConsumption = value;
            }
        }

        public string Drive(double disctance)
        {
            double fuelNeeded = disctance * this.FuelConsumption;

            if (fuelNeeded >= this.FuelQuantity)
            {
                return $"{this.GetType().Name} needs refueling";
            }
            this.FuelQuantity -= fuelNeeded;
            return $"{this.GetType().Name} travelled {disctance} km";
        }

        public virtual void Refuel(double liters)
        {
            this.fuelQuantity += liters;
        }
        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }

    }
}
