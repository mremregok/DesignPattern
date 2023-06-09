namespace OOPEducaiton.UML.CreationalPatterns.AbstractFactory.Example3.ConcreteClass
{
    public class PepsiFactory : AbstractFactory
    {
        public override AbstractBottle CreateBottle()
        {
            return new PepsiBottle();
        }

        public override AbstractWater CreateWater()
        {
            return new PepsiWater();
        }
    }
}
