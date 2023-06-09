using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEducaiton.UML.StructuralPatterns.FlyweightPattern.Example1
{
    // Concrete FlyWeight
    class Sergeant : Soldier
    {

        public Sergeant()
        {
            UnitName = "SWAT";
            Guns = "Sword";
            Health = "Good";
        }

        public override void MoveTo(int x, int y)
        {
            X = x;
            Y = y;

            Console.WriteLine("Çavuş ({0}:{1}) noktasına hareket etti", X, Y);
        }

    }
}
