using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeStoreLibrary.Request
{
    public class AccountLoginRequest
    {
        public string Password { get; set; }
        public string AccountName { get; set; }
    }
}
