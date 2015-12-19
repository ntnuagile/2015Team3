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

        public void publish(Article Art)
        {
            DB[NumArticle] = Art;
            NumArticle += 1;
        }

        //刪除 搜尋 修改..
    }
}
