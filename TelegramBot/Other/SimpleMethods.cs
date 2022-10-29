using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot
{
    public class SimpleMethods
    {
        public static string GetMessageAfterSpace(string str)
        {
            string tmp = "";
            int spaceCoord = str.IndexOf(' ');
            for (int i = spaceCoord; i < str.Length; i++)
            {
                tmp += str[i];
            }
            return tmp;
        }
    }
}
