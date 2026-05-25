using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesginPattrens.Creational
{
    public class AbstractFactory
    {
        private readonly IStorage _storage;
        private readonly IMessageQueue _queue;

        public AbstractFactory(ICloudFactory factory)
        {
            _storage = factory.CreateStorage();
            _queue = factory.CreateQueue();
        }

        public void Process()
        {
            _storage.Upload("data.txt");
            _queue.Send("Processing completed");
        }
    }
    public interface IStorage
    {
        void Upload(string fileName);
    }

    public interface IMessageQueue
    {
        void Send(string message);
    }
    public class AwsStorage : IStorage
    {
        public void Upload(string fileName)
        {
            Console.WriteLine("Uploaded to AWS S3");
        }
    }

    public class AwsQueue : IMessageQueue
    {
        public void Send(string message)
        {
            Console.WriteLine("Message sent via AWS SQS");
        }
    }

    public class AzureStorage : IStorage
    {
        public void Upload(string fileName)
        {
            Console.WriteLine("Uploaded to Azure Blob Storage");
        }
    }

    public class AzureQueue : IMessageQueue
    {
        public void Send(string message)
        {
            Console.WriteLine("Message sent via Azure Service Bus");
        }
    }

    public interface ICloudFactory
    {
        IStorage CreateStorage();
        IMessageQueue CreateQueue();
    }
    public class AwsFactory : ICloudFactory
    {
        public IStorage CreateStorage() => new AwsStorage();
        public IMessageQueue CreateQueue() => new AwsQueue();
    }

    public class AzureFactory : ICloudFactory
    {
        public IStorage CreateStorage() => new AzureStorage();
        public IMessageQueue CreateQueue() => new AzureQueue();
    }


}
