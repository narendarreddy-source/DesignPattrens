using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesginPattrens.Behavioral
{
    public class Mediator
    {
        public void Run()
        {
            IChatRoomMediator chatRoom = new ChatRoomMediator();
            var alice = new User("Alice", chatRoom);
            var bob = new User("Bob", chatRoom);
            alice.SendMessage("Hi Bob!");
            bob.SendMessage("Hello Alice!");
        }
        public interface IChatRoomMediator
        {
            void SendMessage(string message, User user);
            void RegisterUser(User user);
        }
        public class User
        {
            private readonly string _name;
            private readonly IChatRoomMediator _mediator;
            public User(string name, IChatRoomMediator mediator)
            {
                _name = name;
                _mediator = mediator;
                _mediator.RegisterUser(this);
            }
            public void SendMessage(string message)
            {
                Console.WriteLine($"{_name} sends:{message}");
                _mediator.SendMessage(message, this);
            }
            public void ReceiveMessage(string message)
            {
                Console.WriteLine($"{_name} received: {message}");
            }
        }
        public class ChatRoomMediator : IChatRoomMediator
        {
            private readonly List<User> _users = new List<User>();

            public void RegisterUser(User user)
            {
                _users.Add(user);
            }

            public void SendMessage(string message, User user)
            {
                foreach (var u in _users)
                {
                    if (u != user)
                    {
                        Console.WriteLine($"Message from {user}: {message}");
                    }
                }
            }
        }
    }
}

