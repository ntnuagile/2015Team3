using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamProject.Tests
{
    class ReplyDataBase
    {
        public Reply[] RD = new Reply[100];
        public int num = 0;
        public int Article_ID=0;
        public void push(Reply r)
        {
            RD[num] = r;
            num += 1;
        }
        public int SearchReply(string name)
        {
            for (int i = 0; i < num; ++i)
            {
                if (RD[i].user_name == name)
                    return i;
            }
            return -1;
        }
        public bool RemoveReply(string name)
        {
            int index = SearchReply(name);

            if (index == -1) return false;

            for (int i = index + 1; i < num; ++i)
                RD[i-1] = RD[i];

            num -= 1;
            return true;
        }
        public bool EditReply(string name,string context)
        {
            int index = SearchReply(name);

            if (index == -1) return false;

            RD[index].Reply_context = context;
            return true;
        }
    }
}
