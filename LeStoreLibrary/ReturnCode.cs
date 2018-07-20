using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeStoreLibrary
{
    public enum ReturnCode
    {
        Success = 1,
        Fail,
        InvalidRequest = 2,
        Account_NotExist = -1001,

        // Product
        Product_Exist = -2001,

        // Category
        Category_Exist = -3001,

        // Order
        Order_Exist = -4001,
        Order_NotExist = -4002

    }
}
