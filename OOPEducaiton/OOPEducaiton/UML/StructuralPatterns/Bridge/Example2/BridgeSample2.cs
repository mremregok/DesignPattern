using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEducaiton.UML.StructuralPatterns.Bridge.Example2
{
	// Soyutlama, iki sınıf hiyerarşisinin "kontrol" kısmı için arayüzü tanımlar.
	// Uygulama hiyerarşisindeki bir nesneye referans tutar
	// ve tüm gerçek işi bu nesneye devreder.
	abstract class Abstraction
	{
		protected IBanka _banka;

		public Abstraction(IBanka banka)
		{
			this._banka = banka;
		}

		public virtual string Deposit(double amount)
		{
			return "Soyut sınıfın operasyonu: \n" +
				_banka.DepositMoney(amount);
		}
	}

	class Operator : Abstraction
	{
		public Operator(IBanka banka) : base(banka)
		{
			this._banka = banka;
		}
	}

	// Uygulama sınıflarını değiştirmeden soyutlamayı genişletebilirsiniz.
	class ExtendedAbstraction : Abstraction
	{
		public ExtendedAbstraction(IBanka banka) : base(banka)
		{
		}

		public override string Deposit(double amount)
		{
			return "Genişletilmiş soyut sınıfın operasyonu: \n" +
				base._banka.DepositMoney(amount);
		}
	}

	// IBanka, çalışacak uygulama sınıflarına arayüz sağlayacak.
	// Soyutlamanın arayüzüyle eşleşmesine gerek yoktur.
	// Hatta iki arayüz birbirinden tamamen farklı bile olabilir.
	// Genelde uygulama arayüzü basit işlemleri içerirken
	// Soyutlama arayüzü, bu basit işlemler üzerinden oluşturulan
	// karmaşık işlemleri tanımlar.
	public interface IBanka
	{
		string DepositMoney(double amount);
	}

	// Her somut uygulama, belirli bir platforma karşılık gelir ve o platformun 
	// API'sini kullanarak uygulama arayüzünü uygular.
	class Abank : IBanka
	{
		public string DepositMoney(double amount)
		{
			return $"A Bankasındaki hesabınıza {amount} TL tutarında para yatırıldı.";
		}
	}

	class Bbank : IBanka
	{
		public string DepositMoney(double amount)
		{
			return $"B Bankasındaki hesabınıza {amount} TL tutarında para yatırıldı.";
		}
	}

	class Client
	{
		// Soyutlama objesinin bir uygulama ile bağlanmasının dışında
		// Client tarafı sadece soyutlama sınıfı ile ilgilenecektir.
		// Böylelikle Client sadece soyutlama-uygulama metotlarını uygulayabilecektir.
		public void ClientCode(Abstraction abstraction)
		{
			Console.WriteLine("Bankaya ne kadar para yatırmak istersiniz?");

			double amount = Convert.ToDouble(Console.ReadLine());

			Console.Write(abstraction.Deposit(amount));
		}
	}

	class BPExample2Runner
	{
        public BPExample2Runner()
        {
			Client client = new Client();

			Abstraction abstraction;
			// Client kısmı, önceden tanımlanmış herhangi bir soyutlama-uygulama
			// kombinasyonu ile çalışabilir.
			abstraction = new Operator(new Abank());
			client.ClientCode(abstraction);

			Console.WriteLine();

			abstraction = new ExtendedAbstraction(new Bbank());
			client.ClientCode(abstraction);
		}
	}
}
