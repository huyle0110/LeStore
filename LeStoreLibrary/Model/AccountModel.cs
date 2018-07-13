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
        public string AccountName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string ID { get; set; }
        public DateTime? DOB { get; set; }

        public AccountModel() { }
        public AccountModel(DataRow row)
        {
            this.AccountName = row["AccountName"] != DBNull.Value ? row["AccountName"].ToString() : null;
            this.PhoneNumber = row["PhoneNumber"] != DBNull.Value ? row["PhoneNumber"].ToString() : null;
            this.Address = row["AccountName"] != DBNull.Value ? row["Address"].ToString() : null;
            this.DOB = row["DateTime"] != DBNull.Value ? (DateTime?)DateTime.Parse(row["Address"].ToString()) : null;
        }
    }
}
