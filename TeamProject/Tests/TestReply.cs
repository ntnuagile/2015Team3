using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject.Tests
{
    [TestFixture]
    class TestReply
    {
        [Test]
        public void PushReplay()
        {
            Article a = new Article();
            a.ArticleIndex = 1;
            a.AuthorAccount = "u1";

            User u1 = new User();
            u1.IsLogin = true;
            u1.SetAccount("u1");

            User u2 = new User();
            u2.IsLogin = true;
            u2.SetAccount("u2");



            a.RD.PushReply("aaa", u1);

            Assert.That(a.RD.num, Is.EqualTo(1));
            Assert.That(a.RD.RD[0].Reply_content, Is.EqualTo("aaa"));
            Assert.That(a.RD.RD[0].user_account, Is.EqualTo("u1"));

            a.RD.PushReply("bbb", u2);

            Assert.That(a.RD.num, Is.EqualTo(2));
            Assert.That(a.RD.RD[1].Reply_content, Is.EqualTo("bbb"));
            Assert.That(a.RD.RD[1].user_account, Is.EqualTo("u2"));

            User u3 = new User();
            u3.IsLogin = false;
            u3.SetAccount("u3");

            Assert.That(a.RD.PushReply("ccc", u3), Is.EqualTo(false));
            Assert.That(a.RD.num, Is.EqualTo(2));

            u3.IsLogin = true;
            Assert.That(a.RD.PushReply("ccc", u3), Is.EqualTo(true));
            Assert.That(a.RD.num, Is.EqualTo(3));
            Assert.That(a.RD.RD[2].Reply_content, Is.EqualTo("ccc"));
            Assert.That(a.RD.RD[2].user_account, Is.EqualTo("u3"));



        }
        [Test]
        public void ReplayAdress()
        {
            Article a = new Article();
            a.ArticleIndex = 1;
            a.AuthorAccount = "u1";

            User u1 = new User();
            u1.IsLogin = true;
            u1.SetAccount("u1");

            User u2 = new User();
            u2.IsLogin = true;
            u2.SetAccount("u2");

            User u3 = new User();
            u3.IsLogin = true;
            u3.SetAccount("u3");


            a.RD.PushReply("aaa", u1);
            a.RD.PushReply("bbb", u2);
            a.RD.PushReply("ccc", u3);



            Assert.That(a.RD.ReplyAddress("u1"), Is.EqualTo(0));
            Assert.That(a.RD.ReplyAddress("u2"), Is.EqualTo(1));
            Assert.That(a.RD.ReplyAddress("u5"), Is.EqualTo(-1));

            a.RD.RemoveReply(u1);
            Assert.That(a.RD.ReplyAddress("u2"), Is.EqualTo(0));

        }
        [Test]
        public void SearchReplay()
        {
            Article a = new Article();
            a.ArticleIndex = 1;
            a.AuthorAccount = "u1";

            User u1 = new User();
            u1.IsLogin = true;
            u1.SetAccount("u1");

            User u2 = new User();
            u2.IsLogin = true;
            u2.SetAccount("u2");

            User u3 = new User();
            u3.IsLogin = true;
            u3.SetAccount("u3");


            a.RD.PushReply("aaa", u1);
            a.RD.PushReply("bbb", u2);
            a.RD.PushReply("ccc", u3);

            Reply r1 = new Reply();
            r1.user_account = "u1";
            r1.Reply_content = "aaa";
            r1.index = 0;

            Assert.That(a.RD.SearchReply("u1").index, Is.EqualTo(r1.index));
            Assert.That(a.RD.SearchReply("u1").Reply_content, Is.EqualTo(r1.Reply_content));
            Assert.That(a.RD.SearchReply("u1").user_account, Is.EqualTo(r1.user_account));

            Reply r2 = new Reply();
            r2.user_account = "u2";
            r2.Reply_content = "bbb";
            r2.index = 1;

            Assert.That(a.RD.SearchReply("u2").index, Is.EqualTo(r2.index));
            Assert.That(a.RD.SearchReply("u2").Reply_content, Is.EqualTo(r2.Reply_content));
            Assert.That(a.RD.SearchReply("u2").user_account, Is.EqualTo(r2.user_account));


        }
        [Test]
        public void RemoveReply()
        {
            Article a = new Article();
            a.ArticleIndex = 1;
            a.AuthorAccount = "u1";

            User u1 = new User();
            u1.IsLogin = true;
            u1.SetAccount("u1");

            User u2 = new User();
            u2.IsLogin = true;
            u2.SetAccount("u2");


            User u3 = new User();
            u3.IsLogin = true;
            u3.SetAccount("u3");

            a.RD.PushReply("aaa", u1);
            a.RD.PushReply("bbb", u2);
            a.RD.PushReply("ccc", u3);

            Assert.That(a.RD.num, Is.EqualTo(3));


            u1.IsLogin = false;
            Assert.That(a.RD.ReplyAddress("u1"), Is.EqualTo(0));
            Assert.That(a.RD.RemoveReply(u1), Is.EqualTo(false));
            u1.IsLogin = true;
            Assert.That(a.RD.RemoveReply(u1), Is.EqualTo(true));
            Assert.That(a.RD.ReplyAddress("u1"), Is.EqualTo(-1));
            Assert.That(a.RD.num, Is.EqualTo(2));


            Assert.That(a.RD.ReplyAddress("u2"), Is.EqualTo(0));
            Assert.That(a.RD.RemoveReply(u2), Is.EqualTo(true));
            Assert.That(a.RD.ReplyAddress("u2"), Is.EqualTo(-1));
            Assert.That(a.RD.num, Is.EqualTo(1));

            Assert.That(a.RD.RemoveReply(u1), Is.EqualTo(false));





        }
        [Test]
        public void EditReplay()
        {
            Article a = new Article();
            a.ArticleIndex = 1;
            a.AuthorAccount = "u1";

            User u1 = new User();
            u1.IsLogin = true;
            u1.SetAccount("u1");

            User u2 = new User();
            u2.IsLogin = true;
            u2.SetAccount("u2");


            User u3 = new User();
            u3.IsLogin = true;
            u3.SetAccount("u3");

            a.RD.PushReply("aaa", u1);
            a.RD.PushReply("bbb", u2);
            a.RD.PushReply("ccc", u3);


            Assert.That(a.RD.RD[0].Reply_content, Is.EqualTo("aaa"));
            Assert.That(a.RD.RD[0].user_account, Is.EqualTo("u1"));

            u1.IsLogin = false;
            Assert.That(a.RD.EditReply(u1, "can't change"), Is.EqualTo(false));
            Assert.That(a.RD.RD[0].Reply_content, Is.EqualTo("aaa"));

            u1.IsLogin = true;
            Assert.That(a.RD.EditReply(u1, "change a"), Is.EqualTo(true));
            Assert.That(a.RD.RD[0].Reply_content, Is.EqualTo("change a"));

            a.RD.RemoveReply(u1);

            Assert.That(a.RD.EditReply(u1, "can't change again"), Is.EqualTo(false));

            Assert.That(a.RD.EditReply(u2, "change b"), Is.EqualTo(true));
            Assert.That(a.RD.RD[0].Reply_content, Is.EqualTo("change b"));


        }
    }
}
