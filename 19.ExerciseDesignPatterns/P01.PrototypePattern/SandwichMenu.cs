using System.Collections.Generic;

namespace P01.PrototypePattern
{
    public class SandwichMenu
    {
        private readonly Dictionary<string, SandwichPrototype> sandwiches;

        public SandwichMenu()
        {
          this.sandwiches = new Dictionary<string, SandwichPrototype>();
        }

        //Indexer
        public SandwichPrototype this[string name]
        {
            get
            {
                return this.sandwiches[name];
            }
            set
            {
                this.sandwiches[name] = value;
            }
        }
    }
}
