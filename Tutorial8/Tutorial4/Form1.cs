using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.IO;
using System.Security.Cryptography;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace Tutorial4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            dataGridView1.RowTemplate.Height = 80;
            getTotalPage();
        }

        public string sourcePage { get; set; }
        public string connectionString = "Server=DESKTOP-4VM5D0P\\SQLEXPRESS;Database=AllDB;User Id=sa;Password=root;Trusted_Connection=True;";

        int select;
        string imagePath = "";
        int num = 0;
        int pageSize = 3;
        int currentPageIndex = 1;
        int totalPage = 0;

        private byte[] key = Convert.FromBase64String("k1rZt6cU5fD9G2dIbZRZksQ2pZJfw6PzfvA1wfg3Zb8=");
        private byte[] iv = Convert.FromBase64String("9vHdlrZ7QwJwU4r1cqls2g==");

        public void LoadData(int page)
        {
            string query = "";
            if (page == 1)
            {
                query = "SELECT TOP " + pageSize + " [id], [customer_id], [customer_name], [nrc_number], [dob], [member_card], [email], [gender], [phone_no_1], [phone_no_2], [photo], [address], [password] FROM CustomerTable WHERE is_deleted = 0 ORDER BY id";
            }
            else
            {
                int previousPageOffSet = (page - 1) * pageSize;
                query = "SELECT TOP " + pageSize + " [id], [customer_id], [customer_name], [nrc_number], [dob], [member_card], [email], [gender], [phone_no_1], [phone_no_2], [photo], [address], [password] FROM CustomerTable WHERE id NOT IN (SELECT TOP " + previousPageOffSet + " [id] FROM CustomerTable WHERE is_deleted = 0 ORDER BY [id]) AND is_deleted = 0 ORDER BY [id]";
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                dataTable.Clear();
                dataAdapter.Fill(dataTable);
                dataTable.Columns.Add("GenderType", typeof(string));
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
                            row["GenderType"] = "Other";
                            break;
                        case 1:
                            row["GenderType"] = "Male";
                            break;
                        case 2:
                            row["GenderType"] = "Female";
                            break;
                        default:
                            break;
                    }

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
                ((DataGridViewImageColumn)dataGridView1.Columns["PhotoImage"]).ImageLayout = DataGridViewImageCellLayout.Stretch;
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

                if (selectRow.Cells["customer_name"].Value != null)
                {
                    txtName.Text = selectRow.Cells["customer_name"].Value.ToString();
                    txtAge.Text = string.Empty;
                    txtId.Text = string.Empty;
                    memberDate.CustomFormat = null;
                    txtMemberCard.Text = null;
                }
                else
                {
                    txtName.Text = string.Empty;
                }

                if (selectRow.Cells["customer_id"].Value != null)
                {
                    txtId.Text = selectRow.Cells["customer_id"].Value.ToString();
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


                if (selectRow.Cells["dob"].Value == null || selectRow.Cells["dob"].Value == DBNull.Value)
                {
                    memberDate.CustomFormat = "";
                    //memberDate.Format = DateTimePickerFormat.Custom;

                }
                else
                {
                    try
                    {
                        string dateString = selectRow.Cells["dob"].Value.ToString();
                        DateTime date = DateTime.Parse(dateString);
                        memberDate.Value = date;
                        int age = DateTime.Today.Year - memberDate.Value.Year;
                        txtAge.Text = age.ToString();
                    }
                    catch (Exception ex)
                    {
                        memberDate.CustomFormat = null;
                    }
                }

                if (selectRow.Cells["gender"].Value == null || selectRow.Cells["gender"].Value == DBNull.Value)
                {
                    rdoMale.Checked = false;
                    rdoFemale.Checked = false;
                    rdoOther.Checked = false;
                }
                else
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
                    else if (gender == "0")
                    {
                        rdoOther.Checked = true;
                    }
                }

                if (selectRow.Cells["phone_no_1"].Value != null)
                {
                    txtPhone1.Text = selectRow.Cells["phone_no_1"].Value.ToString();
                }
                else
                {
                    txtPhone1.Text = string.Empty;
                }

                if (selectRow.Cells["phone_no_2"].Value != null)
                {
                    txtPhone2.Text = selectRow.Cells["phone_no_2"].Value.ToString();
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

                if (selectRow.Cells["password"].Value != null)
                {
                    txtPassword.Text = selectRow.Cells["password"].Value.ToString();
                }
                else
                {
                    txtPassword.Text = string.Empty;
                }
                if (selectRow.Cells["password"].Value != null)
                {
                    txtConfirmPassword.Text = selectRow.Cells["password"].Value.ToString();
                }
                else
                {
                    txtConfirmPassword.Text = string.Empty;
                }
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string customerId = generateId();
            string name = txtName.Text;
            string nrc = txtNrc.Text;
            string Mtype = txtMemberCard.Text;
            string password = txtPassword.Text;
            string confirmPassowrd = txtConfirmPassword.Text;
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

            if (password == "")
            {
                MessageBox.Show("Enter Password");
                return;
            }

            validatePassword(password);

            if (confirmPassowrd == "")
            {
                MessageBox.Show("Confirm Password");
                return;
            }
            if (password != confirmPassowrd)
            {
                MessageBox.Show("Password don't match");
                return;
            }

            string passwordE = encryptPassword(password, key, iv);

            string imageFileName = Path.GetFileName(imagePath);

            string distination = Path.Combine(Application.StartupPath, "images", name + imageFileName);
            if (!Directory.Exists(Path.Combine(Application.StartupPath, "images")))
            {
                Directory.CreateDirectory(Path.Combine(Application.StartupPath, "images"));
            }
            File.Copy(imagePath, distination);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO CustomerTable ( [customer_id],[customer_name], [nrc_number], [dob], [member_card], [email], [gender], [phone_no_1], [phone_no_2], [photo], [address], [created_user_id], [created_datetime], [updated_user_id], [updated_datetime], [is_deleted], [deleted_user_id], [deleted_datetime], [password]) " +
"VALUES (@customer_id, @customer_name, @nrc_number, @dob, @member_card, @Email, @gender, @phone_no_1, @phone_no_2, @photo, @address, @created_user_id, @created_datetime, @updated_user_id, @updated_datetime, @is_deleted, @deleted_user_id, @deleted_datetime, @password)";

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
                    command.Parameters.AddWithValue("@password", passwordE);

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
            //int id = Convert.ToInt32(selectRow.Cells["id"].Value);
            string customer_id = txtId.Text;
            string name = txtName.Text;
            string nrc = txtNrc.Text;
            string Mtype = txtMemberCard.Text;
            string password = txtPassword.Text;
            string confirmPassowrd = txtConfirmPassword.Text;
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

            if (password == "")
            {
                MessageBox.Show("Enter Password");
                return;
            }

            validatePassword(password);

            if (confirmPassowrd == "")
            {
                MessageBox.Show("Confirm Password");
                return;
            }
            if (password != confirmPassowrd)
            {
                MessageBox.Show("Password don't match");
                return;
            }

            string passwordE = encryptPassword(password, key, iv);


            string newImage = "";
            if (imagePath == "")
            {

                imagePath = selectRow.Cells["photo"].Value.ToString();
                newImage = imagePath;
            }
            else
            {


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

            }



            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE CustomerTable SET [customer_name] = @customer_name, [nrc_number] = @nrc_number, [dob] = @dob, [member_card] = @member_card, [email] = @Email, [gender] = @gender, [phone_no_1] = @phone_no_1, [phone_no_2] = @phone_no_2, [photo] = @photo, [address] = @address, [updated_user_id] = @updated_user_id, [updated_datetime] = @updated_datetime, [password] = @password WHERE [customer_id] = @customer_id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@customer_id", customer_id);
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
                    command.Parameters.AddWithValue("@updated_user_id", 1);
                    command.Parameters.AddWithValue("@updated_datetime", DateTime.Now);
                    command.Parameters.AddWithValue("@password", passwordE);

                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("update successful !");
                }
            }


            LoadData(totalPage);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectRow = dataGridView1.Rows[select];
            //int id = Convert.ToInt32(selectRow.Cells["id"].Value);
            string customer_id = txtId.Text;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE CustomerTable SET is_deleted = 1 WHERE customer_id = @customer_id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@customer_id", customer_id);
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("deleted !");
                }
            }
            txtId.Text = null;
            txtName.Text = null;
            txtNrc.Text = null;
            txtEmail.Text = null;
            txtPhone1.Text = null;
            txtPhone2.Text = null;
            txtAddress.Text = null;
            txtPassword.Text = null;
            txtConfirmPassword.Text = null;
            rdoFemale.Checked = false;
            rdoMale.Checked = false;
            rdoOther.Checked = false;
            txtAge.Text = null;
            pictureBox1.Image = null;
            memberDate.Text = null;
            txtMemberCard .Text = null;
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
            txtId.Text = null;
            txtName.Text = null;
            txtNrc.Text = null;
            txtEmail.Text = null;
            txtPhone1.Text = null;
            txtPhone2.Text = null;
            txtAddress.Text = null;
            txtPassword.Text = null;
            txtConfirmPassword.Text = null;
            rdoFemale.Checked = false;
            rdoMale.Checked = false;
            rdoOther.Checked = false;
            txtAge.Text = null;
            pictureBox1.Image = null;
            memberDate.Text = null;
            txtMemberCard.Text = null;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            LoadData(1);
            if (sourcePage == "listing")
            {
                DataTable dataTable = Listing.table;
                if (dataTable.Rows.Count > 0)
                {
                    txtId.Text = dataTable.Rows[0]["Customer ID"].ToString();
                    txtName.Text = dataTable.Rows[0]["Customer Name"].ToString();
                    txtNrc.Text = dataTable.Rows[0]["NRC Number"].ToString();
                    txtEmail.Text = dataTable.Rows[0]["Email"].ToString();
                    txtPhone1.Text = dataTable.Rows[0]["Phone Number 1"].ToString();
                    txtPhone2.Text = dataTable.Rows[0]["Phone Number 2"].ToString();
                    txtAddress.Text = dataTable.Rows[0]["Address"].ToString();
                    txtPassword.Text = dataTable.Rows[0]["password"].ToString();
                    txtConfirmPassword.Text = dataTable.Rows[0]["password"].ToString();

                    if (dataTable.Rows[0]["gender"] == null)
                    {
                        rdoMale.Checked = false;
                        rdoFemale.Checked = false;
                        rdoOther.Checked = false;
                    }
                    else
                    {

                        string gender = dataTable.Rows[0]["gender"].ToString();
                        if (gender == "1")
                        {
                            rdoMale.Checked = true;
                        }
                        else if (gender == "2")
                        {
                            rdoFemale.Checked = true;
                        }
                        else if (gender == "0")
                        {
                            rdoOther.Checked = true;
                        }
                    }
                    if (dataTable.Rows[0]["member_card"] != null)
                    {
                        string type = dataTable.Rows[0]["member_card"].ToString();
                        if (type == "1")
                        {
                            txtMemberCard.Text = "Yes";
                        }
                        else if (type == "2")
                        {
                            txtMemberCard.Text = "No";
                        }
                    }

                    string photo = dataTable.Rows[0]["photo"].ToString();
                    if (File.Exists(photo))
                    {
                        pictureBox1.Image = Image.FromFile(photo);
                    }
                    else
                    {
                        pictureBox1.Image = null;
                    }

                    if (dataTable.Rows[0]["Date of Birth"].ToString() == null)
                    {
                        memberDate.CustomFormat = "";

                    }
                    else
                    {
                        try
                        {
                            string dateString = dataTable.Rows[0]["Date of Birth"].ToString();
                            DateTime date = DateTime.Parse(dateString);
                            memberDate.Value = date;
                            int age = DateTime.Today.Year - memberDate.Value.Year;
                            txtAge.Text = age.ToString();
                        }
                        catch (Exception ex)
                        {
                            memberDate.CustomFormat = null;
                        }
                    }
                }
            }
            else if (sourcePage == "login")
            {
                txtId.Text = Login.Lid;
                txtName.Text = Login.name;
                txtNrc.Text = Login.nrc;
                txtEmail.Text = Login.email;
                txtPhone1.Text = Login.phone1;
                txtPhone2.Text = Login.phone2;
                txtAddress.Text = Login.address;
                txtPassword.Text = Login.Lpassword;
                txtConfirmPassword.Text = Login.Lpassword;

                if (Login.gender == null)
                {
                    rdoMale.Checked = false;
                    rdoFemale.Checked = false;
                    rdoOther.Checked = false;
                }
                else
                {

                    string gender = Login.gender;
                    if (gender == "1")
                    {
                        rdoMale.Checked = true;
                    }
                    else if (gender == "2")
                    {
                        rdoFemale.Checked = true;
                    }
                    else if (gender == "0")
                    {
                        rdoOther.Checked = true;
                    }
                }
                if (Login.memberCard != null)
                {
                    string type = Login.memberCard;
                    if (type == "1")
                    {
                        txtMemberCard.Text = "Yes";
                    }
                    else if (type == "2")
                    {
                        txtMemberCard.Text = "No";
                    }
                }

                string photo = Login.image;
                if (File.Exists(photo))
                {
                    pictureBox1.Image = Image.FromFile(photo);
                }
                else
                {
                    pictureBox1.Image = null;
                }

                if (Login.date == null)
                {
                    memberDate.CustomFormat = "";

                }
                else
                {
                    try
                    {
                        string dateString = Login.date;
                        DateTime date = DateTime.Parse(dateString);
                        memberDate.Value = date;
                        int age = DateTime.Today.Year - memberDate.Value.Year;
                        txtAge.Text = age.ToString();
                    }
                    catch (Exception ex)
                    {
                        memberDate.CustomFormat = null;
                    }
                }
            }



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
            getTotalPage();
            if (currentPageIndex > 1)
            {
                currentPageIndex--;
                LoadData(currentPageIndex);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            getTotalPage();
            if (currentPageIndex < totalPage)
            {
                currentPageIndex++;
                LoadData(currentPageIndex);

            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            getTotalPage();
            LoadData(totalPage);
            currentPageIndex = totalPage;
        }

        private void txtPhone2_TextChanged(object sender, EventArgs e)
        {

        }

        private string generateId()
        {
            string cid;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT MAX(id) FROM CustomerTable";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    connection.Open();
                    object result = cmd.ExecuteScalar();

                    int id = result != DBNull.Value ? Convert.ToInt32(result) : 0;

                    id++;
                    cid = "C-" + id.ToString("D4");
                    MessageBox.Show(cid.ToString());
                }
            }
            return cid;
        }

        private void validatePassword(string passowrd)
        {
            if (passowrd.Length < 5)
            {
                MessageBox.Show("Password must be greate than 5");
                return;
            }
            if (!Regex.IsMatch(passowrd, @"\d"))
            {
                MessageBox.Show("Password must contain number");
                return;
            }
            if (!Regex.IsMatch(passowrd, @"[a-zA-Z]"))
            {
                MessageBox.Show("Password must contain character");
                return;
            }
        }

        //private void generateKey()
        //{
        //    using(Aes aes = Aes.Create())
        //    {
        //        aes.GenerateKey();
        //        aes.GenerateIV();
        //        key = aes.Key;
        //        iv = aes.IV;
        //    }
        //}

        private string encryptPassword(string password, byte[] key, byte[] iv)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter writer = new StreamWriter(cryptoStream))
                        {
                            writer.Write(password);
                        }
                    }

                    byte[] encrypted = memoryStream.ToArray();
                    return Convert.ToBase64String(encrypted);
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

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Listing list = new Listing();
            list.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
