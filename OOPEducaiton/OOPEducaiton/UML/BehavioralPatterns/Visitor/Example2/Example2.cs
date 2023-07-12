using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEducaiton.UML.BehavioralPatterns.Visitor.Example2
{
    //Visitor Interface
    public interface IVisitor
    {
        void Visit(HPPrinter hpPrinter);
        void Visit(LexmarkPrinter lexmarkPrinter);
    }

    //Concrete Visitor
    public class FaxVisitor : IVisitor
    {
        public void Visit(HPPrinter hpPrinter)
        {
            //...Process
            Console.WriteLine($"{nameof(HPPrinter)}'dan faks gönderiliyor...");
        }

        public void Visit(LexmarkPrinter lexmarkPrinter)
        {
            //...Process
            Console.WriteLine($"{nameof(LexmarkPrinter)}'dan faks gönderiliyor...");
        }
    }

    public interface IPrinter
    {
        //Yazıcılarda zaten var olan yazdırma özelliği.
        void Print();
        //Concrete Visitor nesnesiyle bu Concrete Element nesnesini
        //ilişkilendirip, süreci Concrete Visitor nesnesine bırakmamızı
        //sağlayan metot.
        void Accept(IVisitor visit);
    }

    //Concrete Element
    public class HPPrinter : IPrinter
    {
        public void Print()
        {
            //...Process
            Console.WriteLine($"{nameof(HPPrinter)} yazdırıyor...");
        }

        public void Accept(IVisitor visit)
            => visit.Visit(this);
    }

    //Concrete Element
    public class LexmarkPrinter : IPrinter
    {
        public void Print()
        {
            //...Process
            Console.WriteLine($"{nameof(LexmarkPrinter)} yazdırıyor...");
        }

        public void Accept(IVisitor visit)
            => visit.Visit(this);
    }

    public class VisitorExample2Runner
    {
        public static void Main()
        {
            HPPrinter hp = new();
            LexmarkPrinter lexmark = new();

            hp.Print();
            lexmark.Print();

            IVisitor fax = new FaxVisitor();
            hp.Accept(fax);
            lexmark.Accept(fax);
        }
    }
}
