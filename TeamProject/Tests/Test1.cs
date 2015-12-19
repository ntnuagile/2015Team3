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
        public void TestPublish()
        {
            string Title = "Article1";
            List<string> Content = new List<string>();

            Content.Add("I am Stupid");
            Content.Add("Second Line");

            DB.publish(0, Title, Content);

           // Assert.That(DB.DB[0].ArticleIndex, Is.EqualTo(0));
        }

        //test XXXX

    }
}
