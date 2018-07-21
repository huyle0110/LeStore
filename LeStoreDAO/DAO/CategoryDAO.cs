using LeStoreDAO.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeStoreDAO.DAO
{
    public partial class DataAccess
    {
        public CreateProductResponse CreateProduct(CreateProductRequest request)
        {
            CreateProductResponse res = new CreateProductResponse();
            string strSP = SqlCommandStore.uspCreateProduct;
            try
            {
                using (SqlCommand cmd = new SqlCommand(strSP))
                {
                    cmd.Parameters.Add("ProductName", SqlDbType.NVarChar, 100).Value = request.ProductName;
                    cmd.Parameters.Add("Price", SqlDbType.Decimal).Value = request.Price;
                    cmd.Parameters.Add("CategoryID", SqlDbType.BigInt).Value = request.CategoryID;
                    cmd.Parameters.Add("Image1Path", SqlDbType.NVarChar, 20).Value = request.Image1Path;
                    cmd.Parameters.Add("Image2Path", SqlDbType.NVarChar, 100).Value = request.Image2Path;
                    cmd.Parameters.Add("Image3Path", SqlDbType.NVarChar, 100).Value = request.Image3Path;
                    cmd.Parameters.Add("Image4Path", SqlDbType.NVarChar, 100).Value = request.Image4Path;
                    cmd.Parameters.Add("Image5Path", SqlDbType.NVarChar, 100).Value = request.Image5Path;

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

        public UpdateProductResponse UpdateProduct(UpdateProductRequest request)
        {
            UpdateProductResponse res = new UpdateProductResponse();
            string strSP = SqlCommandStore.uspUpdateProduct;
            try
            {
                using (SqlCommand cmd = new SqlCommand(strSP))
                {
                    cmd.Parameters.Add("ProductID", SqlDbType.BigInt).Value = request.ProductID;
                    cmd.Parameters.Add("ProductName", SqlDbType.NVarChar, 100).Value = request.ProductName;
                    cmd.Parameters.Add("Price", SqlDbType.Decimal).Value = request.Price;
                    cmd.Parameters.Add("CategoryID", SqlDbType.BigInt).Value = request.CategoryID;
                    cmd.Parameters.Add("Image1Path", SqlDbType.NVarChar, 20).Value = request.Image1Path;
                    cmd.Parameters.Add("Image2Path", SqlDbType.NVarChar, 100).Value = request.Image2Path;
                    cmd.Parameters.Add("Image3Path", SqlDbType.NVarChar, 100).Value = request.Image3Path;
                    cmd.Parameters.Add("Image4Path", SqlDbType.NVarChar, 100).Value = request.Image4Path;
                    cmd.Parameters.Add("Image5Path", SqlDbType.NVarChar, 100).Value = request.Image5Path;

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


        public SearchProductResponse SearchProduct(SearchProductRequest request)
        {
            SearchProductResponse res = new SearchProductResponse();
            string strSP = SqlCommandStore.uspSearchProduct;
            try
            {
                using (SqlCommand cmd = new SqlCommand(strSP))
                {
                    cmd.Parameters.Add("ProductCode", SqlDbType.NVarChar, 100).Value = request.ProductCode;
                    cmd.Parameters.Add("ProductName", SqlDbType.NVarChar, 100).Value = request.ProductName;
                    cmd.Parameters.Add("FromPrice", SqlDbType.Decimal, 18).Value = request.FromPrice;
                    cmd.Parameters.Add("ToPrice", SqlDbType.Decimal, 18).Value = request.ToPrice;
                    cmd.Parameters.Add("CategoryID", SqlDbType.BigInt).Value = request.CategoryID;

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
                    res.products = rows.Select(row => new ProductModel(row)).ToList();
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


        public DeleteProductResponse DeleteProduct(DeleteProductRequest request)
        {
            DeleteProductResponse res = new DeleteProductResponse();
            string strSP = SqlCommandStore.uspDeleteProduct;
            try
            {
                using (SqlCommand cmd = new SqlCommand(strSP))
                {
                    cmd.Parameters.Add("ProductID", SqlDbType.BigInt).Value = request.ProductID;

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
