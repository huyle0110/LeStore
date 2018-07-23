using LeStoreLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeStoreLibrary.Response.Category
{
    public class SearchCategoryResponse : Response
    {
        public List<CategoryModel> categorys { get; set; }
    }
}
