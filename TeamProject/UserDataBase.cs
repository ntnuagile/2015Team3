using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject
{
    class UserDatabase
    {
        public const int maxUserQuantity = 200;
        public int nowUserQuantity = 0; 
        public User[] userDatabase = new User[maxUserQuantity];
        
	
		 
            public void SetUserDatabase()
            {
                for(int i=0 ; i < maxUserQuantity ; ++i)
                {
                    userDatabase[i] = new User();
                }
            }
            //註冊介面
            public bool RegisterInterface()
            {
                User newOne = new User();
                
                Console.WriteLine("The Register service:");
                Console.WriteLine();
                if(nowUserQuantity < maxUserQuantity)
                {
                    Console.WriteLine("Please input the Account Name that you want to register:");
                    newOne.SetAccount(Console.ReadLine());
                    Console.WriteLine("Please wait , the system is searching whether the account has been used before.");
                    while (SearchUser_Account(newOne.GetAccount()) != -1)
                    {
                        Console.WriteLine("The account has been used. Please re-enter a account :");
                        newOne.SetAccount(Console.ReadLine());
                    }
                    Console.WriteLine("The name is available , do you want to create your account?(Y/N)");
                    Console.WriteLine("If you press N , than you will back to the main page :");

                    if (Console.ReadLine()[0] == 'Y')
                    {
                        Console.WriteLine("Now, please input the following information :");
                        Console.WriteLine("Your nickname: ");
                        newOne.SetName(Console.ReadLine());
                        Console.WriteLine("Your gender (M/F): ");
                        newOne.SetGender(Console.ReadLine()[0]);
                        Console.WriteLine("Your password :");
                        newOne.SetPassword(Console.ReadLine());
                        Console.WriteLine("Your Birth (XXXX/XX/XX):");
                        newOne.SetBirth(Console.ReadLine());
                        Console.WriteLine("Your ID number :");
                        newOne.SetID(Console.ReadLine());
                        AddUser(newOne);
                        Console.WriteLine();
                        Console.WriteLine("The account is available now , back to the main page.");
                        Console.Read();
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Now, back to the main page.");
                        Console.Read();
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine("The user quantity reached the limit , back to the main page.");
                    Console.Read();
                    return false;
                }
                
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
                    if(string.Compare(userDatabase[index].GetPassword(),UserPassword)==0)
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
            //登入畫面
            public void SignIn()
            {
                String Account, Password;
                Console.WriteLine("Please input your Account:");
                Account=Console.ReadLine();
                Console.WriteLine("Please input your Password:");
                Password = Console.ReadLine();
                if(CheckUserSignIn(Account,Password)==true)
                {
                    Console.WriteLine("Welcome back ");
                }
                else
                {
                    
                    
                }
            }
            
           
    }
    
}
