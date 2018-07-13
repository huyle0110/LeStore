using LeStoreDAO.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeStoreDAO
{
    public partial class DataAccess
    {
        static DataAccess instance;
        public DataAccess() { }
        private DBConnector _db = null;
        static readonly object lockDAO = new object();

        public DBConnector DB
        {
            get
            {
                if (_db == null)
                {
                    _db = new DBConnector();
                    _db.SetConnectionString(ConfigurationManager.ConnectionStrings["connectionString"].ToString());
                }
                return _db;
            }
        }

        public DataAccess getInstance()
        {
            if (instance == null)
            {
                lock (lockDAO)
                {
                    instance = new DataAccess();
                }
            }
            return instance;
        }
    }
}
