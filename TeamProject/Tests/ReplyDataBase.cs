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

    }
}
