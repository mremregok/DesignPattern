using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEducaiton.UML.CreationalPatterns.AbstractFactory.Example1.Abstracts
{
	//Abstract Factory
	public abstract class DatabaseFactory
	{
		public abstract Connection CreateConnection();
		public abstract Command CreateCommand();
	}
}
