using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPEducaiton.UML.BuilderPattern.PersonelPromosyon
{
    public class Promosyon
    {
        public string UrunAdi { get; set; }
        public int PromosyonNumarasi { get; set; }
        public string CalisanProfili { get; set; }
        public override string ToString()
        {
            string str = $"{PromosyonNumarasi} numaralı {UrunAdi} promosyonu {CalisanProfili} calışanlarına verilmiştir.";
            Console.WriteLine(str);
            return str;
        }
    }
}