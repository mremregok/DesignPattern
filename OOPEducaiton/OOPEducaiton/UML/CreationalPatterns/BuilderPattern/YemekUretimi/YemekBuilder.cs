using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEducaiton.UML.CreationalPatterns.BuilderPattern.YemekUretimi
{
	internal abstract class YemekBuilder
	{
		protected Yemek yemek;

		public Yemek Yemek { get {  return yemek; } }

		public abstract void SetTuz();
		public abstract void SetYemekAdi();
		public abstract void SetYemekTipi();
	}
}
