using CustomerDAO.Common;
using System.Data;
using System.Data.SqlClient;
using CustomerEntity.Customer;
public class CustomerDao
{
    private DBConnection connection = new DBConnection();


    private string strSql = String.Empty;


    private DataTable resultDataTable = new DataTable();


    private int existCount;


    public DataTable GetAll()
    {
        strSql = "SELECT * FROM CustomerTable ";

        return connection.ExecuteDataTable(CommandType.Text, strSql);
    }

    public DataTable Get(int id)
    {
        strSql = "SELECT * FROM CustomerTable " +
                  "WHERE  EmployeeId= " + id;

        return connection.ExecuteDataTable(CommandType.Text, strSql);
    }

    public bool Insert(Customer customer)
    {
        strSql = "INSERT INTO CustomerTable ( [customer_id],[customer_name], [nrc_number], [dob]," +
            " [member_card], [email], [gender], [phone_no_1], [phone_no_2], [photo], [address]," +
            " [created_user_id], [created_datetime], [updated_user_id], [updated_datetime], " +
            "[is_deleted], [deleted_user_id], [deleted_datetime], [password]) " +
            "VALUES (@customer_id, @customer_name, @nrc_number, @dob, @member_card, " +
            "@Email, @gender, @phone_no_1, @phone_no_2, @photo, @address, @created_user_id," +
            " @created_datetime, @updated_user_id, @updated_datetime, @is_deleted, " +
            "@deleted_user_id, @deleted_datetime, @password)";

        SqlParameter[] sqlParam = {
                                    new SqlParameter("@customer_id", customer.customer_id),
                                    new SqlParameter("@customer_name", customer.customer_name),
                                    new SqlParameter("@nrc_number", customer.nrc_number),
                                    new SqlParameter("@dob", customer.dob),
                                    new SqlParameter("@member_card", customer.member_card),
                                    new SqlParameter("@Email", customer.email),
                                    new SqlParameter("@gender", customer.gender),
                                    new SqlParameter("@phone_no_1", customer.phone_no_1),
                                    new SqlParameter("@phone_no_2", customer.phone_no_2),
                                    new SqlParameter("@photo", customer.photo),
                                    new SqlParameter("@address", customer.address),
                                    new SqlParameter("@created_user_id", 1),
                                    new SqlParameter("@created_datetime", DateTime.Now),
                                    new SqlParameter("@updated_user_id", 1),
                                    new SqlParameter("@updated_datetime", DateTime.Now),
                                    new SqlParameter("@is_deleted", 0),
                                    new SqlParameter("@deleted_user_id", 1),
                                    new SqlParameter("@password", customer.password)
                                  };
        bool success = connection.ExecuteNonQuery(CommandType.Text, strSql, sqlParam);

        return success;
    }

    public bool Update(Customer customer)
    {
        strSql = "UPDATE CustomerTable SET [customer_name] = @customer_name, [nrc_number] = @nrc_number," +
            " [dob] = @dob, [member_card] = @member_card, [email] = @Email, [gender] = @gender," +
            " [phone_no_1] = @phone_no_1, [phone_no_2] = @phone_no_2, [photo] = @photo," +
            " [address] = @address, [updated_user_id] = @updated_user_id, [updated_datetime] = @updated_datetime," +
            " [password] = @password WHERE [customer_id] = @customer_id";

        SqlParameter[] sqlParam = {
                                    new SqlParameter("@customer_id", customer.customer_id),
                                    new SqlParameter("@customer_name", customer.customer_name),
                                    new SqlParameter("@nrc_number", customer.nrc_number),
                                    new SqlParameter("@dob", customer.dob),
                                    new SqlParameter("@member_card", customer.member_card),
                                    new SqlParameter("@Email", customer.email),
                                    new SqlParameter("@gender", customer.gender),
                                    new SqlParameter("@phone_no_1", customer.phone_no_1),
                                    new SqlParameter("@phone_no_2", customer.phone_no_2),
                                    new SqlParameter("@photo", customer.photo),
                                    new SqlParameter("@address", customer.address),
                                    new SqlParameter("@updated_user_id", 1),
                                    new SqlParameter("@updated_datetime", DateTime.Now),
                                    new SqlParameter("@password", customer.password)
                                  };
        bool success = connection.ExecuteNonQuery(CommandType.Text, strSql, sqlParam);

        return success;
    }

    public bool Delete(int id)
    {
        strSql = "UPDATE CustomerTable SET is_deleted = 1 WHERE customer_id = @customer_id";
        SqlParameter[] sqlParam = {
                                    new SqlParameter("@customer_id", id)
                                  };
        bool success = connection.ExecuteNonQuery(CommandType.Text, strSql, sqlParam);
        return success;
    }
}
