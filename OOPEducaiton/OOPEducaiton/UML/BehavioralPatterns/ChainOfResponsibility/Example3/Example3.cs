using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEducaiton.UML.BehavioralPatterns.ChainOfResponsibility.Example3
{
	// Bu senaryoda, Chain of Responsibility deseni kullanılarak
	// haber paylaşma işlemi gerçekleştirildi. Her kullanıcı tipinin
	// farklı kontrolleri gerçekleştirdiği ve haberin yayınlanmasına
	// izin verdiği bir zincir oluşturuldu. Bu sayede haberlerin doğru
	// şekilde yayınlanması ve gereksiz kontrollerin atlanması engellendi.
	// Haber sınıfı
	public class News
	{
		public string Title { get; set; }
		public string Content { get; set; }
	}

	// Handler soyut sınıfı
	public abstract class NewsHandler
	{
		protected NewsHandler nextHandler;

		public void SetNextHandler(NewsHandler handler)
		{
			nextHandler = handler;
		}

		public abstract bool PublishNews(News news);
	}

	// Kullanıcı Handler sınıfı
	public class UserHandler : NewsHandler
	{
		private bool _loggedIn { get; set; }
		public UserHandler(bool loggedIn)
        {
            this._loggedIn = loggedIn;
        }
		public override bool PublishNews(News news)
		{
			// Kullanıcı giriş yapmış mı kontrolü
			if (UserLoggedIn())
			{
				if (nextHandler != null)
				{
					return nextHandler.PublishNews(news);
				}
				else
				{
					// Zincirin sonuna gelindi, haber onaylandı
					Console.WriteLine($"{this.GetType().Name} diyor ki:  Haber başarıyla yayınlandı.");
					return true;
				}
			}
			else
			{
				// Kullanıcı giriş yapmamış, haber reddedildi
				Console.WriteLine($"{this.GetType().Name} diyor ki: Haber paylaşma işlemi reddedildi. Giriş yapmalısınız.");
				return false;
			}
		}

		private bool UserLoggedIn()
		{
			// Kullanıcı giriş yapmış mı kontrolü
			// Gerçek bir giriş kontrolü yapılabilir
			return this._loggedIn;
		}
	}

	// Editör Handler sınıfı
	public class EditorHandler : NewsHandler
	{
		public override bool PublishNews(News news)
		{
			// Haber başlık ve içeriği kontrolü
			if (!string.IsNullOrEmpty(news.Title) && !string.IsNullOrEmpty(news.Content))
			{
				if (nextHandler != null)
				{
					return nextHandler.PublishNews(news);
				}
				else
				{
					// Zincirin sonuna gelindi, haber onaylandı
					Console.WriteLine($"{this.GetType().Name} diyor ki: Haber başarıyla yayınlandı.");
					return true;
				}
			}
			else
			{
				// Haber eksik başlık veya içeriğe sahip, haber reddedildi
				Console.WriteLine($"{this.GetType().Name} diyor ki: Haber paylaşma işlemi reddedildi. Başlık ve içerik gereklidir.");
				return false;
			}
		}
	}

	// Yönetici Handler sınıfı
	public class AdminHandler : NewsHandler
	{
		public override bool PublishNews(News news)
		{
			// Uygunsuz içerik kontrolü
			if (!ContainsInappropriateContent(news.Content))
			{
				if (nextHandler != null)
				{
					return nextHandler.PublishNews(news);
				}
				else
				{
					// Zincirin sonuna gelindi, haber onaylandı
					Console.WriteLine($"{this.GetType().Name} diyor ki: Haber başarıyla yayınlandı.");
					return true;
				}
			}
			else
			{
				// Haber uygunsuz içerik barındırıyor, haber reddedildi
				Console.WriteLine($"{this.GetType().Name} diyor ki: Haber paylaşma işlemi reddedildi. Haber uygunsuz içerik barındırıyor.");
				return false;
			}
		}

		private bool ContainsInappropriateContent(string content)
		{
			// Uygunsuz içerik kontrolü
			// Gerçek bir kontrol yapılabilir, örneğin kara liste kontrolü vb.
			return false;
		}
	}

	public class CoRExample3Runner
	{
        public CoRExample3Runner()
        {
			UserHandler userHandler = new UserHandler(true);
			EditorHandler editorHandler = new EditorHandler();
			AdminHandler adminHandler = new AdminHandler();

			userHandler.SetNextHandler(editorHandler);
			editorHandler.SetNextHandler(adminHandler);

			userHandler.PublishNews(new News());

			userHandler.PublishNews(new News
			{
				Title = "Asgari Ücrete zam geldi!!!",
				Content = "Zam geldi."
			});

			UserHandler anotherHandler = new UserHandler(false);
			anotherHandler.PublishNews(new News());
			anotherHandler = new UserHandler(true);
			anotherHandler.PublishNews(new News());
		}
	}
}
