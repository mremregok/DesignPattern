using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEducaiton.UML.FactoryMethod.Example1
{
    //CONCRETE PRODUCTS (GAMES)

    //Product abstract veya interface
    public interface IGame
    {
        void Platform();
    }


    //Concrete Product
    public class AtariGame : IGame
    {
        public void Platform()
        {
            Console.WriteLine("Bu oyun ATARİ platformunda çalışmaktadır.");
        }
    }

    //Concrete Product
    public class PcGame : IGame
    {
        public void Platform()
        {
            Console.WriteLine("Bu oyun PC platformunda çalışmaktadır.");
        }
    }

    //Concrete Product
    public class PlayStationGame : IGame
    {
        public void Platform()
        {
            Console.WriteLine("Bu oyun Play Station platformunda çalışmaktadır.");
        }
    }
}
