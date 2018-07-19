using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeStoreLibrary.Request.Product
{
    public class UpdateProductRequest : ICheckRequest
    {
        public ReturnCode CheckValid()
        {
            return ReturnCode.Success;
        }
    }
}
