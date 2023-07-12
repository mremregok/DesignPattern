using System;

namespace OOPEducaiton.UML.BehavioralPatterns.TemplateMethod.Example1
{
    // AbstractClass (Soyut Sınıf)
    abstract class CoffeeMaker
    {
        public void MakeCoffee()
        {
            GrindCoffee();
            HeatWater();
            BrewCoffee();
            ServeCoffee();
        }

        protected abstract void GrindCoffee();
        protected abstract void HeatWater();
        protected abstract void BrewCoffee();
        protected abstract void ServeCoffee();
    }

    // ConcreteClass (Somut Sınıf) - Espresso Makinesi
    class EspressoMaker : CoffeeMaker
    {
        protected override void GrindCoffee()
        {
            Console.WriteLine("Espresso için kahve çekirdekleri öğütülüyor.");
        }

        protected override void HeatWater()
        {
            Console.WriteLine("Su 90°C'ye kadar ısıtılıyor.");
        }

        protected override void BrewCoffee()
        {
            Console.WriteLine("Sıcak su espresso çekirdekleri üzerinden geçiriliyor.");
        }

        protected override void ServeCoffee()
        {
            Console.WriteLine("Espresso servise hazır.");
        }
    }

    // ConcreteClass (Somut Sınıf) - Damlalık Kahve Makinesi
    class DripCoffeeMaker : CoffeeMaker
    {
        protected override void GrindCoffee()
        {
            Console.WriteLine("Damlalık kahve için kahve çekirdekleri öğütülüyor.");
        }

        protected override void HeatWater()
        {
            Console.WriteLine("Su 80°C'ye kadar ısıtılıyor.");
        }

        protected override void BrewCoffee()
        {
            Console.WriteLine("Sıcak su damlalık üzerinden kahve filtresine akıtılıyor.");
        }

        protected override void ServeCoffee()
        {
            Console.WriteLine("Damlalık kahve servise hazır.");
        }
    }

    // Kullanım
    public class TemplateMethodExample1Runner
    {
        public static void Main()
        {
            CoffeeMaker espressoMaker = new EspressoMaker();
            Console.WriteLine("Espresso yapılıyor...");
            espressoMaker.MakeCoffee();

            Console.WriteLine();

            CoffeeMaker dripCoffeeMaker = new DripCoffeeMaker();
            Console.WriteLine("Damlalık kahve yapılıyor...");
            dripCoffeeMaker.MakeCoffee();

            Console.ReadLine();
        }
    }
}
