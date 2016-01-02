﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject
{
    class ArticleDataBase
    {
        public List<Article> DB = new List<Article>();

        public int MaxArticle = 100;
        public int NumArticle = 0;
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

        public List<int> SearchByAuthor(string AuthorAccount)
        {
            List<int> Index = new List<int>();

            for (int i = 0; i < NumArticle; ++i)
            {
                if (DB[i].AuthorAccount == AuthorAccount)
                    Index.Add(DB[i].ArticleIndex);
            }
            return Index;
        }

        public List<int> SearchByTitle(string Str)
        {
            List<int> Index = new List<int>();

            for (int i = 0; i < NumArticle; ++i)
            {
                if (DB[i].Title == Str)
                    Index.Add(DB[i].ArticleIndex);
            }
            return Index;
        }

        // Remove

        public bool RemoveArticle(User U, string Title)
        {
            if (U.IsLogin == false) return false;

            int Index = -1;
            int ArticleIndex = 0;

            for (int i = 0; i < NumArticle; i++)
            {
                if (DB[i].AuthorAccount == U.GetAccount() && DB[i].Title == Title)
                {
                    Index = i;
                    ArticleIndex = DB[i].ArticleIndex;
                }
            }

            if (Index == -1) return false;  //沒找到

            DB.RemoveAt(Index);
            NumArticle -= 1;

            U.ArticleID.Remove(ArticleIndex);
            U.NumArticle -= 1;

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
        // 修改..


    }
}
