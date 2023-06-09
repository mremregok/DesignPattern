using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEducaiton.ISP
{
    /*
     * Bu örnekte, IShape arayüzü, çizim, hareket ettirme ve yeniden boyutlandırma işlemlerini içeren üç metodu tanımlar.
     * Ardından Circle, Square ve Line sınıfları, bu arayüzü uygular ve kendi özel davranışlarını bu metodlarda gerçekleştirir.
     * Bu sayede, her sınıf yalnızca ihtiyaç duyduğu metodları uygular ve gereksiz bağımlılıklardan kaçınılmış olur.
     * Örneğin, Circle sınıfı kendine özgü çizme, hareket ettirme ve yeniden boyutlandırma işlemlerini uygularken,
     * Line sınıfı da kendine özgü çizme, hareket ettirme ve yeniden boyutlandırma işlemlerini uygular.
     * Bu sayede sınıflar daha esnek ve sürdürülebilir hale gelir.
     */
    public interface IShape
    {
        void Draw();
        void Move();
        void Resize();
    }

    public class Circle : IShape
    {
        public void Draw()
        {
            // Çemberi çizme işlemleri
        }

        public void Move()
        {
            // Çemberi hareket ettirme işlemleri
        }

        public void Resize()
        {
            // Çemberi yeniden boyutlandırma işlemleri
        }
    }

    public class Square : IShape
    {
        public void Draw()
        {
            // Kareyi çizme işlemleri
        }

        public void Move()
        {
            // Kareyi hareket ettirme işlemleri
        }

        public void Resize()
        {
            // Kareyi yeniden boyutlandırma işlemleri
        }
    }

    public class Line : IShape
    {
        public void Draw()
        {
            // Çizgiyi çizme işlemleri
        }

        public void Move()
        {
            // Çizgiyi hareket ettirme işlemleri
        }

        public void Resize()
        {
            // Çizgiyi yeniden boyutlandırma işlemleri
        }
    }

    //Burada bir sınıf daha ekleyip, sonra ortak bir sınıfta kullanma örneği sergilenmeli.

    //Generic Type örneği yapılmalı.

}
