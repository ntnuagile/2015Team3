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
        private static int nowUserQua = 0; 
        private static User[] userDataBase = new User[maxUserQua];
        class Register
        {
            private int SearchUserAccount(string s_name)
            {
                
                for(int index = 0 ; index < nowUserQua ; ++index)
                {
                    if(string.Compare(s_name , userDataBase[index].Account) == 0)
                    {
                        return index;
                    }
                }
                return -1;
            }
            public bool RegisterInterface()
            {
                string account_name;
                string nickname;
                string password;
                string birth;
                string id_number;
                char gender = '\0';

                Console.WriteLine("The Register service:");
                Console.WriteLine();
                Console.WriteLine("Please input the Account Name that you want to register:");
                account_name = Console.ReadLine();
                Console.WriteLine("Please wait , the system is searching whether the account has been used before.");
                while( SearchUserAccount(account_name) != -1 )
                {
                    Console.WriteLine("The account has been used. Please re-enter a account :");
                    account_name = Console.ReadLine();
                }
                Console.WriteLine("The name is available , please fill in the follow information:");
                Console.WriteLine("Your nickname: ");
                nickname = Console.ReadLine();
                Console.WriteLine("Your gender (M/F): ");
                gender = Console.ReadLine()[0];
                Console.WriteLine("Your password :");
                password = Console.ReadLine();
                Console.WriteLine("Your Birth (XXXX/XX/XX):");
                birth = Console.ReadLine();
                Console.WriteLine("Your ID number :");
                id_number = Console.ReadLine();
                userDataBase[nowUserQua].SetAccount(account_name);
                userDataBase[nowUserQua].SetName(nickname);
                userDataBase[nowUserQua].SetGender(gender);
                userDataBase[nowUserQua].SetPassword(password);
                userDataBase[nowUserQua].SetBirth(birth);
                userDataBase[nowUserQua].SetID(id_number);
                return true;
            }
        }
        

    }
    
}
