using DAO.Employee;
using OJT.DAO.Product;
using OJT.Entities.Product;

namespace OJT.Services.Product
{
    public class ProductService
    {
        private ProductDao productDao = new ProductDao();


        public bool Insert(ProductEntity product, UnitEntity unit)
        {
            return productDao.Insert(product, unit);
        }

    }
}
