using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEducaiton.UML.StructuralPatterns.ProxyPattern.Example1
{
	//Proxy Class
	class ProxyBanka : IBanka
	{
		Banka banka;
		bool Login;
		string KullaniciAdi, Sifre;
		public ProxyBanka(string KullaniciAdi, string Sifre)
		{
			this.KullaniciAdi = KullaniciAdi;
			this.Sifre = Sifre;
		}

		bool GirisYap()
		{
			if (KullaniciAdi.Equals("test") && Sifre.Equals("1234"))
			{
				banka = new Banka();
				Login = true;
				Console.WriteLine("Hesaba giriş yapıldı.");
				return true;
			}
			else
				Console.WriteLine("Lütfen kullanıcı adı ve şifreinizi doğru girdiğinize emin olunuz.");

			Login = false;
			return false;
		}

		public bool OdemeYap(double Tutar)
		{
			GirisYap();

			if (!Login)
			{
				Console.WriteLine("Hesaba giriş yapılmadığından dolayı ödeme alamıyoruz.");
				return false;
			}

			banka.OdemeYap(Tutar);
			return true;
		}
	}
}
