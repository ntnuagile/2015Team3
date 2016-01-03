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

        public int MaxArticle = 100; //最大文章量
        public int NumArticle = 0;   //文章數量
        public int ArticleIndex = 0; //文章編號
        public string BlockName = "";

        public bool AddArticle(User U, string Title, List<string> Content)
        {
            if (U.IsLogin == false) return false;
            if (NumArticle >= MaxArticle) return false;

            Article Art = new Article();

            Art.AuthorAccount = U.GetAccount();
            Art.ArticleIndex = ArticleIndex;
            Art.Title = Title;
            Art.Content = Content;

            U.ArticleID.Add(ArticleIndex);
            U.NumArticle += 1;

            DB.Add(Art);

            ArticleIndex += 1;
            NumArticle += 1;

            return true;
        }

        //Search

        public List<Article> SearchByAuthor(string AuthorAccount)
        {
            List<Article> Arts = new List<Article>();
            Arts = DB.FindAll(x => x.AuthorAccount == AuthorAccount);
            return Arts;
        }

        public List<Article> SearchByTitle(string Title)
        {
            List<Article> Arts = new List<Article>();
            Arts = DB.FindAll(x => x.Title.Contains(Title));
            return Arts;
        }
        public List<Article> SearchByContext(string keyword)
        {
            List<Article> Arts = new List<Article>();
            Arts = DB.FindAll(x => x.Content.Contains(keyword));
            return Arts;
        }
        // Remove

        public bool RemoveArticle(User U, Article Art)
        {
            if (U.IsLogin == false) return false;
            if (U.GetAccount() != Art.AuthorAccount) return false;

            int Index = -1;

            for (int i = 0; i < NumArticle; i++)
            {
                if (DB[i].ArticleIndex == Art.ArticleIndex)
                {
                    Index = i;
                    break;
                }
            }

            if (Index == -1) return false;  //沒找到

            DB.RemoveAt(Index);
            NumArticle -= 1;

            U.ArticleID.Remove(Art.ArticleIndex);
            U.NumArticle -= 1;

            return true;
        }


        // 修改..
        public bool ModifyArticle(User U, Article Art, string NewTitle, List<string> NewContent)
        {
            if (U.IsLogin == false) return false;
            if (U.GetAccount() != Art.AuthorAccount) return false;

            Art.Title = NewTitle;
            Art.Content = NewContent;

            return true;
        }

        // GP
        public bool GPtoArticle(User U, Article Art)
        {
            if (U.IsLogin == false) return false;
            if (U.GetAccount() == Art.AuthorAccount) return false;

            string result;
            
            result = Art.GPList.Find(x => x == U.GetAccount());
            if (result == U.GetAccount()) return false;

            result = Art.BPList.Find(x => x == U.GetAccount());
            if (result == U.GetAccount()) return false;

            Art.GoodPoint += 1;
            Art.GPList.Add(U.GetAccount());
            return true;
        }

        // BP
        public bool BPtoArticle(User U, Article Art)
        {
            if (U.IsLogin == false) return false;
            if (U.GetAccount() == Art.AuthorAccount) return false;

            string result;

            result = Art.GPList.Find(x => x == U.GetAccount());
            if (result == U.GetAccount()) return false;

            result = Art.BPList.Find(x => x == U.GetAccount());
            if (result == U.GetAccount()) return false;

            Art.BadPoint += 1;
            Art.BPList.Add(U.GetAccount());
            return true;
        }

        //Sort
        public void SotrByTitle()
        {
            DB.Sort(delegate(Article x, Article y)
            {
                return x.Title.CompareTo(y.Title);
            });
        }

        public void SotrByTime()
        {
            DB.Sort(delegate(Article x, Article y)
            {
                return x.ArticleIndex.CompareTo(y.ArticleIndex);
            });
        }

    }
}
