using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject.Tests
{
    [TestFixture]
    public class Sign_in
    {
        [Test]
        public void CheckUser()
        {
            User[] array = new User[5];
        }
       /* [Test]
        public void SearchbyTitle()
        {
            Article a = new Article(); //construct one article
            a.title = "haha";
            Assert.That(a.getTitle(),Is.EqualTo("haha"));

            Article[] b = new Article[5];
            b[0] = new Article() { title = "apple" };
            b[1] = new Article() { title = "banana" };
            b[2] = new Article() { title = "cat" };
            b[3] = new Article() { title = "cat" };
            b[4] = new Article() { title = "cat" };

            Assert.That(b[0].getTitle(),Is.EqualTo("apple"));
            Assert.That(b[1].getTitle(), Is.EqualTo("banana"));
            Assert.That(b[2].getTitle(), Is.EqualTo("cat"));
            Assert.That(b[3].getTitle(), Is.EqualTo("cat"));
            Assert.That(b[4].getTitle(), Is.EqualTo("cat"));


            int[] same = new int[5];
            for (int i = 0; i < b.Length;++i )
            {
                if(b[i].SameTitle("apple") == 0)
                {
                    same[i] = 1;
                }
            }
            Assert.That(same[0],Is.EqualTo(1));
            Assert.That(same[1], Is.EqualTo(0));
            Assert.That(same[2], Is.EqualTo(0));
            Assert.That(same[3], Is.EqualTo(0));
            Assert.That(same[4], Is.EqualTo(0));
            
        }*/
    }
}
