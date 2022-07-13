using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Rectangle : IDrawable
    {
        public double Width { get; private set; }
        public double Height { get; private set; }

        public Rectangle(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }

        public void Draw()
        {
            DrawLine(this.Width, '*', '*');
            for (int i = 1; i < this.Height - 1; ++i)
            {
                DrawLine(this.Width, '*', ' ');
            }
            DrawLine(this.Width, '*', '*');
        }

        private void DrawLine(double width, char end, char mid)
        {
            Console.WriteLine(end);
            for (int i = 1; i < width - 1; ++i)
            {
                Console.WriteLine(mid);
            }
            Console.WriteLine(end);
        }
    }
}
