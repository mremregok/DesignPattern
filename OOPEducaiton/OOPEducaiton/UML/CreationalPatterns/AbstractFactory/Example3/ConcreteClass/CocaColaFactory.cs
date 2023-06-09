namespace OOPEducaiton.UML.CreationalPatterns.AbstractFactory.Example3.ConcreteClass
{
    public class CocaColaFactory : AbstractFactory
    {
        public override AbstractBottle CreateBottle()
        {
            return new CocaColaBottle();
        }

        public override AbstractWater CreateWater()
        {
            return new CocaColaWater();
        }
    }
}
