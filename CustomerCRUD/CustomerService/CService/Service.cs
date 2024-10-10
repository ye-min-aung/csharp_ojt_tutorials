namespace CustomerService.CService
{
    public class Service
    {
        private CustomerDao customerDao = new CustomerDao();


        #region==========Employee========== 
        /// <summary>
        /// Get All.
        /// </summary>
        public DataTable GetAll()
        {
            DataTable dt = customerDao.GetAll();
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
            DataTable dt = customerDao.Get(id);
            return dt;
        }

        /// <summary>
        /// Save Employee.
        /// </summary>
        /// <param name="employeeEntity">.</param>
        public bool Insert(Customer customer)
        {
            return customerDao.Insert(customer);
        }

        /// <summary>
        /// Update Employee.
        /// </summary>
        /// <param name="employeeEntity">.</param>
        public bool Update(Customer customer)
        {
            return customerDao.Update(customer);
        }

        /// <summary>
        /// Delete Employee.
        /// </summary>
        /// <param name="id">.</param>
        public bool Delete(int id)
        {
            return customerDao.Delete(id);
        }
    }
}
