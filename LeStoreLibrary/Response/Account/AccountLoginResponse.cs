using LeStoreLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeStoreLibrary.Response
{
    public class AccountLoginResponse : Response
    {
        public AccountModel Account { get; set; }
        public List<PermisstionType?> PermissionTypes { get; set; }
    }
}
