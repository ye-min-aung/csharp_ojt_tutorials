using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Tutorial4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        public string connectionString = "Server=DESKTOP-4VM5D0P\\SQLEXPRESS;Database=AllDB;User Id=sa;Password=root;Trusted_Connection=True;";

        int select;
        string imagePath = "";
        int num = 0;
        int pageSize = 3;
        int currentPageIndex = 1;
        int totalPage = 0;
        public void LoadData(int page)
        {
            string query = "";
            if (page == 1)
            {
                query = "SELECT TOP " + pageSize + " [id], [customer_id], [customer_name], [nrc_number], [dob], [member_card], [email], [gender], [phone_no_1], [phone_no-2], [photo], [address] FROM CustomerTable WHERE is_deleted = 0 ORDER BY id";
            }
            else
            {
                int previousPageOffSet = (page - 1) * pageSize;
                query = "SELECT TOP " + pageSize + " [id], [customer_id], [customer_name], [nrc_number], [dob], [member_card], [email], [gender], [phone_no_1], [phone_no-2], [photo], [address] FROM CustomerTable WHERE id NOT IN (SELECT TOP " + previousPageOffSet + " id FROM CustomerTable ) AND is_deleted = 0 ORDER BY id";
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                dataTable.Columns.Add("PhotoImage", typeof(Image));

                foreach (DataRow row in dataTable.Rows)
                {
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

                dataGridView1.Columns["photo"].Visible = false;
                ((DataGridViewImageColumn)dataGridView1.Columns["PhotoImage"]).ImageLayout = DataGridViewImageCellLayout.Stretch;
                dataGridView1.RowTemplate.Height = 300;
            }

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            select = e.RowIndex;

            if (select >= 0)
            {
                DataGridViewRow selectRow = dataGridView1.Rows[select];

                if (selectRow.Cells["customer_id"].Value != null)
                {
                    txtId.Text = selectRow.Cells["customer_id"].Value.ToString();
                }
                else
                {
                    txtId.Text = string.Empty;
                }

                if (selectRow.Cells["customer_name"].Value != null)
                {
                    txtName.Text = selectRow.Cells["customer_name"].Value.ToString();
                }
                else
                {
                    txtName.Text = string.Empty;
                }

                if (selectRow.Cells["address"].Value != null)
                {
                    txtAddress.Text = selectRow.Cells["address"].Value.ToString();
                }
                else
                {
                    txtAddress.Text = string.Empty;
                }

                if (selectRow.Cells["member_card"].Value != null)
                {
                    string type = selectRow.Cells["member_card"].Value.ToString();
                    if (type == "1")
                    {
                        txtMemberCard.Text = "Yes";
                    }
                    else if (type == "2")
                    {
                        txtMemberCard.Text = "No";
                    }
                }

                if (selectRow.Cells["nrc_number"].Value != null)
                {
                    txtNrc.Text = selectRow.Cells["nrc_number"].Value.ToString();
                }
                else
                {
                    txtNrc.Text = string.Empty;
                }

                if (selectRow.Cells["email"].Value != null)
                {
                    txtEmail.Text = selectRow.Cells["email"].Value.ToString();
                }
                else
                {
                    txtEmail.Text = string.Empty;
                }


                if (selectRow.Cells["dob"].Value == null)
                {
                    memberDate.CustomFormat = null;
                }
                else
                {
                    try
                    {
                        string dateString = selectRow.Cells["dob"].Value.ToString();
                        DateTime date = DateTime.Parse(dateString);
                        memberDate.Value = date;
                    }
                    catch (Exception ex)
                    {
                        memberDate.CustomFormat = null;
                    }
                }



                int age = DateTime.Today.Year - memberDate.Value.Year;
                txtAge.Text = age.ToString();



                if (selectRow.Cells["gender"].Value != null)
                {
                    string gender = selectRow.Cells["gender"].Value.ToString();
                    if (gender == "1")
                    {
                        rdoMale.Checked = true;
                    }
                    else if (gender == "2")
                    {
                        rdoFemale.Checked = true;
                    }
                    else
                    {
                        rdoOther.Checked = true;
                    }
                }
                else
                {
                    rdoMale.Checked = false;
                    rdoFemale.Checked = false;
                    rdoOther.Checked = false;
                }

                if (selectRow.Cells["phone_no_1"].Value != null)
                {
                    txtPhone1.Text = selectRow.Cells["phone_no_1"].Value.ToString();
                }
                else
                {
                    txtPhone1.Text = string.Empty;
                }

                if (selectRow.Cells["phone_no-2"].Value != null)
                {
                    txtPhone2.Text = selectRow.Cells["phone_no-2"].Value.ToString();
                }
                else
                {
                    txtPhone2.Text = string.Empty;
                }

                string photo = selectRow.Cells["photo"].Value.ToString();
                if (File.Exists(photo))
                {
                    pictureBox1.Image = Image.FromFile(photo);
                }
                else
                {
                    pictureBox1.Image = null;
                }
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string customerId = "C" + num.ToString("D4");
            string name = txtName.Text;
            string nrc = txtNrc.Text;
            string Mtype = txtMemberCard.Text;
            int type = 0;
            if (Mtype == "Yes")
            {
                type = 1;
            }
            else
            {
                type = 2;
            }
            string email = txtEmail.Text;
            int gender = 0;
            if (rdoMale.Checked)
            {
                gender = 1;
            }
            else if (rdoFemale.Checked)
            {
                gender = 2;
            }
            string phone1 = txtPhone1.Text;
            string phone2 = txtPhone2.Text;
            string address = txtAddress.Text;

            DateTime date = memberDate.Value;
            DateTime today = DateTime.Today;
            int age = today.Year - date.Year;


            //validate
            if (name.Equals(""))
            {
                MessageBox.Show("Enter Name");
                return;
            }

            string pattern = @"[0-9]{1,2}/[A-Z]{6}\([A-Z]\)[0-9]{6}";
            if (!nrc.Equals(""))
            {
                if (!Regex.IsMatch(nrc, pattern))
                {
                    MessageBox.Show("Invalid Nrc");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Enter nrc");
                return;
            }

            if (type.Equals(""))
            {
                MessageBox.Show("Enter Member Card");
                return;
            }

            if (!email.Equals(""))
            {

                if (!email.Contains("@") && !email.Contains("."))
                {
                    MessageBox.Show("invalid Email");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Enter Email");
                return;
            }

            if (phone1 != "")
            {
                if (!IsPhone(phone1))
                {
                    MessageBox.Show("invalid Phone1");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Enter Phone 1");
                return;
            }

            if (phone2 != "")
            {
                if (!IsPhone(phone2))
                {
                    MessageBox.Show("invalid Phone2");
                    return;
                }
            }

            if (imagePath == "")
            {
                MessageBox.Show("Select Photo");
                return;
            }

            string imageFileName = Path.GetFileName(imagePath);

            string distination = Path.Combine(Application.StartupPath, "images", name + imageFileName);
            if (!Directory.Exists(Path.Combine(Application.StartupPath, "images")))
            {
                Directory.CreateDirectory(Path.Combine(Application.StartupPath, "images"));
            }
            File.Copy(imagePath, distination);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO CustomerTable ( [customer_id],[customer_name], [nrc_number], [dob], [member_card], [email], [gender], [phone_no_1], [phone_no-2], [photo], [address], [created_user_id], [created_datetime], [updated_user_id], [updated_datetime], [is_deleted], [deleted_user_id], [deleted_datetime]) " +
"VALUES (@customer_id, @customer_name, @nrc_number, @dob, @member_card, @Email, @gender, @phone_no_1, @phone_no_2, @photo, @address, @created_user_id, @created_datetime, @updated_user_id, @updated_datetime, @is_deleted, @deleted_user_id, @deleted_datetime)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@customer_id", customerId);
                    command.Parameters.AddWithValue("@customer_name", name);
                    command.Parameters.AddWithValue("@nrc_number", nrc);
                    command.Parameters.AddWithValue("@dob", date);
                    command.Parameters.AddWithValue("@member_card", type);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@gender", gender);
                    command.Parameters.AddWithValue("@phone_no_1", phone1);
                    command.Parameters.AddWithValue("@phone_no_2", phone2);
                    command.Parameters.AddWithValue("@photo", distination);
                    command.Parameters.AddWithValue("@address", address);
                    command.Parameters.AddWithValue("@created_user_id", 1);
                    command.Parameters.AddWithValue("@created_datetime", DateTime.Now);
                    command.Parameters.AddWithValue("@updated_user_id", 1);
                    command.Parameters.AddWithValue("@updated_datetime", DateTime.Now);
                    command.Parameters.AddWithValue("@is_deleted", 0);
                    command.Parameters.AddWithValue("@deleted_user_id", 1);
                    command.Parameters.AddWithValue("@deleted_datetime", DateTime.Now);

                    connection.Open();
                    command.ExecuteNonQuery();
                }

            }

            LoadData(totalPage);
            num++;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectRow = dataGridView1.Rows[select];
            int id = Convert.ToInt32(selectRow.Cells["id"].Value);
            string name = txtName.Text;
            string nrc = txtNrc.Text;
            string Mtype = txtMemberCard.Text;
            int type = 0;
            if (Mtype == "Yes")
            {
                type = 1;
            }
            else
            {
                type = 2;
            }
            string email = txtEmail.Text;
            int gender = 0;
            if (rdoMale.Checked)
            {
                gender = 1;
            }
            else if (rdoFemale.Checked)
            {
                gender = 2;
            }
            string phone1 = txtPhone1.Text;
            string phone2 = txtPhone2.Text;
            string address = txtAddress.Text;

            DateTime date = memberDate.Value;
            DateTime today = DateTime.Today;
            int age = today.Year - date.Year;



            //validate
            if (name.Equals(""))
            {
                MessageBox.Show("Enter Name");
                return;
            }

            string pattern = @"[0-9]{1,2}/[A-Z]{6}\([A-Z]\)[0-9]{6}";
            if (!nrc.Equals(""))
            {
                if (!Regex.IsMatch(nrc, pattern))
                {
                    MessageBox.Show("Invalid Nrc");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Enter nrc");
                return;
            }

            if (type.Equals(""))
            {
                MessageBox.Show("Enter Member Card");
                return;
            }

            if (!email.Equals(""))
            {

                if (!email.Contains("@") && !email.Contains("."))
                {
                    MessageBox.Show("invalid Email");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Enter Email");
                return;
            }

            if (phone1 != "")
            {
                if (!IsPhone(phone1))
                {
                    MessageBox.Show("invalid Phone1");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Enter Phone 1");
                return;
            }

            if (phone2 != "")
            {
                if (!IsPhone(phone2))
                {
                    MessageBox.Show("invalid Phone2");
                    return;
                }
            }

            if (imagePath == "")
            {
                imagePath = selectRow.Cells["id"].Value.ToString();
            }



            string newImage = "";

            string imageFileName = Path.GetFileName(imagePath);

            newImage = Path.Combine(Application.StartupPath, "images", name + imageFileName);
            if (!Directory.Exists(Path.Combine(Application.StartupPath, "images")))
            {
                Directory.CreateDirectory(Path.Combine(Application.StartupPath, "images"));
            }

            if (!File.Exists(newImage))
            {
                File.Copy(imagePath, newImage);
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE CustomerTable SET [customer_name] = @customer_name, [nrc_number] = @nrc_number, [dob] = @dob, [member_card] = @member_card, [email] = @Email, [gender] = @gender, [phone_no_1] = @phone_no_1, [phone_no-2] = @phone_no_2, [photo] = @photo, [address] = @address, [updated_user_id] = @updated_user_id, [updated_datetime] = @updated_datetime WHERE [id] = @id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@customer_name", name);
                    command.Parameters.AddWithValue("@nrc_number", nrc);
                    command.Parameters.AddWithValue("@dob", date);
                    command.Parameters.AddWithValue("@member_card", type);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@gender", gender);
                    command.Parameters.AddWithValue("@phone_no_1", phone1);
                    command.Parameters.AddWithValue("@phone_no_2", phone2);
                    command.Parameters.AddWithValue("@photo", newImage);
                    command.Parameters.AddWithValue("@address", address);
                    command.Parameters.AddWithValue("@updated_user_id", 1); // Replace with actual user ID if available
                    command.Parameters.AddWithValue("@updated_datetime", DateTime.Now);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }


            LoadData(totalPage);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectRow = dataGridView1.Rows[select];
            int id = Convert.ToInt32(selectRow.Cells["id"].Value);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE CustomerTable SET is_deleted = 1 WHERE id = @id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            LoadData(totalPage);
        }

        bool IsPhone(string phone)
        {
            foreach (char c in phone)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            getTotalPage();
            LoadData(1);
        }

        private void btnChooseImage_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                imagePath = openFileDialog1.FileName;
                pictureBox1.Load(openFileDialog1.FileName);
            }
        }

        //Pagination 

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

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (currentPageIndex > 1)
            {
                currentPageIndex--;
                LoadData(currentPageIndex);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentPageIndex < totalPage)
            {
                currentPageIndex++;
                LoadData(currentPageIndex);
                
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {  
            LoadData(totalPage);
            currentPageIndex = 4;
        }
    }
}
