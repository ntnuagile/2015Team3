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
        public void TestSinglePublish()
        {
            Article Art = new Article();
            Art.Title = "Test1";
            Art.AuthorID = DB.NumArticle;
            Art.Content.Add("123");
            Art.Content.Add("456");

            DB.publish(Art);

            Assert.That(DB.DB[0].ArticleIndex, Is.EqualTo(0));
            Assert.That(DB.DB[0].AuthorID, Is.EqualTo(0));
            Assert.That(DB.DB[0].Title, Is.EqualTo("Test1"));
            Assert.That(DB.DB[0].Content[0], Is.EqualTo("123"));
            Assert.That(DB.DB[0].Content[1], Is.EqualTo("456"));
        }

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

            Assert.That(DB.DB[1].ArticleIndex, Is.EqualTo(1));
            Assert.That(DB.DB[2].ArticleIndex, Is.EqualTo(2));
        }

        //test XXXX

    }
}
