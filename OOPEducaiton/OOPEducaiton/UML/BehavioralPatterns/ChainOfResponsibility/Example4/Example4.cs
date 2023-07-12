using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEducaiton.UML.BehavioralPatterns.ChainOfResponsibility.Example4
{
	public interface ISirket
	{
		public string Name { get; set; }
		public int SirketId { get; set; }
		public ISirket Successor { get; set; }
		public Personel GetPersonel(string TC);
		public void SetSuccessor(ISirket successor);
	}

	public class Personel
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public string TC { get; set; }
		public int OzlukId { get; set; }
	}

	public class Sirket : ISirket
	{
		private List<Personel> _personeller { get; set; }
		public string Name { get; set; }
		public int SirketId { get; set; }
		public ISirket Successor { get; set; }

		public Sirket(List<Personel> personeller, string name, int id)
        {
            this._personeller = personeller;
			this.Name = name;
			this.SirketId = id;
        }

        public Personel GetPersonel(string TC)
		{
			Console.WriteLine($"Şu anki bakılan şirket: {this.Name}, Şirket ID: {this.SirketId}");
			foreach(var personel in _personeller)
			{
				if(personel.TC == TC)
				{
					Console.WriteLine($"Aranan personelin bulunduğu şirket: {this.Name}, Şirket ID: {this.SirketId}");
					return personel;
				}
					
			}
			Console.WriteLine($"Zincirin bu halkasında aranan " +
				$"kişi bulunamadığı için, bir sonraki halkaya " +
				$"geç. Geçilen Şirket: {this.Successor?.Name}");

			var returnPersonel = Successor?.GetPersonel(TC);

			return returnPersonel;
		}

		public void SetSuccessor(ISirket successor)
		{
			this.Successor = successor;
		}
	}

	public class CoRExample4Runner
	{
		public static Personel Main(string TC)
		{
			ISirket iztek = new Sirket(new List<Personel>
			{
				new Personel
				{
					Name = "Emre",
					Surname = "Gok",
					TC = "152",
					OzlukId = 1
				}
			}, "İztek", 1);

			ISirket izelman = new Sirket(new List<Personel>
			{
				new Personel
				{
					Name = "Umut",
					Surname = "Akter",
					TC = "555",
					OzlukId = 2
				}
			}, "İzelman", 2);

			ISirket izbeton = new Sirket(new List<Personel>
			{
				new Personel
				{
					Name = "Cihan",
					Surname = "Dürmüş",
					TC = "444",
					OzlukId = 3
				}
			}, "izbeton", 3);

			iztek.SetSuccessor(izelman);
			izelman.SetSuccessor(izbeton);

			var personel = iztek.GetPersonel(TC);

			if (personel == null) Console.WriteLine("Personel bulunamadı...");

			return personel;
		}
	}
}
