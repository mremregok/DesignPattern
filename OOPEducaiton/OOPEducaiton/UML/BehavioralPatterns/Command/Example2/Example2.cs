using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEducaiton.UML.BehavioralPatterns.Command.Example2
{
	// İlk olarak, Command arayüzünü veya soyut sınıfını tanımlıyoruz.
	// Bu arayüzde veya sınıfta, komutu temsil edecek bir "Execute"
	// metodu bulunmalıdır.
	public interface ICommand
	{
		void Execute();
	}
	// Ardından, Concrete Command sınıflarını oluşturuyoruz. Her bir sınıf,
	// belirli bir işlemi gerçekleştirecek ve gerekirse alıcı nesneleri kullanacak.
	public class WithdrawCommand : ICommand
	{
		private BankAccount account;
		private decimal amount;

		public WithdrawCommand(BankAccount account, decimal amount)
		{
			this.account = account;
			this.amount = amount;
		}

		public void Execute()
		{
			account.Withdraw(amount);
		}
	}

	public class DepositCommand : ICommand
	{
		private BankAccount account;
		private decimal amount;

		public DepositCommand(BankAccount account, decimal amount)
		{
			this.account = account;
			this.amount = amount;
		}

		public void Execute()
		{
			account.Deposit(amount);
		}
	}

	// Diğer Concrete Command sınıfları (hesap özeti alma, transfer yapma vb.) da burada tanımlanabilir.

	// Receiver sınıfını oluşturuyoruz. Bu sınıf, gerçekleştirilecek işlemleri temsil eder.
	public class BankAccount
	{
		public string AccountNumber { get; set; }
		public decimal Balance { get; set; }

		public void Withdraw(decimal amount)
		{
			if (Balance >= amount)
			{
				Balance -= amount;
				Console.WriteLine("Para çekme işlemi gerçekleştirildi. Güncel bakiye: " + Balance);
			}
			else
			{
				Console.WriteLine("Yetersiz bakiye. Para çekme işlemi gerçekleştirilemedi.");
			}
		}

		public void Deposit(decimal amount)
		{
			Balance += amount;
			Console.WriteLine("Para yatırma işlemi gerçekleştirildi. Güncel bakiye: " + Balance);
		}

		// Diğer işlemler de burada tanımlanabilir.
	}

	// Diğer Receiver sınıfları (hesap özeti alma, transfer yapma vb.) da burada tanımlanabilir.

	// Son olarak, Invoker sınıfını oluşturuyoruz. Bu sınıf, komutu yürüten nesneyi temsil eder. 
	public class ATM
	{
		private ICommand command;

		public void SetCommand(ICommand command)
		{
			this.command = command;
		}

		public void ExecuteTransaction()
		{
			command.Execute();
		}
	}
	// Bu senaryoda, Command tasarım deseni kullanılarak banka işlemleri temsil edildi.
	// Kullanıcı, ATM üzerinden seçtiği işlemi Concrete Command sınıfları aracılığıyla
	// gerçekleştirir. Bu desen sayesinde yeni işlemler eklemek veya mevcut işlemleri
	// değiştirmek kolay olur ve sistem esnek bir şekilde genişletilebilir.
	public class CommandExample2Runner
	{
        public CommandExample2Runner()
        {
			// Örnek kullanım
			BankAccount account = new BankAccount { AccountNumber = "12345678", Balance = 1000 };
			ATM atm = new ATM();
			ICommand command = new WithdrawCommand(account, 500);
			atm.SetCommand(command);
			atm.ExecuteTransaction();
			atm.ExecuteTransaction();
			atm.ExecuteTransaction();
		}
    }
}
