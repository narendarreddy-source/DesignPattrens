using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesginPattrens.Behavioral
{
    public class Memento
    {
        public void Run()
        {
            var editor = new TextEditor();
            var history = new History();
            editor.Type("This is the first sentence. ");
            editor.Type("This is the second sentence. ");
            history.Push(editor.Save());
            editor.Type("This is the third sentence. ");
            Console.WriteLine(editor.Content); // Output: This is the first sentence. This is the second sentence. This is the third sentence.
            editor.Restore(history.Pop());
            Console.WriteLine(editor.Content); // Output: This is the first sentence. This is the second sentence. 
        }
    }
    //Memento 
    public class EditorMemento
    {
        public string Content { get;}
        public EditorMemento(string content)
        {
            Content = content;
        }
    }

    //Originator
    public class TextEditor
    {
       public string Content { get; private set; } ="";
       public void Type(string words)
        {
            Content += words;
        }
        public EditorMemento Save()
        {
            return new EditorMemento(Content);
        }
        public void Restore(EditorMemento memento)
        {
            Content = memento.Content;
        }
    }

    //Caretaker
    public class History
    {
        private readonly Stack<EditorMemento> _mementos = new Stack<EditorMemento>();
        public void Push(EditorMemento state) => _mementos.Push(state);
        public EditorMemento Pop() => _mementos.Pop();
    }
}
