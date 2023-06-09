using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEducaiton.UML.FactoryMethod.Example1
{
    internal class GameStart<T> where T : IGameCreator, new()
    {
        private IGame game;
        private IGameCreator gameCreator;

        public GameStart()
        {
            gameCreator = new T();
            game = gameCreator.CreateGame();
        }

        public void StartGame()
        {
            game.Platform();
        }
    }
}
