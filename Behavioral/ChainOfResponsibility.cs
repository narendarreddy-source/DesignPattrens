using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesginPattrens.Behavioral
{
    public class ChainOfResponsibility
    {
        public void Run()
        {
            Handler level1 = new Level1Handler();
            Handler level2 = new Level2Handler();
            Handler level3 = new Level3Handler();
            level1.SetNext(level2);
            level2.SetNext(level3);
            string[] requests = { "Basic", "Intermediate", "Advanced", "Unknown" };
            foreach (var request in requests)
            {
                Console.WriteLine($"Processing request: {request}");
                level1.HandleRequest(request);
                Console.WriteLine();
            }
        }
    }
    public abstract class Handler
    {
        protected Handler _nextHandler;
        public void SetNext(Handler nextHandler)
        {
            _nextHandler = nextHandler;
        }
        public abstract void HandleRequest(string request);
    }

    public class Level1Handler : Handler
    {
        public override void HandleRequest(string request)
        {
            if(request == "Basic")
                Console.WriteLine("Level 1 Handler processed the request.");
            else
                 _nextHandler.HandleRequest(request);
        }
    }

    public class Level2Handler : Handler
    {
        public override void HandleRequest(string request)
        {
            if (request == "Intermediate")
                Console.WriteLine("Level 2 Handler processed the request.");
            else
                _nextHandler.HandleRequest(request);
        }
    }

    public class Level3Handler : Handler
    {
        public override void HandleRequest(string request)
        {
            if (request == "Advanced")
                Console.WriteLine("Level 3 Handler processed the request.");
            else
                Console.WriteLine("No handler could process the request.");
        }
    }
}
