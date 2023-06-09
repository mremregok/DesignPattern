using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEducaiton.UML.StructuralPatterns.ProxyPattern.Example1
{
	internal class ProxyPatternExample1Runner
	{
        public ProxyPatternExample1Runner()
        {
			string KullaniciAdi = "", Sifre = "";
			double Tutar = 0;
			while (true)
			{
				Console.WriteLine("Lütfen kullanıcı adınızı giriniz.");
				KullaniciAdi = Console.ReadLine();

				Console.WriteLine("Lütfen şifrenizi giriniz.");
				Sifre = Console.ReadLine();

				Console.WriteLine("Lütfen ödenecek miktarı giriniz.");
				Tutar = Convert.ToInt32(Console.ReadLine());

				IBanka banka = new ProxyBanka(KullaniciAdi, Sifre);
				banka.OdemeYap(Tutar);

				Console.WriteLine("************");
			}
		}
    }
}
