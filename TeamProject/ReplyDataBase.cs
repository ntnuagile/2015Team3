using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject
{
    public class ReplyDataBase
    {
        public Reply[] RD = new Reply[100];
        public int num = 0;
        public int Article_ID=0;
        public bool PushReply(string content,User user)
        {
            if(num<100 && user.IsLogin==true)
            {
                Reply r=new Reply();
                r.user_account = user.GetAccount();
                r.Reply_content = content;
                r.index = num;
                RD[num] = r;
                num += 1;
                return true;
            }
            return false;
            
        }
        public int SearchReply(User user)
        {
            if (user.IsLogin == true)
            { 
                for (int i = 0; i < num; ++i)
                {
                    if (RD[i].user_account == user.GetAccount())
                        return i;
                }
            
            }
            
            return -1;
        }
        public bool RemoveReply(User user)
        {
            int index = SearchReply(user);
            if (index == -1) return false;
            for (int i = index + 1; i < num; ++i)
                RD[i-1] = RD[i];
            num -= 1;
            return true;
        }
        public bool EditReply(User user, string context)
        {
            int index = SearchReply(user);
            if (index == -1) return false;
            RD[index].Reply_content = context;
            return true;
        }
    }
}
