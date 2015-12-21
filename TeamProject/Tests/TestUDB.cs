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
            addOne.SetPassword("asdzxc123");
            newUDB.AddUser(addOne);
            User addTwo = new User();
            addTwo.SetAccount("bnm321");
            addTwo.SetBirth("1996/05/01");
            addTwo.SetGender('F');
            addTwo.SetID("F123456789");
            addTwo.SetName("Backeeeeeee");
            addTwo.SetPassword("Asdzxc123");
            newUDB.AddUser(addTwo);
            //Test AddUser() 
            Assert.That(newUDB.nowUserQuantity, Is.EqualTo(2));
            Assert.That(newUDB.userDatabase[0].GetAccount(), Is.EqualTo(addOne.GetAccount()));
            Assert.That(newUDB.userDatabase[0].GetBirth(), Is.EqualTo(addOne.GetBirth()));
            Assert.That(newUDB.userDatabase[0].GetGender(), Is.EqualTo(addOne.GetGender()));
            Assert.That(newUDB.userDatabase[0].GetID(), Is.EqualTo(addOne.GetID()));
            Assert.That(newUDB.userDatabase[0].GetName(), Is.EqualTo(addOne.GetName()));
            Assert.That(newUDB.userDatabase[0].GetPassword(), Is.EqualTo(addOne.GetPassword()));
            //Test SearchUser_Account()
            Assert.That(newUDB.SearchUser_Account("jj123"), Is.EqualTo(0));
            Assert.That(newUDB.SearchUser_Account("bnm321"), Is.EqualTo(1));

        }
    }
}
