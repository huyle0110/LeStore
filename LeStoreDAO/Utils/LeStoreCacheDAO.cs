using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeStoreDAO.Utils
{
    public class LeStoreCacheDAO
    {
        public static string connectionString = string.Empty;
        static readonly object lockConnectionString = new object();

        public static void InitConnectionString(string connectionstring)
        {
            lock (lockConnectionString)
            {
                connectionString = connectionstring;
            }
        }
    }
}
