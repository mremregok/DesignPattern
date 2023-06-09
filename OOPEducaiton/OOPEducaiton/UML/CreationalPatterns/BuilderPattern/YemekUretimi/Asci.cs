using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEducaiton.UML.CreationalPatterns.BuilderPattern.YemekUretimi
{
	internal class Asci
	{
		public void YemekYap(YemekBuilder builder)
		{
			builder.SetTuz();
			builder.SetYemekAdi();
			builder.SetYemekTipi();
		}
	}
}
