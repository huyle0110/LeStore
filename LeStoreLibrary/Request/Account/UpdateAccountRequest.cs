using LeStoreLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeStoreLibrary.Request.Account
{
    public class UpdateAccountRequest : ICheckRequest
    {
        public long? AccountID { get; set; }
        public string AccountName { get; set; }
        public AccountType? AccountType { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string IDNumber { get; set; }
        public DateTime? DOB { get; set; }
        public AccountStatus? Status { get; set; }
        public ReturnCode CheckValid()
        {
            return ReturnCode.Success;
        }
    }
}
