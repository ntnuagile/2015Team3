﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject
{
    class User
    {
        //暱稱
        private string Name { get; set; }
        internal void SetName(string account_name)
        {
            Name = account_name;
        }
        public string GetName()
        {
            return Name;
        }


        //帳號
        private string Account { get; set; }
        public void SetAccount(string account_name)
        {
            Account = account_name;
        }
        public string GetAccount()
        {
            return Account;
        }


        //性別
        private char Gender { get; set; }
        public void SetGender(char gender_kind)
        {
            Gender = gender_kind;
        }
        public char GetGender()
        {
            return Gender;
        }


        //密碼
        private string Password { get; set; }
        public void SetPassword(string password)
        {
            Password = password;
        }
        public string GetPassword()
        {
            return Password;
        }


        //生日
        private string Birth { get; set; }
        public void SetBirth(string birth)
        {
            Birth = birth;
        }
        public string GetBirth()
        {
            return Birth;
        }


        //身分證字號
        private string ID { get; set; }
        public void SetID(string id_number)
        {
            ID = id_number;
        }
        public string GetID()
        {
            return ID;
        }


        //登入狀態
        public bool IsLogin { get; private set; }

    }
}
