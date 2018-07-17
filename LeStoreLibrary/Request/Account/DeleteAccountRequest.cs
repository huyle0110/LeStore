using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeStoreLibrary.Request.Account
{
    public class DeleteAccountRequest : ICheckRequest
    {
        public long? AccountID { get; set; }
        public ReturnCode CheckValid()
        {
            return ReturnCode.Success;
        }
    }
}
