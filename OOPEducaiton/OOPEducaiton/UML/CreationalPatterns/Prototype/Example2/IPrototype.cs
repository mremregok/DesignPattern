using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEducaiton.UML.CreationalPatterns.Prototype.Example2
{
	public interface IPrototype
	{
		public Prototype Clone();
		public string ToString();
		public void SetName(string name, string surname);
	}
}
