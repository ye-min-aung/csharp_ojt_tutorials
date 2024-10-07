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
            dataGridView1.AutoGenerateColumns = false;
            getTotalPage();
        }

        public string connectionString = "Server=DESKTOP-4VM5D0P\\SQLEXPRESS;Database=AllDB;User Id=sa;Password=root;Trusted_Connection=True;";

        public static DataTable table;
        int select;
        string imagePath = "";
        int num = 0;
        int pageSize = 5;
        int currentPageIndex = 1;
        int totalPage = 0;
        string searchKeyword = "";

        private byte[] key = Convert.FromBase64String("k1rZt6cU5fD9G2dIbZRZksQ2pZJfw6PzfvA1wfg3Zb8=");
        private byte[] iv = Convert.FromBase64String("9vHdlrZ7QwJwU4r1cqls2g==");

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
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                command = new SqlCommand(query, connection);

                if (!string.IsNullOrEmpty(searchKeyword))
                {
                    command.Parameters.AddWithValue("@searchKeyword", searchKeyword);
                }

                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

                dataTable.Clear();
                dataAdapter.Fill(dataTable);
            }

            dataGridView1.DataSource = dataTable;
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
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            LoadData(currentPageIndex, searchKeyword);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = new Form1
            {
                sourcePage = "new"
            };
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
            if (e.ColumnIndex == 1)
            {

                if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count - 1)
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
                            newRow[i] = dataGridView1.Rows[e.RowIndex].Cells[i].Value?.ToString() ?? null;
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

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {

        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            LoadData(1, searchKeyword);
            currentPageIndex = 1;
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "gender")
            {
                if (e.Value != null)
                {
                    switch (e.Value.ToString())
                    {
                        case "0":
                            e.Value = "Other";
                            e.FormattingApplied = true;
                            break;

                        case "1":
                            e.Value = "Male";
                            e.FormattingApplied = true;
                            break;

                        case "2":
                            e.Value = "Female";
                            e.FormattingApplied = true;
                            break;
                    }
                }
            }

            if (dataGridView1.Columns[e.ColumnIndex].Name == "member_card")
            {
                if (e.Value != null)
                {
                    switch (e.Value.ToString())
                    {
                        case "1":
                            e.Value = "Yes";
                            e.FormattingApplied = true;
                            break;

                        case "2":
                            e.Value = "No";
                            e.FormattingApplied = true;
                            break;
                    }
                }
            }
            if (dataGridView1.Columns[e.ColumnIndex].Name == "password")
            {
                if (e.Value != null)
                {
                    e.Value = decryptPassword(e.Value.ToString(), key, iv);
                    e.FormattingApplied = true;
                }
            }

            if (dataGridView1.Columns[e.ColumnIndex].Name == "photo" && e.Value != null)
            {
                string photoPath = e.Value.ToString();

                if (dataGridView1.Columns[e.ColumnIndex] is DataGridViewImageColumn)
                {
                    if (File.Exists(photoPath))
                    {
                        using (Image image = Image.FromFile(photoPath))
                        {
                            e.Value = new Bitmap(image);
                        }
                        e.FormattingApplied = true;
                    }
                    else
                    {
                        e.Value = null;
                        e.FormattingApplied = true;
                    }
                }
            }

        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        private void entryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = new Form1
            {
                sourcePage = "new"
            };
            f.Show();
        }

        private void listingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Listing list = new Listing();
            list.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }
    }
}
