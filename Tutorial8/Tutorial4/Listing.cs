using OfficeOpenXml;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace Tutorial4
{
    public partial class Listing : Form
    {
        public Listing()
        {
            InitializeComponent();
            dataGridView1.RowTemplate.Height = 80;
            getTotalPage();
        }

        public string connectionString = "Server=DESKTOP-4VM5D0P\\SQLEXPRESS;Database=AllDB;User Id=sa;Password=root;Trusted_Connection=True;";

        public static DataTable table;
        int select;
        string imagePath = "";
        int num = 0;
        int pageSize = 3;
        int currentPageIndex = 1;
        int totalPage = 0;
        string searchKeyword = "";

        private byte[] key = Convert.FromBase64String("k1rZt6cU5fD9G2dIbZRZksQ2pZJfw6PzfvA1wfg3Zb8=");
        private byte[] iv = Convert.FromBase64String("9vHdlrZ7QwJwU4r1cqls2g==");

        //public void LoadData(int page, string searchKeyword)
        //{
        //    string query = "";
        //    if (page == 1)
        //    {
        //        if(searchKeyword != null ||  searchKeyword.Length != 0)
        //        {
        //            query = "SELECT TOP " + pageSize + " [id], [customer_id], [customer_name], [nrc_number], [dob], [member_card], [email], [gender], [phone_no_1], [phone_no_2], [photo], [address], [password] FROM CustomerTable" +
        //                " WHERE is_deleted = 0 AND (customer_name LIKE '%'+ @searchKeyword+'%' OR email LIKE '%'+ @searchKeyword+'%' OR  phone_no_1 LIKE '%' + @searchKeyword + '%' OR  phone_no_2 LIKE '%' + @searchKeyword + '%' OR  gender LIKE '%' + @searchKeyword + '%' )" +
        //                " ORDER BY id";
        //        }
        //        else
        //        {
        //            query = "SELECT TOP " + pageSize + " [id], [customer_id], [customer_name], [nrc_number], [dob], [member_card], [email], [gender], [phone_no_1], [phone_no_2], [photo], [address], [password] FROM CustomerTable WHERE is_deleted = 0 ORDER BY id";
        //        }
        //    }
        //    else
        //    {
        //        if(searchKeyword != null || searchKeyword.Length != 0)
        //        {
        //            int previousPageOffSet = (page - 1) * pageSize;
        //            query = "SELECT TOP " + pageSize + " [id], [customer_id], [customer_name], [nrc_number], [dob], [member_card], [email], [gender], [phone_no_1], [phone_no_2], [photo], [address], [password] FROM CustomerTable WHERE id NOT IN (SELECT TOP " + previousPageOffSet + " [id] FROM CustomerTable WHERE is_deleted = 0 ORDER BY [id]) " +
        //                "AND is_deleted = 0 AND (customer_name LIKE '%'+ @searchKeyword+'%' OR email LIKE '%'+ @searchKeyword+'%' OR  phone_no_1 LIKE '%' + @searchKeyword + '%' OR  phone_no_2 LIKE '%' + @searchKeyword + '%' OR  gender LIKE '%' + @searchKeyword + '%' )" +
        //                " ORDER BY [id]";
        //        }
        //        else
        //        {
        //            int previousPageOffSet = (page - 1) * pageSize;
        //            query = "SELECT TOP " + pageSize + " [id], [customer_id], [customer_name], [nrc_number], [dob], [member_card], [email], [gender], [phone_no_1], [phone_no_2], [photo], [address], [password] FROM CustomerTable WHERE id NOT IN (SELECT TOP " + previousPageOffSet + " [id] FROM CustomerTable WHERE is_deleted = 0 ORDER BY [id]) AND is_deleted = 0 ORDER BY [id]";
        //        }
        //    }

        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();

        //        SqlCommand cmd = new SqlCommand(query, connection);
        //        if (searchKeyword != null || searchKeyword.Length != 0)
        //        {
        //            cmd.Parameters.AddWithValue("@searchKeyword", searchKeyword);
        //        }
        //        {
        //            cmd.Parameters.AddWithValue("@searchKeyword", searchKeyword);
        //        }

        //        SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
        //        DataTable dataTable = new DataTable();
        //        dataTable.Clear();
        //        dataAdapter.Fill(dataTable);

        //        dataTable.Columns.Add("GenderType", typeof(string));
        //        dataTable.Columns.Add("Member", typeof(string));
        //        dataTable.Columns.Add("Password", typeof(string));

        //        dataTable.Columns.Add("PhotoImage", typeof(Image));

        //        foreach (DataRow row in dataTable.Rows)
        //        {

        //            int genderValue = Convert.ToInt32(row["gender"]);
        //            int member = Convert.ToInt32(row["member_card"]);
        //            string encryptedPassword = row["password"].ToString();
        //            string decryptedPassword = decryptPassword(encryptedPassword, key, iv);
        //            row["password"] = decryptedPassword;

        //            switch (genderValue)
        //            {
        //                case 0:
        //                    row["GenderType"] = "Other";
        //                    break;
        //                case 1:
        //                    row["GenderType"] = "Male";
        //                    break;
        //                case 2:
        //                    row["GenderType"] = "Female";
        //                    break;
        //                default:
        //                    break;
        //            }

        //            switch (member)
        //            {
        //                case 1:
        //                    row["Member"] = "Yes";
        //                    break;
        //                case 2:
        //                    row["Member"] = "No";
        //                    break;
        //                default:
        //                    break;
        //            }

        //            string photoPath = row["photo"].ToString();

        //            if (File.Exists(photoPath))
        //            {
        //                Image image = Image.FromFile(photoPath);
        //                row["PhotoImage"] = image;
        //            }
        //            else
        //            {
        //                row["PhotoImage"] = null;
        //            }
        //        }

        //        dataGridView1.DataSource = dataTable;

        //        dataGridView1.Columns["gender"].Visible = false;
        //        dataGridView1.Columns["member_card"].Visible = false;
        //        dataGridView1.Columns["photo"].Visible = false;
        //        dataGridView1.Columns["id"].Visible = false;
        //        ((DataGridViewImageColumn)dataGridView1.Columns["PhotoImage"]).ImageLayout = DataGridViewImageCellLayout.Stretch;
        //    }
        //}

        public void LoadData(int page, string searchKeyword)
        {
            string query = "";
            SqlCommand command = null;

            if (page == 1)
            {
                if (!string.IsNullOrEmpty(searchKeyword))
                {
                    query = "SELECT TOP " + pageSize + " [id], [customer_id], [customer_name], [nrc_number], [dob], [member_card], [email], [gender], [phone_no_1], [phone_no_2], [photo], [address], [password] FROM CustomerTable " +
                            "WHERE is_deleted = 0 AND (customer_name LIKE '%' + @searchKeyword + '%' OR email LIKE '%' + @searchKeyword + '%' OR phone_no_1 LIKE '%' + @searchKeyword + '%' OR phone_no_2 LIKE '%' + @searchKeyword + '%' OR gender LIKE '%' + @searchKeyword + '%') " +
                            "ORDER BY id";
                }
                else
                {
                    query = "SELECT TOP " + pageSize + " [id], [customer_id], [customer_name], [nrc_number], [dob], [member_card], [email], [gender], [phone_no_1], [phone_no_2], [photo], [address], [password] FROM CustomerTable WHERE is_deleted = 0 ORDER BY id";
                }
            }
            else
            {
                int previousPageOffSet = (page - 1) * pageSize;

                if (!string.IsNullOrEmpty(searchKeyword))
                {
                    query = "SELECT TOP " + pageSize + " [id], [customer_id], [customer_name], [nrc_number], [dob], [member_card], [email], [gender], [phone_no_1], [phone_no_2], [photo], [address], [password] FROM CustomerTable " +
                            "WHERE id NOT IN (SELECT TOP " + previousPageOffSet + " [id] FROM CustomerTable WHERE is_deleted = 0 AND (customer_name LIKE '%' + @searchKeyword + '%' OR email LIKE '%' + @searchKeyword + '%' OR phone_no_1 LIKE '%' + @searchKeyword + '%' OR phone_no_2 LIKE '%' + @searchKeyword + '%' OR gender LIKE '%' + @searchKeyword + '%') ORDER BY [id]) " +
                            "AND is_deleted = 0 AND (customer_name LIKE '%' + @searchKeyword + '%' OR email LIKE '%' + @searchKeyword + '%' OR phone_no_1 LIKE '%' + @searchKeyword + '%' OR phone_no_2 LIKE '%' + @searchKeyword + '%' OR gender LIKE '%' + @searchKeyword + '%') " +
                            "ORDER BY [id]";
                }
                else
                {
                    query = "SELECT TOP " + pageSize + " [id], [customer_id], [customer_name], [nrc_number], [dob], [member_card], [email], [gender], [phone_no_1], [phone_no_2], [photo], [address], [password] FROM CustomerTable " +
                            "WHERE id NOT IN (SELECT TOP " + previousPageOffSet + " [id] FROM CustomerTable WHERE is_deleted = 0 ORDER BY [id]) AND is_deleted = 0 ORDER BY [id]";
                }
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                command = new SqlCommand(query, connection);

                if (!string.IsNullOrEmpty(searchKeyword))
                {
                    command.Parameters.AddWithValue("@searchKeyword", searchKeyword);
                }

                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                dataTable.Clear();
                dataAdapter.Fill(dataTable);

                dataTable.Columns.Add("Gender Type", typeof(string));
                dataTable.Columns.Add("Member", typeof(string));
                dataTable.Columns.Add("Password", typeof(string));
                dataTable.Columns.Add("PhotoImage", typeof(Image));

                foreach (DataRow row in dataTable.Rows)
                {
                    int genderValue = Convert.ToInt32(row["gender"]);
                    int member = Convert.ToInt32(row["member_card"]);
                    string encryptedPassword = row["password"].ToString();
                    string decryptedPassword = decryptPassword(encryptedPassword, key, iv);
                    row["password"] = decryptedPassword;

                    switch (genderValue)
                    {
                        case 0:
                            row["Gender Type"] = "Other";
                            break;
                        case 1:
                            row["Gender Type"] = "Male";
                            break;
                        case 2:
                            row["Gender Type"] = "Female";
                            break;
                        default:
                            break;
                    }

                    //if (genderValue == 0)
                    //{
                    //    row["Gender"] = "Other";
                    //}else if(genderValue == 1)
                    //{
                    //    row["Gender"] = "Male";
                    //}
                    //else if (genderValue == 2)
                    //{
                    //    row["Gender"] = "Female";
                    //}

                    switch (member)
                    {
                        case 1:
                            row["Member"] = "Yes";
                            break;
                        case 2:
                            row["Member"] = "No";
                            break;
                        default:
                            break;
                    }

                    string photoPath = row["photo"].ToString();

                    if (File.Exists(photoPath))
                    {
                        Image image = Image.FromFile(photoPath);
                        row["PhotoImage"] = image;
                    }
                    else
                    {
                        row["PhotoImage"] = null;
                    }
                }

                dataGridView1.DataSource = dataTable;

                dataGridView1.Columns["gender"].Visible = false;
                dataGridView1.Columns["member_card"].Visible = false;
                dataGridView1.Columns["photo"].Visible = false;
                dataGridView1.Columns["id"].Visible = false;
                dataGridView1.Columns["password"].Visible = false;
                dataGridView1.Columns["customer_id"].HeaderText = "Customer ID";
                dataGridView1.Columns["customer_name"].HeaderText = "Customer Name";
                dataGridView1.Columns["nrc_number"].HeaderText = "NRC Number";
                dataGridView1.Columns["dob"].HeaderText = "Date of Birth";
                dataGridView1.Columns["email"].HeaderText = "Email";
                dataGridView1.Columns["phone_no_1"].HeaderText = "Phone Number 1";
                dataGridView1.Columns["phone_no_2"].HeaderText = "Phone Number 2";
                dataGridView1.Columns["address"].HeaderText = "Address";
                dataGridView1.Columns["PhotoImage"].DisplayIndex = 3;
                dataGridView1.Columns["Gender"].DisplayIndex = 4;
                ((DataGridViewImageColumn)dataGridView1.Columns["PhotoImage"]).ImageLayout = DataGridViewImageCellLayout.Stretch;
            }
        }

        public void getTotalPage()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM CustomerTable WHERE is_deleted = 0";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    connection.Open();
                    int record = (int)cmd.ExecuteScalar();
                    totalPage = record / pageSize;
                    if (record % pageSize > 0)
                    {
                        totalPage += 1;
                    }
                }
            }
        }

        private string decryptPassword(string password, byte[] key, byte[] iv)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;

                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(password)))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader reader = new StreamReader(cryptoStream))
                        {
                            return reader.ReadToEnd();
                        }
                    }
                }
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            getTotalPage();
            if (currentPageIndex > 1)
            {
                currentPageIndex--;
                LoadData(currentPageIndex, searchKeyword);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            getTotalPage();
            if (currentPageIndex < totalPage)
            {
                currentPageIndex++;
                LoadData(currentPageIndex, searchKeyword);

            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            getTotalPage();
            LoadData(totalPage, searchKeyword);
            currentPageIndex = totalPage;
        }

        private void Listing_Load(object sender, EventArgs e)
        {
            LoadData(currentPageIndex, searchKeyword);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = new Form1();
            f.Show();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            searchKeyword = txtSearch.Text;
            currentPageIndex = 1;
            LoadData(currentPageIndex, searchKeyword);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                table = new DataTable();

                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    table.Columns.Add(column.HeaderText, column.ValueType);
                }

                DataRow newRow = table.NewRow();

                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {

                    if (dataGridView1.Columns[i].ValueType == typeof(Image))
                    {
                        newRow[i] = dataGridView1.Rows[e.RowIndex].Cells[i].Value as Image;
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(dataGridView1.Rows[e.RowIndex].Cells[i].Value?.ToString()))
                        {
                            newRow[i] = dataGridView1.Rows[e.RowIndex].Cells[i].Value;
                        }
                        else
                        {
                            newRow[i] = DBNull.Value; 
                        }
                    }
                }

                table.Rows.Add(newRow);

                Form1 f = new Form1
                {
                    sourcePage = "listing"
                };
                this.Hide();
                f.Show();
            }

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            download();
        }

        private void download()
        {
            string filePath = "";
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Customer Data");

                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    worksheet.Cells[1, i + 1].Value = dataGridView1.Columns[i].HeaderText;
                }

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1].Value = dataGridView1.Rows[i].Cells[j].Value;
                    }
                }

                if (saveFileDialog1.ShowDialog() == DialogResult.OK) { 
                    filePath = saveFileDialog1.FileName;
                    package.SaveAs(new FileInfo(filePath));
                }

            }

            MessageBox.Show("File saved "+ filePath, "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
