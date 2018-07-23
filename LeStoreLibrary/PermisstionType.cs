using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeStoreLibrary
{
    public enum PermisstionType
    {
        // System
        LoginLogout = 1001,

        // Admin
        SetRole4User = 2001,

        // Account
        CreateAccount = 3001,
        UpdateAccount = 3002,
        SearchAccount = 3003,
        DeleteAccount = 3003,

        // Product
        CreateProduct = 4001,
        UpdateProduct = 4002,
        SearchProduct = 4003,
        DeleteProduct = 4004,

        // Category
        CreateCategory = 5001,
        UpdateCategory = 5002,
        DeleteCategory = 5003,
        SearchCategory = 5004,
    }
}
