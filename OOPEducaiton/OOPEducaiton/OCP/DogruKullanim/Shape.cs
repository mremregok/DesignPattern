using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEducaiton.OCP.DogruKullanim
{
    //Burada SSR, OCP, LSP prensipleri gözetilmiştir.

    /*
        Bu örnekte, Shape soyut sınıfı Open/Closed Principle'ı takip etmektedir. 
        Shape sınıfı soyut bir CalculateArea metodu içerir. 
        Ardından Rectangle ve Circle sınıfları, 
        Shape sınıfından türetilerek kendi CalculateArea uygulamalarını yaparlar.
        
        AreaCalculator sınıfı, bir dizi Shape örneğini alır ve her şeklin alanını hesaplamak için CalculateArea yöntemini çağırır.
        Bu sayede, yeni bir şekil eklemek istediğimizde 
        AreaCalculator sınıfını değiştirmemize gerek kalmadan yeni şekil sınıfıyla birlikte çalışabiliriz.
        
        Bu örnek, Open/Closed Principle'ın uygulandığını gösterir. 
        Mevcut kodu değiştirmeden yeni bir şekil ekleyebiliriz ve AreaCalculator sınıfı üzerinde herhangi bir değişiklik yapmamız gerekmez.
        Böylece mevcut kodun kırılganlığı azalır ve yeni gereksinimlere uyum sağlamak daha kolay hale gelir.
*/

    public abstract class Shape
    {
        public abstract double CalculateArea();
        public virtual double Draw()
        {
            return 1;
        }
    }

    public class Rectangle : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public override double CalculateArea()
        {
            return Width * Height;
        }
        
    }

    public class Circle : Shape
    {
        public double Radius { get; set; }

        public override double CalculateArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }
    }
}


