using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject
{
    class Category
    {
        public ArticleDataBase[] CategoryList = new ArticleDataBase[100];
        public int MaxCategory = 100;
        public int NumCategory = 0;

        public void AddCategory(ArticleDataBase db)
        {
            CategoryList[NumCategory] = db;
            NumCategory += 1;
        }

        public void Print()
        {
            for(int i=0;i<NumCategory;i+=1)
            {
                Console.WriteLine("<{0}> {1}", i + 1, CategoryList[i].name);
            }
        }
    }

    
}
