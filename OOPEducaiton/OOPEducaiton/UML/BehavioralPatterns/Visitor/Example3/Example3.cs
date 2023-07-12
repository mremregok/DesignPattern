using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OOPEducaiton.UML.BehavioralPatterns.Visitor.Example3
{
    //Visitor Interface
    public interface IShapeVisitor
    {
        void Visit(Dot dot);
        void Visit(Circle circle);
        void Visit(Rectangle rectangle);
    }

    //Concrete Visitor
    public class JSONExportVisitor : IShapeVisitor
    {
        public void Visit(Dot dot)
            => Console.WriteLine(JsonSerializer.Serialize(new
            {
                Location = new Point(dot.X, dot.Y),
                dot.Shape
            }));

        public void Visit(Circle circle)
            => Console.WriteLine(JsonSerializer.Serialize(new
            {
                Location = new Point(circle.X, circle.Y),
                circle.Shape,
                circle.Radius
            }));

        public void Visit(Rectangle rectangle)
            => Console.WriteLine(JsonSerializer.Serialize(new
            {
                Location = new Point(rectangle.X, rectangle.Y),
                rectangle.Shape,
                Size = new Size(rectangle.Width, rectangle.Height)
            }));
    }

    //Concrete Visitor
    public class XMLExportVisitor : IShapeVisitor
    {
        void Report(object data)
        {
            XmlSerializer xmlSerializer = new(data.GetType());
            StringWriter stringWriter = new();
            xmlSerializer.Serialize(stringWriter, data);
            Console.WriteLine(stringWriter.ToString());
        }
        public void Visit(Dot dot)
            => Report(dot);

        public void Visit(Circle circle)
            => Report(circle);

        public void Visit(Rectangle rectangle)
            => Report(rectangle);
    }

    public interface IShape
    {
        void Move(int x, int y);
        void Draw();
        void Accept(IShapeVisitor shapeVisitor);
    }

    //Concrete Element
    public class Dot : IShape
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string Shape { get; } = ".";

        public void Accept(IShapeVisitor shapeVisitor)
            => shapeVisitor.Visit(this);

        public void Draw()
            => Console.WriteLine(Shape);

        public void Move(int x, int y)
            => Console.WriteLine($"Nokta X: {(X = x)} | Y: {(Y = y)} koordinatlarına taşınmıştır.");
    }

    //Concrete Element
    public class Circle : IShape
    {
        public int Radius { get; set; } = 10;
        public int X { get; set; }
        public int Y { get; set; }
        public string Shape { get; } = "⬤";

        public void Accept(IShapeVisitor visitor)
            => visitor.Visit(this);

        public void Draw()
            => Console.WriteLine(Shape);

        public void Move(int x, int y)
            => Console.WriteLine($"Daire X: {(X = x)} | Y: {(Y = y)} koordinatlarına taşınmıştır.");
    }

    //Concrete Element
    public class Rectangle : IShape
    {
        public int Width { get; set; } = 20;
        public int Height { get; set; } = 5;
        public int X { get; set; }
        public int Y { get; set; }
        public string Shape { get; } = "▭";

        public void Accept(IShapeVisitor visitor)
            => visitor.Visit(this);

        public void Draw()
            => Console.WriteLine(Shape);

        public void Move(int x, int y)
            => Console.WriteLine($"Dikdörtgen X: {(X = x)} | Y: {(Y = y)} koordinatlarına taşınmıştır.");
    }

    public class VisitorExample3Runner
    {
        public static void Main()
        {
            Dot dot = new();
            Circle circle = new();
            Rectangle rectangle = new();

            dot.Move(3, 5);
            circle.Move(13, 15);
            rectangle.Move(23, 25);

            Console.WriteLine("-----------");

            IShapeVisitor shapeVisitor = new JSONExportVisitor();
            dot.Accept(shapeVisitor);
            circle.Accept(shapeVisitor);
            rectangle.Accept(shapeVisitor);

            Console.WriteLine("-----------");

            shapeVisitor = new XMLExportVisitor();
            dot.Accept(shapeVisitor);
            circle.Accept(shapeVisitor);
            rectangle.Accept(shapeVisitor);
        }
    }
}
