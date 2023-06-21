using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEducaiton.UML.StructuralPatterns.ProxyPattern.Example3
{
	// Bu senaryoda, Proxy tasarım deseni mesaj gönderme işlemlerinin
	// kontrolünü sağlar. Proxy sınıfı, kullanıcının yetkilendirme
	// durumunu kontrol eder ve gerektiğinde gerçek mesaj göndericiye
	// başvurarak mesajı gönderir. Bu şekilde, kullanıcıların belirli
	// koşullar altında mesaj gönderme yetkisini kontrol ederken, gerçek
	// mesaj gönderme işlemlerini gerçekleştirirsiniz.

	// Mesaj gönderici arayüzü
	public interface IMessageSender
	{
		void SendMessage(string message, string recipient);
	}

	// Gerçek mesaj gönderici
	public class MessageSender : IMessageSender
	{
		public void SendMessage(string message, string recipient)
		{
			Console.WriteLine($"Mesaj gönderildi: '{message}' -> {recipient}");
		}
	}

	// Mesaj gönderici Proxy sınıfı
	public class MessageSenderProxy : IMessageSender
	{
		private IMessageSender messageSender;
		private string[] authorizedRecipients; // Yetkilendirilmiş alıcılar

		public MessageSenderProxy()
		{
			messageSender = new MessageSender();
			authorizedRecipients = new string[] { "admin@example.com", "vipuser@example.com" };
		}

		public void SendMessage(string message, string recipient)
		{
			// Kullanıcının yetkilendirilmiş alıcılardan biri olup olmadığını kontrol et
			if (IsAuthorizedRecipient(recipient))
			{
				messageSender.SendMessage(message, recipient);
			}
			else
			{
				Console.WriteLine("Hata: Yetkilendirilmemiş alıcıya mesaj gönderme girişimi.");
			}
		}

		private bool IsAuthorizedRecipient(string recipient)
		{
			// Yetkilendirilmiş alıcılara sahip mi kontrol et
			return Array.Exists(authorizedRecipients, r => r == recipient);
		}
	}

	// İstemci kodu
	public class Client
	{
		private IMessageSender messageSender;

		public Client()
		{
			messageSender = new MessageSenderProxy();
		}
		// İstemci, SendMessage metodu aracılığıyla mesaj gönderme
		// isteğinde bulunur. Proxy sınıfı, kullanıcının yetkilendirme
		// durumunu kontrol eder ve gerektiğinde gerçek mesaj göndericiye
		// başvurarak mesajı gönderir.
		public void SendMessage(string message, string recipient)
		{
			messageSender.SendMessage(message, recipient);
		}
	}
	// Bu örnekte, IMessageSender arayüzü mesaj gönderme işlevini tanımlar.
	// MessageSender sınıfı gerçek mesaj gönderme işlemini gerçekleştirir.
	// MessageSenderProxy sınıfı, mesaj gönderme işlemini kontrol eder ve
	// yetkilendirme durumunu kontrol eder. Client sınıfı ise Proxy sınıfını
	// kullanarak mesaj gönderme işlemini gerçekleştirir.
	public class ProxyExample3Runner
	{
        public ProxyExample3Runner()
        {
			Client client = new Client();

			// Yetkilendirilmiş bir alıcıya mesaj gönderme
			client.SendMessage("Merhaba!", "admin@example.com");

			// Yetkilendirilmemiş bir alıcıya mesaj gönderme
			client.SendMessage("Gizli bilgiler", "user@example.com");
		}
    }
}
