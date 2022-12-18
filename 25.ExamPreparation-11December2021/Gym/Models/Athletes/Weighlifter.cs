using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Athletes
{
    public class Weighlifter : Athlete
    {
        public Weighlifter(string fullName, string motivation, int numberOfMedals)
            : base(fullName, motivation, numberOfMedals, 50) { }

        public override void Exercise()
        {
            this.Stamina += 10;
        }
    }
}
