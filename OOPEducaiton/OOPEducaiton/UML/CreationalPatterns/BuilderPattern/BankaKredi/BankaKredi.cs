using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOPEducaiton.UML.StructuralPatterns.FacadePattern;

namespace OOPEducaiton.UML.CreationalPatterns.BuilderPattern.BankaKredi
{
	// Builder soyut sınıfıdır.
	public abstract class KrediUretimi
	{
		protected Kredi _kredi = new Kredi();
		public Kredi kredi { get { return _kredi; } private set { } }
        public abstract void IstenenKrediOlustur(int krediMiktari);
		public abstract void VerilebilecekKrediOlustur();
		public virtual bool KaralisteyeBak(int tc)
		{
			return _kredi.KaralistedeMi = !(_kredi.OlumluMu = tc != 123);
		}
		public virtual bool DurumGetir()
		{
			return _kredi.OlumluMu;
		}
		public virtual string AciklamaDon()
		{
			if (_kredi.KaralistedeMi) _kredi.KrediAciklamasi = "Karalistede olduğunuz için kredi verilemiyor.";
			return _kredi.KrediAciklamasi;
		}
	}
	// Builder'i kullanarak işlem adımlarını tanımlayacak sınıftır.
	public class BuilderPatternBankaPersoneli
	{
		public void KrediUret(KrediUretimi uretim, int tc, int krediMiktari)
		{
			uretim.KaralisteyeBak(tc);

			if (uretim.DurumGetir())
			{
				uretim.IstenenKrediOlustur(krediMiktari);
				uretim.VerilebilecekKrediOlustur();
				Console.WriteLine(uretim.AciklamaDon());
			}
			else
			{
				Console.WriteLine(uretim.AciklamaDon());
			}
		}
    }
	// Product class
	public class Kredi
	{
		public int KrediMiktari { get; set; }
		public int TalepEdilenMiktar { get; set; }
		public bool OlumluMu { get; set; }
		public string KrediAciklamasi { get; set; }
		public bool KaralistedeMi { get; set; }
	}
	// Concrete Class
	public class TicaretKredisiUretimi : KrediUretimi
	{
		public override void IstenenKrediOlustur(int krediMiktari)
		{
			if (_kredi.OlumluMu && krediMiktari < 100000) _kredi.TalepEdilenMiktar = krediMiktari;
			else _kredi.KrediAciklamasi = "Ticari kredi istediğiniz reddedilmiştir.";
		}

		public override bool KaralisteyeBak(int tc)
		{
			return _kredi.KaralistedeMi = !(_kredi.OlumluMu = tc != 345);
		}

		public override void VerilebilecekKrediOlustur()
		{
			if (_kredi.OlumluMu) _kredi.KrediMiktari = _kredi.TalepEdilenMiktar;
		}

		public override string AciklamaDon()
		{
			if (_kredi.OlumluMu)
			{
				_kredi.KrediAciklamasi = "Ticari krediniz onaylanmıştır.";
			}
			return base.AciklamaDon();
		}
	}

	// Concrete Class
	public class BireyselKredisiUretimi : KrediUretimi
	{

		public override void IstenenKrediOlustur(int krediMiktari)
		{
			if (_kredi.OlumluMu && krediMiktari < 10000) _kredi.TalepEdilenMiktar = krediMiktari;
			else _kredi.KrediAciklamasi = "Bireysel kredi istediğiniz reddedilmiştir.";
		}

		public override void VerilebilecekKrediOlustur()
		{
			if (_kredi.OlumluMu) _kredi.KrediMiktari = _kredi.TalepEdilenMiktar - 1000;
		}

		public override string AciklamaDon()
		{
			if (_kredi.OlumluMu)
			{
				_kredi.KrediAciklamasi = $"Bireysel krediniz için {_kredi.KrediMiktari} TL miktarı onaylanmıştır.";
			}
			return base.AciklamaDon();
		}
	}
	// Concrete Class
	public class AracKredisiUretimi : KrediUretimi
	{
		public override void IstenenKrediOlustur(int krediMiktari)
		{
			if (_kredi.OlumluMu) _kredi.TalepEdilenMiktar = krediMiktari;
			else _kredi.KrediAciklamasi = "Araç kredisi istediğiniz reddedilmiştir.";
		}
		public override string AciklamaDon()
		{
			if (_kredi.OlumluMu)
			{
				_kredi.KrediAciklamasi = $"Araç krediniz için {_kredi.KrediMiktari} TL miktarı onaylanmıştır.";
			}
			return base.AciklamaDon();
		}
		public override void VerilebilecekKrediOlustur()
		{
			if (_kredi.OlumluMu) _kredi.KrediMiktari = Convert.ToInt32(Math.Round(_kredi.TalepEdilenMiktar * 0.25));
		}
	}
}
