using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEducaiton.UML.CreationalPatterns.Prototype.Example1
{

    public class ToplantiMesaj : IPrototypeToplantiMesaj
    {
        public string DavetliAdiSoyadi { get; set; }
        public DateTime Tarih { get; set; }
        public TimeSpan BaslangicSaati { get; set; }
        public TimeSpan BitisSaati { get; set; }

        public string ToplantiKonusu { get; set; }
        public string Adres { get; set; }

        public string SalonNo { get; set; }
        public string[] Katilimcilar { get; set; }

        public ToplantiMesaj Clone()
        {
            return (ToplantiMesaj)MemberwiseClone();
        }

        public string MesajMetni()
        {
            return "";
        }
    }
}
