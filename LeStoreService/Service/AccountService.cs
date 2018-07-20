using LeStoreDAO;
using LeStoreLibrary;
using LeStoreLibrary.Request;
using LeStoreLibrary.Request.Account;
using LeStoreLibrary.Response;
using LeStoreLibrary.Response.Account;
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
        DataAccess dao = new DataAccess();
        public AccountLoginResponse AccountLogin(AccountLoginRequest request)
        {
            AccountLoginResponse res = new AccountLoginResponse();
            res = dao.AccountLogin(new AccountLoginRequest() {
                AccountName = request.AccountName,
                Password = Securities.SHA1(request.Password)
            });
            return res;
        }

        public CreateAccountResponse CreateAccount(CreateAccountRequest request)
        {
            CreateAccountResponse res = new CreateAccountResponse();
            res = dao.CreateAccount(new CreateAccountRequest()
            {
                AccountName = request.AccountName,
                Password = Securities.SHA1(request.Password),
                AccountType = request.AccountType,
                Address = request.Address,
                DOB = request.DOB,
                IDNumber = request.IDNumber,
                PhoneNumber = request.PhoneNumber,
                Status = request.Status
            });
            return res;
        }


        public UpdateAccountResponse UpdateAccount(UpdateAccountRequest request)
        {
            UpdateAccountResponse res = new UpdateAccountResponse();
            res = dao.UpdateAccount(new UpdateAccountRequest()
            {
                AccountName = request.AccountName,
                Password = Securities.SHA1(request.Password),
                AccountType = request.AccountType,
                Address = request.Address,
                DOB = request.DOB,
                IDNumber = request.IDNumber,
                PhoneNumber = request.PhoneNumber,
                Status = request.Status
            });
            return res;
        }

        public SearchAccountResponse SearchAccount(SearchAccountRequest request)
        {
            SearchAccountResponse res = new SearchAccountResponse();
            res = dao.SearchAccount(new SearchAccountRequest()
            {
                AccountName = request.AccountName,
                AccountType = request.AccountType,
                IDNumber = request.IDNumber,
                PhoneNumber = request.PhoneNumber,
                Status = request.Status
            });
            return res;
        }


        public DeleteAccountResponse DeleteAccount(DeleteAccountRequest request)
        {
            DeleteAccountResponse res = new DeleteAccountResponse();
            res = dao.DeleteAccount(new DeleteAccountRequest()
            {
                AccountID = request.AccountID
            });
            return res;
        }
    }
}
