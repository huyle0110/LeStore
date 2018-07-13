using LeStoreLibrary.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeStoreDAO.Utils
{
    public class DBConnector
    {
        private SqlConnection sqlConnect = null;
        private SqlTransaction sqlTran = null;

        private Boolean bHasTran = false;

        private string ConnectionString = string.Empty;

        private void Init()
        {
            try
            {
                sqlConnect = new SqlConnection();
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// Huy.le
        /// </summary>
        /// <param name="ConnectionString">Connection String to Connect to Database</param>
        public void SetConnectionString(string ConnectionString)
        {
            this.ConnectionString = ConnectionString;
            this.sqlConnect.ConnectionString = ConnectionString;
        }

        /// <summary>
        /// BeginTran
        /// </summary>
        /// <returns></returns>
        public int BeginTran()
        {
            int iBegin = 1;
            try
            {
                if (Connect() == -1) return -4;
                if (sqlTran == null)
                {
                    sqlTran = sqlConnect.BeginTransaction();
                }
                bHasTran = true;
            }
            catch (Exception ex)
            {
                LogWriter.WriteLogException(ex);
                iBegin = -1;
            }
            return iBegin;
        }

        /// <summary>
        /// CommitTran
        /// </summary>
        /// <returns></returns>
        public int CommitTran()
        {
            int iCommit = 1;
            try
            {
                if (sqlTran != null && bHasTran == true)
                {
                    sqlTran.Commit();
                    sqlTran.Dispose();
                    sqlTran = null;
                }
                bHasTran = false;
            }
            catch (Exception ex)
            {
                LogWriter.WriteLogException(ex);
                iCommit = -1;
            }
            finally
            {
                CloseConnect();
            }
            return iCommit;
        }

        /// <summary>
        /// RollBackTran
        /// </summary>
        /// <returns></returns>
        public int RollBackTran()
        {
            int iRollback = 1;
            try
            {
                if (sqlTran != null && bHasTran == true)
                {
                    sqlTran.Rollback();
                    sqlTran.Dispose();
                    sqlTran = null;
                }
                bHasTran = false;
            }
            catch (Exception ex)
            {
                LogWriter.WriteLogException(ex);
                iRollback = -1;
            }
            finally
            {
                CloseConnect();
            }
            return iRollback;
        }

        /// <summary>
        /// Connnect DB
        /// </summary>
        /// <returns></returns>
        private int Connect()
        {
            bool isOpen = true;
            try
            {
                if (sqlConnect.State == ConnectionState.Closed)
                    sqlConnect.Open();
            }
            catch (Exception ex)
            {
                LogWriter.WriteLogException(ex);
                isOpen = false;
            }
            return isOpen ? 1 : -1;
        }
        public DataSet ExecuteSP(SqlCommand cmd)
        {
            DataSet ds = null;
            try
            {
                if (this.Connect() == -1)
                    return null;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = sqlConnect;
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    ds = new DataSet("DataSet");
                    da.Fill(ds);
                };
            }
            catch (Exception ex)
            {
                LogWriter.WriteLogException(ex);
            }
            return ds;
        }

        public int CloseConnect()
        {
            int iClose = 1;
            try
            {
                if (sqlConnect != null)
                    sqlConnect.Close();
            }
            catch (Exception ex)
            {
                LogWriter.WriteLogException(ex);
                iClose = 0;
            }
            return iClose;
        }
    }
}
