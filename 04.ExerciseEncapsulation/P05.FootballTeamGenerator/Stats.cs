using System;
using System.Collections.Generic;
using System.Text;

namespace P05.FootballTeamGenerator
{
    public class Stats
    {
        private const int StatMinValue = 0;
        private const int StatMaxValue = 100;

        private int endurance;
        private int sprint;
        private int drible;
        private int passing;
        private int shooting;

        public Stats(int endurance, int sprint, int drible, int passing, int shooting)
        {
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Drible = drible;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        public int Endurance
        {
            get
            {
                return this.endurance;
            }
            private set
            {
                if (value < StatMinValue || value > StatMaxValue)
                {
                    throw new ArgumentException
                        (string.Format(ErrorMessages.StatInvalidValue, nameof(this.Endurance)));
                }
                this.endurance = value;
            }
        }
        public int Sprint
        {
            get
            {
                return this.sprint;
            }
            private set
            {
                if (value < StatMinValue || value > StatMaxValue)
                {
                    throw new ArgumentException
                        (string.Format(ErrorMessages.StatInvalidValue, nameof(this.Sprint)));
                }
                this.sprint = value;
            }
        }
        public int Drible
        {
            get
            {
                return this.drible;
            }
            private set
            {
                if (value > StatMaxValue || value < StatMinValue)
                {
                    throw new ArgumentException
                        (string.Format(ErrorMessages.StatInvalidValue, nameof(this.Drible)));
                }
                this.drible = value;
            }
        }
        public int Passing
        {
            get
            {
                return this.passing;
            }
            private set
            {
                if (value > StatMaxValue || value < StatMinValue)
                {
                    throw new ArgumentException
                        (string.Format(ErrorMessages.StatInvalidValue, nameof(this.Passing)));
                }
                this.passing = value;
            }
        }
        public int Shooting
        {
            get
            {
                return this.shooting;
            }
            private set
            {
                if (value > StatMaxValue || value < StatMinValue)
                {
                    throw new ArgumentException
                        (string.Format(ErrorMessages.StatInvalidValue, nameof(this.Shooting)));
                }
                this.shooting = value;
            }
        }
        public int GetOverallStack()
            => (this.Endurance + this.Shooting + this.Sprint + this.Drible + this.Passing) / 5;
    }
}
