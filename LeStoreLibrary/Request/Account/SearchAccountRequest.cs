using LeStoreLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeStoreLibrary.Request.Account
{
    public class SearchAccountRequest : ICheckRequest
    {
        public string AccountName { get; set; }
        public AccountType? AccountType { get; set; }
        public string PhoneNumber { get; set; }
        public string IDNumber { get; set; }
        public AccountStatus? Status { get; set; }
        public ReturnCode CheckValid()
        {
            return ReturnCode.Success;
        }
    }
}
