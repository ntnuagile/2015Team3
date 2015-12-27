using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject
{
    class ArticleDataBase
    {
        public List<Article> DB = new List<Article>();

        Article[] ee = new Article[100];

        public int MaxArticle = 100;
        public int NumArticle = 0;
        public int ArticleIndex = 0; //sort時使用
        public string BlockName = "";

        public void AddArticle(Article Art)
        {
            Article tmp = new Article();

            tmp = Art;
            tmp.ArticleIndex = ArticleIndex;
            DB.Add(tmp);

            ArticleIndex += 1;
            NumArticle += 1;
        }

        public int SearchByAuthor(int AuthorID)
        {
            for (int i = 0; i < NumArticle; ++i)
            {
                if (DB[i].AuthorID == AuthorID)
                    return i;
            }
            return -1;
        }

        public int SearchByTitle(string Str)
        {
            for (int i = 0; i < NumArticle; ++i)
            {
                if (DB[i].Title == Str)
                    return i;
            }
            return -1;
        }

        public bool RemoveByAuthor(int AuthorID)
        {
            int index = SearchByAuthor(AuthorID);

            if (index == -1) return false;

            for (int i = index + 1; i < NumArticle; ++i) 
                DB[i-1] = DB[i];

            NumArticle -= 1;
            DB.RemoveAt(NumArticle);
            return true;
        }

        public bool RemoveByTitle(string Str)
        {
            int index = SearchByTitle(Str);

            if (index == -1) return false;

            for (int i = index + 1; i < NumArticle; ++i)
                DB[i-1] = DB[i];

            NumArticle -= 1;
            DB.RemoveAt(NumArticle);
            return true;
        }


        // 修改..
    }
}
