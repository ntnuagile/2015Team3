using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject
{
    class Article
    {
        public string Title;
        public string[] Content = new string[20];
        public int AuthorID;
        public int ArticleIndex;

        void publish(int UserID)
        {
            AuthorID = UserID;
        }

    }
}
