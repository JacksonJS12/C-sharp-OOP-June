using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDriveRent.Models;
using EDriveRent.Models.Contracts;
using EDriveRent.Repositories.Contracts;

namespace EDriveRent.Repositories
{
    public class VehicleRepository : IRepository<IVehicle>
    {
        private List<IVehicle> vehicles;

        public VehicleRepository()
        {
            vehicles = new List<IVehicle>();
        }
        public void AddModel(IVehicle model)
        {
            vehicles.Add(model);
        }

        public bool RemoveById(string identifier)
        {
            var vehicleToRemove = vehicles.FirstOrDefault(i => i.LicensePlateNumber == identifier);

            return vehicles.Remove(vehicleToRemove);
        }

        public IVehicle FindById(string identifier)
        {
            return vehicles.FirstOrDefault(i => i.LicensePlateNumber == identifier);
        }

        public IReadOnlyCollection<IVehicle> GetAll()
        {
            return vehicles.AsReadOnly();
        }
    }
}
