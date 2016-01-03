using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject.Tests
{
    [TestFixture]
    class TestCate
    {
        [Test]
        public void TestC()
        {
            Category cate=new Category();
            ArticleDataBase DB = new ArticleDataBase();
            ArticleDataBase DB2 = new ArticleDataBase();
            ArticleDataBase DB3 = new ArticleDataBase();
            DB.BlockName = "123";
            DB2.BlockName = "abc";
            DB3.BlockName = "555";
            cate.AddCategory(DB);
            cate.AddCategory(DB2);
            cate.AddCategory(DB3);
            cate.GetADB(1);
            cate.GetADB(1);
            Assert.That(cate.SearchCate("123"), Is.EqualTo(0));
            Assert.That(cate.SearchCate("abc"), Is.EqualTo(1));
            Assert.That(cate.NumCategory, Is.EqualTo(3));
            cate.DeleteCate("abc");
            Assert.That(cate.SearchCate("abc"), Is.EqualTo(-1));
        }
    }
}
