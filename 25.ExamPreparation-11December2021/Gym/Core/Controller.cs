using Gym.Core.Contracts;
using Gym.Models.Athletes;
using Gym.Models.Equipment;
using Gym.Models.Gyms;
using Gym.Repositories;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Core
{
    public class Controller : IController
    {
        private EquipmentRepository equipmentRepository;
        private ICollection<Gym.Models.Gyms.Gym> gyms;

        public Controller()
        {
            this.gyms = new List<Gym.Models.Gyms.Gym>();
            this.equipmentRepository = new EquipmentRepository();
        }
        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            var gym = this.gyms.FirstOrDefault(g => g.Name == gymName);

            bool isAdded = false;
            if (athleteType == "Boxer")
            {
                if (gym.GetType().Name == nameof(BoxingGym))
                {
                    isAdded = true;
                    Boxer boxer = new Boxer(athleteName, motivation, numberOfMedals);
                }
            }
            else if (athleteType == "Weightlifter")
            {
                if (gym.GetType().Name == nameof(WeightliftingGym))
                {
                    isAdded = true;
                    Weighlifter weighlifter = new Weighlifter(athleteName, motivation, numberOfMedals);
                }
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAthleteType);
            }

            if (isAdded)
            {
                return string.Format(OutputMessages.EntityAddedToGym, athleteType, gymName);
            }

            return OutputMessages.InappropriateGym;
        }

        public string AddEquipment(string equipmentType)
        {
            if (equipmentType == "BoxingGloves")
            {
                this.equipmentRepository.Add(new BoxingGloves());
            }
            else if (equipmentType == "Kettlebell")
            {
                this.equipmentRepository.Add(new Kettlebell());
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidEquipmentType);
            }

            return $"Successfully added {equipmentType}.";
        }

        public string AddGym(string gymType, string gymName)
        {
            if (gymType == "BoxingGym")
            {
                this.gyms.Add(new BoxingGym(gymName));
            }
            else if (gymType == "WeightliftingGym")
            {
                this.gyms.Add(new WeightliftingGym(gymName));
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidGymType);
            }

            return $"Successfully added {gymType}.";
        }

        public string EquipmentWeight(string gymName)
        {
            throw new NotImplementedException();
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            Equipment equipment = this.equipmentRepository.FindByType(equipmentType);
            if (equipment == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentEquipment, equipmentType));
            }

            var gym = this.gyms.FirstOrDefault(g => g.Name == gymName);
            gym.AddEquipment(equipment);
            equipmentRepository.Remove(equipment);

            return string.Format(OutputMessages.EntityAddedToGym, equipmentType, gymName);
        }

        public string Report()
        {
            throw new NotImplementedException();
        }

        public string TrainAthletes(string gymName)
        {
            throw new NotImplementedException();
        }
    }
}
