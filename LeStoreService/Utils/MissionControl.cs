using LeStoreDAO;
using LeStoreDAO.Utils;
using LeStoreLibrary.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeStoreService.Utils
{
    public class MissionControl
    {
        private static MissionControl instance = null;
        private static readonly object lockConfig = new object();
        public MissionControl()
        {
            Init();
        }
        public static MissionControl getInstance()
        {
            lock(lockConfig)
            {
                if (instance == null)
                {
                    instance = new MissionControl();
                }
            }
            return instance;
        }

        private void Init()
        {
            LogWriter.Init(ConfigurationManager.AppSettings["LogFolderPath"]);
            //(ConfigurationManager.AppSettings["connectionString"]);
            LeStoreCacheDAO.InitConnectionString(ConfigurationManager.AppSettings["connectionString"]);
        }
    }
}
