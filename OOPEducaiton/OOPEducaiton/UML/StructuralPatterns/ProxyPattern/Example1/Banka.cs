using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEducaiton.UML.StructuralPatterns.ProxyPattern.Example1
{
	//Real Subject Class
	class Banka : IBanka
	{
		public bool OdemeYap(double Tutar)
		{
			if (Tutar < 100)
				Console.WriteLine($"Ödeyeceğiniz tutar 100 TL'den az olamaz. Fark -> {100 - Tutar}");
			else if (Tutar > 100)
				Console.WriteLine($"Ödeyeceğiniz tutar 100 TL'den fazla olamaz. Fark -> {Tutar - 100}");
			else
			{
				Console.WriteLine($"Ödeme başarıyla gerçekleştirildi. -> {Tutar}");
				return true;
			}

			return false;
		}
	}
}
