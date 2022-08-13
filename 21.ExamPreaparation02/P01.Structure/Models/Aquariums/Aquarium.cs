﻿using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;
        private ICollection<IDecoration> decorations;
        private ICollection<IFish> fish;

        protected Aquarium(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.decorations = new HashSet<IDecoration>();
            this.fish = new HashSet<IFish>();
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
                this.name = value;
            }
        }

        public int Capacity { get; }

        public int Comfort
          => this.decorations.Sum(d => d.Comfort);

        public ICollection<IDecoration> Decorations
            => this.decorations;

        public ICollection<IFish> Fish
            => this.fish;
        public void AddDecoration(IDecoration decoration)
            => this.Decorations.Add(decoration);

        public void AddFish(IFish fish)
        {
            if (this.Capacity == this.Fish.Count)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }
            this.fish.Add(fish);
        }

        public bool RemoveFish(IFish fish)
            => this.Fish.Remove(fish);

        public void Feed()
        {
            foreach (IFish fish in this.Fish)
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
                .Append($"Comfort: {this.Comfort}");

            return sb.ToString();
        }

    }
}
