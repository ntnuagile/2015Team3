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
            UserDataBase tudb = new UserDataBase();
            Assert.That(tudb.nowUserQua, Is.EqualTo(0));
            User newu = new User();
            newu.SetAccount("GG123");
            tudb.AddUser(newu);
            Assert.That(tudb.nowUserQua, Is.EqualTo(1));
            User cpyu;
            tudb.GetUser(out cpyu, 0);
            Assert.That(cpyu.GetAccount() , Is.EqualTo("GG123"));
        }
    }
}
