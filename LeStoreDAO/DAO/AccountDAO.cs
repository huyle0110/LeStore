using LeStoreDAO.Utils;
using LeStoreLibrary;
using LeStoreLibrary.Request;
using LeStoreLibrary.Response;
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
                    DataSet ds = DB.ExecuteSP(cmd);

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
