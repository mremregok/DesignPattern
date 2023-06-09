using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEducaiton.UML.CreationalPatterns.BuilderPattern.YemekUretimi
{
	internal class EtliYemekConcreteBuilder : YemekBuilder
	{
		public EtliYemekConcreteBuilder()
		{
			yemek = new Yemek();
		}
		public override void SetTuz() => yemek.Tuz = 65;

		public override void SetYemekAdi() => yemek.YemekAdi = "Etli Pilav";

		public override void SetYemekTipi() => yemek.YemekTipi = YemekTipi.Etli;
	}
}
