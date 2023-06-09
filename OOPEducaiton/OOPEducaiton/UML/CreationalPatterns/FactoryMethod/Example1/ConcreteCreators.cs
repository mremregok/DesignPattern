using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEducaiton.UML.FactoryMethod.Example1
{
    //CONCRETE CREATORS (CREATOR GAMES)

    public interface IGameCreator
    {
        //Factory Method
        IGame CreateGame();
    }

    //Concrete Creator Atari
    public class AtariGameCreator : IGameCreator
    {
        public IGame CreateGame()
        {
            return new AtariGame();
        }
    }

    //Concrete Creator PcGame
    public class PcGameCreator : IGameCreator
    {
        public IGame CreateGame()
        {
            return new PcGame();
        }
    }

    //Concrete Creator PlayStation
    public class PlayStationGameCreator : IGameCreator
    {
        public IGame CreateGame()
        {
            return new PlayStationGame();
        }
    }
}
