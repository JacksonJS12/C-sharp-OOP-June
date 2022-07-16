namespace Vehicle.Core
{
    using Vehicle.Models.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Engine : IEngine
    {
        private readonly Vehicle car;
        private readonly Vehicle truck;
        public Engine(Vehicle car, Vehicle truck)
        {
            this.car = car;
            this.truck = truck;
        }
        public void Start()
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < i; i++)
            {
                string[] cmdArgs = Console.ReadLine()
                    .Split();
                string cmdType = cmdArgs[0];
                string vehicleType = cmdArgs[1];
                double cmdParams = double.Parse(cmdArgs[2]);

                if (cmdType == "Drive")
                {
                    if (vehicleType == "Car")
                    {
                        Console.WriteLine(this.car.Drive(cmdParams));
                        this.car.Drive(cmdParams);
                    }
                    else if (vehicleType == "Truck")
                    {
                        Console.WriteLine(this.car.Drive(cmdParams));
                        this.truck.Drive(cmdParams);
                    }
                }
                else if (cmdType == "Refuel")
                {
                    if (vehicleType == "Car")
                    {
                        this.car.Refuel(cmdParams);
                    }
                    else if (vehicleType == "Truck")
                    {
                        this.truck.Refuel(cmdParams);
                    }
                }
            }
            Console.WriteLine(this.car);
            Console.WriteLine(this.truck);
        }
    }
}
