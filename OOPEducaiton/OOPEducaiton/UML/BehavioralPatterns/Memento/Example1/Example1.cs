using System;
using System.Collections.Generic;

namespace OOPEducaiton.UML.BehavioralPatterns.Memento.Example1
{
    // Memento
    class TextMemento
    {
        public string Text { get; }

        public TextMemento(string text)
        {
            Text = text;
        }
    }

    // Kaydedici (Originator)
    class TextEditor
    {
        private string _text;

        public string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                Console.WriteLine("Metin güncellendi: " + _text);
            }
        }

        public TextMemento Save()
        {
            return new TextMemento(_text);
        }

        public void Restore(TextMemento memento)
        {
            _text = memento.Text;
            Console.WriteLine("Metin geri yüklendi: " + _text);
        }
    }

    // Bakıcı (Caretaker)
    class TextHistory
    {
        private Stack<TextMemento> _history = new Stack<TextMemento>();

        public void Push(TextMemento memento)
        {
            _history.Push(memento);
        }

        public TextMemento Pop()
        {
            return _history.Pop();
        }
    }

    // Kullanım
    public class MementoExample1Runner
    {
        public static void Main()
        {
            TextEditor editor = new TextEditor();
            TextHistory history = new TextHistory();

            // Başlangıç metnini ayarla
            editor.Text = "Bu bir deneme metnidir.";

            // İlk durumu kaydet
            history.Push(editor.Save());

            // Metni güncelle
            editor.Text = "Yeni metin güncellemesi 1";

            // Yeni durumu kaydet
            history.Push(editor.Save());

            // Metni güncelle
            editor.Text = "Yeni metin güncellemesi 2";

            // Yeni durumu kaydet
            history.Push(editor.Save());

            // Geri alma işlemi - 2 kez geri al
            editor.Restore(history.Pop());
            editor.Restore(history.Pop());
            Console.WriteLine(editor.Text);

            editor.Restore(history.Pop());
            Console.WriteLine(editor.Text);
            Console.ReadLine();
        }
    }
}
