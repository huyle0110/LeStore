using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeStoreLibrary.Model
{
    public class ProductModel
    {
        public long? ProductID { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public long? Price { get; set; }
        public long? CategoryID { get; set; }
        public ProductStatus? Status { get; set; }
        public string Image1Path { get; set; }
        public string Image2Path { get; set; }
        public string Image3Path { get; set; }
        public string Image4Path { get; set; }
        public string Image5Path { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastUpdate { get; set; }

        public ProductModel() { }
        public ProductModel(DataRow row)
        {
            this.ProductID = row["ProductID"] != DBNull.Value ? (long?)long.Parse(row["ProductID"].ToString()) : null;
            this.ProductName = row["ProductName"] != DBNull.Value ? row["ProductName"].ToString() : null;
            this.ProductCode = row["ProductCode"] != DBNull.Value ? row["ProductCode"].ToString() : null;
            this.Price = row["Price"] != DBNull.Value ? (long?)long.Parse(row["Price"].ToString()) : null;
            this.CategoryID = row["CategoryID"] != DBNull.Value ? (long?)long.Parse(row["CategoryID"].ToString()) : null;
            this.Status = row["Status"] != DBNull.Value ? (ProductStatus?)long.Parse(row["Status"].ToString()) : null;
            
            this.Image1Path = row["Image1Path"] != DBNull.Value ? row["Image1Path"].ToString() : null;
            this.Image2Path = row["Image2Path"] != DBNull.Value ? row["Image2Path"].ToString() : null;
            this.Image3Path = row["Image3Path"] != DBNull.Value ? row["Image3Path"].ToString() : null;
            this.Image4Path = row["Image4Path"] != DBNull.Value ? row["Image4Path"].ToString() : null;
            this.Image5Path = row["Image5Path"] != DBNull.Value ? row["Image5Path"].ToString() : null;

            this.CreateDate = row["CreateDate"] != DBNull.Value ? (DateTime?)DateTime.Parse(row["CreateDate"].ToString()) : null;
            this.LastUpdate = row["LastUpdate"] != DBNull.Value ? (DateTime?)DateTime.Parse(row["LastUpdate"].ToString()) : null;
        }
    }

    public enum ProductStatus
    {
        Not_Available = 0,
        Available = 1
    }
}
