using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEducaiton.UML.BehavioralPatterns.Visitor.Example4
{
    //Visitor Interface
    public interface IToolVisitor
    {
        void Visit(TextBox textBox);
        void Visit(ComboBox comboBox);
        void Visit(RadioButton radioButton);
    }

    //Concrete Visitor
    public class MemberDetailVisitor : IToolVisitor
    {
        public void Visit(TextBox textBox)
            => Console.WriteLine($"{nameof(TextBox)} tool detayı...");

        public void Visit(ComboBox comboBox)
            => Console.WriteLine($"{nameof(ComboBox)} tool detayı...");

        public void Visit(RadioButton radioButton)
            => Console.WriteLine($"{nameof(RadioButton)} tool detayı...");
    }

    //Concrete Visitor
    public class StyleVisitor : IToolVisitor
    {
        public void Visit(TextBox textBox)
        {
            //...Process
            Console.WriteLine($"{nameof(TextBox)}'a stil uygulanmıştır.");
        }

        public void Visit(ComboBox comboBox)
        {
            //...Process
            Console.WriteLine($"{nameof(ComboBox)}'a stil uygulanmıştır.");
        }

        public void Visit(RadioButton radioButton)
        {
            //...Process
            Console.WriteLine($"{nameof(RadioButton)}'a stil uygulanmıştır.");
        }
    }

    public interface ITool
    {
        void Accept(IToolVisitor visitor);
        void Use();
    }

    //Concrete Element
    public class TextBox : ITool
    {
        public string Name { get; set; }
        public Color FontColor { get; set; }
        public Color BackGroundColor { get; set; }

        public void Accept(IToolVisitor visitor)
            => visitor.Visit(this);

        public void Use()
            => Console.WriteLine($"{nameof(TextBox)} kullanılmıştır.");
    }

    //Concrete Element
    public class ComboBox : ITool
    {
        public bool ScrollBar { get; set; }

        public void Accept(IToolVisitor visitor)
            => visitor.Visit(this);

        public void Use()
            => Console.WriteLine($"{nameof(ComboBox)} kullanılmıştır.");
    }

    //Concrete Element
    public class RadioButton : ITool
    {
        public bool Selected { get; set; } = false;
        public string Text { get; set; }

        public void Accept(IToolVisitor visitor)
            => visitor.Visit(this);

        public void Use()
            => Console.WriteLine($"{nameof(RadioButton)} kullanılmıştır.");
    }

    public class VisitorExample4Runner
    {
        public static void Main()
        {
            TextBox textBox = new();
            ComboBox comboBox = new();
            RadioButton radioButton = new();

            textBox.Use();
            comboBox.Use();
            radioButton.Use();

            Console.WriteLine("--------------");

            IToolVisitor toolVisitor = new MemberDetailVisitor();
            textBox.Accept(toolVisitor);
            comboBox.Accept(toolVisitor);
            radioButton.Accept(toolVisitor);

            Console.WriteLine("--------------");

            toolVisitor = new StyleVisitor();
            textBox.Accept(toolVisitor);
            comboBox.Accept(toolVisitor);
            radioButton.Accept(toolVisitor);
        }
    }
}
