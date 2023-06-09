using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOPEducaiton.UML.CreationalPatterns.AbstractFactory.Example1.Abstracts;

namespace OOPEducaiton.UML.CreationalPatterns.AbstractFactory.Example1.ConcreteProducts
{
	//Concrete Product
	public class SqlConnection : Connection
	{
		public override string State => "Open";
		public override bool Connect()
		{
			Console.WriteLine("SqlConnection bağlantısı kuruluyor.");
			return true;
		}
		public override bool DisConnect()
		{
			Console.WriteLine("SqlConnection bağlantısı kesiliyor.");
			return false;
		}
	}

	//Concrete Product
	class SqlCommand : Command
	{
		public override void Execute(string query) => Console.WriteLine("SqlCommand sorgusu çalıştırıldı.");
	}
}
