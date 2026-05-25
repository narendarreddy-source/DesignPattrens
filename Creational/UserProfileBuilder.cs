using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesginPattrens.Creational
{
    public class UserProfileBuilder
    {
        private readonly UserProfile _user = new UserProfile();

        public UserProfileBuilder WithName(string name)
        { _user.Name = name; return this; }

        public UserProfileBuilder WithEmail(string email)
        { _user.Email = email; return this; }

        public UserProfileBuilder WithPhone(string phone)
        { _user.Phone = phone; return this; }

        public UserProfile Build() => _user;
    }
    public class UserProfile
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone {  get; set; }
    }

}
