using DAO.Common;
using Entities.Employee;
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
            strSql = "SELECT * FROM Employees ";

            return connection.ExecuteDataTable(CommandType.Text, strSql);
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
        public bool Insert(ProductEntity product, UnitEntity unit)
        {
            string id = generateId();
            string insertProductSql = "INSERT INTO ProductTable (product_id, product_name, product_price) " +
                                       "VALUES (@ProductId, @ProductName, @ProductPrice);";

            string insertUnitSql = "INSERT INTO Unit (unit_name) " +
                                    "OUTPUT INSERTED.unit_id " + // Get the inserted UnitID
                                    "VALUES (@UnitName);";

            string insertProductUnitSql = "INSERT INTO ProductUnit (product_id, unit_id) " +
                                           "VALUES (@ProductId, @UnitID);";

            SqlParameter[] productParams = {
                    new SqlParameter("@ProductId", id),
                    new SqlParameter("@ProductName", product.Product_Name),
                    new SqlParameter("@ProductPrice", product.Product_Price)
                };
                bool productSuccess = connection.ExecuteNonQuery(CommandType.Text, insertProductSql, productParams);

                // Insert the unit and get the generated UnitID
                int unitId;
                SqlParameter[] unitParams = {
                    new SqlParameter("@UnitName", unit.unitName)
                };
                unitId = (int)connection.ExecuteScalar(CommandType.Text, insertUnitSql, unitParams); // Get the inserted UnitID

            // Insert the relationship into the ProductUnit table
            SqlParameter[] productUnitParams = {
                    new SqlParameter("@ProductId", id),
                    new SqlParameter("@UnitID", unitId)
                };
                bool productUnitSuccess = connection.ExecuteNonQuery(CommandType.Text, insertProductUnitSql, productUnitParams);

                return productSuccess && productUnitSuccess;
        }



        /// <summary>
        /// Create Employee
        /// </summary>
        /// <param name="employeeEntity">.</param>
        public bool Update(EmployeeEntity employeeEntity)
        {
            strSql = "UPDATE Employees SET Name=@Name,Address=@Address,Designation=@Designation,Salary=@Salary,JoiningDate=@JoiningDate WHERE EmployeeId = @EmployeeId";

            SqlParameter[] sqlParam = {
                                        new SqlParameter("@EmployeeId", employeeEntity.employeeId),
                                        new SqlParameter("@Name", employeeEntity.name),
                                        new SqlParameter("@Address", employeeEntity.address),
                                        new SqlParameter("@Designation", employeeEntity.designation),
                                        new SqlParameter("@Salary", employeeEntity.salary),
                                        new SqlParameter("@JoiningDate", employeeEntity.joiningDate)
                                      };
            bool success = connection.ExecuteNonQuery(CommandType.Text, strSql, sqlParam);

            return success;
        }

        /// <summary>
        /// Delete.
        /// </summary>
        /// <param name="id">.</param>
        public bool Delete(int id)
        {
            strSql = "DELETE FROM Employees  WHERE EmployeeId =@EmployeeId";
            SqlParameter[] sqlParam = {
                                        new SqlParameter("@EmployeeId", id)
                                      };
            bool success = connection.ExecuteNonQuery(CommandType.Text, strSql, sqlParam);
            return success;
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
    }
}
