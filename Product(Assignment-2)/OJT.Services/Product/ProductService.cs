using OJT.DAO.Product;
using OJT.Entities.Product;
using System.Data;

namespace OJT.Services.Product
{
    public class ProductService
    {
        private ProductDao productDao = new ProductDao();


        public bool Insert(ProductEntity product, string unit)
        {
            return productDao.Insert(product, unit);
        }

        public DataTable getAllData()
        {
            DataTable dataTable = new DataTable();
            dataTable = productDao.GetAll();

            return dataTable;
        }

        public bool Update(ProductEntity product, string unit)
        {
            return productDao.Update(product, unit);
        }

        public bool Delete(string productId)
        {
            return productDao.Delete(productId);
        }

        public bool AddUnit(UnitEntity unit)
        {
            return productDao.AddUnit(unit);
        }

        public DataTable GetAllUnit()
        {
            return productDao.GetAllUnit();
        }

        public bool DeleteUnit(string unitId)
        {
            return productDao.UnitDelete(unitId);
        }
        public bool UpdateUnit(UnitEntity unit)
        {
            return productDao.UpdateUnit(unit);
        }

    }
}
