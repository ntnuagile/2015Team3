using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject
{
    class UserDataBase
    {
        const int maxUserQua = 200;
        public int nowUserQua = 0; 
        private static User[] userDataBase = new User[maxUserQua];
        
            //註冊介面
            public bool RegisterInterface()
            {
                User newOne = new User();
                
                Console.WriteLine("The Register service:");
                Console.WriteLine();
                if(nowUserQua < 100)
                {
                    Console.WriteLine("Please input the Account Name that you want to register:");
                    newOne.SetAccount(Console.ReadLine());
                    Console.WriteLine("Please wait , the system is searching whether the account has been used before.");
                    while (SearchUserAccount(newOne.GetAccount()) != -1)
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

            private int SearchUserAccount(string s_account)
            {

                for (int index = 0; index < nowUserQua; ++index)
                {
                    if (string.Compare(s_account, userDataBase[index].GetAccount()) == 0)
                    {
                        return index;
                    }
                }
                return -1;
            }
            public void AddUser(User newOne)
            {
                userDataBase[nowUserQua] = newOne;
                nowUserQua += 1;
            }
            
            //登入時搜尋user資料庫
            public string IsAccountCorrect(string inputAccount , string inputPassword)
            {
                int index;
                for( index = 0 ; index < nowUserQua ; ++index)
                {
                    if(string.Compare(inputAccount , userDataBase[index].GetAccount()) == 0 )
                    {
                        if(string.Compare(inputPassword , userDataBase[index].GetPassword()) == 0)
                        {
                            return index.ToString();
                        }
                        else
                        {
                            return "WrongPassword";
                        }
                    }
                }
                return "NotFound";
            }

            //丟出某個USER
            
    }
    
}
