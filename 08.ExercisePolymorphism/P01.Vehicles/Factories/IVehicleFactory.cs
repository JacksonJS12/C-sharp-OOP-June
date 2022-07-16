namespace Vehicle.Factories
{
    using Vehicle.Models.Interfaces;
    public interface IVehicleFactory
    {
        public Vehicle CreateVehicle(string vehicleTyep, double fuelQuantity, double fuelConsumption);
    }
}
