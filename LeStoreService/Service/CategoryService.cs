using LeStoreDAO;
using LeStoreLibrary.Request.Category;
using LeStoreLibrary.Response.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeStoreService.Service
{
    public class CategoryService
    {
        DataAccess dao = new DataAccess();

        public CreateCategoryResponse CreateCategory(CreateCategoryRequest request)
        {
            return dao.CreateCategory(request);
        }

        public UpdateCategoryResponse UpdateCategory(UpdateCategoryRequest request)
        {
            return dao.UpdateCategory(request);
        }
        public SearchCategoryResponse SearchCategory(SearchCategoryRequest request)
        {
            return dao.SearchCategory(request);
        }

        public DeleteCategoryResponse DeleteCategory(DeleteCategoryRequest request)
        {
            return dao.DeleteCategory(request);
        }
    }
}
