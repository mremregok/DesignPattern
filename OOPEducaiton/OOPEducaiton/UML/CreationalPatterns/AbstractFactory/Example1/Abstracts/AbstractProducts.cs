using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEducaiton.UML.CreationalPatterns.AbstractFactory.Example1.Abstracts
{
	//Abstract Product
	public abstract class Connection
	{
		public abstract bool Connect();
		public abstract bool DisConnect();
		public abstract string State { get; }
	}

	//Abstract Product
	public abstract class Command
	{
		public abstract void Execute(string query);
	}
}
