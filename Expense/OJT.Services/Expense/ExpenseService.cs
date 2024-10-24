using OJT.DAO.Expense;
using OJT.Entities.Expense;
using System;
using System.Data;

namespace OJT.Services.Expense
{
    public class ExpenseService
    {
        ExpenseDAO expenseDAO = new ExpenseDAO();

        public DataTable GetAllCategory()
        {
            DataTable dt = expenseDAO.GetAllCategory();
            return dt;
        }

        public bool InsertCategory(string categoryName)
        {
            return expenseDAO.InsertCategory(categoryName);
        }

        //public DataTable Get(int id)
        //{
        //    DataTable dt = employeeDao.Get(id);
        //    return dt;
        //}

        public bool Insert(ExpenseEntity ExpenseEntity)
        {
            return expenseDAO.Insert(ExpenseEntity);
        }

        public DataTable GetAllExpense(DateTime? fromDate, DateTime? toDate, string person, int? categoryId, int pageSize, int pageNumber)
        {
            return expenseDAO.GetAllExpense(fromDate, toDate, person, categoryId, pageSize, pageNumber);
        }

        public DataTable GetAllExpenseNOFit()
        {
            return expenseDAO.GetAllExpenseNOFit();
        }

        //public bool Update(EmployeeEntity employeeEntity)
        //{
        //    return employeeDao.Update(employeeEntity);
        //}

        //public bool Delete(int id)
        //{
        //    return employeeDao.Delete(id);
        //}

    }
}
