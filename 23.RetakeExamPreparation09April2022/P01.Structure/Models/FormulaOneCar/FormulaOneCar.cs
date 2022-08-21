using Formula1.Models.Contracts;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Models
{
    public abstract class FormulaOneCar : IFormulaOneCar
    {
        private string model;
        private double engineDisplacement;
        private int horsepower;

        protected FormulaOneCar(string model, int horsepower, double engineDisplacement)
        {
            this.Model = model;
            this.Horsepower = horsepower;
            this.EngineDisplacement = engineDisplacement;
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidF1CarModel, value);
                }
                this.model = value;
            }
        }

        public int Horsepower
        {
            get
            {
                return this.horsepower;
            }
            private set
            {
                if (value < 900 ||
                    value > 1050)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidF1HorsePower, $"{value}");
                }
                this.horsepower = value;
            }
        }

        public double EngineDisplacement
        {
            get
            {
                return this.engineDisplacement;
            }
            private set
            {
                if (value < 1.6 ||
                    value > 2)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidF1EngineDisplacement, $"{value}");
                }
                this.engineDisplacement = value;
            }
        }

        public double RaceScoreCalculator(int laps)
        {
            double racePoints = this.EngineDisplacement / this.Horsepower * laps;
            return racePoints;
        }
    }
}
