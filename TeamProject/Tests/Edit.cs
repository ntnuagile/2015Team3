using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject.Tests
{
    class userEditor
    {
        public User edit()
        {
            Console.WriteLine("Before re-editing the data, ");
            Console.WriteLine("please re-enter your name: ");
            Console.WriteLine();

            string userName = Console.ReadLine();           

            User oldUser = new User();

            UserDatabase userDatabase = new UserDatabase();

            oldUser = userDatabase.userDatabase[userDatabase.SearchUser_Account(userName)];

            char ch;
            do
            {
                Console.WriteLine("1. Re-input your nickname\n");
                Console.WriteLine("2. Re-input your gender\n");
                Console.WriteLine("3. Re-input your password\n");
                Console.WriteLine("4. Re-input your birthday\n");
                Console.WriteLine("5. Re-input your id\n");
                Console.WriteLine("6. To quit.\n");
                
                Console.WriteLine("Please select the option: 1 or 2 ...etc.");
                                
                ch = (char) Console.Read();
                switch(ch)
                {
                    case '1':
                        Console.WriteLine("Please re-enter your nickname: ");
                        oldUser.SetName(Console.ReadLine());
                        break;
                    case '2':
                        Console.WriteLine("Please re-enter your gender: ");
                        oldUser.SetGender(Console.ReadLine()[0]);
                        break;
                    case '3':
                        Console.WriteLine("Please re-enter your password: ");
                        oldUser.SetPassword(Console.ReadLine());
                        break;
                    case '4':
                        Console.WriteLine("Please re-enter your birthday: ");
                        oldUser.SetBirth(Console.ReadLine());
                        break;
                    case '5':
                        Console.WriteLine("Please re-enter your id: ");
                        oldUser.SetID(Console.ReadLine());
                        break;
                }
            } while(ch != '6');

            return oldUser;
         }        

    }
}




