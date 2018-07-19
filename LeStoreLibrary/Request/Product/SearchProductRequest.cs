using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeStoreLibrary.Request.Product
{
    public class SearchProductRequest : ICheckRequest
    {
        public string ProductName { get; set; }
        public decimal? Price { get; set; }
        public long? Category { get; set; }

        public ReturnCode CheckValid()
        {
            return ReturnCode.Success;
        }
    }
}
