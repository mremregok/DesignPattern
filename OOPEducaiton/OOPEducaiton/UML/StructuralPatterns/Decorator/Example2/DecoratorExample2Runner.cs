using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEducaiton.UML.StructuralPatterns.Decorator.Example2
{
	internal class DecoratorExample2Runner
	{
        public DecoratorExample2Runner()
        {
			Console.WriteLine("Circle");
			Circle circle = new Circle();
			circle.Draw(new Size(5, 10), 100);

			Console.WriteLine("\nCircleEdge");
			Console.WriteLine("****************");
			CircleEdge circleEdge = new CircleEdge(circle);
			circleEdge.Draw(new Size(5, 10), 100);

			Console.WriteLine("\nCircleFill");
			Console.WriteLine("****************");
			CircleFill circleFill = new CircleFill(circle);
			circleFill.Draw(new Size(5, 10), 100);

			Console.WriteLine("\nCircleFull");
			Console.WriteLine("****************");
			CircleFull circleFull = new CircleFull(circle);
			circleFull.Draw(new Size(5, 10), 100);
		}
    }
}
