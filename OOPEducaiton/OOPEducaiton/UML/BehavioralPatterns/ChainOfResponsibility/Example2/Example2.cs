using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEducaiton.UML.BehavioralPatterns.ChainOfResponsibility.Example2
{
	public class CoRBadExample
	{
        public CoRBadExample()
        {
			var istenenYer = "";
			if (istenenYer == "Türkiye")
			{
				//150.143.253.114 sunucusuna bağlan ve gerekli işlemleri yap
			}
			else if (istenenYer == "Almanya")
			{
				//28.158.96.108 sunucusuna bağlan ve gerekli işlemleri yap
			}
			else if (istenenYer == "Belçika")
			{
				//107.181.170.186 sunucusuna bağlan ve gerekli işlemleri yap
			}
		}
    }

	public class CoRGoodExample
	{
        public CoRGoodExample()
        {
			AlmanyaRezervasyon almanyaRezervasyon = new AlmanyaRezervasyon();
			BelcikaRezervasyon belcikaRezervasyon = new BelcikaRezervasyon();
			TurkiyeRezervasyon turkiyeRezervasyon = new TurkiyeRezervasyon();

			almanyaRezervasyon.BirSonrakiSorumlu = belcikaRezervasyon;
			belcikaRezervasyon.BirSonrakiSorumlu = turkiyeRezervasyon;

			almanyaRezervasyon.UygunSalonlariAra(new AramaKriteri { KatilimciSayisi = 15, Ulke = "Türkiye" });
			Console.ReadLine();
		}
	}

	public class AramaKriteri
	{
		public string Ulke { get; set; }
		public string Sehir { get; set; }
		public int KatilimciSayisi { get; set; }
		public DateTime TalepTarihi { get; set; }
	}

	public abstract class ToplantiSalonRezervasyon
	{
		//Zincirin bir üst halkası
		public ToplantiSalonRezervasyon BirSonrakiSorumlu { get; set; }

		//kriteri yakalayıcı
		private EventHandler<AramaKriteri> aramaKriteriHandler;
		//kriter yakalandığında çalışacak metot
		protected abstract void ara(object sender, AramaKriteri kriter);
		public ToplantiSalonRezervasyon()
		{
			//ara metodunu delege'ye aktar:
			aramaKriteriHandler += ara;
		}

		public void UygunSalonlariAra(AramaKriteri kriter)
		{
			aramaKriteriHandler(this, kriter);
		}
	}

	public class AlmanyaRezervasyon : ToplantiSalonRezervasyon
	{
		protected override void ara(object sender, AramaKriteri kriter)
		{
			if (kriter.Ulke == "Almanya")
			{
				Console.WriteLine("Almanya için uygun salonlar aranıyor");
			}
			else
			{
				//birsonrakiSorumlu boş değilse
				BirSonrakiSorumlu?.UygunSalonlariAra(kriter);
			}
		}
	}
	//2. Halka
	public class BelcikaRezervasyon : ToplantiSalonRezervasyon
	{
		protected override void ara(object sender, AramaKriteri kriter)
		{
			if (kriter.Ulke == "Belçika")
			{
				Console.WriteLine("Belçika için uygun salonlar aranıyor");
			}
			else
			{
				BirSonrakiSorumlu?.UygunSalonlariAra(kriter);
			}
		}
	}
	//3. Halka
	public class TurkiyeRezervasyon : ToplantiSalonRezervasyon
	{
		protected override void ara(object sender, AramaKriteri kriter)
		{
			if (kriter.Ulke == "Türkiye")
			{
				Console.WriteLine("Türkiye için uygun salonlar aranıyor");
			}
		}
	}
}
