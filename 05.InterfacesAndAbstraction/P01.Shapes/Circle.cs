﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Circle : IDrawable
    {
        public Circle(int radius)
        {
            this.Radius = radius;
        }
        public double Radius { get; private set; }
        public void Draw()
        {
            double rIn = this.Radius - 0.4;
            double rOut = this.Radius + 0.4;
            for (double y = this.Radius; y >= -this.Radius; --y)
            {
                for (double x = -this.Radius; x < rOut; x += 0.5)
                {
                    double value = x * x + y * y;
                    if (value >= rIn * rIn && value <= rOut * rOut)
                    {
                        Console.WriteLine("*");
                    }
                    else
                    {
                        Console.WriteLine(" ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
