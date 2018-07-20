﻿using LeStoreLibrary;
using LeStoreLibrary.Model;
using LeStoreLibrary.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeStoreWeb.Utils
{
    public class LeStoreAttributes : ActionFilterAttribute
    {
        public List<PermisstionType> PermissionType;
        public AccountType accountType { get; set; }
        public LeStoreAttributes(params PermisstionType[] permissionType)
        {
            this.PermissionType = permissionType.ToList();
        }
        public LeStoreAttributes(AccountType type, params PermisstionType[] permissionType)
        {
            this.PermissionType = permissionType.ToList();
            this.accountType = type;
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            // Check Session
            if (!LeStoreSession.IsLogin())
            {

            }
            if (LeStoreSession.GetUserInfo() == null ||
                !LeStoreSession.GetUserInfo().Account.ListRoles.Any(item => this.PermissionType.Contains(item)))
            {
                LogWriter.WriteLogMsg("Not Permission");
            }

            if (LeStoreSession.GetUserInfo().Account.AccountType != this.accountType)
            {
                LogWriter.WriteLogMsg("Account Not Permission");
            }
        }
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            base.OnResultExecuted(filterContext);
        }
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            base.OnResultExecuting(filterContext);
        }
    }


}