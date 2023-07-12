using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEducaiton.UML.BehavioralPatterns.HookMethod.Example1
{
	// Ana sınıf: Oyun
	public abstract class Game
	{
		public void Play()
		{
			Initialize();
			StartGame();
			PlayGame();
			EndGame();
		}

		protected abstract void Initialize();

		protected abstract void StartGame();

		protected virtual void PlayGame()
		{
			// Boş implementasyon (isteğe bağlı olarak alt sınıflar tarafından geçersiz kılınabilir)
		}

		protected abstract void EndGame();
	}

	// Alt sınıf: Gölge Savaşçısı
	public class ShadowWarrior : Game
	{
		protected override void Initialize()
		{
			Console.WriteLine("Gölge Savaşçısı: Oyun başlatılıyor...");
		}

		protected override void StartGame()
		{
			Console.WriteLine("Gölge Savaşçısı: Görevi kabul edildi.");
		}

		protected override void PlayGame()
		{
			Console.WriteLine("Gölge Savaşçısı: Özel saldırı kullanılıyor!");
		}

		protected override void EndGame()
		{
			Console.WriteLine("Gölge Savaşçısı: Görev tamamlandı. Oyun sona eriyor.");
		}
	}

	// Alt sınıf: Savaş Büyücüsü
	public class BattleWizard : Game
	{
		protected override void Initialize()
		{
			Console.WriteLine("Savaş Büyücüsü: Oyun başlatılıyor...");
		}

		protected override void StartGame()
		{
			Console.WriteLine("Savaş Büyücüsü: Zindanı keşfe çıkıyoruz.");
		}

		protected override void EndGame()
		{
			Console.WriteLine("Savaş Büyücüsü: Zindanı temizledik. Oyun sona eriyor.");
		}
	}

	// Senaryo uygulaması
	public class HookMethodExample1Runner
	{
		public static void Main()
		{
			Console.WriteLine("Gölge Savaşçısı oyunu başlatılıyor...");
			Game shadowWarriorGame = new ShadowWarrior();
			shadowWarriorGame.Play();

			Console.WriteLine();

			Console.WriteLine("Savaş Büyücüsü oyunu başlatılıyor...");
			Game battleWizardGame = new BattleWizard();
			battleWizardGame.Play();
		}
	}
}
