using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeStoreDAO.Utils
{
    public class SqlCommandStore
    {
        // Account
        public const string uspAccountLogin =  "uspAccountLogin";
        public const string uspCreateAccount = "uspCreateAccount";
        public const string uspUpdateAccount = "uspUpdateAccount";
        public const string uspDeleteAccount = "uspDeleteAccount";
        public const string uspSearchAccount = "uspSearchAccount";

        // Product
        public const string uspCreateProduct = "uspCreateProduct";
        public const string uspUpdateProduct = "uspUpdateProduct";
        public const string uspSearchProduct = "uspSearchProduct";
        public const string uspDeleteProduct = "uspDeleteProduct";

        // Category
        public const string uspCreateCategory = "uspCreateCategory";
        public const string uspDeleteCategory = "uspDeleteCategory";
        public const string uspSearchCategory = "uspSearchCategory";
        public const string uspUpdateCategory = "uspUpdateCategory";
    }
}
