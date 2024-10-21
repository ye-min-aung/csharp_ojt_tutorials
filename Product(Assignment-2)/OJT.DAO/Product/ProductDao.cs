using DAO.Common;
using OJT.Entities.Product;
using System;
using System.Data;
using System.Data.SqlClient;

namespace OJT.DAO.Product
{
    public class ProductDao
    {

        /// <summary>
        /// Defines Database Connection..
        /// </summary>
        private DbConnection connection = new DbConnection();

        /// <summary>
        /// Defines strSql..
        /// </summary>
        private string strSql = String.Empty;

        /// <summary>
        /// Defines the resultDataTable.
        /// </summary>
        private DataTable resultDataTable = new DataTable();

        /// <summary>
        /// Defines the existCount.
        /// </summary>
        private int existCount;

        /// <summary>
        /// Get All
        /// </summary>
        public DataTable GetAll()
        {
            string strSql = "SELECT P.product_id, P.product_name, P.product_price, U.unit_name, U.unit_id " +
                "FROM ProductTable P LEFT JOIN ProductUnit PU ON P.product_id = PU.product_id " +
                "LEFT JOIN Unit U ON PU.unit_id = U.unit_id";
            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        public DataTable GetAllUnit()
        {
            strSql = "SELECT * FROM Unit";

            return connection.ExecuteDataTable (CommandType.Text, strSql);
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable Get(int id)
        {
            strSql = "SELECT * FROM Employees " +
                      "WHERE  EmployeeId= " + id;

            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        /// <summary>
        /// Create Employee
        /// </summary>
        /// <param name="employeeEntity">.</param>
        public bool Insert(ProductEntity product, string unit)
        {
            string id = generateId();
            string insertProductSql = "INSERT INTO ProductTable (product_id, product_name, product_price) " +
                                       "VALUES (@ProductId, @ProductName, @ProductPrice);";

            //string insertUnitSql = "INSERT INTO Unit (unit_name) " +
            //                        "OUTPUT INSERTED.unit_id " +
            //                        "VALUES (@UnitName);";

            string insertProductUnitSql = "INSERT INTO ProductUnit (product_id, unit_id) " +
                                           "VALUES (@ProductId, @UnitID);";

            SqlParameter[] productParams = {
                new SqlParameter("@ProductId", id),
                new SqlParameter("@ProductName", product.Product_Name),
                new SqlParameter("@ProductPrice", product.Product_Price)
            };
             bool productSuccess = connection.ExecuteNonQuery(CommandType.Text, insertProductSql, productParams);

            //int unitId;
            //SqlParameter[] unitParams = {
            //    new SqlParameter("@UnitName", unit.unitName)
            //};
            //unitId = (int)connection.ExecuteScalar(CommandType.Text, insertUnitSql, unitParams); // Get the inserted UnitID

            SqlParameter[] productUnitParams = {
                new SqlParameter("@ProductId", id),
                new SqlParameter("@UnitID", unit)
            };
            bool productUnitSuccess = connection.ExecuteNonQuery(CommandType.Text, insertProductUnitSql, productUnitParams);

            return productSuccess && productUnitSuccess;
        }



        /// <summary>
        /// Create Employee
        /// </summary>
        /// <param name="employeeEntity">.</param>
        public bool Update(ProductEntity product, string unit)
        {
            string updateProductSql = "UPDATE ProductTable " +
                                        "SET product_name = @ProductName, product_price = @ProductPrice " +
                                        "WHERE product_id = @ProductId;";

            string updateProductUnitSql = "UPDATE ProductUnit " +
                                            "SET unit_id = @UnitId " +
                                            "WHERE product_id = @ProductId";

            SqlParameter[] productunitParams =
            {
                new SqlParameter("@UnitId" , unit),
                new SqlParameter("@ProductId" , product.Product_Id)
            };

            SqlParameter[] productParams = {
            new SqlParameter("@ProductId", product.Product_Id), 
            new SqlParameter("@ProductName", product.Product_Name),
            new SqlParameter("@ProductPrice", product.Product_Price)
            };

            bool productSuccess = connection.ExecuteNonQuery(CommandType.Text, updateProductSql, productParams);
            bool productunitSuccess = connection.ExecuteNonQuery(CommandType.Text, updateProductUnitSql, productunitParams);

            //SqlParameter[] unitParams = {
            //new SqlParameter("@UnitName", unit.unitName), 
            //new SqlParameter("@ProductId", product.Product_Id)
            //};

            //bool unitSuccess = connection.ExecuteNonQuery(CommandType.Text, updateUnitSql, unitParams);

            //return productSuccess && unitSuccess;
            return productSuccess && productunitSuccess;

        }

        /// <summary>
        /// Delete.
        /// </summary>
        /// <param name="id">.</param>
        public bool Delete(string id)
        {
            string productSql = "DELETE FROM ProductTable  WHERE product_id = @ProductId;";
            string unitSql = "DELETE FROM Unit  WHERE unit_id = (select unit_id from ProductUnit where product_id = @ProductId);";
            string productunitSql = "DELETE FROM ProductUnit  WHERE product_id = @ProductId;";

            SqlParameter[] productIdParam = {
                                        new SqlParameter("@ProductId", id)
                                      };

            bool productSuccess = connection.ExecuteNonQuery(CommandType.Text, productSql, productIdParam);
            bool unitSuccess = connection.ExecuteNonQuery(CommandType.Text, unitSql, productIdParam);
            bool productUnitSuccess = connection.ExecuteNonQuery(CommandType.Text, productunitSql, productIdParam);
            return productSuccess && unitSuccess && productUnitSuccess;
        }

        private string generateId()
        {
            string cid;
            using (SqlConnection connection = new SqlConnection("Server=DESKTOP-4VM5D0P\\SQLEXPRESS;Database=AllDB;User Id=sa;Password=root;Trusted_Connection=True;"))
            {
                string query = "SELECT MAX(id) FROM ProductTable";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    connection.Open();
                    object result = cmd.ExecuteScalar();

                    int id = result != DBNull.Value ? Convert.ToInt32(result) : 0;

                    id++;
                    cid = "C-" + id.ToString("D4");
                }
            }
            return cid;
        }

        public bool AddUnit(UnitEntity unit)
        {
            string insertUnitSql = "INSERT INTO Unit (unit_name) " +
                                    "VALUES (@UnitName);";

            SqlParameter[] unitParams = {
                new SqlParameter("@UnitName", unit.unitName)
            };

            bool unitSuccess = connection.ExecuteNonQuery(CommandType.Text, insertUnitSql, unitParams);

            return unitSuccess;
        }

        public bool UnitDelete(string id)
        {
            string unitSql = "DELETE FROM Unit  WHERE unit_id = @UnitId;";

            SqlParameter[] unitIdParam = {
                                        new SqlParameter("@UnitId", id)
                                      };

            bool unitSuccess = connection.ExecuteNonQuery(CommandType.Text, unitSql, unitIdParam);
            return unitSuccess;
        }

        public bool UpdateUnit(UnitEntity unit)
        {
            string updateUnitSql = "UPDATE Unit " +
                                    "SET unit_name = @UnitName " +
                                    "WHERE unit_id = @UnitId;";

            SqlParameter[] unitUpdateParam = {
                                        new SqlParameter("@UnitName", unit.unitName),
                                        new SqlParameter("@UnitId", unit.unitId)
                                      };

            bool unitSuccess = connection.ExecuteNonQuery(CommandType.Text, updateUnitSql, unitUpdateParam);
            return unitSuccess;
        }
    }
}
