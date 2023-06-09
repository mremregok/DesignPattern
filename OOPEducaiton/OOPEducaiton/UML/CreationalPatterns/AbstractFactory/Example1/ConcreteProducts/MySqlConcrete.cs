using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOPEducaiton.UML.CreationalPatterns.AbstractFactory.Example1.Abstracts;

namespace OOPEducaiton.UML.CreationalPatterns.AbstractFactory.Example1.ConcreteProducts
{
	//Concrete Product
	public class MySqlConnection : Connection
	{
		public override string State => "Open";
		public override bool Connect()
		{
			Console.WriteLine("MySqlConnection bağlantısı kuruluyor.");
			return true;
		}
		public override bool DisConnect()
		{
			Console.WriteLine("MySqlConnection bağlantısı kesiliyor.");
			return false;
		}
	}

	//Concrete Product
	class MySqlCommand : Command
	{
		public override void Execute(string query) => Console.WriteLine("MySqlCommand sorgusu çalıştırıldı.");
	}
}
