using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeStoreLibrary.Request.Product
{
    public class CreateProductRequest : ICheckRequest
    {
        public string ProductName { get; set; }
        public decimal? Price { get; set; }
        public string Image1Path { get; set; }
        public string Image2Path { get; set; }
        public string Image3Path { get; set; }
        public string Image4Path { get; set; }
        public string Image5Path { get; set; }
        public long? CategoryID { get; set; }
        public ReturnCode CheckValid()
        {
            return ReturnCode.Success;
        }
    }
}
