using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject
{
    class User
    {
        public string Username { get; set; }//姓名
        public string Password { get; set; }

        
        public string Name { get; set; }//暱稱

        internal void SetName(string account_name)
        {
            Name = account_name;
        }

        public string Account { get; set; }

        internal void SetAccount(string account_name)
        {
            Account = account_name;
        }

        public char Gender { get; set; }
        internal void SetGender(char gender_kind)
        {
            Gender = gender_kind;
        }

        internal void SetPassword(string password)
        {
            Password = password;
        }
        public string Birth { get; set; }
        internal void SetBirth(string birth)
        {
            Birth = birth;
        }
        public string ID { get; set; }
        internal void SetID(string id_number)
        {
            ID = id_number;
        }
        public bool IsLogin { get; set; }

        internal string GetAccount()
        {
            throw new NotImplementedException();
        }
    }
}
