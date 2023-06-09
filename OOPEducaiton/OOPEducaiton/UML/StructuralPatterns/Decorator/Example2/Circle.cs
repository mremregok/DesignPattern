using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEducaiton.UML.StructuralPatterns.Decorator.Example2
{
	//ConcreteComponent
	class Circle : IShape
	{
		public void Draw(Size size, int location)
		{
			Console.WriteLine("Daire çizildi.");
		}
	}
}
