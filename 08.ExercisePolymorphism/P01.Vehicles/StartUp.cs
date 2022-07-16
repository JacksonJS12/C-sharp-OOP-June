namespace P01.Vehicles
{
    using System;
    using Vehicle.Core;
    using Vehicle.Factories;
    using Vehicle.Models;
    using Vehicle.Models.Interfaces;
    internal class StartUp
    {
        static void Main(string[] args)
        {
            string[] carData = Console.ReadLine()
                .Split();
            string[] truckData = Console.ReadLine()
                .Split();

            IVehicleFactory vehicleFacoty = new VehicleFactory();
            Vehicle car = vehicleFacoty
                .CreateVehicle(carData[0], double.Parse(carData[1]), double.Parse(carData[2]));
            Vehicle truck = vehicleFacoty
                .CreateVehicle(carData[0], double.Parse(carData[1]), double.Parse(carData[2]));

            IEngine engine = new Engine(car, truck);
            engine.Start();
        }
    }
}
