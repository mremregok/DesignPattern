using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEducaiton.UML.FactoryMethod.Example2
{
    internal class GameGenerator
    {
        IGame game;

        public GameGenerator(Oyunlar oyunTipi)
        {
            game = new GameCreator().GameFactory(oyunTipi);
        }

        public void StartGame()
        {
            game.Platform();
        }
    }
}
