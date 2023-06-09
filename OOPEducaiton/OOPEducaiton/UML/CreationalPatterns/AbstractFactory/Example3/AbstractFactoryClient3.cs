using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEducaiton.UML.CreationalPatterns.AbstractFactory.Example3
{
    public class AbstractFactoryClient3<T> where T : AbstractFactory, new()
    {
        private AbstractWater water;
        private AbstractBottle bottle;
        public AbstractFactoryClient3()
        {
            AbstractFactory factory = new T();
            water = factory.CreateWater();
            bottle = factory.CreateBottle();
        }
        public void Run()
        {
            bottle.Interact(water);
        }
    }
}
