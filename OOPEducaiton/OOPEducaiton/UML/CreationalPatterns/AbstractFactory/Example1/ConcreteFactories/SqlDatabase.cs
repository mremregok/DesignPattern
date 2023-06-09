using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOPEducaiton.UML.CreationalPatterns.AbstractFactory.Example1.Abstracts;
using OOPEducaiton.UML.CreationalPatterns.AbstractFactory.Example1.ConcreteProducts;

namespace OOPEducaiton.UML.CreationalPatterns.AbstractFactory.Example1.ConcreteFactories
{
	public class SqlDatabase : DatabaseFactory
	{
		public override Command CreateCommand() => new SqlCommand();
		public override Connection CreateConnection() => new SqlConnection();
	}
}
