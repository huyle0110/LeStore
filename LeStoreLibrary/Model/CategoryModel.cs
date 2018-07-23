using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeStoreLibrary.Model
{
    public class CategoryModel
    {
        public long? CategoryID { get; set; }
        public string CategoryName { get; set; }
        public CategoryModel() { }
        public CategoryModel(DataRow row)
        {
            this.CategoryID = row["CategoryID"] != DBNull.Value ? (long?)long.Parse(row["CategoryID"].ToString()) : null;
            this.CategoryName = row["CategoryName"] != DBNull.Value ? row["CategoryName"].ToString() : null;
        }
    }
}
