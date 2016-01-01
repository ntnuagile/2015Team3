using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using System.Security.Cryptography;
namespace TeamProject
{
    class UserDatabase
    {
        public const int maxUserQuantity = 200;
        public int nowUserQuantity = 0; 
        public User[] userDatabase = new User[maxUserQuantity];
            public void SetUserDatabase()
            {
                for(int i=0 ; i <maxUserQuantity ; ++i)
                {
                    userDatabase[i] = new User();
                }
            }
            //註冊
            public bool SetANewUser(string account,string name,char gender,string password,string birth, string id,bool pass)
            {
                if(pass == true)
                {
                    User newOne = new User();
                    newOne.SetAccount(account);
                    newOne.SetName(name);
                    newOne.SetGender(gender);
                    password = GetMD5(password);
                    newOne.SetPassword(password);
                    newOne.SetBirth(birth);
                    newOne.SetID(id);
                    AddUser(newOne);
                    return true;
                }
                return false;
            }
            public bool IsAccountAvaliable(string account)
            {
                for(int i=0 ; i<nowUserQuantity ; ++i)
                {
                    if(string.Compare(account , userDatabase[i].GetAccount()) == 0)
                    {
                        return false;
                    }
                }
                return true;
            }
            public string GetMD5(string text)
            {
                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));
                byte[] result = md5.Hash;
                StringBuilder str = new StringBuilder(32);
                for (int i = 0; i < result.Length; i++)
                {
                    str.Append(result[i].ToString("X2").ToLower());
                }
                return str.ToString();
            }
            public int SearchUser_Account(string s_account)
            {

                for (int index = 0; index <= nowUserQuantity; ++index)
                {
                     if (string.Compare(s_account, userDatabase[index].GetAccount()) == 0)
                    {
                        return index;
                    }
                }
                return -1;
            }
            public void AddUser(User newOne)
            {
                userDatabase[nowUserQuantity] = newOne;
                nowUserQuantity += 1;
            }
            //確認帳密
            public bool CheckUserSignIn(String UserAccount, String UserPassword)
            {
                int index = SearchUser_Account(UserAccount);
                if(index!=-1)
                {
                    if(string.Compare(userDatabase[index].GetPassword(),GetMD5(UserPassword))==0)
                    {
                        
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("The Password is wrong!!");
                        Console.WriteLine("Please check your password.");
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine("We can't find this User");
                    Console.WriteLine("Please check your account.");
                    return false;
                }
            }
           
            
           
    }
    
}
