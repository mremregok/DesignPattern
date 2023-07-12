using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOPEducaiton.UML.BehavioralPatterns.Iterator.Example1;

namespace OOPEducaiton.UML.BehavioralPatterns.Iterator.Example2
{
    struct Personel
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public string SoyAdi { get; set; }
    }

    interface IAggregate
    {
        IIterator CreateIterator();
    }

    interface IIterator
    {
        //Bir sonraki adımda eleman var mı?
        bool HasItem();
        //Bir sonraki adımdaki elemanı getir.
        Personel NextItem();
        //Mevcut elemanı getir.
        Personel CurrentItem();
    }

    class PersonelAggregate : IAggregate
    {
        List<Personel> PersonelListesi = new List<Personel>();
        public void Add(Personel Model) => PersonelListesi.Add(Model);
        public Personel GetItem(int index) => PersonelListesi[index];
        public int Count { get => PersonelListesi.Count; }
        public IIterator CreateIterator() => new PersonelIterator(this);
    }

    class PersonelIterator : IIterator
    {
        PersonelAggregate aggregate;
        int currentIndex;
        public PersonelIterator(PersonelAggregate aggregate) => this.aggregate = aggregate;
        public Personel CurrentItem() => aggregate.GetItem(currentIndex);
        public bool HasItem()
        {
            if (currentIndex < aggregate.Count)
                return true;
            return false;
        }
        public Personel NextItem()
        {
            if (HasItem())
                return aggregate.GetItem(currentIndex++);
            return new Personel();
        }
    }

    public class IteratorExample2Runner
    {
        public static void Main()
        {
            PersonelAggregate aggregate = new PersonelAggregate();
            aggregate.Add(new Personel { Id = 1, Adi = "Gençay", SoyAdi = "Yıldız" });
            aggregate.Add(new Personel { Id = 2, Adi = "Ahmet", SoyAdi = "Çakmak" });
            aggregate.Add(new Personel { Id = 3, Adi = "Mehmet", SoyAdi = "Aslıbay" });
            aggregate.Add(new Personel { Id = 4, Adi = "Ayşe", SoyAdi = "Solmaz" });
            aggregate.Add(new Personel { Id = 5, Adi = "Fatma", SoyAdi = "Nurgül" });

            IIterator iterasyon = aggregate.CreateIterator();
            while (iterasyon.HasItem())
            {
                Console.WriteLine($"ID : {iterasyon.CurrentItem().Id}\nAdı : {iterasyon.CurrentItem().Adi}\nSoyadı : {iterasyon.CurrentItem().SoyAdi}\n*****");
                iterasyon.NextItem();
            }

            Console.Read();
        }
    }
}
