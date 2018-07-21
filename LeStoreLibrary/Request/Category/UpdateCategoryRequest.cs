using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeStoreLibrary.Request.Category
{
    public class UpdateCategoryRequest : ICheckRequest
    {
        public long? CategoryID { get; set; }
        public string CategoryName { get; set; }

        public ReturnCode CheckValid()
        {
            return ReturnCode.Success;
        }
    }
}
