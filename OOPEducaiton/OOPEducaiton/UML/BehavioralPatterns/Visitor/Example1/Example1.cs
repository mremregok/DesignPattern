using System;
using System.Collections.Generic;

namespace OOPEducaiton.UML.BehavioralPatterns.Visitor.Example1
{
    // Visitor (Ziyaretçi) arabirimi
    interface IMuseumVisitor
    {
        void VisitExhibitA(ExhibitA exhibit);
        void VisitExhibitB(ExhibitB exhibit);
        void VisitExhibitC(ExhibitC exhibit);
    }

    // Element (Eleman) sınıfı - Müze Sergisi
    abstract class MuseumExhibit
    {
        public abstract void Accept(IMuseumVisitor visitor);
    }

    // Concrete Element (Somut Eleman) sınıfı - Sergi A
    class ExhibitA : MuseumExhibit
    {
        public override void Accept(IMuseumVisitor visitor)
        {
            visitor.VisitExhibitA(this);
        }

        public void ShowInformation()
        {
            Console.WriteLine("Bu sergi A ile ilgili bilgileri gösterir.");
        }
    }

    // Concrete Element (Somut Eleman) sınıfı - Sergi B
    class ExhibitB : MuseumExhibit
    {
        public override void Accept(IMuseumVisitor visitor)
        {
            visitor.VisitExhibitB(this);
        }

        public void ShowInformation()
        {
            Console.WriteLine("Bu sergi B ile ilgili bilgileri gösterir.");
        }
    }

    // Concrete Element (Somut Eleman) sınıfı - Sergi C
    class ExhibitC : MuseumExhibit
    {
        public override void Accept(IMuseumVisitor visitor)
        {
            visitor.VisitExhibitC(this);
        }

        public void ShowInformation()
        {
            Console.WriteLine("Bu sergi C ile ilgili bilgileri gösterir.");
        }
    }

    // Concrete Visitor (Somut Ziyaretçi) sınıfı - Yetişkin Ziyaretçi
    class AdultVisitor : IMuseumVisitor
    {
        public void VisitExhibitA(ExhibitA exhibit)
        {
            exhibit.ShowInformation();
            Console.WriteLine("Yetişkin ziyaretçi için sergi A rehberlik hizmeti sunuluyor.");
        }

        public void VisitExhibitB(ExhibitB exhibit)
        {
            exhibit.ShowInformation();
            Console.WriteLine("Yetişkin ziyaretçi için sergi B rehberlik hizmeti sunuluyor.");
        }

        public void VisitExhibitC(ExhibitC exhibit)
        {
            exhibit.ShowInformation();
            Console.WriteLine("Yetişkin ziyaretçi için sergi C rehberlik hizmeti sunuluyor.");
        }
    }

    // Concrete Visitor (Somut Ziyaretçi) sınıfı - Çocuk Ziyaretçi
    class ChildVisitor : IMuseumVisitor
    {
        public void VisitExhibitA(ExhibitA exhibit)
        {
            exhibit.ShowInformation();
            Console.WriteLine("Çocuk ziyaretçi için sergi A rehberlik hizmeti sunuluyor.");
        }

        public void VisitExhibitB(ExhibitB exhibit)
        {
            exhibit.ShowInformation();
            Console.WriteLine("Çocuk ziyaretçi için sergi B rehberlik hizmeti sunuluyor.");
        }

        public void VisitExhibitC(ExhibitC exhibit)
        {
            exhibit.ShowInformation();
            Console.WriteLine("Çocuk ziyaretçi için sergi C rehberlik hizmeti sunuluyor.");
        }
    }

    // Kullanım
    public class VisitorExample1Runner
    {
        public static void Main()
        {
            List<MuseumExhibit> exhibits = new List<MuseumExhibit>
            {
                new ExhibitA(),
                new ExhibitB(),
                new ExhibitC()
            };

            IMuseumVisitor adultVisitor = new AdultVisitor();
            IMuseumVisitor childVisitor = new ChildVisitor();

            foreach (MuseumExhibit exhibit in exhibits)
            {
                exhibit.Accept(adultVisitor);
                Console.WriteLine();

                exhibit.Accept(childVisitor);
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
