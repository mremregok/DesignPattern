using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOPEducaiton.UML.CreationalPatterns.AbstractFactory.Example3;

namespace OOPEducaiton.UML.CreationalPatterns.AbstractFactory.Example3.ConcreteClass
{
    public class CocaColaBottle : AbstractBottle
    {
        public override void Interact(AbstractWater water)
        {
			Console.WriteLine($"{this.GetType().Name}, {water.GetType().Name} suyuyla dolduruldu.");
		}
    }
}
