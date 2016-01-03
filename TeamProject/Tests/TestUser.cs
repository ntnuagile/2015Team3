using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TeamProject.Tests
{
    [TestFixture]
    public class TestUser
    {
        User userA=new User(); 
        [Test]
        public void TestAddFocusBlock
        {
            //User userFuck=new User();
            userA.SetFocusBlock(Smart);
            userA.SetFocusBlock(Ha);
            Assert.That(SearchBlock(Smart),Is.EqaulTo(0));
            //測試10個還能不能加
            for(int i=0;i<8;++i)userA.SetFocusBlock(Stupid);
            userA.SetFocusBlock(Overflow)
            Assert.That(searchBlock(Overflow),Is.EqualTo(-1));
        }
        [Test]
        public void TestDeleteFocusBlock
        {
            //User userB=new User();
            userA.DeleteFocusBlock(Smart);
            Assert.That(searchBlock(Smart),Is.EqualTo(-1));
            Assert.That(searchBlock(Ha),Is.EqualTo(0));
        }

    }
}
