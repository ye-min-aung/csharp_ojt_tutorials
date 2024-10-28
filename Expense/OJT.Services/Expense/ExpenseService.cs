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

        public bool UpdateCategory(CategoryEntity categoryEntity)
        {
            return expenseDAO.UpdateCategory(categoryEntity);
        }

        public bool DeleteCategory(int id)
        {
            return expenseDAO.DeleteCategory(id);
        }


        //Expense
        public bool Insert(ExpenseEntity ExpenseEntity)
        {
            return expenseDAO.Insert(ExpenseEntity);
        }

        public DataTable GetAllExpense(DateTime? fromDate, DateTime? toDate, string person, int? categoryId, int pageSize, int pageNumber)
        {
            return expenseDAO.GetAllExpense(fromDate, toDate, person, categoryId, pageSize, pageNumber);
        }

        public int GetTotalExpensesCount(DateTime? fromDate, DateTime? toDate, string person, int? categoryId)
        {
            return expenseDAO.GetTotalExpensesCount(fromDate, toDate, person, categoryId);
        }

        public DataTable GetAllExpenseNOFit()
        {
            return expenseDAO.GetAllExpenseNOFit();
        }

        public bool Update(ExpenseEntity expenseEntity)
        {
            return expenseDAO.Update(expenseEntity);
        }

        public bool Delete(int id)
        {
            return expenseDAO.Delete(id);
        }

    }
}
