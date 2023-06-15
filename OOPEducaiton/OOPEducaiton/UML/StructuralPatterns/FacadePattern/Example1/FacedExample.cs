using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEducaiton.UML.StructuralPatterns.FacadePattern
{
    class Musteri
    {
        public int MusteriNumarasi { get; set; }
        public string TcNo { get; set; }
        public string Ad { get; set; }
    }

    class Banka
    {
        public bool KrediyiKullan(Musteri m, decimal talepEdilenMiktar)
        {
            return true;
        }
    }
    class Kredi
    {
        public bool KrediKullanmaDurumu(Musteri m)
        {
            return true;
        }
    }

    class MerkezBanka
    {
        public bool KaraListeKontrol(string tcNo)
        {
            return false;
        }
    }

    class Facade
    {
        private Banka _banka;
        private MerkezBanka _merkezBanka;
        private Kredi _kredi;

        public Facade()
        {
            _banka = new Banka();
            _merkezBanka = new MerkezBanka();
            _kredi = new Kredi();

        }

        public void KrediKullan(Musteri m, decimal talep)
        {
            if (!_merkezBanka.KaraListeKontrol(m.TcNo) && _kredi.KrediKullanmaDurumu(m))
            {
                _banka.KrediyiKullan(m, talep);
                Console.WriteLine("krediyi kullandırdık");
            }
            else
            {
                Console.WriteLine("Kredi kullandırtmadık...");
            }
        }
    }

    class FacadeExample1Runner
    {
        public FacadeExample1Runner()
        {
            Facade facade = new Facade();

            facade.KrediKullan(new Musteri(), 1);
        }
    }
}
