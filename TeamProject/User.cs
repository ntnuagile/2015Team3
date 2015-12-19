using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject
{
    class User
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public string getuser()
        {
            return Username;
        }



        public string Name { get; set; }

        internal void SetName(string account_name)
        {
            throw new NotImplementedException();
        }

        public string Account { get; set; }

        internal void SetAccount(string account_name)
        {
            throw new NotImplementedException();
        }

        internal void SetGender(char gender)
        {
            throw new NotImplementedException();
        }

        internal void SetPassword(string password)
        {
            throw new NotImplementedException();
        }

        internal void SetBirth(string birth)
        {
            throw new NotImplementedException();
        }

        internal void SetID(string id_number)
        {
            throw new NotImplementedException();
        }
    }
}
