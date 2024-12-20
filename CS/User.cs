using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB011911.CS
{
    internal class User
    {
        private string name;
        private string contact;

        //properties
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Contact
        {
            get { return contact; }
            set { contact = value; }
        }

        //constructor
        public User(string name, string contact)
        {
            this.name = name;
            this.contact = contact;
        }
    }
}
