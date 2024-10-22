using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAO.Employee;
using Entities.Employee;

namespace Services.Employee
{
    /// <summary>
    /// Defines the <see cref="ProductService" />.
    /// </summary>
    public class EmployeeService
    {
        /// <summary>
        /// Define product Dao..
        /// </summary>
        private EmployeeDao employeeDao = new EmployeeDao();


        #region==========Employee========== 
        /// <summary>
        /// Get All.
        /// </summary>
        public DataTable GetAll()
        {
            DataTable dt = employeeDao.GetAll();
            return dt;
        }
        #endregion

        /// <summary>
        /// Get.
        /// </summary>
        /// <param name="id">.</param>
        /// <returns>.</returns>
        public DataTable Get(int id)
        {
            DataTable dt = employeeDao.Get(id);
            return dt;
        }

        /// <summary>
        /// Save Employee.
        /// </summary>
        /// <param name="employeeEntity">.</param>
        public bool Insert(EmployeeEntity employeeEntity)
        {
           return employeeDao.Insert(employeeEntity);
        }

        /// <summary>
        /// Update Employee.
        /// </summary>
        /// <param name="employeeEntity">.</param>
        public bool Update(EmployeeEntity employeeEntity)
        {
            return employeeDao.Update(employeeEntity);
        }

        /// <summary>
        /// Delete Employee.
        /// </summary>
        /// <param name="id">.</param>
        public bool Delete(int id)
        {
            return employeeDao.Delete(id);
        }
    }
}
