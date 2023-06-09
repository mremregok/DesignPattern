using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEducaiton.UML.CreationalPatterns.BuilderPattern.YemekUretimi
{
	internal class SuluYemekConcreteBuilder : YemekBuilder
	{
        public SuluYemekConcreteBuilder()
        {
            yemek = new Yemek();
        }
		public override void SetTuz() => yemek.Tuz = 75;

		public override void SetYemekAdi() => yemek.YemekAdi = "Çorba";

		public override void SetYemekTipi() => yemek.YemekTipi = YemekTipi.Sulu;
	}
}
