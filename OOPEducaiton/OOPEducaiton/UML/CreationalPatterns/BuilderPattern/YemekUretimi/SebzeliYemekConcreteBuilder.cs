using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEducaiton.UML.CreationalPatterns.BuilderPattern.YemekUretimi
{
	internal class SebzeliYemekConcreteBuilder : YemekBuilder
	{
		public SebzeliYemekConcreteBuilder()
		{
			yemek = new Yemek();
		}
		public override void SetTuz() => yemek.Tuz = 15;

		public override void SetYemekAdi() => yemek.YemekAdi = "Pırasa";

		public override void SetYemekTipi() => yemek.YemekTipi = YemekTipi.Sebzeli;
	}
}
