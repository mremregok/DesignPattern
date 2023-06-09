using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEducaiton.LSP.DogruKullanim
{

    /*
     *  Rectangle ve Square sınıfları, her biri kendi alanlarını hesaplamak için CalculateArea metotunu uygular.
     *  Her iki sınıf da Shape sınıfından türetilmiştir ve LSP'ye uygundur.
     *  Yani, Shape tipindeki bir nesne, 
     *  ya Rectangle ya da Square nesnesiyle değiştirilebilir ve beklenen davranışı sergileyecektir.
     *  
     *  OCP doğru kullanılan örneğe bak.
     */
    public abstract class Shape
    {
        public abstract int CalculateArea();
    }

    public class Rectangle : Shape
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public override int CalculateArea()
        {
            return Width * Height;
        }
    }

    public class Square : Shape
    {
        public int SideLength { get; set; }

        public override int CalculateArea()
        {
            return SideLength * SideLength;
        }
    }

}
