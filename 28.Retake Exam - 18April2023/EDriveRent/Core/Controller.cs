using System.Collections.Generic;
using EDriveRent.Core.Contracts;
using EDriveRent.Models;
using EDriveRent.Models.Contracts;
using EDriveRent.Repositories;
using EDriveRent.Utilities.Messages;

namespace EDriveRent.Core;

public class Controller : IController
{
    private UserRepository users;
    private VehicleRepository vehicles;
    private RouteRepository routes;

    public Controller()
    {
        this.users = new UserRepository();
        this.vehicles = new VehicleRepository();
        this.routes = new RouteRepository();
    }
    public string RegisterUser(string firstName, string lastName, string drivingLicenseNumber)
    {

        if (users.FindById(drivingLicenseNumber) != null)
        {
            return string.Format(OutputMessages.UserWithSameLicenseAlreadyAdded, drivingLicenseNumber);
        }

        IUser user = new User(firstName, lastName, drivingLicenseNumber);
        this.users.AddModel((User)user);

        return string.Format(OutputMessages.UserSuccessfullyAdded, firstName, lastName, drivingLicenseNumber);
    }

    public string UploadVehicle(string vehicleType, string brand, string model, string licensePlateNumber)
    {

        if (vehicles.FindById(licensePlateNumber) != null)
        {
            return string.Format(OutputMessages.LicensePlateExists, licensePlateNumber);
        }
        if (vehicleType == "PassengerCar" ||
        vehicleType == "CargoVan")
        {
            IVehicle vehicle;
            if (vehicleType == "PassengerCar")
            {
                vehicle = new PassengerCar(brand, model, licensePlateNumber);
            }
            else
            {
                vehicle = new CargoVan(brand, model, licensePlateNumber);
            }

            this.vehicles.AddModel(vehicle);
            return string.Format(OutputMessages.VehicleAddedSuccessfully, brand, model, licensePlateNumber);
        }
        return string.Format(OutputMessages.VehicleTypeNotAccessible, vehicleType);

        
    }

    public string AllowRoute(string startPoint, string endPoint, double length)
    {
        IRoute route = new Route(startPoint, endPoint, length, routes.ToString().Length+1);
        if (routes.FindById(route.RouteId.ToString()) != null)
        {
            if (length > route.Length)
            {
                return string.Format(OutputMessages.RouteIsTooLong, startPoint, endPoint);
            }
            return string.Format(OutputMessages.RouteExisting, startPoint, endPoint, length);
        }

        this.routes.AddModel((Route)route);

        return string.Format(OutputMessages.NewRouteAdded, startPoint, endPoint, length);
    }

    public string MakeTrip(string drivingLicenseNumber, string licensePlateNumber, string routeId, bool isAccidentHappened)
    {
        IUser user = this.users.FindById(drivingLicenseNumber);
        IVehicle vehicle = this.vehicles.FindById(licensePlateNumber);
        IRoute route = this.routes.FindById(routeId);
        if (user.IsBlocked)
        {
            return string.Format(OutputMessages.UserBlocked, drivingLicenseNumber);
        }

        if (vehicle.IsDamaged)
        {
            return string.Format(OutputMessages.VehicleDamaged, licensePlateNumber);
        }

        if (route.IsLocked)
        {
            return string.Format(OutputMessages.RouteLocked, routeId);
        }
        vehicle.Drive(route.Length);

        if (isAccidentHappened)
        {
            vehicle.ChangeStatus();
            user.DecreaseRating();
        }
        user.IncreaseRating();
        return vehicle.ToString();
    }

    public string RepairVehicles(int count)
    {
        var vehiclesToRepair = this.vehicles.GetAll()
    }

    public string UsersReport()
    {
        throw new System.NotImplementedException();
    }
}