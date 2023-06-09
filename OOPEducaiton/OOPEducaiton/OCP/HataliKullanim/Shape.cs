using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEducaiton.OCP.HataliKullanim
{
    public class Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public double CalculateArea()
        {
            if (this is Rectangle)
            {
                return Width * Height;
            }
            else if (this is Circle)
            {
                return Math.PI * Math.Pow(Width / 2, 2);
            }

            return 0;
        }
    }

    public class Rectangle : Shape
    {
        // Ekstra özellikler ve davranışlar
    }

    public class Circle : Shape
    {
        // Ekstra özellikler ve davranışlar
    }
}
