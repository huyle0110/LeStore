using LeStoreLibrary;
using LeStoreLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeStoreWeb.Utils
{
    public class LeStoreSession
    {
        public static UserSession GetUserInfo()
        {
            var user = HttpContext.Current.Session["User"] as UserSession;
            return user;
        }

        public static bool IsLogin()
        {
            return GetUserInfo() != null;
        }

        public static void ClearSession()
        {
            HttpContext.Current.Session.RemoveAll();
            HttpContext.Current.Session.Clear();
        }
    }

    public class UserSession
    {
        public AccountModel Account { get; set; }
        public List<PermisstionType> permissions { get; set; }
    }
}