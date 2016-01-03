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

        public bool AddCategory(ArticleDataBase db)
        {
            if (NumCategory == MaxCategory)
                return false;
            CategoryList[NumCategory] = db;
            NumCategory += 1;
            return true;
        }

        public void Print()
        {
            for(int i=0;i<NumCategory;i+=1)
            {
                Console.WriteLine("<{0}> {1}", i + 1, CategoryList[i].BlockName);
            }
        }

        public int SearchCate(string name)
        {
            for(int i=0;i<NumCategory;i+=1)
            {
                if (name == CategoryList[i].BlockName)
                    return i;
            }
            return -1;
        }

        public ArticleDataBase GetADB(int index)
        {
            return CategoryList[index];
        }

        public void DeleteCate(int index)
        {
            for(int i=index;i<NumCategory-1;i+=1)
            {
                CategoryList[i] = CategoryList[i + 1];
            }
            NumCategory -= 1;
        }
        
        public void DeleteCate(string name)
        {
            int i = SearchCate(name);
            DeleteCate(i);
        }
    }

    
}
