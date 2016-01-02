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

          

       }
     /*  [Test]
       public void SearchReplay()
       {
           int A_ID = 0;
           ReplyDataBase R = new ReplyDataBase();
           R.Article_ID = A_ID;

           Reply re = new Reply();
           re.user_account = "lala";
           re.Reply_content = "thanks";

           R.push(re);


           Reply re2 = new Reply();
           re2.user_account = "lili";
           re2.Reply_content = "aaaaaaa";

           R.push(re2);

           RD[0] = R;
           A_ID = 4;
           ReplyDataBase R1 = new ReplyDataBase();
           Reply re3 = new Reply();
           re3.user_account = "ruru";
           re3.Reply_content = "cccccccc";

           R1.push(re3);
           RD[4] = R1;
           Assert.That(RD[0].SearchReply("lala"), Is.EqualTo(0));
           Assert.That(RD[0].SearchReply("lili"), Is.EqualTo(1));
           Assert.That(RD[4].SearchReply("ruru"), Is.EqualTo(0));
           Assert.That(RD[4].SearchReply("lala"), Is.EqualTo(-1));
           
       }
       [Test]
       public void RemoveReplay()
       {
           int A_ID = 0;
           ReplyDataBase R = new ReplyDataBase();
           R.Article_ID = A_ID;

           Reply re = new Reply();
           re.user_account = "lala";
           re.Reply_content = "thanks";

           R.push(re);


           Reply re2 = new Reply();
           re2.user_account = "lili";
           re2.Reply_content = "aaaaaaa";

           R.push(re2);

          
           Reply re3 = new Reply();
           re3.user_account = "ruru";
           re3.Reply_content = "cccccccc";

           R.push(re3);
            
           RD[0] = R;


           Assert.That(RD[0].num, Is.EqualTo(3));
           RD[0].RemoveReply("lala");
           Assert.That(RD[0].num, Is.EqualTo(2));
           Assert.That(RD[0].RD[0].user_account, Is.EqualTo("lili"));

           Assert.That(RD[0].RemoveReply("lala"), Is.EqualTo(false));

            
         
       }
       [Test]
       public void EditReplay()
       {
           int A_ID = 0;
           ReplyDataBase R = new ReplyDataBase();
           R.Article_ID = A_ID;

           Reply re = new Reply();
           re.user_account = "lala";
           re.Reply_content = "thanks";

           R.push(re);


           Reply re2 = new Reply();
           re2.user_account = "lili";
           re2.Reply_content = "aaaaaaa";

           R.push(re2);

           RD[0] = R;
           A_ID = 4;
           ReplyDataBase R1 = new ReplyDataBase();
           Reply re3 = new Reply();
           re3.user_account = "ruru";
           re3.Reply_content = "cccccccc";

           R1.push(re3);
           RD[4] = R1;

           RD[0].EditReply("lala", "new_context");
           Assert.That(RD[0].RD[0].Reply_content, Is.EqualTo("new_context"));


           Assert.That(RD[0].EditReply("ruru", "new_context"), Is.EqualTo(false));


           RD[0].EditReply("lili", "nnnnnnnnn");
           Assert.That(RD[0].RD[1].Reply_content, Is.EqualTo("nnnnnnnnn"));
            

       }*/
    }
}
