using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEducaiton.UML.StructuralPatterns.CompositePattern.Example2
{
	public enum Birimler
	{
		DaireBaskanligi,
		GenelSekreterlik,
		GenelSekreterYardimciligi,
		Baskanlik,
		Mudurluk,
		Seflik
	}

	public abstract class Birim
	{
		public Birim(Birimler birim) 
		{
			_birimAdi = birim;
		}
		protected Birimler _birimAdi { get; set; }
		public abstract void MailGonder();
		public abstract void BirimCikart(Birim birim);

		public abstract void BirimEkle(Birim birim);
	}

	public class KompozitBirim : Birim
	{
		public KompozitBirim(Birimler birim) : base(birim)
		{
			
		}
		private List<Birim> birimler { get; set; } = new List<Birim>();

		public override void BirimCikart(Birim birim)
		{
			birimler.Remove(birim);
		}

		public override void BirimEkle(Birim birim)
		{
			birimler.Add(birim);
		}

		public override void MailGonder()
		{
			Console.WriteLine($"{_birimAdi.ToString()} biriminden mail gönderildi.");

			foreach(var birim in birimler)
			{
				birim.MailGonder();
			}
		}
	}

	public class LeafBirim : Birim
	{
        public LeafBirim(Birimler birim) : base(birim)
        {
            
        }

		public override void BirimCikart(Birim birim)
		{
			throw new NotImplementedException();
		}

		public override void BirimEkle(Birim birim)
		{
			throw new NotImplementedException();
		}

		public override void MailGonder()
		{
			Console.WriteLine($"{_birimAdi.ToString()} biriminden mail gönderildi.");
		}
	}

	public class CompositePatternExample2Runner
	{
        public CompositePatternExample2Runner()
        {
			Birim daireBaskanligi = new KompozitBirim(Birimler.DaireBaskanligi);

			Birim bilgiIslemMudurlugu = new KompozitBirim(Birimler.Mudurluk);

			Birim genelSekreterlik = new KompozitBirim(Birimler.GenelSekreterlik);

			genelSekreterlik.BirimEkle(new LeafBirim(Birimler.GenelSekreterYardimciligi));

			bilgiIslemMudurlugu.BirimEkle(genelSekreterlik);

			bilgiIslemMudurlugu.BirimEkle(new LeafBirim(Birimler.Seflik));

			daireBaskanligi.BirimEkle(bilgiIslemMudurlugu);

			daireBaskanligi.BirimEkle(new LeafBirim(Birimler.Baskanlik));

			genelSekreterlik.MailGonder();
		}
	}
}
