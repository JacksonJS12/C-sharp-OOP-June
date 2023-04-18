using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDriveRent.Models.Contracts;
using EDriveRent.Repositories.Contracts;

namespace EDriveRent.Repositories
{
    public class UserRepository : IRepository<IUser>
    {
        private List<IUser> users;

        public UserRepository()
        {
            users = new List<IUser>();
        }
        public void AddModel(IUser model)
        {
            users.Add(model);
        }

        public bool RemoveById(string identifier)
        {
            var userToRemove = users.FirstOrDefault(i => i.DrivingLicenseNumber == identifier);

            return users.Remove(userToRemove);
        }

        public IUser FindById(string identifier)
        {
            return users.FirstOrDefault(i => i.DrivingLicenseNumber == identifier);
        }

        public IReadOnlyCollection<IUser> GetAll()
        {
            return users.AsReadOnly();
        }
    }
}
