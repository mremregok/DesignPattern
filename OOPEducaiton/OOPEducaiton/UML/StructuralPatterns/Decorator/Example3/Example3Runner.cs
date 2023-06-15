using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEducaiton.UML.StructuralPatterns.Decorator.Example3
{
	//Örnekte, pizzaların sahip olacağı şema
	public interface IPizza
	{
		void MakePizza();
	}
	//Dekore etmek istediğimiz sınıf
	public class SadePizza : IPizza
	{
		public void MakePizza()
		{
			Console.WriteLine("Pizza yapılıyor...");
		}
	}
	//Decorator Sınıfı
	public abstract class PizzaDecorator : IPizza
	{
		//Var olan pizza nesnesini tutuyoruz.
		protected SadePizza _pizza;
		// _pizza field ini başlangıçta tanımlamak için constructor oluşturuyoruz.
		// Soyut PizzaDecorator sınıfını kalıtan bir nesne çağrılırken,
		// var olan pizza nesnesine ihtiyaç duymaktayız.
		public PizzaDecorator(SadePizza pizza)
        {
			// Var olan pizza nesnesini protected field a eşitliyoruz.
            this._pizza = pizza;
        }
		// Arayüz implementasyonu
		// Burada Somut Bileşenin MakePizza methodunu, almış olduğumuz pizza nesnesinden kullanacağız
		// Virtual yapıyoruz ki kalıtan sınıflar farklı işlemler yapmak isteyebilirler.
		public virtual void MakePizza()
		{
			_pizza.MakePizza();
		}
	}
	// Abstract Decorator sınıfından türetilmiş concrete decorator
	// Var olan pizza nesnesine tavuk ekleyecek.
	public class TavukluPizzaDecorator : PizzaDecorator
	{
		// Var olan pizza nesnesini alır, base constructor kullanarak bu örnekte içerisine tavuk ekleyecek 
		public TavukluPizzaDecorator(SadePizza pizza) : base(pizza)
		{
		}
		// Abstract sınıftaki Makepizza metodunu eziyoruz
		public override void MakePizza()
		{
			// Öncelikle almış olduğumuz SadePizza somut bileşeninin MakePizza metodunu çağırıyoruz, sonrasında 
			// AddChicken metodunu çağırıyoruz.
			base.MakePizza();
			AddChicken();			
		}

		private void AddChicken()
		{
			Console.WriteLine("Pizzaya tavuk eklendi.");
		}
	}
	// Abstract Decorator sınıfından türetilmiş concrete decorator
	// Var olan pizza nesnesini vegan pizzaya çevirecek
	public class VeganPizzaDecorator : PizzaDecorator
	{
		// Var olan pizza nesnesini alır, base constructor kullanarak bu örnekte pizzayı vegan pizzaya çevirecek
		public VeganPizzaDecorator(SadePizza pizza) : base(pizza)
		{
		}
		// MakePizza metodunu eziyoruz
		public override void MakePizza()
		{
			base.MakePizza();
			AddVegetables();
		}
		private void AddVegetables()
		{
			Console.WriteLine("Pizzaya sebzeler eklendi.");
		}
	}
	public class DecoratorExample3Runner
	{
        public DecoratorExample3Runner()
        {
			SadePizza pizza = new SadePizza();

			pizza.MakePizza();

			Console.WriteLine("*********");

			PizzaDecorator pizzaDecorator = new TavukluPizzaDecorator(pizza);

			pizzaDecorator.MakePizza();

			Console.WriteLine("*********");

			pizzaDecorator = new VeganPizzaDecorator(pizza);

			pizzaDecorator.MakePizza();
        }
    }
}
