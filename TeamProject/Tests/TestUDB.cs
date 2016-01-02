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
        public void TestMD5()
        {
            UserDatabase newUDB = new UserDatabase();
            newUDB.SetUserDatabase();
            Assert.That(newUDB.GetMD5(""), Is.EqualTo("d41d8cd98f00b204e9800998ecf8427e"));
        }

        [Test]
        public void TestAddUser()
        {
            UserDatabase newUDB = new UserDatabase();
            newUDB.SetUserDatabase();
            Assert.That(newUDB.nowUserQuantity, Is.EqualTo(0));
            User newU = new User();
            newUDB.AddUser(newU);
            Assert.That(newUDB.nowUserQuantity, Is.EqualTo(1));
        }

        [Test]
        public void TestIsAccountAvaliable()
        {
            UserDatabase newUDB = new UserDatabase();
            newUDB.SetUserDatabase();
            Assert.That(newUDB.IsAccountAvaliable("12345"), Is.EqualTo(true));
            User newU = new User();
            newU.SetAccount("asdzxc");
            newUDB.AddUser(newU);
            Assert.That(newUDB.IsAccountAvaliable("asdzxc"), Is.EqualTo(false));
        }
        
        [Test]  
        public void TestSearchUser_Account()
        {
            UserDatabase newUDB = new UserDatabase();
            newUDB.SetUserDatabase();
            Assert.That(newUDB.SearchUser_Account("GG123"), Is.EqualTo(-1));
            User newU = new User();
            newU.SetAccount("GG123");
            newUDB.AddUser(newU);
            Assert.That(newUDB.SearchUser_Account("GG123"), Is.EqualTo(0));
        }
        
        [Test]
        public void TestSetANewUser()
        {
            UserDatabase newUDB = new UserDatabase();
            newUDB.SetUserDatabase();
            Assert.That(newUDB.nowUserQuantity, Is.EqualTo(0));
            Assert.That(newUDB.SetANewUser("asdzxc", "JAJA", 'M', "123123", "2016/01/01", "A123456789", newUDB.IsAccountAvaliable("asdzxc")), Is.EqualTo(true));
            Assert.That(newUDB.nowUserQuantity, Is.EqualTo(1));
            Assert.That(newUDB.SetANewUser("asdzxc", "AABB", 'F', "321321", "2016/11/11", "E123456789", newUDB.IsAccountAvaliable("asdzxc")), Is.EqualTo(false));
            Assert.That(newUDB.nowUserQuantity, Is.EqualTo(1));
        }

      
    }
}
