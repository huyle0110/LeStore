using LeStoreDAO;
using LeStoreLibrary.Request.Product;
using LeStoreLibrary.Response.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeStoreService.Service
{
    public class ProductService
    {
        DataAccess dao = new DataAccess();

        public CreateProductResponse CreateProduct(CreateProductRequest request)
        {
            return dao.CreateProduct(request);
        }

        public UpdateProductResponse UpdateProduct(UpdateProductRequest request)
        {
            return dao.UpdateProduct(request);
        }
        public DeleteProductResponse DeleteProduct(DeleteProductRequest request)
        {
            return dao.DeleteProduct(request);
        }

        public SearchProductResponse SearchProduct(SearchProductRequest request)
        {
            return dao.SearchProduct(request);
        }
    }
}
