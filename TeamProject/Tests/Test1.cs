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

        [Test]
        public void TestAddArticle()
        {
            ArticleDataBase DB = new ArticleDataBase();

            User newU1 = new User();
            newU1.IsLogin = true;
            newU1.SetAccount("mistake");

            User newU2 = new User();
            newU2.IsLogin = false;
            newU2.SetAccount("bebe");

            List<string> Content1 = new List<string>();
            List<string> Content2 = new List<string>();
            List<string> Content3 = new List<string>();

            Content1.Add("123");
            Content2.Add("GG");
            Content2.Add("20FF");
            Content3.Add("GGG");

            Assert.That(DB.AddArticle(newU1, "GG3B0", Content1), Is.EqualTo(true));
            
            Assert.That(DB.NumArticle, Is.EqualTo(1));
            Assert.That(DB.DB[0].ArticleIndex, Is.EqualTo(0));
            Assert.That(DB.DB[0].AuthorAccount, Is.EqualTo("mistake"));
            Assert.That(DB.DB[0].Title, Is.EqualTo("GG3B0"));
            Assert.That(DB.DB[0].Content[0], Is.EqualTo("123"));
            Assert.That(newU1.NumArticle, Is.EqualTo(1));
            Assert.That(newU1.ArticleID[0], Is.EqualTo(0));

            Assert.That(DB.AddArticle(newU2, "Asiagodtone", Content2), Is.EqualTo(false));
            Assert.That(DB.NumArticle, Is.EqualTo(1));

            newU2.IsLogin = true;
            Assert.That(DB.AddArticle(newU2, "Asiagodtone", Content2), Is.EqualTo(true));
            Assert.That(DB.NumArticle, Is.EqualTo(2));
            Assert.That(DB.DB[1].ArticleIndex, Is.EqualTo(1));
            Assert.That(DB.DB[1].AuthorAccount, Is.EqualTo("bebe"));
            Assert.That(DB.DB[1].Title, Is.EqualTo("Asiagodtone"));
            Assert.That(DB.DB[1].Content[0], Is.EqualTo("GG"));
            Assert.That(DB.DB[1].Content[1], Is.EqualTo("20FF"));
            Assert.That(newU2.NumArticle, Is.EqualTo(1));
            Assert.That(newU2.ArticleID[0], Is.EqualTo(1));

            Assert.That(DB.AddArticle(newU1, "TPA", Content3), Is.EqualTo(true));
            Assert.That(DB.NumArticle, Is.EqualTo(3));
            Assert.That(newU1.NumArticle, Is.EqualTo(2));
            Assert.That(newU1.ArticleID[0], Is.EqualTo(0));
            Assert.That(newU1.ArticleID[1], Is.EqualTo(2));

            for (int i = 0; i < 97; i++)
            {
                DB.AddArticle(newU1, "TPA", Content3);
            }

            Assert.That(DB.NumArticle, Is.EqualTo(100));
            Assert.That(newU1.NumArticle, Is.EqualTo(99));
            Assert.That(DB.AddArticle(newU1, "TPA", Content3), Is.EqualTo(false));
        }


        [Test]
        public void TestSearchArticle()
        {
            ArticleDataBase DB = new ArticleDataBase();

            User newU1 = new User();
            newU1.IsLogin = true;
            newU1.SetAccount("mistake");

            User newU2 = new User();
            newU2.IsLogin = true;
            newU2.SetAccount("bebe");

            List<string> Content1 = new List<string>();
            List<string> Content2 = new List<string>();
            List<string> Content3 = new List<string>();

            Content1.Add("123");
            Content2.Add("456");
            Content3.Add("789");

            DB.AddArticle(newU1, "GG3B0", Content1);
            DB.AddArticle(newU2, "GG3B1", Content2);
            DB.AddArticle(newU1, "TPA", Content3);

            Assert.That(DB.NumArticle, Is.EqualTo(3));

            List<Article> result = new List<Article>();

            result = DB.SearchByAuthor("mistake");
            Assert.That(result.Count, Is.EqualTo(2));
            Assert.That(result[0].Title, Is.EqualTo("GG3B0"));
            Assert.That(result[1].Title, Is.EqualTo("TPA"));

            result = DB.SearchByAuthor("mistake2");
            Assert.That(result.Count, Is.EqualTo(0));

            result = DB.SearchByAuthor("bebe");
            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result[0].Title, Is.EqualTo("GG3B1"));

            result = DB.SearchByTitle("GG3B0");
            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result[0].AuthorAccount, Is.EqualTo("mistake"));

            result = DB.SearchByTitle("GG");
            Assert.That(result.Count, Is.EqualTo(2));
            Assert.That(result[0].Title, Is.EqualTo("GG3B0"));
            Assert.That(result[1].Title, Is.EqualTo("GG3B1"));

            result = DB.SearchByTitle("None");
            Assert.That(result.Count, Is.EqualTo(0));
        }


        [Test]
        public void TestRemoveArticle()
        {
            ArticleDataBase DB = new ArticleDataBase();

            User newU1 = new User();
            newU1.IsLogin = true;
            newU1.SetAccount("mistake");

            User newU2 = new User();
            newU2.IsLogin = true;
            newU2.SetAccount("bebe");

            List<string> Content1 = new List<string>();
            List<string> Content2 = new List<string>();
            List<string> Content3 = new List<string>();
            List<string> Content4 = new List<string>();

            Content1.Add("123");
            Content2.Add("456");
            Content3.Add("789");
            Content4.Add("aaaa");

            DB.AddArticle(newU1, "GG3B0", Content1);
            DB.AddArticle(newU2, "GG3B0", Content2);
            DB.AddArticle(newU1, "TPA", Content3);
            DB.AddArticle(newU1, "TPS", Content4);

            Assert.That(DB.NumArticle, Is.EqualTo(4));

            newU1.IsLogin = false;
            Assert.That(DB.RemoveArticle(newU1, DB.DB[0]), Is.EqualTo(false));
            Assert.That(DB.NumArticle, Is.EqualTo(4));

            newU1.IsLogin = true;
            Assert.That(DB.RemoveArticle(newU1, DB.DB[0]), Is.EqualTo(true));
            Assert.That(DB.NumArticle, Is.EqualTo(3));
            Assert.That(DB.DB[0].Title, Is.EqualTo("GG3B0"));
            Assert.That(DB.DB[0].AuthorAccount, Is.EqualTo("bebe"));
            Assert.That(newU1.NumArticle, Is.EqualTo(2));
            Assert.That(newU1.ArticleID[0], Is.EqualTo(2));
            Assert.That(newU1.ArticleID[1], Is.EqualTo(3));

            Assert.That(DB.RemoveArticle(newU2, DB.DB[1]), Is.EqualTo(false));
            Assert.That(DB.NumArticle, Is.EqualTo(3));

            Assert.That(DB.RemoveArticle(newU1, DB.DB[2]), Is.EqualTo(true));
            Assert.That(DB.NumArticle, Is.EqualTo(2));
            Assert.That(newU1.NumArticle, Is.EqualTo(1));
            Assert.That(newU1.ArticleID[0], Is.EqualTo(2));
        }


        [Test]
        public void TestModifyArticle()
        {
            ArticleDataBase DB = new ArticleDataBase();

            User newU1 = new User();
            newU1.IsLogin = true;
            newU1.SetAccount("mistake");

            User newU2 = new User();
            newU2.IsLogin = true;
            newU2.SetAccount("bebe");

            List<string> Content1 = new List<string>();
            List<string> Content2 = new List<string>();

            Content1.Add("123");
            Content1.Add("456");
            Content2.Add("789");
            Content2.Add("aaaa");
            Content2.Add("bbbb");

            DB.AddArticle(newU1, "SKT", Content1);
            DB.AddArticle(newU1, "TPA", Content2);

            newU1.IsLogin = false;
            Assert.That(DB.ModifyArticle(newU1, DB.DB[0], "TPS", Content2), Is.EqualTo(false));

            newU1.IsLogin = true;
            Assert.That(DB.ModifyArticle(newU1, DB.DB[0], "TPS", Content2), Is.EqualTo(true));
            Assert.That(DB.DB[0].Title, Is.EqualTo("TPS"));
            Assert.That(DB.DB[0].Content.Count, Is.EqualTo(3));
            Assert.That(DB.DB[0].Content[0], Is.EqualTo("789"));
            Assert.That(DB.DB[0].Content[1], Is.EqualTo("aaaa"));
            Assert.That(DB.DB[0].Content[2], Is.EqualTo("bbbb"));

            Assert.That(DB.ModifyArticle(newU2, DB.DB[0], "AsianGodTone", Content2), Is.EqualTo(false));
        }


        [Test]
        public void TestGPnBP()
        {
            ArticleDataBase DB = new ArticleDataBase();

            User newU1 = new User();
            newU1.IsLogin = true;
            newU1.SetAccount("mistake");

            User newU2 = new User();
            newU2.IsLogin = true;
            newU2.SetAccount("bebe");

            User newU3 = new User();
            newU3.IsLogin = true;
            newU3.SetAccount("toyz");

            User newU4 = new User();
            newU4.IsLogin = true;
            newU4.SetAccount("dinter");

            User newU5 = new User();
            newU5.IsLogin = false;
            newU5.SetAccount("westdoor");

            List<string> Content1 = new List<string>();

            Content1.Add("HKE eat shit");
            Content1.Add("by mistake");

            DB.AddArticle(newU1, "TPA", Content1);

            Assert.That(DB.DB[0].GoodPoint, Is.EqualTo(0));
            Assert.That(DB.DB[0].BadPoint, Is.EqualTo(0));

            Assert.That(DB.GPtoArticle(newU1, DB.DB[0]), Is.EqualTo(false)); //mistake
            Assert.That(DB.DB[0].GoodPoint, Is.EqualTo(0));
            Assert.That(DB.DB[0].BadPoint, Is.EqualTo(0));

            Assert.That(DB.GPtoArticle(newU2, DB.DB[0]), Is.EqualTo(true)); //bebe
            Assert.That(DB.DB[0].GoodPoint, Is.EqualTo(1));
            Assert.That(DB.DB[0].BadPoint, Is.EqualTo(0));

            Assert.That(DB.GPtoArticle(newU2, DB.DB[0]), Is.EqualTo(false)); //bebe
            Assert.That(DB.DB[0].GoodPoint, Is.EqualTo(1));
            Assert.That(DB.DB[0].BadPoint, Is.EqualTo(0));

            Assert.That(DB.BPtoArticle(newU3, DB.DB[0]), Is.EqualTo(true)); //toyz
            Assert.That(DB.DB[0].GoodPoint, Is.EqualTo(1));
            Assert.That(DB.DB[0].BadPoint, Is.EqualTo(1));

            Assert.That(DB.BPtoArticle(newU4, DB.DB[0]), Is.EqualTo(true)); //dinter
            Assert.That(DB.DB[0].GoodPoint, Is.EqualTo(1));
            Assert.That(DB.DB[0].BadPoint, Is.EqualTo(2));

            Assert.That(DB.BPtoArticle(newU5, DB.DB[0]), Is.EqualTo(false)); //westdoor
            Assert.That(DB.DB[0].GoodPoint, Is.EqualTo(1));
            Assert.That(DB.DB[0].BadPoint, Is.EqualTo(2));

            newU5.IsLogin = true;
            Assert.That(DB.BPtoArticle(newU5, DB.DB[0]), Is.EqualTo(true)); //westdoor
            Assert.That(DB.DB[0].GoodPoint, Is.EqualTo(1));
            Assert.That(DB.DB[0].BadPoint, Is.EqualTo(3));

            Assert.That(DB.GPtoArticle(newU5, DB.DB[0]), Is.EqualTo(false)); //westdoor
            Assert.That(DB.DB[0].GoodPoint, Is.EqualTo(1));
            Assert.That(DB.DB[0].BadPoint, Is.EqualTo(3));

            Assert.That(DB.DB[0].GPList.Count, Is.EqualTo(1));
            Assert.That(DB.DB[0].GPList[0], Is.EqualTo("bebe"));

            Assert.That(DB.DB[0].BPList.Count, Is.EqualTo(3));
            Assert.That(DB.DB[0].BPList[0], Is.EqualTo("toyz"));
            Assert.That(DB.DB[0].BPList[1], Is.EqualTo("dinter"));
            Assert.That(DB.DB[0].BPList[2], Is.EqualTo("westdoor"));
        }


        [Test]
        public void TestSortArticle()
        {
            ArticleDataBase DB = new ArticleDataBase();

            User newU1 = new User();
            newU1.IsLogin = true;
            newU1.SetAccount("mistake");

            User newU2 = new User();
            newU2.IsLogin = true;
            newU2.SetAccount("bebe");

            List<string> Content1 = new List<string>();
            List<string> Content2 = new List<string>();
            List<string> Content3 = new List<string>();

            Content1.Add("123");
            Content2.Add("456");
            Content3.Add("789");

            DB.AddArticle(newU1, "BBB", Content1);
            DB.AddArticle(newU2, "DDDD", Content2);
            DB.AddArticle(newU1, "CCC", Content3);

            DB.SotrByTitle();

            Assert.That(DB.DB[0].Title, Is.EqualTo("BBB"));
            Assert.That(DB.DB[1].Title, Is.EqualTo("CCC"));
            Assert.That(DB.DB[2].Title, Is.EqualTo("DDDD"));

            DB.SotrByTime();

            Assert.That(DB.DB[0].Title, Is.EqualTo("BBB"));
            Assert.That(DB.DB[1].Title, Is.EqualTo("DDDD"));
            Assert.That(DB.DB[2].Title, Is.EqualTo("CCC"));
        }

        //**************************************************************************//
        //                                                                          //
        //               GG3B0~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~             //
        //                                                                          //
        //**************************************************************************//

        
    }
}
