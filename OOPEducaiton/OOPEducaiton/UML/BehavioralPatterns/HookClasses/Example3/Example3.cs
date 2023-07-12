using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEducaiton.UML.BehavioralPatterns.HookClasses.Example3
{
	// Base Hook sınıfı
	public abstract class Hook
	{
		public abstract void Execute();
	}

	// Onboarding Hook sınıfı
	public class OnboardingHook : Hook
	{
		public override void Execute()
		{
			Console.WriteLine("Hoş geldiniz! İlk alışverişinizde %10 indirim kazanabilirsiniz.");
			// İndirim kuponu kodunu müşteriye gönderme veya kaydetme işlemleri burada gerçekleştirilebilir.
		}
	}

	// Satın Alma Hook sınıfı
	public class PurchaseHook : Hook
	{
		public override void Execute()
		{
			Console.WriteLine("Teşekkürler! Bir sonraki alışverişinizde %15 indirim kazandınız.");
			// İndirim kuponu kodunu müşteriye gönderme veya kaydetme işlemleri burada gerçekleştirilebilir.
		}
	}

	// Sepet Terk Hook sınıfı
	public class CartAbandonmentHook : Hook
	{
		public override void Execute()
		{
			Console.WriteLine("Sepetinizdeki ürünleri hala bekliyoruz! Şimdi tamamlarsanız %20 indirim kazanacaksınız.");
			// İndirim kuponu kodunu müşteriye gönderme veya kaydetme işlemleri burada gerçekleştirilebilir.
		}
	}

	// Doğum Günü Hook sınıfı
	public class BirthdayHook : Hook
	{
		public override void Execute()
		{
			Console.WriteLine("Doğum gününüz kutlu olsun! Size özel %25 indirim kazandınız.");
			// İndirim kuponu kodunu müşteriye gönderme veya kaydetme işlemleri burada gerçekleştirilebilir.
		}
	}

	// Sadakat Hook sınıfı
	public class LoyaltyHook : Hook
	{
		public override void Execute()
		{
			Console.WriteLine("Sadakat puanlarınızı kullanarak ekstra %10 indirim kazanabilirsiniz.");
			// İndirim kuponu kodunu müşteriye gönderme veya kaydetme işlemleri burada gerçekleştirilebilir.
		}
	}

	// Senaryo uygulaması
	public class HookClassesExample3Runner
	{
		public static void Main()
		{
			// Senaryo örnekleri
			Hook onboardingHook = new OnboardingHook();
			Hook purchaseHook = new PurchaseHook();
			Hook cartAbandonmentHook = new CartAbandonmentHook();
			Hook birthdayHook = new BirthdayHook();
			Hook loyaltyHook = new LoyaltyHook();

			// Senaryo adımları
			Console.WriteLine("Hoş geldiniz! Lütfen kayıt olun.");
			onboardingHook.Execute();

			Console.WriteLine("Ürün seçtiniz ve satın alma işlemini tamamladınız.");
			purchaseHook.Execute();

			Console.WriteLine("Sepetinizi terk ettiniz. Sepeti tamamlamak için tekrar davetlisiniz.");
			cartAbandonmentHook.Execute();

			Console.WriteLine("Doğum gününüz geldi! Sürpriz bir indirim sizi bekliyor.");
			birthdayHook.Execute();

			Console.WriteLine("Sadakat puanlarınızı kullanarak yeni bir indirim kazanabilirsiniz.");
			loyaltyHook.Execute();
		}
	}
}
