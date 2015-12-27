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
            DB.BlockName = "123";
            cate.AddCategory(DB);
            Assert.That(cate.SearchCate("123"), Is.EqualTo(0));
            Assert.That(cate.NumCategory, Is.EqualTo(1));
            cate.DeleteCate("123");
            Assert.That(cate.SearchCate("123"), Is.EqualTo(-1));
        }
    }
}
