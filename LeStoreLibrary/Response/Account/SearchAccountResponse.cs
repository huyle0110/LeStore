using LeStoreLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeStoreLibrary.Response.Account
{
    public class SearchAccountResponse : Response
    {
        public List<AccountModel> accounts { get; set; }
    }
}
