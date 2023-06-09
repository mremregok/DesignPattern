using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEducaiton.UML.StructuralPatterns.CompositePattern
{
    /// 

    /// Askerlerin rütbeleri
    /// 

    enum Rutbeler
    {
        General,
        Albay,
        Yarbay,
        Binbaşı,
        Yüzbaşı,
        Teğmen
    }


    /// 

    /// Component sınıfı
    /// 

    abstract class Asker
    {

        protected string _isim;
        protected Rutbeler _rutbe;

        public Asker(string name, Rutbeler rank)
        {
            _isim = name;
            _rutbe = rank;
        }

        public abstract void AskerEkle(Asker soldier);
        public abstract void AskerSil(Asker soldier);
        public abstract void ExecuteOrder(); // Hem Leaf hemde Composite tipi için uygulanacak olan fonksiyon

    }


    /// 

    /// Leaf class
    /// 

    class PersonelAsker : Asker
    {

        public PersonelAsker(string name, Rutbeler rank) : base(name, rank)
        {

        }

        // Bu fonksiyonun Leaf için anlamı yoktur.
        public override void AskerEkle(Asker soldier)
        {
            throw new NotImplementedException();
        }

        // Bu fonksiyonun Leaf için anlamı yoktur.
        public override void AskerSil(Asker soldier)
        {
            throw new NotImplementedException();
        }

        public override void ExecuteOrder()
        {
            Console.WriteLine(String.Format("{0} {1}", _rutbe, _isim));
        }

    }


    /// 

    /// Composite Class
    /// 

    class KompoziteAsker : Asker
    {


        // Composite tip kendi içerisinde birden fazla Component tipi içerebilir. Bu tipleri bir koleksiyon içerisinde tutabilir.
        private List<Asker> _askerler = new List<Asker>();

        public KompoziteAsker(string name, Rutbeler rank) : base(name, rank)
        {

        }

        // Composite tipin altına bir Component eklemek için kullanılır
        public override void AskerEkle(Asker soldier)
        {
            _askerler.Add(soldier);
        }

        // Composite tipin altındaki koleksiyon içerisinden bir Component tipinin çıkartmak için kullanılır
        public override void AskerSil(Asker soldier)
        {
            _askerler.Remove(soldier);
        }

        // Önemli nokta. Composite tip içerisindeki bu operasyon, Composite tipe bağlı tüm Component'ler için gerçekleştirilir.
        public override void ExecuteOrder()
        {
            Console.WriteLine(String.Format("{0} {1}", _rutbe, _isim));

            foreach (Asker soldier in _askerler)
            {
                soldier.ExecuteOrder();
            }

        }
    }

    class CompositeRunner1
    {

        public CompositeRunner1()
        {

            // Root oluşturulur.   
            KompoziteAsker generalCagatay = new KompoziteAsker("cagatay", Rutbeler.General);


            // root altına Leaf tipten nesne örnekleri eklenir.
            generalCagatay.AskerEkle(new PersonelAsker("Önder", Rutbeler.Albay));
            generalCagatay.AskerEkle(new PersonelAsker("Umut", Rutbeler.Albay));


            // Composite tipler oluşturulur.
            KompoziteAsker albayMehmet = new KompoziteAsker("Mehmet", Rutbeler.Albay);
            KompoziteAsker yarbaySevgi = new KompoziteAsker("Sevgi", Rutbeler.Yarbay);


            // Composite tipe bağlı primitive tipler oluşturulur.
            yarbaySevgi.AskerEkle(new PersonelAsker("Emre", Rutbeler.Yüzbaşı));
            albayMehmet.AskerEkle(yarbaySevgi);
            albayMehmet.AskerEkle(new PersonelAsker("Özgür", Rutbeler.Yarbay));

            // Root' un altına Composite nesne örneği eklenir.
            generalCagatay.AskerEkle(albayMehmet);


            generalCagatay.AskerEkle(new PersonelAsker("Cihan", Rutbeler.Albay));


            // root için ExecuteOrder operasyonu uygulanır. Buna göre root altındaki tüm nesneler için bu operasyon uygulanır
            Console.WriteLine("General -----");
            generalCagatay.ExecuteOrder();
			Console.WriteLine("Yarbay -----");
            yarbaySevgi.ExecuteOrder();
			Console.WriteLine("Albay -----");
            albayMehmet.ExecuteOrder();
			Console.ReadLine();

        }

    }
}
