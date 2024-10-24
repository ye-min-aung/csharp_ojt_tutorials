using DAO.Common;
using OJT.Entities.Expense;
using System;
using System.Data;
using System.Data.SqlClient;

namespace OJT.DAO.Expense
{
    public class ExpenseDAO
    {
        private DbConnection connection = new DbConnection();

        private string strSql = String.Empty;

        private DataTable resultDataTable = new DataTable();

        private int existCount;

        public DataTable GetAllCategory()
        {
            strSql = "SELECT * FROM Category ";

            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        public bool InsertCategory(string categoryName)
        {
            strSql = "INSERT INTO Category(category_name)" +
                     "VALUES(@CategoryName)";

            SqlParameter[] sqlParam = {
                                        new SqlParameter("@CategoryName", categoryName)
                                      };
            bool success = connection.ExecuteNonQuery(CommandType.Text, strSql, sqlParam);

            return success;
        }

        public bool Insert(ExpenseEntity expenseEntity)
        {
            strSql = "INSERT INTO Expense(expense_name, category, date, person, amount) " +
                     "VALUES(@Name, @Category, @Date, @Person, @Amount)";

            SqlParameter[] sqlParam = {
                                new SqlParameter("@Name", expenseEntity.expenseName),
                                new SqlParameter("@Category", expenseEntity.category),
                                new SqlParameter("@Date", expenseEntity.date),
                                new SqlParameter("@Person", expenseEntity.person),
                                new SqlParameter("@Amount", expenseEntity.Amount)
                              };

            bool success = connection.ExecuteNonQuery(CommandType.Text, strSql, sqlParam);

            return success;
        }


        public DataTable GetAllExpenseNOFit()
        {
            strSql = "select E.expense_id, E.expense_name, C.category_name, C.category_id, e.date, e.person ,e.Amount " +
                                    "from Expense E left Join Category C on E.category = C.category_id";

            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        public DataTable GetAllExpense(DateTime? fromDate, DateTime? toDate, string person, int? categoryId, int pageSize, int pageNumber)
        {
            DataTable dt = new DataTable();
            using (SqlConnection sqlConn = new SqlConnection("Server=DESKTOP-4VM5D0P\\SQLEXPRESS;Database=AllDB;User Id=sa;Password=root;Trusted_Connection=True;"))
            {
                try
                {
                    sqlConn.Open();
                    //strSql = "select E.expense_id, E.expense_name, C.category_name, C.category_id, e.date, e.person,e.Amount " +
                    //               "from Expense E left Join Category C on E.category = C.category_id where 1=1";

                    strSql = "select E.expense_id, E.expense_name, C.category_name, C.category_id, E.date, E.person, E.Amount " +
                           "from Expense E left Join Category C on E.category = C.category_id where 1=1";

                    if (fromDate.HasValue)
                        strSql += " AND E.date >= @FromDate";
                    if (toDate.HasValue)
                        strSql += " AND E.date <= @ToDate";
                    if (!string.IsNullOrEmpty(person))
                        strSql += " AND E.person LIKE @Person";
                    if (categoryId.HasValue)
                        strSql += " AND C.category_id = @CategoryId";

                    strSql += " ORDER BY E.date DESC OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;";

                    using (SqlCommand sqlCmd = new SqlCommand(strSql, sqlConn))
                    {
                        sqlCmd.CommandType = CommandType.Text;

                        if (fromDate.HasValue)
                            sqlCmd.Parameters.AddWithValue("@FromDate", fromDate.Value);
                        if (toDate.HasValue)
                            sqlCmd.Parameters.AddWithValue("@ToDate", toDate.Value);
                        if (!string.IsNullOrEmpty(person))
                            sqlCmd.Parameters.AddWithValue("@Person", "%" + person + "%");
                        if (categoryId.HasValue)
                            sqlCmd.Parameters.AddWithValue("@CategoryId", categoryId.Value);

                        int offset = (pageNumber - 1) * pageSize;
                        sqlCmd.Parameters.AddWithValue("@Offset", offset);
                        sqlCmd.Parameters.AddWithValue("@PageSize", pageSize);

                        Console.WriteLine(strSql);
                        using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
                catch (Exception ex)
                {
                    string msg = ex.Message;
                }
                finally
                {
                    if (sqlConn.State == ConnectionState.Open)
                    {
                        sqlConn.Close();
                    }
                }
            }

            return dt;
        }



        //public bool Update(EmployeeEntity employeeEntity)
        //{
        //    strSql = "UPDATE Employees SET Name=@Name,Address=@Address,Designation=@Designation,Salary=@Salary,JoiningDate=@JoiningDate WHERE EmployeeId = @EmployeeId";

        //    SqlParameter[] sqlParam = {
        //                                new SqlParameter("@EmployeeId", employeeEntity.employeeId),
        //                                new SqlParameter("@Name", employeeEntity.name),
        //                                new SqlParameter("@Address", employeeEntity.address),
        //                                new SqlParameter("@Designation", employeeEntity.designation),
        //                                new SqlParameter("@Salary", employeeEntity.salary),
        //                                new SqlParameter("@JoiningDate", employeeEntity.joiningDate)
        //                              };
        //    bool success = connection.ExecuteNonQuery(CommandType.Text, strSql, sqlParam);

        //    return success;
        //}

        public bool Delete(int id)
        {
            strSql = "DELETE FROM Employees  WHERE EmployeeId =@EmployeeId";
            SqlParameter[] sqlParam = {
                                        new SqlParameter("@EmployeeId", id)
                                      };
            bool success = connection.ExecuteNonQuery(CommandType.Text, strSql, sqlParam);
            return success;
        }
    }
}
