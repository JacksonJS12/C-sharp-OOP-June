using System;
using System.Collections.Generic;
using System.Text;

namespace P01.ClassBoxData
{
    public class Box
    {
        private const double minValue = 0;

        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get
            {
                return this.length;
            }
            private set
            {
                if (value <= minValue)
                {
                    throw new ArgumentException($"{nameof(this.Length)} cannot be zero or negative.");
                }
                this.length = value;
            }
        }
        public double Width
        {
            get
            {
                return this.width;
            }
            private set
            {
                if (value <= minValue)
                {
                    throw new ArgumentException($"{nameof(this.Width)} cannot be zero or negative.");
                }
                this.width = value;
            }
        }
        public double Height
        {
            get
            {
                return this.height;
            }
            private set
            {
                if (value <= minValue)
                {
                    throw new ArgumentException($"{nameof(this.Height)} cannot be zero or negative.");
                }
                this.height = value;
            }
        }
        public double SurfaceArea()
            => (2 * this.Length * this.Width) + (2 * this.Length * this.Height)
            + (2 * this.Width * this.Height);

        public double LateralSurfaceArea()
            => (2 * this.Length * this.Height) + (2 * this.Width * this.Height);

        public double Volume()
            => this.Length * this.Height * this.Width;

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output
                .AppendLine($"Surface Area - {this.SurfaceArea():F2}")
                .AppendLine($"Lateral Surface Area - {this.LateralSurfaceArea():F2}")
                .AppendLine($"Volume - {this.Volume():F2}");

            return output.ToString().TrimEnd();
        }
    }
}
