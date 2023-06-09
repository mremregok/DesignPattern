using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEducaiton.UML.CreationalPatterns.BuilderPattern.YemekUretimi
{
	internal class Yemek 
	{ 
		public YemekTipi YemekTipi { get; set; }
		public string YemekAdi { get; set; }
		public double Tuz { get; set; }
		public override string ToString()
		{
			Console.WriteLine($"{YemekTipi} -> Tuz Oranı : {Tuz}");
			return base.ToString();
		}
	} 
}
