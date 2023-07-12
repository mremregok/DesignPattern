using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEducaiton.UML.BehavioralPatterns.Memento.Example2
{
    // Memento class: T anında save etmek istediğimiz nesnenin
    // saklanacağı class ;hangi özellikleri saklamak istersek
    // onlara uygun propertyler tanımlamamaız yeterli olacaktır.
    class GameWorldMemento
    {
        public string Name { get; set; }
        public long Population { get; set; }
    }
    // Orginator class: Saklamak istediğimiz gerçek nesnemizin sınıfı
    class GameWorld
    {
        public string Name { get; set; }
        public long Population { get; set; }

        //Yeni bir gameworldmomento nesnesi örnekleyip ona orginator
        //classına ait nesnenin ilgili özelliklerini atar.
        public GameWorldMemento Save()
        {
            return new GameWorldMemento { Name = this.Name, Population = this.Population }; //calisma zamanındaki özelllikleri alır.
        }

        //o anda gelen orginator nesnesinin ilgili özelliklerini set eder
        public void Undo(GameWorldMemento memento)
        {
            this.Name = memento.Name;
            this.Population = memento.Population;
        }

        public override string ToString()
        {
            return String.Format("{0} dünyasında {1} insan var", Name, Population);
        }
    }
    // Caretaker class: Memento classı güvenli bir şekilde saklar
    // ama üyeleri üzerinde herhangi bir değişiklik yapmaz.
    class GameWorldCareTaker
    {
        public GameWorldMemento World { get; set; } //mementoyu döner.
    }

    class MementoExample2Runner
    {

        static void Main()
        {
            GameWorld zulu = new GameWorld { Name = "Zulu", Population = 100000 };

            Console.WriteLine(zulu.ToString());

            GameWorldCareTaker taker = new GameWorldCareTaker();
            taker.World = zulu.Save(); //zulunun o anki halini sakla

            zulu.Population += 10;
            Console.WriteLine(zulu.ToString());

            zulu.Undo(taker.World); //eski dünyayi geri yükle

            Console.WriteLine(zulu.ToString());

            Console.ReadKey();
        }

    }
}
