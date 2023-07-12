using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEducaiton.UML.BehavioralPatterns.HookClasses.Example1
{
	// Bu örnek, Hook Classes desenini kullanarak ana sınıfın
	// davranışını genişletmek veya değiştirmek için alt sınıflar
	// aracılığıyla kancalar sağladığını göstermektedir. Alt sınıflar,
	// kancaları üzerine yazarak özelleştirilmiş davranışlarını
	// sağlayabilir ve ana sınıfın temel davranışını etkileyebilir.


	// Hook Classes tasarım deseni örneği

	// Ana sınıf
	// "BaseClass" adında bir ana sınıfımız bulunuyor. Bu sınıf,
	// "TemplateMethod" adında bir şablon yöntemine sahiptir.
	// Şablon yöntemi içerisinde, "HookMethod" adında bir kancanın
	// çağrısı bulunur. "HookMethod" yöntemi varsayılan bir uygulama
	// sağlar, ancak alt sınıflar tarafından özelleştirilebilir.
	public abstract class BaseClass
	{
		public void TemplateMethod()
		{
			Console.WriteLine("Bu adım her durumda çalışır.");

			HookMethod();

			Console.WriteLine("Bu adım her durumda çalışır.");
		}

		protected virtual void HookMethod()
		{
			// Kancaya varsayılan bir uygulama sağlanabilir.
		}
	}

	// "ConcreteClass1" ve "ConcreteClass2" adında iki alt sınıfımız
	// bulunmaktadır. Her iki alt sınıf da "HookMethod" yöntemini
	// üzerine yazarak kendi özelleştirilmiş davranışlarını sağlarlar.

	// Alt sınıf 1
	public class ConcreteClass1 : BaseClass
	{
		protected override void HookMethod()
		{
			Console.WriteLine("ConcreteClass1 için özelleştirilmiş kancanın uygulaması.");
		}
	}

	// Alt sınıf 2
	public class ConcreteClass2 : BaseClass
	{
		protected override void HookMethod()
		{
			Console.WriteLine("ConcreteClass2 için özelleştirilmiş kancanın uygulaması.");
		}
	}

	// Kullanım

	// "Main" metodu içerisinde, hem "ConcreteClass1" hem de
	// "ConcreteClass2" için örnekler oluşturulur ve "TemplateMethod"
	// çağrılarak çalıştırılır. Her iki durumda da, kancanın
	// özelleştirilmiş uygulamaları çağrılarak sonuçlar ekrana yazdırılır.
	public class HookClassesExample1Runner
	{
		public static void Main()
		{
			BaseClass instance1 = new ConcreteClass1();
			instance1.TemplateMethod();

			BaseClass instance2 = new ConcreteClass2();
			instance2.TemplateMethod();
		}
	}
}
