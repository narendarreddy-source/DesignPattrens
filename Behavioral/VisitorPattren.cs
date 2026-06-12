using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesginPattrens.Behavioral
{
    public class VisitorPattren
    {
        public void run()
        {
            Folder root = new Folder("Root");
            root.AddElement(new File("File1.txt", 100));
            root.AddElement(new File("File2.txt", 200));
            Folder subFolder = new Folder("SubFolder");
            subFolder.AddElement(new File("File3.txt", 300));
            root.AddElement(subFolder);
            SizeCalculatorVisitor sizeVisitor = new SizeCalculatorVisitor();
            root.Accept(sizeVisitor);
            Console.WriteLine($"Total Size: {sizeVisitor.TotalSize} bytes");
        }
    }
    public interface IFileSystemVisitor
    {
        void Visit(File file);
        void Visit(Folder folder);
    }
    public interface IFileSystemElement
    {
        void Accept(IFileSystemVisitor visitor);
    }

    public class File : IFileSystemElement
    {
        public string Name { get; set; }
        public int Size { get; set; }
        public File(string name, int size)
        {
            Name = name;
            Size = size;
        }
        public void Accept(IFileSystemVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class Folder : IFileSystemElement
    {
        public string Name { get; set; }
        public List<IFileSystemElement> Elements { get; set; }
        public Folder(string name)
        {
            Name = name;
            Elements = new List<IFileSystemElement>();
        }
        public void AddElement(IFileSystemElement element)
        {
            Elements.Add(element);
        }
        public void Accept(IFileSystemVisitor visitor)
        {
            visitor.Visit(this);
            foreach (var element in Elements)
            {
                element.Accept(visitor);
            }
        }
    }
    public class SizeCalculatorVisitor : IFileSystemVisitor
    {
        public int TotalSize { get; private set; }
        public void Visit(File file)
        {
            TotalSize += file.Size;
        }
        public void Visit(Folder folder)
        {
            // No action needed for folders in this visitor
            Console.WriteLine($"Calculating size for folder: {folder.Name}");
        }
    }
}