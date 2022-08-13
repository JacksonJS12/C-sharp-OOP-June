using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P01.Structure.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;
        private int comfort;

        protected Aquarium(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;

            this.Decorations = new HashSet<IDecoration>();
            this.Fish = new HashSet<IFish>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                }
            }
        }

        public int Capacity { get; private set; }

        public int Comfort
        {
            get
            {
                return this.comfort;
            }
            private set
            {
                this.comfort = this.Decorations.Sum(d => d.Comfort);
            }
        }

        public ICollection<IDecoration> Decorations { get; private set; }

        public ICollection<IFish> Fish { get; private set; }

        public void AddDecoration(IDecoration decoration)
            => this.Decorations.Add(decoration);

        public void AddFish(IFish fish)
        {
            if (this.Capacity < this.Fish.Count + 1)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }
            this.Fish.Add(fish);
        }
        public bool RemoveFish(IFish fish)
            => this.Fish.Remove(fish);

        public void Feed()
        {
            foreach (var fish in this.Fish)
            {
                fish.Eat();
            }
        }

        public string GetInfo()
        {
            var sb = new StringBuilder();

            string fishOutput = this.Fish.Count > 0 ?
                string.Join(", ", this.Fish.Select(f => f.Name))
                : "none";

            sb
                .AppendLine($"{this.Name} ({this.GetType().Name}):")
                .AppendLine($"Fish: {fishOutput}")
                .AppendLine($"Decorations: {this.Decorations.Count}")
                .AppendLine($"Comfort: {this.Comfort}");

            return sb.ToString();
        }

    }
}
