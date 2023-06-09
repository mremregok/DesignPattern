using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEducaiton.LSP.HataliKullanim
{

    /*
     * Bu örnekte, Rectangle sınıfı bir dikdörtgeni temsil eder ve Width ve Height özelliklerini içerir. 
     * Ayrıca CalculateArea metodu, dikdörtgenin alanını hesaplar. 
     * Square sınıfı, Rectangle sınıfından türetilmiştir. 
     * Ancak, Square sınıfı, Width ve Height özelliklerini eşit tutacak şekilde yeniden uygular. 
     * Bu durum, LSP'ye aykırıdır çünkü Square, Rectangle'ın beklenen davranışını değiştirir. 
     * Örneğin, Square sınıfını kullanarak bir dikdörtgeni temsil etmek istediğimizde, 
     * Width ve Height değerlerini bağımsız olarak ayarlayamayız.
     */
    public class Rectangle
    {
        public virtual int Width { get; set; }
        public virtual int Height { get; set; }

        public int CalculateArea()
        {
            return Width * Height;
        }
    }

    public class Square : Rectangle
    {
        public override int Width
        {
            get => base.Width;
            set
            {
                base.Width = value;
                base.Height = value;
            }
        }

        public override int Height
        {
            get => base.Height;
            set
            {
                base.Height = value;
                base.Width = value;
            }
        }
    }

}
