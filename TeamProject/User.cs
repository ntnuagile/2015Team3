﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject
{
    public class User
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
        public bool IsLogin = false;
        //登出
        public void Logout()
        {
            if(IsLogin==true)
            IsLogin = false;
        }


        //給Article用的
        public int NumArticle = 0;
        public List<int> ArticleID = new List<int>();
        //發文紀錄
        public List<Record> ArticleRecord = new List<Record>();



        //關注版區
        public const int FocusBlockMaxNumber=10;
        public int FocusBlockNumber = 0;
        public string[] FocusBlock = new string[FocusBlockMaxNumber];
        //新增關注版區
        public void SetFocusBlock(string BlockName)
        {
            if(FocusBlockNumber<FocusBlockMaxNumber)
            {
                FocusBlock[FocusBlockNumber] = BlockName;
                ++FocusBlockNumber;
            }
        }
        //刪減關注版區
        public void DeleteFocusBlock(string BlockName)
        {
            int findindex = SearchBlock(BlockName);
            if(findindex!=-1)
            {
                for (int j = findindex + 1; j < FocusBlockNumber; ++j)
                {
                    FocusBlock[findindex] = FocusBlock[j];
                    ++findindex;
                }
                --FocusBlockNumber;
            }
        }
        //搜尋關注版區
        public int SearchBlock(string Name)
        {
            for(int i=0;i<FocusBlockNumber;++i)
            {
                if (FocusBlock[i] == Name) return i;
            }
            return -1;
        }

    }
    public class Record
    {
        public string BlockName = "";
        public int ArticleIndex = 0;
    }

    
}
