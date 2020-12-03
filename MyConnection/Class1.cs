using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConnection
{
    public class Class1
    {
        public static string getConnection()
        {
            string sql = "server=.;database=ProjectC#;uid=sa;pwd=123";
            return sql;
        }
    }
}
