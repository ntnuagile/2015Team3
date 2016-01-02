using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject
{
    public class Article
    {
        public int ArticleIndex;
        public string Title;
        public string AuthorAccount;
        public List<string> Content = new List<string>();

        public int GoodPoint = 0;
        public int BadPoint = 0;
    }
}
