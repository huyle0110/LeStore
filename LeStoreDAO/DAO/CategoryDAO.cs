using LeStoreDAO.Utils;
using LeStoreLibrary;
using LeStoreLibrary.Model;
using LeStoreLibrary.Request.Category;
using LeStoreLibrary.Response.Category;
using LeStoreLibrary.Response.Product;
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
        public CreateCategoryResponse CreateCategory(CreateCategoryRequest request)
        {
            CreateCategoryResponse res = new CreateCategoryResponse();
            string strSP = SqlCommandStore.uspCreateCategory;
            try
            {
                using (SqlCommand cmd = new SqlCommand(strSP))
                {
                    cmd.Parameters.Add("CategoryName", SqlDbType.NVarChar, 100).Value = request.CategoryName;

                    cmd.Parameters.Add("@Return", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

                    DataSet ds = DB.ExecuteSPDataSet(cmd);
                    res.Code = (ReturnCode)Convert.ToInt32(cmd.Parameters["@Return"].Value);

                    if (res.Code != ReturnCode.Success)
                    {
                        DB.RollBackTran();
                        return res;
                    }
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

        public UpdateCategoryResponse UpdateCategory(UpdateCategoryRequest request)
        {
            UpdateCategoryResponse res = new UpdateCategoryResponse();
            string strSP = SqlCommandStore.uspUpdateCategory;
            try
            {
                using (SqlCommand cmd = new SqlCommand(strSP))
                {
                    cmd.Parameters.Add("CategoryID", SqlDbType.BigInt).Value = request.CategoryID;
                    cmd.Parameters.Add("CategoryName", SqlDbType.NVarChar, 100).Value = request.CategoryName;

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

        public SearchCategoryResponse SearchCategory(SearchCategoryRequest request)
        {
            SearchCategoryResponse res = new SearchCategoryResponse();
            string strSP = SqlCommandStore.uspSearchCategory;
            try
            {
                using (SqlCommand cmd = new SqlCommand(strSP))
                {
                    cmd.Parameters.Add("CategoryID", SqlDbType.BigInt).Value = request.CategoryID;
                    cmd.Parameters.Add("CategoryName", SqlDbType.NVarChar, 100).Value = request.CategoryName;

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
                    res.categorys = rows.Select(row => new CategoryModel(row)).ToList();
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

        public DeleteCategoryResponse DeleteCategory(DeleteCategoryRequest request)
        {
            DeleteCategoryResponse res = new DeleteCategoryResponse();
            string strSP = SqlCommandStore.uspDeleteCategory;
            try
            {
                using (SqlCommand cmd = new SqlCommand(strSP))
                {
                    cmd.Parameters.Add("CategoryID", SqlDbType.BigInt).Value = request.CategoryID;

                    cmd.Parameters.Add("@Return", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

                    DataSet ds = DB.ExecuteSPDataSet(cmd);
                    res.Code = (ReturnCode)Convert.ToInt32(cmd.Parameters["@Return"].Value);

                    if (res.Code != ReturnCode.Success)
                    {
                        DB.RollBackTran();
                        return res;
                    }
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
