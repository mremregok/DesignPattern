using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEducaiton.UML.BehavioralPatterns.Iterator.Example1
{
	// Iterator (Yineleyici) arayüzü
	public interface IIterator
	{
		bool HasNext();
		object Next();
	}

	// Aggregate (Koleksiyon) arayüzü
	public interface IPlaylist
	{
		IIterator CreateIterator();
	}

	// ConcreteAggregate (Somut Koleksiyon) sınıfı

	// "Playlist" sınıfı, çalma listesini temsil eder ve şarkıların
	// saklandığı bir koleksiyon içerir. "IPlaylist" arayüzü, iterator
	// nesnesinin oluşturulması için gerekli olan createIterator() metodu tanımlar.
	public class Playlist : IPlaylist
	{
		private ArrayList songs = new ArrayList();

		public void AddSong(string song)
		{
			songs.Add(song);
		}

		public IIterator CreateIterator()
		{
			return new PlaylistIterator(this);
		}

		public int Count
		{
			get { return songs.Count; }
		}

		public object GetSong(int index)
		{
			return songs[index];
		}
	}

	// ConcreteIterator (Somut Yineleyici) sınıfı

	// "PlaylistIterator" sınıfı, IIterator arayüzünü uygular ve çalma
	// listesindeki şarkılara sırayla erişim sağlar. "IIterator" arayüzü,
	// hasNext() metoduyla bir sonraki şarkının olup olmadığını kontrol
	// eder ve Next() metoduyla bir sonraki şarkıya geçer.
	public class PlaylistIterator : IIterator
	{
		private Playlist playlist;
		private int currentIndex = 0;

		public PlaylistIterator(Playlist playlist)
		{
			this.playlist = playlist;
		}

		public bool HasNext()
		{
			return currentIndex < playlist.Count;
		}

		public object Next()
		{
			object song = playlist.GetSong(currentIndex);
			currentIndex++;
			return song;
		}
	}

	// Senaryo uygulaması

	// Senaryo uygulamasında, çalma listesi oluşturulur ve şarkılar eklenir.
	// Ardından, çalma listesinden bir iterator oluşturulur ve while döngüsü
	// kullanılarak şarkılara sırayla erişim sağlanır. Her bir şarkı ekrana yazdırılır.
	public class IteratorExample1Runner
	{
		public static void Main()
		{
			// Çalma listesi oluştur
			Playlist playlist = new Playlist();
			playlist.AddSong("Song 1");
			playlist.AddSong("Song 2");
			playlist.AddSong("Song 3");
			playlist.AddSong("Song 4");
			playlist.AddSong("Song 5");

			// Iterator oluştur
			IIterator iterator = playlist.CreateIterator();

			// Şarkılara erişim sağla
			while (iterator.HasNext())
			{
				object song = iterator.Next();
				Console.WriteLine("Çalıyor: " + song);
			}
		}
	}

}
