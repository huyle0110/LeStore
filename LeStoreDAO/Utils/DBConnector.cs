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
        private SqlTransaction tn = null;
        private Boolean bHasTran = false;

        private string ConnectionString = string.Empty;

        bool bAutoCloseConnection = true;

        /// <summary>
        /// SetConnectString
        /// </summary>
        /// <param name="cs"></param>
        public void SetConnectString(string cs)
        {
            ConnectionString = cs;
            sqlConnect.ConnectionString = ConnectionString;
        }

        /// <summary>
        /// DBConnector
        /// </summary>
        public DBConnector()
        {
            InitConnection();
        }

        /// <summary>
        /// InitConnection
        /// </summary>
        void InitConnection()
        {
            try
            {
                sqlConnect = new SqlConnection();
            }
            catch (Exception ex)
            {
                LogWriter.WriteLogException(ex);
            }
        }

        /// <summary>
        /// OpenConnect
        /// </summary>
        /// <returns></returns>
        public int OpenConnect()
        {
            bool isOpen = true;
            try
            {
                if (sqlConnect.State == ConnectionState.Closed)
                {
                    sqlConnect.Open();
                }
            }
            catch (Exception ex)
            {
                LogWriter.WriteLogException(ex);
                isOpen = false;
            }
            return isOpen ? 1 : -1;
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
                if (OpenConnect() == -1) return -4;
                if (tn == null)
                {
                    tn = sqlConnect.BeginTransaction();
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
                if (tn != null && bHasTran == true)
                {
                    tn.Commit();
                    tn.Dispose();
                    tn = null;
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
                if (tn != null && bHasTran == true)
                {
                    tn.Rollback();
                    tn.Dispose();
                    tn = null;
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
        /// ExecuteSP
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public int ExecuteSP(SqlCommand cmd)
        {
            int iOk = -1;
            try
            {
                if (bHasTran) cmd.Transaction = tn;
                else if (OpenConnect() == -1) return -4;

                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.CommandTimeout = CoreConfig.GetSqlCommandTimeOut;
                cmd.Connection = sqlConnect;
                cmd.ExecuteNonQuery();
                iOk = 1;
            }
            catch (Exception ex)
            {
                LogWriter.WriteLogException(ex);
                iOk = 0;
            }
            if (!bHasTran && bAutoCloseConnection)
            {
                CloseConnect();
            }
            return iOk;
        }

        /// <summary>
        /// ExecuteSPDataSet
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public DataSet ExecuteSPDataSet(SqlCommand cmd)
        {
            DataSet ds = null;
            Boolean err = false;
            try
            {
                if (bHasTran)
                    cmd.Transaction = tn;
                else if (OpenConnect() == -1) return null;

                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.CommandTimeout = CoreConfig.GetSqlCommandTimeOut;
                cmd.Connection = sqlConnect;
                //cmd.escapeSQL(bHasTran ? false : true);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    try
                    {
                        ds = new DataSet("DataSet");
                        //da.SelectCommand.CommandTimeout = CoreConfig.GetSqlDataAdapterCommandTimeout;
                        da.Fill(ds);
                    }
                    catch (Exception ex)
                    {
                        err = true;
                        LogWriter.WriteLogException(ex);
                    }
                }
            }
            catch (Exception ex)
            {
                err = true;
                LogWriter.WriteLogException(ex);
            }
            if (!bHasTran && bAutoCloseConnection)
                CloseConnect();
            return (err ? null : ds);
        }

        /// <summary>
        /// CloseConnect
        /// </summary>
        /// <returns></returns>
        public int CloseConnect()
        {
            int iClose = 1;
            try
            {
                if (sqlConnect != null)
                {
                    sqlConnect.Close();
                }
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
