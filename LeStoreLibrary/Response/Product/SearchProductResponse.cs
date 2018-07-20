using LeStoreLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeStoreLibrary.Response.Product
{
    public class SearchProductResponse : Response
    {
        public List<ProductModel> products { get; set; }
    }
}
