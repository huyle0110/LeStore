using LeStoreDAO.Utils;
using LeStoreLibrary;
using LeStoreLibrary.Model;
using LeStoreLibrary.Request;
using LeStoreLibrary.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeStoreDAO
{
    public partial class DataAccess
    {
        public AccountLoginResponse AccountLogin(AccountLoginRequest request)
        {
            AccountLoginResponse res = new AccountLoginResponse();
            string strSP = SqlCommandStore.uspAccountLogin;
            try
            {
                using (SqlCommand cmd = new SqlCommand(strSP))
                {
                    cmd.Parameters.Add("AccountName", SqlDbType.NVarChar, 100).Value = request.AccountName;
                    cmd.Parameters.Add("Password", SqlDbType.NVarChar, 100).Value = request.Password;

                    cmd.Parameters.Add("@Return", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
                    DataSet ds = DB.ExecuteSPDataSet(cmd);
                    res.Code = (ReturnCode)Convert.ToInt32(cmd.Parameters["@Return"].Value);

                    if (res.Code != ReturnCode.Success)
                    {
                        DB.RollBackTran();
                        return res;
                    }
                    DB.CommitTran();

                    DataRow[] rows = new DataRow[ds.Tables[0].Rows.Count];
                    rows = new DataRow[ds.Tables[0].Rows.Count];
                    ds.Tables[0].Rows.CopyTo(rows, 0);
                    res.Account = rows.Select(row => new AccountModel(row)).First();

                    // Return permisstiontypes
                    rows = new DataRow[ds.Tables[1].Rows.Count];
                    ds.Tables[1].Rows.CopyTo(rows, 0);
                    //res.PermissionTypes = rows.Select(row => row.Field<string>("PermisstionTypes")).ToList();
                    return res;
                };
            }
            catch (Exception ex)
            {
                LogWriter.WriteLogException(ex);
                res.Code = ReturnCode.Fail;
                return res;
            }
        }
    }
}
