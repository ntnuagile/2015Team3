using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject
{
    class ArticleDataBase
    {
        public Article[] DB = new Article[100];

        public int MaxArticle = 100;
        public int NumArticle = 0;
        public int ArticleIndex = 0; //sort時使用
        public string BlockName = "";

        public void AddArticle(Article Art)
        {
            Art.ArticleIndex = ArticleIndex;
            DB[ArticleIndex] = Art;
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

        /*public bool RemoveByIndex(int index)
        {
            return true;
        }*/

        //刪除 搜尋 修改..
    }
}
