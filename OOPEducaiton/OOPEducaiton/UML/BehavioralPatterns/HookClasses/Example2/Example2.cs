using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEducaiton.UML.BehavioralPatterns.HookClasses.Example2
{
	// Ana sınıf
	public abstract class UserAuthentication
	{
		public void Authenticate(string username, string password)
		{
			if (ValidateUser(username, password))
			{
				Console.WriteLine("Kullanıcı doğrulandı. Kaynaklara erişim sağlanabilir.");
				AuthorizeUser(username);
			}
			else
			{
				Console.WriteLine("Kullanıcı doğrulanamadı. Erişim reddedildi.");
			}
		}

		protected abstract bool ValidateUser(string username, string password);

		protected virtual void AuthorizeUser(string username)
		{
			// Kancaya varsayılan bir uygulama sağlanabilir.
			Console.WriteLine("Varsayılan erişim yetkilendirmesi uygulandı.");
		}
	}

	// Alt sınıf - Yetkilendirme gerektirmeyen kullanıcı
	public class GuestUserAuthentication : UserAuthentication
	{
		protected override bool ValidateUser(string username, string password)
		{
			// Doğrulama süreci
			// Yetkilendirme gerektirmeyen kullanıcıların doğrulama süreci burada uygulanır.
			return true;
		}
	}

	// Alt sınıf - Yetkilendirme gerektiren kullanıcı
	public class AuthenticatedUserAuthentication : UserAuthentication
	{
		protected override bool ValidateUser(string username, string password)
		{
			// Doğrulama süreci
			// Yetkilendirme gerektiren kullanıcıların doğrulama süreci burada uygulanır.

			return username == "Emre" && password == "Gok123*";
		}

		protected override void AuthorizeUser(string username)
		{
			// Kancanın özelleştirilmiş uygulaması
			Console.WriteLine("Özelleştirilmiş erişim yetkilendirmesi uygulandı.");
		}
	}

	// Kullanım
	public class HookClassesExample2Runner
	{
		public static void Main()
		{
			UserAuthentication guestUser = new GuestUserAuthentication();
			guestUser.Authenticate("guestuser", "password123");

			Console.WriteLine();

			UserAuthentication authenticatedUser = new AuthenticatedUserAuthentication();
			authenticatedUser.Authenticate("Emre", "Gok123*");
			authenticatedUser.Authenticate("Umut", "akter1234");
		}
	}
}
