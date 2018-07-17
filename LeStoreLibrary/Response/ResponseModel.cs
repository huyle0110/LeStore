using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeStoreLibrary
{
    public class ResponseModel
    {
        public ReturnCode Code { get; set; }
        public object ResponseData { get; set; }
        public string Message { get; set; }
    }
}
