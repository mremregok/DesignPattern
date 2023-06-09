using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEducaiton.ImplementExmp
{
    internal interface IArac
    {
        int KM { get; set; }
        int Model { get; set; }
    }

    internal class Otomobil : DizelArac, IArac
    {
        public int KM { get; set; }
        public int Model { get; set; }

        public override void BakimYap()
        {
            throw new NotImplementedException();
        }
    }

    internal abstract class DizelArac
    {
        protected void MotorinBenzinDoldur()
        {
            //benzin doldurma işlemi yapılıyor.
        }
        public abstract void BakimYap();
    }

    internal class Kamyon : DizelArac, IArac
    {
        public int KM { get; set; }
        public int Model { get; set; }

        public override void BakimYap()
        {
            //her sınıf kendi eylemini yapar.
            //araç sınıfına göre bakımlar farklı eylemlerdir.
        }
    }

    internal class Otobus : DizelArac, IArac
    {
        public int KM { get; set; }
        public int Model { get; set; }

        public override void BakimYap()
        {
            //her sınıf kendi eylemini yapar.
            //araç sınıfına göre bakımlar farklı eylemlerdir.
        }
    }
    internal class Minibus : DizelArac, IArac
    {
        public int KM { get; set; }
        public int Model { get; set; }

        public override void BakimYap()
        {
            //her sınıf kendi eylemini yapar.
            //araç sınıfına göre bakımlar farklı eylemlerdir.
        }
    }
}
