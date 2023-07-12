using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEducaiton.UML.BehavioralPatterns.State.Example3
{
    //State
    abstract class MusicPlayerState
    {
        public abstract void PlayMusic();
        public abstract void StopMusic();
    }

    //Context
    class MusicPlayer
    {
        MusicPlayerState state;
        MusicPlayerState play;
        MusicPlayerState stop;
        public MusicPlayer()
        {
            play = new Play(this);
            stop = new Stop(this);
            state = play;
        }

        public void SetPlay()
            => state = play;
        public void SetStop()
            => state = stop;

        public void Play()
            => state.PlayMusic();
        public void Stop()
            => state.StopMusic();
    }

    //Concrete State
    class Play : MusicPlayerState
    {
        MusicPlayer _context;
        public Play(MusicPlayer context)
            => _context = context;

        public override void PlayMusic()
            => Console.WriteLine("Zaten müzik çalmaktadır!");
        public override void StopMusic()
        {
            Console.WriteLine("Müzik durdurulmuştur.");
            _context.SetStop();
        }
    }

    //Concrete State
    class Stop : MusicPlayerState
    {
        MusicPlayer _context;
        public Stop(MusicPlayer context)
            => _context = context;

        public override void PlayMusic()
        {
            Console.WriteLine("Müzik başlatılmıştır.");
            _context.SetPlay();
        }
        public override void StopMusic()
            => Console.WriteLine("Zaten müzik durmaktadır!");
    }

    public class StateExample3Runner
    {
        public static void Main()
        {
            MusicPlayer musicPlayer = new MusicPlayer();
            musicPlayer.Play();
            musicPlayer.Stop();
            Console.WriteLine("*******");
            musicPlayer.Stop();
            musicPlayer.Play();
            Console.WriteLine("*******");
            musicPlayer.Stop();
            Console.WriteLine("*******");
            musicPlayer.Play();
            musicPlayer.Stop();
        }
    }
}
