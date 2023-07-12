using System;
using System.Collections.Generic;
using System.Threading;

namespace OOPEducaiton.UML.BehavioralPatterns.Mediator.Example3
{
    // Mediator
    interface IAirportControl
    {
        void Register(Airline airLine);
        void SuggestWay(string fligthNumber, string way);
    }

    // Concrete Mediator
    class IstanbulControl
        : IAirportControl
    {
        // Concrete Colleague nesne örnekleri bu koleksiyonda depolanmaktadır.
        private Dictionary<string, Airline> _planes;

        public IstanbulControl()
        {
            _planes = new Dictionary<string, Airline>();
        }

        #region IAirportControl Members

        // Kontrol kulesine çevredeki uçakların kayıt olması için Register metodu kullanılır. Bu metod parametre olarak Colleague' den türeyen her hangibir Concrete Colleague nesne örnepğini alabilir.
        public void Register(Airline airLine)
        {
            if (!_planes.ContainsValue(airLine))
                _planes[airLine.FlightNumber] = airLine;

            // Hava yolu şirketine ait uçağın, kuleden yeni rota talep edebilmesi için, Concrete Colleague nesne örneğinin, Mediator referansının bildirilmesi gerekir.
            airLine.Airport = this;
        }

        // Concrete Colleague nesne örneklerinin yeni rota talep ederken kullandıkları metod. Bu metod o anki koşullar gereği sakladığı diğer uçakların konum bilgilerinden yararlanıp bir takım sonuçlara varmaktadır. Bu sayede n tane kombinasyonun, her bir uçak tarafından ele alınması yerine, tüm bu kombinasyonlar daha az sayıya indirgenerek Mediator içerisinde değerlendirilebilmektedir.
        public void SuggestWay(string fligthNumber, string way)
        {
            // TODO: Diğer uçakların konumlarına bakılarak flightNumber için yeni bir rota önerilir. Gerekirse diğer uçaklarada farklı rotalar önerilebilir.

            // Sembolik olarak yeni bir rota belirleniyor. Bilgilendirme rotayı talep eden Concrete Colleague nesne örneğinin GetWay metoduna yapılan çağrı ile gerçekleştiriliyor.
            Thread.Sleep(250);
            Random rnd = new Random();
            _planes[fligthNumber].GetWay(String.Format("{0}:{1}E;{2}:{3}W", rnd.Next(1, 100).ToString(), rnd.Next(1, 100).ToString(), rnd.Next(1, 100).ToString(), rnd.Next(1, 100).ToString()));
        }

        #endregion
    }

    // Colleague
    abstract class Airline
    {
        public IAirportControl Airport { get; set; }
        public string FlightNumber { get; set; }
        public string From { get; set; }

        // Mediator' den yani kuleden yeni bir rota talep ederken kullanılan metod.
        public void RequestNewWay(string myWay)
        {
            // Çağrı dikkat edileceği üzere Mediator tipine ait nesne referansına
            // doğru yapılmaktadır. Peki bu referansı nerede verdik. Bknz Register metodu. :)
            Airport.SuggestWay(FlightNumber, myWay);
        }

        // Mediator tipinin, çağırıda bulunacağı GetWay metodu. Bu metodun parametre
        // içeriği, kuleden(Concrete Mediator) üzerinden gelmektedir.
        public virtual void GetWay(string messageFromAirport)
        {
            Console.WriteLine("{0} rotasına yönelmemiz gerekmektedir.", messageFromAirport);
        }
    }

    // Concrete Colleague
    class OzHawaii
        : Airline
    {
        public override void GetWay(string messageFromAirport)
        {
            Console.WriteLine("Oz Hawaii, Uçuş {0} : ", FlightNumber);
            base.GetWay(messageFromAirport);
        }
    }

    // Concrete Colleague
    class ZorluYol
        : Airline
    {
        public override void GetWay(string messageFromAirport)
        {
            Console.WriteLine("ZorluYol, Uçuş {0} : ", FlightNumber);
            base.GetWay(messageFromAirport);
        }
    }

    class MediatorExample3Runner
    {
        static void Main()
        {
            // Kule nesnesi örneklenir(Concrete Mediator)
            IstanbulControl istanbulKule = new IstanbulControl();

            // Kuleden hizmet alacak tüm uçakların kendisini kuleye bildirmesi gerekmektedir.
            // Bu nedenle uçaklar örneklendikten sonra Concrete Mediator tipine Register metodu
            // yardımıyla kayıt olurlar.
            OzHawaii oh101 = new OzHawaii { Airport = istanbulKule, FlightNumber = "oh101", From = "Hawai" };
            istanbulKule.Register(oh101);
            OzHawaii oh132 = new OzHawaii { Airport = istanbulKule, FlightNumber = "oh132", From = "Roma" };
            istanbulKule.Register(oh132);
            ZorluYol zy99 = new ZorluYol { Airport = istanbulKule, FlightNumber = "zy99", From = "Antarktika" };
            istanbulKule.Register(zy99);

            // Uçaklar yeni rotalarını talep ederler.
            zy99.RequestNewWay("34:43E;41:41W");

            oh101.RequestNewWay("34:43E;41:41W");
        }
    }
}
