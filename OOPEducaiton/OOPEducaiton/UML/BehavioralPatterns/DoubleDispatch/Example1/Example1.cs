using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace OOPEducaiton.UML.BehavioralPatterns.DoubleDispatch.Example1
{
	// Karakterler arasındaki etkileşimleri tanımlayan bir arayüz
	public interface ICharacterInteraction
	{
		void Interact(Warrior warrior);
		void Interact(Mage mage);
	}

	// Savaşçı sınıfı
	public class Warrior : ICharacterInteraction
	{
		public void Interact(Warrior warrior)
		{
			Console.WriteLine("Savaşçı, başka bir savaşçıyla etkileşime geçti.");
		}

		public void Interact(Mage mage)
		{
			Console.WriteLine("Savaşçı, bir büyücüyle etkileşime geçti.");
		}
	}

	// Büyücü sınıfı
	public class Mage : ICharacterInteraction
	{
		public void Interact(Warrior warrior)
		{
			Console.WriteLine("Büyücü, bir savaşçıyla etkileşime geçti.");
		}

		public void Interact(Mage mage)
		{
			Console.WriteLine("Büyücü, başka bir büyücüyle etkileşime geçti.");
		}
	}

	// Senaryo
	// Bu örnek, Double Dispatch desenini kullanarak farklı karakter türlerinin
	// birbirleriyle etkileşime geçebildiği bir oyun senaryosunu temsil etmektedir.
	public class GameScenario
	{
		public static void Main()
		{
			Warrior warrior = new Warrior();
			Mage mage = new Mage();

			warrior.Interact(mage); // Savaşçı, bir büyücüyle etkileşime geçti.
			mage.Interact(warrior); // Büyücü, bir savaşçıyla etkileşime geçti.
			warrior.Interact(warrior); // Savaşçı, başka bir savaşçıyla etkileşime geçti.
			mage.Interact(mage); // Büyücü, başka bir büyücüyle etkileşime geçti.
		}
	}

	public class DoubleDispatchExample1Runner
	{
        public DoubleDispatchExample1Runner()
        {
			GameScenario.Main();

			Console.ReadKey();
        }
    }
}
