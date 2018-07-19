using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeStoreLibrary.Model
{
    public class AccountModel
    {
        public long? AccountID { get; set; }
        public string AccountName { get; set; }
        public AccountType? AccountType { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string IDNumber { get; set; }
        public DateTime? DOB { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastUpdate { get; set; }
        public AccountStatus? Status { get; set; }
        public string Roles  { get; set; }
        public List<string> ListRoles { get; set; }
        public AccountModel() { }
        public AccountModel(DataRow row)
        {
            this.AccountID = row["AccountID"] != DBNull.Value ? (long?)long.Parse(row["AccountID"].ToString()) : null;
            this.AccountType = row["AccountType"] != DBNull.Value ? (AccountType?)int.Parse(row["AccountType"].ToString()) : null;
            this.AccountName = row["AccountName"] != DBNull.Value ? row["AccountName"].ToString() : null;
            this.PhoneNumber = row["PhoneNumber"] != DBNull.Value ? row["PhoneNumber"].ToString() : null;
            this.Address = row["Address"] != DBNull.Value ? row["Address"].ToString() : null;
            this.IDNumber = row["IDNumber"] != DBNull.Value ? row["IDNumber"].ToString() : null;
            this.DOB = row["DOB"] != DBNull.Value ? (DateTime?)DateTime.Parse(row["DOB"].ToString()) : null;
            this.CreateDate = row["CreateDate"] != DBNull.Value ? (DateTime?)DateTime.Parse(row["CreateDate"].ToString()) : null;
            this.LastUpdate = row["LastUpdate"] != DBNull.Value ? (DateTime?)DateTime.Parse(row["LastUpdate"].ToString()) : null;

            this.ListRoles = Roles.Split(',').ToList();
        }

        public void GetListRoles()
        {
            this.ListRoles = Roles.Split(',').ToList();
        }
    }

    public enum AccountType
    {
        Admin = 1,
        Staff = 2
    }

    public enum AccountStatus
    {
        Inactive = 0,
        Active = 1
    }
}
