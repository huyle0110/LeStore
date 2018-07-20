using LeStoreDAO.Utils;
using LeStoreLibrary;
using LeStoreLibrary.Model;
using LeStoreLibrary.Request;
using LeStoreLibrary.Request.Account;
using LeStoreLibrary.Response;
using LeStoreLibrary.Response.Account;
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
                    //rows = new DataRow[ds.Tables[1].Rows.Count];
                    //ds.Tables[1].Rows.CopyTo(rows, 0);
                    //res.PermissionTypes = rows.Select(row => row["RoleCode"] != DBNull.Value? (PermisstionType?)row["RoleCode"] : null).ToList();

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

        public CreateAccountResponse CreateAccount(CreateAccountRequest request)
        {
            CreateAccountResponse res = new CreateAccountResponse();
            string strSP = SqlCommandStore.uspCreateAccount;
            try
            {
                using(SqlCommand cmd = new SqlCommand(strSP))
                {
                    cmd.Parameters.Add("AccountName", SqlDbType.NVarChar, 100).Value = request.AccountName;
                    cmd.Parameters.Add("AccountType", SqlDbType.Int).Value = (int)request.AccountType;
                    cmd.Parameters.Add("Address", SqlDbType.NVarChar, 200).Value = request.Address;
                    cmd.Parameters.Add("DOB", SqlDbType.DateTime).Value = request.DOB;
                    cmd.Parameters.Add("IDNumber", SqlDbType.NVarChar, 20).Value = request.IDNumber;
                    cmd.Parameters.Add("Password", SqlDbType.NVarChar, 100).Value = request.Password;
                    cmd.Parameters.Add("Status", SqlDbType.Int).Value = (int)request.Status;
                    cmd.Parameters.Add("PhoneNumber", SqlDbType.NVarChar, 20).Value = request.PhoneNumber;

                    cmd.Parameters.Add("@Return", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

                    DataSet ds = DB.ExecuteSPDataSet(cmd);
                    res.Code = (ReturnCode)Convert.ToInt32(cmd.Parameters["@Return"].Value);

                    if (res.Code != ReturnCode.Success)
                    {
                        DB.RollBackTran();
                        return res;
                    }
                    DB.CommitTran();
                    return res;
                }
            }
            catch(Exception ex)
            {
                LogWriter.WriteLogException(ex);
                res.Code = ReturnCode.Fail;
                return res;
            }
        }


        public UpdateAccountResponse UpdateAccount(UpdateAccountRequest request)
        {
            UpdateAccountResponse res = new UpdateAccountResponse();
            string strSP = SqlCommandStore.uspUpdateAccount;
            try
            {
                using (SqlCommand cmd = new SqlCommand(strSP))
                {
                    cmd.Parameters.Add("AccountName", SqlDbType.NVarChar, 100).Value = request.AccountName;
                    cmd.Parameters.Add("AccountType", SqlDbType.Int).Value = (int)request.AccountType;
                    cmd.Parameters.Add("Address", SqlDbType.NVarChar, 200).Value = request.Address;
                    cmd.Parameters.Add("DOB", SqlDbType.DateTime).Value = request.DOB;
                    cmd.Parameters.Add("IDNumber", SqlDbType.NVarChar, 20).Value = request.IDNumber;
                    cmd.Parameters.Add("Password", SqlDbType.NVarChar, 100).Value = request.Password;
                    cmd.Parameters.Add("Status", SqlDbType.Int).Value = (int)request.Status;
                    cmd.Parameters.Add("PhoneNumber", SqlDbType.NVarChar, 20).Value = request.PhoneNumber;

                    cmd.Parameters.Add("@Return", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

                    DataSet ds = DB.ExecuteSPDataSet(cmd);
                    res.Code = (ReturnCode)Convert.ToInt32(cmd.Parameters["@Return"].Value);

                    if (res.Code != ReturnCode.Success)
                    {
                        DB.RollBackTran();
                        return res;
                    }
                    DB.CommitTran();
                    return res;
                }
            }
            catch (Exception ex)
            {
                LogWriter.WriteLogException(ex);
                res.Code = ReturnCode.Success;
                return res;
            }
        }

        public SearchAccountResponse SearchAccount(SearchAccountRequest request)
        {
            SearchAccountResponse res = new SearchAccountResponse();
            string strSP = SqlCommandStore.uspSearchAccount;
            try
            {
                using (SqlCommand cmd = new SqlCommand(strSP))
                {
                    cmd.Parameters.Add("AccountName", SqlDbType.NVarChar, 100).Value = request.AccountName;
                    cmd.Parameters.Add("AccountType", SqlDbType.Int).Value = (int)request.AccountType;
                    cmd.Parameters.Add("IDNumber", SqlDbType.NVarChar, 20).Value = request.IDNumber;
                    cmd.Parameters.Add("Status", SqlDbType.Int).Value = (int)request.Status;
                    cmd.Parameters.Add("PhoneNumber", SqlDbType.NVarChar, 20).Value = request.PhoneNumber;

                    cmd.Parameters.Add("@Return", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

                    DataSet ds = DB.ExecuteSPDataSet(cmd);
                    res.Code = (ReturnCode)Convert.ToInt32(cmd.Parameters["@Return"].Value);

                    if (res.Code != ReturnCode.Success)
                    {
                        DB.RollBackTran();
                        return res;
                    }
                    DataRow[] rows = new DataRow[ds.Tables[0].Rows.Count];
                    rows = new DataRow[ds.Tables[0].Rows.Count];
                    ds.Tables[0].Rows.CopyTo(rows, 0);
                    res.accounts = rows.Select(row => new AccountModel(row)).ToList();
                    DB.CommitTran();
                    return res;
                }
            }
            catch (Exception ex)
            {
                LogWriter.WriteLogException(ex);
                res.Code = ReturnCode.Fail;
                return res;
            }
        }


        public DeleteAccountResponse DeleteAccount(DeleteAccountRequest request)
        {
            DeleteAccountResponse res = new DeleteAccountResponse();
            string strSP = SqlCommandStore.uspDeleteAccount;
            try
            {
                using (SqlCommand cmd = new SqlCommand(strSP))
                {
                    cmd.Parameters.Add("AccountID", SqlDbType.BigInt).Value = (int)request.AccountID;

                    cmd.Parameters.Add("@Return", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

                    DataSet ds = DB.ExecuteSPDataSet(cmd);
                    res.Code = (ReturnCode)Convert.ToInt32(cmd.Parameters["@Return"].Value);

                    if (res.Code != ReturnCode.Success)
                    {
                        DB.RollBackTran();
                        return res;
                    }
                   
                    DB.CommitTran();
                    return res;
                }
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
