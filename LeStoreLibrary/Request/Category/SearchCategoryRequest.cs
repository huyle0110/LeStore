using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeStoreLibrary.Request.Category
{
    public class SearchCategoryRequest : ICheckRequest
    {
        public long? CategoryID { get; set; }
        public long? CategoryName { get; set; }

        public ReturnCode CheckValid()
        {
        return ReturnCode.Success;
        }
    }
}
