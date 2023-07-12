using System;
using System.Collections.Generic;

namespace OOPEducaiton.UML.BehavioralPatterns.Observer.Example1
{
    // Subject (Gözlemciye Konu Olan) sınıfı
    class MusicPlayer
    {
        private string currentSong;
        private bool isPlaying;

        private List<IMusicObserver> observers = new List<IMusicObserver>();

        public void Attach(IMusicObserver observer)
        {
            observers.Add(observer);
        }

        public void Detach(IMusicObserver observer)
        {
            observers.Remove(observer);
        }

        public void PlaySong(string song)
        {
            currentSong = song;
            isPlaying = true;
            NotifyObservers();
        }

        public void Pause()
        {
            isPlaying = false;
            NotifyObservers();
        }

        public void Resume()
        {
            isPlaying = true;
            NotifyObservers();
        }

        private void NotifyObservers()
        {
            foreach (var observer in observers)
            {
                observer.Update(currentSong, isPlaying);
            }
        }
    }

    // Observer (Gözlemci) arabirimi
    interface IMusicObserver
    {
        void Update(string song, bool isPlaying);
    }

    // Observer (Gözlemci) sınıfı - Ekran (Screen)
    class Screen : IMusicObserver
    {
        public void Update(string song, bool isPlaying)
        {
            Console.WriteLine("Ekran: Şarkı: " + song + ", Oynatılıyor: " + isPlaying);
        }
    }

    // Observer (Gözlemci) sınıfı - Ses Kontrolü (VolumeControl)
    class VolumeControl : IMusicObserver
    {
        public void Update(string song, bool isPlaying)
        {
            if (isPlaying)
            {
                Console.WriteLine("Ses Kontrolü: Şarkı çalıyor, ses seviyesi ayarlanıyor...");
            }
            else
            {
                Console.WriteLine("Ses Kontrolü: Şarkı duraklatıldı, ses seviyesi sıfırlandı.");
            }
        }
    }

    // Kullanım
    public class ObserverExample1Runner
    {
        public static void Main()
        {
            MusicPlayer musicPlayer = new MusicPlayer();

            // Observer (Gözlemci) nesneleri oluşturuluyor
            Screen screen = new Screen();
            VolumeControl volumeControl = new VolumeControl();

            // Observer (Gözlemci) nesneleri Subject (Gözlemciye Konu Olan) nesnesine kaydediliyor
            musicPlayer.Attach(screen);
            musicPlayer.Attach(volumeControl);

            // Şarkı çalınıyor
            musicPlayer.PlaySong("Dream On");

            // Şarkı duraklatılıyor
            musicPlayer.Pause();

            // Şarkı devam ettiriliyor
            musicPlayer.Resume();

            // Observer (Gözlemci) nesneleri Subject (Gözlemciye Konu Olan) nesnesinden ayrılıyor
            musicPlayer.Detach(volumeControl);

            // Yeni şarkı çalınıyor
            musicPlayer.PlaySong("Bohemian Rhapsody");

            Console.ReadLine();
        }
    }
}
