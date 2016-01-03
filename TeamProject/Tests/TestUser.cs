﻿using System;
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
        [Test]
        public void TestAddFocusBlock
        {
            User userW=new User();
            userW.SetFocusBlock(Smart);
            userW.SetFocusBlock(Ha);
            Assert.That(userW.SearchBlock(Smart),Is.EqaulTo(0));
            Assert.That(userW.searchBlock(Ha),Is.EqualTo(1));
            //測試10個還能不能加
            for(int i=0;i<8;++i)
            {
                userW.SetFocusBlock(Stupid);
            }
            userW.SetFocusBlock(Overflow)
            Assert.That(userW.searchBlock(Overflow),Is.EqualTo(-1));
        }
        [Test]
        public void TestDeleteFocusBlock
        {
            User userB=new User();
            userB.SetFocusBlock(Smart);
            userB.SetFocusBlock(Ha);
            userB.DeleteFocusBlock(Smart);
            Assert.That(userB.searchBlock(Smart),Is.EqualTo(-1));
            Assert.That(userB.searchBlock(Ha),Is.EqualTo(0));

        }

    }
}