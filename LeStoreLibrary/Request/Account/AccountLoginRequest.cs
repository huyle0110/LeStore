using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeStoreLibrary.Request
{
    public class AccountLoginRequest : ICheckRequest
    {
        public string Password { get; set; }
        public string AccountName { get; set; }

        public ReturnCode CheckValid()
        {
            if (string.IsNullOrEmpty(this.Password) || string.IsNullOrEmpty(this.AccountName))
                return ReturnCode.InvalidRequest;
            return ReturnCode.Success;
        }
    }
}
