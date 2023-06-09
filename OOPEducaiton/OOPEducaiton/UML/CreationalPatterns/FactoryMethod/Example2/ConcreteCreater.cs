using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEducaiton.UML.FactoryMethod.Example2
{
    public class GameCreator
    {
        //Factory Method
        public IGame GameFactory(Oyunlar oyunTipi)
        {
            IGame game = null;
            switch (oyunTipi)
            {
                case Oyunlar.Atari: game = new AtariGame(); break;
                case Oyunlar.PC: game = new PcGame(); break;
                case Oyunlar.PlayStation: game = new PlayStationGame(); break;
            }
            return game;
        }
    }
}
