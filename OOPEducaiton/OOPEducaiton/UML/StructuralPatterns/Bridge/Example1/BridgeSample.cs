namespace OOPEducaiton.UML.StructuralPatterns.Bridge.Example1
{
	public abstract class Abstraction
	{
		public Bridge Implementer { get; set; }
        public Abstraction(Bridge bridge)
        {
            Implementer = bridge;
        }
        public virtual void Operation()
		{
			Console.WriteLine("ImplementationBase:Operation()");
			Implementer.OperationImplementation();
		}
	}
	// Abstraction sınıfını değiştirmeden, genişlettiğimiz sınıf.
	public class RefinedAbstraction : Abstraction
	{
		public RefinedAbstraction(Bridge bridge) : base(bridge) 
		{

		}
		public override void Operation()
		{
			Console.WriteLine("RefinedAbstraction:Operation()");
			Implementer.OperationImplementation();
		}
	}

	public class Operator : Abstraction
	{
        public Operator(Bridge bridge) : base(bridge)
        {

        }
	}

	public interface Bridge
	{
		void OperationImplementation();
	}

	public class ImplementationA : Bridge
	{
		public void OperationImplementation()
		{
			Console.WriteLine("ImplementationA:OperationImplementation()");
		}
	}

	public class ImplementationB : Bridge
	{
		public void OperationImplementation()
		{
			Console.WriteLine("ImplementationB:OperationImplementation()");
		}
	}



	class BridgePatternRunner
    {
        public BridgePatternRunner()
        {
			Abstraction abstraction;

			abstraction = new Operator(new ImplementationA());

			abstraction.Operation();

			abstraction = new RefinedAbstraction(new ImplementationB());

			abstraction.Operation();

			Console.ReadKey();
        }
    }
}
