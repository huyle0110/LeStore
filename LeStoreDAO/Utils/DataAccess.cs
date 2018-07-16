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
        public DataAccess()
        {
        }

        private DBConnector _db = null;

        public DBConnector DB
        {
            get
            {
                if (_db == null)
                {
                    _db = new DBConnector();
                    _db.SetConnectString(LeStoreCacheDAO.connectionString);
                }
                return _db;
            }
        }
    }
}
