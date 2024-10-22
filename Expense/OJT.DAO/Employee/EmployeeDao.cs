using DAO.Common;
using System;
using System.Data;
using System.Collections.Generic;
using Entities.Employee;
using System.Data.SqlClient;

namespace DAO.Employee
{
    /// <summary>
    /// Defines the <see cref="ProductDao" />.
    /// </summary>
    public class EmployeeDao
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

        #region==========Product========== 

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
        public bool Insert(EmployeeEntity employeeEntity)
        {
            strSql = "INSERT INTO Employees(Name,Address,Designation,Salary,JoiningDate)" +
                     "VALUES(@Name, @Address, @Designation, @Salary, @JoiningDate)";

            SqlParameter[] sqlParam = {
                                        new SqlParameter("@Name", employeeEntity.name),
                                        new SqlParameter("@Address", employeeEntity.address),
                                        new SqlParameter("@Designation", employeeEntity.designation),
                                        new SqlParameter("@Salary", employeeEntity.salary),
                                        new SqlParameter("@JoiningDate", employeeEntity.joiningDate)
                                      };
            bool success =  connection.ExecuteNonQuery(CommandType.Text, strSql, sqlParam);

            return success;
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
        #endregion
    }
}
