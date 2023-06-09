using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEducaiton.UML.StructuralPatterns.FlyweightPattern.Example1
{
    // Concrete FlyWeight
    class Private : Soldier
    {

        public Private()
        {
            // Intrinsict değerler set edilir
            UnitName = "SWAT";
            Guns = "Machine Gun";
            Health = "Good";
        }

        public override void MoveTo(int x, int y)
        {
            // Extrinsic değerler set edilir ve bir işlem gerçekleştirilir
            X = x;
            Y = y;
            Console.WriteLine("Er ({0}:{1}) noktasına hareket etti", X, Y);

        }

    }
}
