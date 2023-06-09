using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OOPEducaiton.OCP.DogruKullanim
{
    public class AreaCalculator
    {
        public double CalculateTotalArea(Shape[] shapes)
        {
            double totalArea = 0;

            foreach (var shape in shapes)
            {
                totalArea += shape.CalculateArea();
            }

            return totalArea;
        }
    }


    //IArac km, model
    //abtract DizelArac -> MotorinBenzinDoldur, -> BakimYap

    //Otobus, minibüs ve kamyon
}
