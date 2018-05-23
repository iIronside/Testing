using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStringFormatter
{
    public class StringFormatter
    {
        public string SafeString(string s)
        {
            if (s == null)
            {
                throw new NullReferenceException("The transmitted value can not be NULL!");
            }
            else if (s == "")
            {
                return "";
            }
            
            s = s.Replace("'", "'''").Replace("select","SELECT").Replace("insert","INSERT")
                .Replace("update","UPDATE").Replace("delete","DELETE").Replace("from","FROM")
                .Replace("where","WHERE").Replace("like", "LIKE").Replace("order by", "ORDER BY");
            return s;
        }
    }
}
