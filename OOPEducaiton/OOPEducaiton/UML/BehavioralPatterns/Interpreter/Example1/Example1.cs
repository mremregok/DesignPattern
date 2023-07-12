using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEducaiton.UML.BehavioralPatterns.Interpreter.Example1
{
	// Bu örnek senaryoda, bir metin ifadesinin içinde belirli kelimelerin olup olmadığını kontrol
	// etmek için Interpreter Pattern kullanılır.

	// "Context" sınıfı, metin ifadesini ve sonucu içeren bağlam bilgisini temsil eder.
	// "Expression" soyut sınıfı, metin ifadesini yorumlamak için gerekli olan temel
	// davranışı ve interpret() metodunu içerir. "TerminalExpression" sınıfı, belirli
	// bir kelimenin metin ifadesinde bulunup bulunmadığını kontrol ederken "NonTerminalExpression"
	// sınıfı, birden fazla terminal ifadeyi birleştirerek bir ifadeyi yorumlar.

	// Senaryo uygulamasında, bir metin ifadesi oluşturulur ve içinde "Hello", "World"
	// ve "Interpreter" kelimelerini kontrol eden bir ifade yapısı oluşturulur. Ardından,
	// oluşturulan ifade yapısı bir bağlam ile yorumlanır. Sonuç olarak, ekrana ifadenin
	// yorumlanıp yorumlanmadığı ve çıktı değeri yazdırılır.

	// Bu şekilde, Interpreter Pattern kullanılarak belirli bir dil veya ifadenin yorumlanması
	// sağlanır. İfadenin yapısı veya yorumlama kuralları değiştiğinde, yeni ifadeler veya
	// kurallar eklemek kolay olur ve mevcut yapıyı değiştirmek gerekmez.


	// Context (Bağlam) sınıfı
	public class Context
	{
		private string input;
		private bool output;

		public Context(string input)
		{
			this.input = input;
		}

		public string Input
		{
			get { return input; }
			set { input = value; }
		}

		public bool Output
		{
			get { return output; }
			set { output = value; }
		}
	}

	// AbstractExpression (Soyut İfade) sınıfı
	public abstract class Expression
	{
		public abstract bool Interpret(Context context);
	}

	// TerminalExpression (Terminal İfade) sınıfı
	public class TerminalExpression : Expression
	{
		private string data;

		public TerminalExpression(string data)
		{
			this.data = data;
		}

		public override bool Interpret(Context context)
		{
			if (context.Input.Contains(data))
			{
				context.Output = true;
				return true;
			}
			else
			{
				context.Output = false;
				return false;
			}
		}
	}

	// NonTerminalExpression (Non-Terminal İfade) sınıfı
	public class NonTerminalExpression : Expression
	{
		private List<Expression> expressions;

		public NonTerminalExpression(List<Expression> expressions)
		{
			this.expressions = expressions;
		}

		public override bool Interpret(Context context)
		{
			foreach (Expression expression in expressions)
			{
				if (!expression.Interpret(context))
				{
					return false;
				}
			}

			return true;
		}
	}

	// Senaryo uygulaması
	public class InterpreterExample1Runner
	{
		public static void Main()
		{
			// İfadeyi oluştur
			Expression expression1 = new TerminalExpression("Hello");
			Expression expression2 = new TerminalExpression("World");
			Expression expression3 = new TerminalExpression("Interpreter");

			// İfadenin sıralamasını ve kombinasyonunu oluştur
			List<Expression> expressions = new List<Expression>
		{
			expression1,
			expression2,
			expression3
		};

			Expression nonTerminalExpression = new NonTerminalExpression(expressions);

			// Bağlamı oluştur ve ifadeyi yorumla
			Context context = new Context("Hello World!");

			bool result = nonTerminalExpression.Interpret(context);

			Console.WriteLine("İfade yorumlandı: " + result);
			Console.WriteLine("Çıktı: " + context.Output);
		}
	}
}
