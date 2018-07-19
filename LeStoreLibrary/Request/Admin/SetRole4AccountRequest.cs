using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeStoreLibrary.Request.Admin
{
    public class SetRole4AccountRequest : ICheckRequest
    {
        public long? RoleID { get; set; }
        public long? AccountID { get; set; }
        public ReturnCode CheckValid()
        {
            return ReturnCode.Success;
        }
    }
}
