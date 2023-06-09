using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEducaiton.UML.StructuralPatterns.Decorator.Example2
{
	//Decorator
	class Decorator : IShape
	{
		readonly IShape _shape;
		public Decorator(IShape shape)
		{
			_shape = shape;
		}
		virtual public void Draw(Size size, int location)
		{
			_shape.Draw(size, location);
		}
	}
}
