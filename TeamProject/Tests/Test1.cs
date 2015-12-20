using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject.Tests
{
    [TestFixture]
    public class Test1
    {
        //因為所有東西都是存在記憶體內 所以所有Test都得放在一起

        //不然註冊完的test之後 登入的test是看不到註冊的內容的

        //test 註冊

        //test 登入

        //test OOOO

        //test 發文
        ArticleDataBase DB = new ArticleDataBase();
       

        [Test]
        public void TestPublishes()
        {
            Article Art = new Article();
            Art.Title = "GG3B0";
            Art.AuthorID = 0;
            Art.Content.Add("123");

            Article Art2 = new Article();
            Art2.Title = "Asiagodtone";
            Art2.AuthorID = 4;
            Art2.Content.Add("GG");
            Art2.Content.Add("20FF");

            DB.publish(Art);
            DB.publish(Art2);

            Assert.That(DB.DB[0].ArticleIndex, Is.EqualTo(0));
            Assert.That(DB.DB[1].ArticleIndex, Is.EqualTo(1));

            Assert.That(DB.DB[0].AuthorID, Is.EqualTo(0));
            Assert.That(DB.DB[1].AuthorID, Is.EqualTo(4));

            Assert.That(DB.DB[0].Title, Is.EqualTo("GG3B0"));
            Assert.That(DB.DB[1].Title, Is.EqualTo("Asiagodtone"));

            Assert.That(DB.DB[0].Content[0], Is.EqualTo("123"));
            Assert.That(DB.DB[1].Content[0], Is.EqualTo("GG"));
            Assert.That(DB.DB[1].Content[1], Is.EqualTo("20FF"));
        }


        ReplyDataBase[] RD = new ReplyDataBase[100];
        [Test]
        public void PushReplay()
        {
            int A_ID = 0;
            ReplyDataBase R =new ReplyDataBase();
            R.Article_ID=A_ID;

            Reply  re=new Reply();
            re.user_name="lala";
            re.Reply_context="thanks";
           
            R.push(re);
            

            Reply re2 = new Reply();
            re2.user_name = "lili";
            re2.Reply_context = "aaaaaaa";

            R.push(re2);

            RD[0]=R;
            A_ID=4;
            ReplyDataBase R1 = new ReplyDataBase();
            Reply  re3=new Reply();
            re3.user_name="ruru";
            re3.Reply_context="cccccccc";

            R1.push(re3);
            RD[4] = R1;

            Assert.That(RD[0].num, Is.EqualTo(2));
            Assert.That(RD[0].RD[0].Reply_context, Is.EqualTo("thanks"));
            Assert.That(RD[0].RD[0].user_name, Is.EqualTo("lala"));


            Assert.That(RD[0].RD[1].Reply_context, Is.EqualTo("aaaaaaa"));
            Assert.That(RD[0].RD[1].user_name, Is.EqualTo("lili"));


            Assert.That(RD[4].num, Is.EqualTo(1));
            Assert.That(RD[4].RD[0].Reply_context, Is.EqualTo("cccccccc"));
            Assert.That(RD[4].RD[0].user_name, Is.EqualTo("ruru"));


        }

    }
}
