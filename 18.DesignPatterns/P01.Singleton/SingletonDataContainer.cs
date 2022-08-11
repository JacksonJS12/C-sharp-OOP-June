using System;
using System.Collections.Generic;
using System.IO;

namespace P01.Singleton
{
    public class SingletonDataContainer : ISingletonContainer
    {
        private Dictionary<string, int> capitals;
        public SingletonDataContainer()
        {
            this.capitals = new Dictionary<string, int>();

            Console.WriteLine("Initializing singleton object");
            var elemnets = File.ReadAllLines("capitals.txt");
            for (int i = 0; i < elemnets.Length; i += 2)
            {
                string key = elemnets[i];
                int value = int.Parse(elemnets[i + 1]);

                this.capitals.Add(key, value);
            }
        }
        public int GetPopulation(string name)
        {
            return this.capitals[name];
        }
    }
}
