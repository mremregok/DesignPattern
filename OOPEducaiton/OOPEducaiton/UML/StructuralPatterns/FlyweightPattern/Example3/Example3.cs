using System;
using System.Collections.Generic;

namespace OOPEducaiton.UML.StructuralPatterns.FlyweightPattern.Example3
{
	// Flyweight arayüzü
	public interface IMusicFile
	{
		// Müzik dosyasını çalar
		void Play();

		// Müzik dosyasını belirtilen kullanıcıyla paylaşır
		void Share(string user);
	}

	// Concrete Flyweight sınıfı
	public class MusicFile : IMusicFile
	{
		private string fileName;
		private string artist;
		private string album;

		public MusicFile(string fileName, string artist, string album)
		{
			this.fileName = fileName;
			this.artist = artist;
			this.album = album;
		}

		public void Play()
		{
			Console.WriteLine($"Müzik çalınıyor: Dosya Adı: {fileName}, Sanatçı: {artist}, Albüm: {album}");
		}

		public void Share(string user)
		{
			Console.WriteLine($"Müzik paylaşılıyor: Dosya Adı: {fileName}, Sanatçı: {artist}, Albüm: {album}, Kullanıcı: {user}");
		}
	}

	// Flyweight Factory sınıfı
	public class MusicFileFactory
	{
		private Dictionary<string, IMusicFile> musicFiles;

		public MusicFileFactory()
		{
			musicFiles = new Dictionary<string, IMusicFile>();
		}

		// Müzik dosyasını havuzdan al veya oluştur
		public IMusicFile GetMusicFile(string fileName, string artist, string album)
		{
			string key = fileName + artist + album;
			if (musicFiles.ContainsKey(key))
			{
				return musicFiles[key];
			}
			else
			{
				IMusicFile musicFile = new MusicFile(fileName, artist, album);
				musicFiles.Add(key, musicFile);
				return musicFile;
			}
		}
	}

	public class FlyweightExample3Runner
	{
        public FlyweightExample3Runner()
        {
			// Müzik çalar uygulaması kullanımı

			MusicFileFactory musicFileFactory = new MusicFileFactory();

			// Müzik dosyalarını çalarken aynı dosya adı, sanatçı ve albümdeki dosyaları paylaşalım

			// İlk müzik dosyası
			IMusicFile musicFile1 = musicFileFactory.GetMusicFile("SetFireToTheRain.mp3", "Adele", "21");
			musicFile1.Play();
			musicFile1.Share("Emre");

			// İkinci müzik dosyası (aynı dosya adı, sanatçı ve albüm)
			IMusicFile musicFile2 = musicFileFactory.GetMusicFile("SetFireToTheRain.mp3", "Adele", "21");
			musicFile2.Play();
			musicFile2.Share("Burak");

			// Üçüncü müzik dosyası (farklı dosya adı, sanatçı ve albüm)
			IMusicFile musicFile3 = musicFileFactory.GetMusicFile("Poşet.mp3", "Serdar Ortaç", "Kara Kedi");
			musicFile3.Play();
			musicFile3.Share("Selim");

			// Dördüncü müzik dosyası (farklı dosya adı, sanatçı ve albüm)
			IMusicFile musicFile4 = musicFileFactory.GetMusicFile("Poşet.mp3", "Serdar Ortaç", "Kara Kedi");
			musicFile4.Play();
			musicFile4.Share("Murat");
			Console.ReadLine();
		}
    }
}
