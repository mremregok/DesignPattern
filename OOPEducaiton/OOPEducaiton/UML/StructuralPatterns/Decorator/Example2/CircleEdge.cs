﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEducaiton.UML.StructuralPatterns.Decorator.Example2
{
	//ConcreteDecorator
	class CircleEdge : Decorator
	{
		readonly IShape _shape;
		public CircleEdge(IShape shape) : base(shape)
		{
			_shape = shape;
		}
		private void ColorEdge()
		{
			Console.WriteLine("Kenarlar renklendirildi.");
		}
		public override void Draw(Size size, int location)
		{
			base.Draw(size, location);
			ColorEdge();
		}
	}
}
