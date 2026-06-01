using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesginPattrens.Structural
{
    public class Proxy
    {
        //public Proxy()
        //{
        //    IDocument document1 = new DocumentProxy("Confidential Report", "Admin");
        //    IDocument document2 = new DocumentProxy("Confidential Report", "User");
        //    document1.Display(); // Access granted, displays the document
        //    document2.Display(); // Access denied, does not display the document
        //}
        public void Run()
        {
            IDocument document1 = new DocumentProxy("Confidential Report", "Admin");
            IDocument document2 = new DocumentProxy("Confidential Report", "User");
            document1.Display(); // Access granted, displays the document
            document2.Display(); // Access denied, does not display the document
        }
    }
    public interface IDocument
    {
        void Display();
    }
    public class RealDocument : IDocument
    {
        private readonly string _title;
        public RealDocument(string title)
        {
            _title = title;
        }
        public void Display()
        {
            Console.WriteLine($"Displaying document: {_title}");
        }
    }
    public class DocumentProxy : IDocument
    {
        private readonly string _title;
        private RealDocument _realDocument;
        private readonly string _userRole;
        public DocumentProxy(string title, string userRole)
        {
            _title = title;
            _userRole = userRole;
        }
        public void Display()
        {
            if (_userRole == "Admin")
            {
                if (_realDocument == null)
                {
                    _realDocument = new RealDocument(_title);
                }
                _realDocument.Display();
            }
            else
            {
                Console.WriteLine("Access denied. You do not have permission to view this document.");
            }
        }
    }
}
