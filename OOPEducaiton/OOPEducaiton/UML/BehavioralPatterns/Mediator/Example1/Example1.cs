using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEducaiton.UML.BehavioralPatterns.Mediator.Example1
{
	// Mediator (Ortaklaşa) arayüzü
	public interface IChatMediator
	{
		void SendMessage(string message, IUser user);
		void AddUser(IUser user);
	}

	// ConcreteMediator (Somut Ortaklaşa) sınıfı
	public class ChatMediator : IChatMediator
	{
		private List<IUser> users = new List<IUser>();

		public void AddUser(IUser user)
		{
			users.Add(user);
		}

		public void SendMessage(string message, IUser sender)
		{
			foreach (var user in users)
			{
				if (user != sender)
				{
					user.ReceiveMessage(message);
				}
			}
		}
	}

	// Colleague (İş Arkadaşı) arayüzü
	public interface IUser
	{
		void SendMessage(string message);
		void ReceiveMessage(string message);
	}

	// ConcreteColleague (Somut İş Arkadaşı) sınıfı
	public class ChatUser : IUser
	{
		private IChatMediator mediator;
		private string name;

		public ChatUser(IChatMediator mediator, string name)
		{
			this.mediator = mediator;
			this.name = name;
		}

		public void SendMessage(string message)
		{
			Console.WriteLine(name + " is sending a message: " + message);
			mediator.SendMessage(message, this);
		}

		public void ReceiveMessage(string message)
		{
			Console.WriteLine(name + " received a message: " + message);
		}
	}

	// Senaryo uygulaması
	public class MediatorExample1Runner
	{
		public static void Main()
		{
			// Mediator oluştur
			IChatMediator mediator = new ChatMediator();

			// Kullanıcıları oluştur
			IUser user1 = new ChatUser(mediator, "User 1");
			IUser user2 = new ChatUser(mediator, "User 2");
			IUser user3 = new ChatUser(mediator, "User 3");

			// Kullanıcıları ekle
			mediator.AddUser(user1);
			mediator.AddUser(user2);
			mediator.AddUser(user3);

			// Mesaj gönder
			user1.SendMessage("Hello, everyone!");

			// Çıktı:
			// User 1 is sending a message: Hello, everyone!
			// User 2 received a message: Hello, everyone!
			// User 3 received a message: Hello, everyone!
		}
	}
}
