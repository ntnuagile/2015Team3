using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject
{
    class Article
    {
        public string title;
       
        public string getTitle()
        {
            return title;
        }

        public int SameTitle(string keyword)
        {
            return String.Compare(title, keyword);
        }
        static public int  five()
        {
      
            return 5;
        }

        static public int zero()
        {
            return 0;
        }
    }
}
