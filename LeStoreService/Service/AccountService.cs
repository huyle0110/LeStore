using LeStoreDAO;
using LeStoreLibrary;
using LeStoreLibrary.Request;
using LeStoreLibrary.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeStoreService.Service
{
    public class AccountService
    {
        private DataAccess dao = new DataAccess().getInstance();
        public AccountLoginResponse AccountLogin(AccountLoginRequest request)
        {
            AccountLoginResponse res = new AccountLoginResponse();
            res = dao.AccountLogin(new AccountLoginRequest() {
                AccountName = request.AccountName,
                Password = Securities.SHA1(request.Password)
            });
            return res;
        }
    }
}
