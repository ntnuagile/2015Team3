using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject.Tests
{
    [TestFixture]
    public class TestUDB
    {
        [Test]
        public void TestAddUser( )
        {
            UserDatabase newUDB = new UserDatabase();
            newUDB.SetUserDatabase();
            
            Assert.That(newUDB.nowUserQuantity, Is.EqualTo(0));
            User addOne = new User();
            addOne.SetAccount("jj123");
            addOne.SetBirth("1995/05/01");
            addOne.SetGender('M');
            addOne.SetID("E123456789");
            addOne.SetName("Jackeeeeeee");
            addOne.SetPassword(newUDB.GetMD5("asdzxc123"));
            newUDB.AddUser(addOne);
            //Test AddUser() 
            Assert.That(newUDB.nowUserQuantity, Is.EqualTo(1));
            Assert.That(newUDB.userDatabase[0].GetAccount(), Is.EqualTo(addOne.GetAccount()));
            Assert.That(newUDB.userDatabase[0].GetBirth(), Is.EqualTo(addOne.GetBirth()));
            Assert.That(newUDB.userDatabase[0].GetGender(), Is.EqualTo(addOne.GetGender()));
            Assert.That(newUDB.userDatabase[0].GetID(), Is.EqualTo(addOne.GetID()));
            Assert.That(newUDB.userDatabase[0].GetName(), Is.EqualTo(addOne.GetName()));
            Assert.That(newUDB.userDatabase[0].GetPassword(), Is.EqualTo(addOne.GetPassword()));
            //Test SearchUser_Account()
            Assert.That(newUDB.SearchUser_Account("jj123"), Is.EqualTo(0));
            //Test SetANewUser()
            newUDB.SetANewUser("asdzxc", "balabala", 'M', "987654321", "2015/12/31", "A123456789",newUDB.IsAccountAvaliable("asdzxc"));
            Assert.That(newUDB.nowUserQuantity, Is.EqualTo(2));
            Assert.That(newUDB.userDatabase[1].GetAccount(), Is.EqualTo("asdzxc"));
            Assert.That(newUDB.userDatabase[1].GetBirth(), Is.EqualTo("2015/12/31"));
            Assert.That(newUDB.userDatabase[1].GetGender(), Is.EqualTo('M'));
            Assert.That(newUDB.userDatabase[1].GetID(), Is.EqualTo("A123456789"));
            Assert.That(newUDB.userDatabase[1].GetName(), Is.EqualTo("balabala"));
            Assert.That(newUDB.userDatabase[1].GetPassword(), Is.EqualTo(newUDB.GetMD5("987654321")));
        }

        
        [Test]
        public void TestCheckUser()
        {
            UserDatabase newUDB = new UserDatabase();
            newUDB.SetUserDatabase();
            User one = new User();
            one.SetAccount("kkk123");
            one.SetPassword(newUDB.GetMD5("issecret"));
            newUDB.AddUser(one);
            Assert.That(newUDB.CheckUserSignIn("kkk123", "issecret"), Is.EqualTo(true));
        }
    }
}
