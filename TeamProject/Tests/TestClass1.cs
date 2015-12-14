using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject.Tests
{
    [TestFixture]
    public class TestClass1
    {
        [Test]
        public void AddUser()
        {
            User new_user = new User();
            Lists list = new Lists();
            list.add(new_user);
            Assert.That(list.number(),Is.EqualTo(1));

        }
        [Test]
        public void Test2()
        {
            Assert.That('A' + 1, Is.EqualTo('B'));
        }

        [Test]
        public void Test3()
        {
            Assert.That(6, Is.EqualTo(6));
        }
    }
}
