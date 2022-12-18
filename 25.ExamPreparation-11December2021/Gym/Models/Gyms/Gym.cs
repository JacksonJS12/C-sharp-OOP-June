using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Gym.Models.Gyms
{
    public abstract class Gym : IGym
    {
        private string name;
        private int capacity;
        private double equipmentWeight;
        private ICollection<IEquipment> equipment;
        private ICollection<IAthlete> athletes;

        protected Gym(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Equipment = new List<IEquipment>();
            this.Athletes = new List<IAthlete>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGymName);
                }
                this.name = value;
            }
        }

        public int Capacity { get; private set; }

        public double EquipmentWeight 
        { 
            get
            {
                return this.Equipment.Select(e => e.Weight).Sum();
            }
        }

        public ICollection<IEquipment> Equipment { get; private set; }

        public ICollection<IAthlete> Athletes { get; private set; }

        public void AddAthlete(IAthlete athlete)
        {
            if (this.Athletes.Count >= this.Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughSize);
            }
            this.Athletes.Add(athlete);
        }

        public void AddEquipment(IEquipment equipment) 
            => this.Equipment.Add(equipment);

        public void Exercise()
        {
            foreach (var athlete in this.Athletes)
            {
                athlete.Exercise();
            }
        }

        public string GymInfo()
        {
            StringBuilder sb = new StringBuilder();

            string athletes = this.Athletes.Count > 0 ?
                string.Join(", ", this.Athletes.Select(a => a.FullName)) :
                "No athletes";

            sb
                .AppendLine($"{this.Name} is a {this.GetType().Name}:")
                .AppendLine($"Athletes: {athletes}")
                .AppendLine($"Equipment total count: {this.Equipment.Count}")
                .AppendLine($"Equipment total weight: {this.EquipmentWeight:f2} grams");

            return sb.ToString().TrimEnd();
        }

        public bool RemoveAthlete(IAthlete athlete) 
            => this.Athletes.Remove(athlete);
    }
}
