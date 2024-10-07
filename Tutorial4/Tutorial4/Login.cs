using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace Tutorial4
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        private byte[] key = Convert.FromBase64String("k1rZt6cU5fD9G2dIbZRZksQ2pZJfw6PzfvA1wfg3Zb8=");
        private byte[] iv = Convert.FromBase64String("9vHdlrZ7QwJwU4r1cqls2g==");

        public string connectionString = "Server=DESKTOP-4VM5D0P\\SQLEXPRESS;Database=AllDB;User Id=sa;Password=root;Trusted_Connection=True;";

            public static string  Lid;
            public static string name;
            public static string nrc;
            public static string date;
            public static string age;
            public static string memberCard;
            public static string email;
            public static string gender;
            public static string phone1;
            public static string phone2;
            public static string image;
            public static string address;
            public static string Lpassword;
        private void InitializeComponent()
        {
            label1 = new Label();
            btnLogin = new Button();
            txtId = new TextBox();
            label2 = new Label();
            label3 = new Label();
            txtPassword = new TextBox();
            btnCancle = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(460, 59);
            label1.Name = "label1";
            label1.Size = new Size(71, 31);
            label1.TabIndex = 0;
            label1.Text = "Login";
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(571, 329);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(94, 29);
            btnLogin.TabIndex = 1;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // txtId
            // 
            txtId.Location = new Point(402, 162);
            txtId.Name = "txtId";
            txtId.Size = new Size(263, 27);
            txtId.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(313, 165);
            label2.Name = "label2";
            label2.Size = new Size(55, 20);
            label2.TabIndex = 3;
            label2.Text = "User Id";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(313, 247);
            label3.Name = "label3";
            label3.Size = new Size(70, 20);
            label3.TabIndex = 4;
            label3.Text = "Password";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(402, 244);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(263, 27);
            txtPassword.TabIndex = 5;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // btnCancle
            // 
            btnCancle.Location = new Point(402, 329);
            btnCancle.Name = "btnCancle";
            btnCancle.Size = new Size(94, 29);
            btnCancle.TabIndex = 6;
            btnCancle.Text = "Cancle";
            btnCancle.UseVisualStyleBackColor = true;
            btnCancle.Click += btnCancle_Click;
            // 
            // Login
            // 
            ClientSize = new Size(1057, 587);
            Controls.Add(btnCancle);
            Controls.Add(txtPassword);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtId);
            Controls.Add(btnLogin);
            Controls.Add(label1);
            Name = "Login";
            Load += Login_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private Label label1;
        private Button btnLogin;
        private TextBox txtId;
        private Label label2;
        private Label label3;
        private Button btnCancle;
        private TextBox txtPassword;

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            txtId.Text = String.Empty; txtPassword.Text = String.Empty;
            txtId.Focus();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
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

        private void btnLogin_Click(object sender, EventArgs e)
        {

            if(string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Enter Id");
                return;
            }

            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Enter Password");
                return;
            }

            try
            {
                string id = txtId.Text;
                string password = txtPassword.Text;
                string Epassword = encryptPassword(password, key, iv);

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string qu = "select count(*) from customertable where customer_id=@id";
                    using (SqlCommand command = new SqlCommand(qu, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        int user = (int)command.ExecuteScalar();
                        if (user == 0)
                        {
                            MessageBox.Show("User is not found");
                            return;
                        }
                    }

                    string query = "select * from CustomerTable where customer_id = '" + id + "' and password = '" + Epassword + "'";
                    SqlDataAdapter adaptar = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adaptar.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        foreach(DataRow row in dt.Rows)
                        {
                            Lid = row["customer_id"].ToString();
                            name = row["customer_name"].ToString();
                            nrc = row["nrc_number"].ToString();
                            date = row["dob"].ToString();
                            memberCard = row["member_card"].ToString();
                            email = row["email"].ToString();
                            gender = row["gender"].ToString();
                            phone1 = row["phone_no_1"].ToString();
                            phone2 = row["phone_no_2"].ToString();
                            image = row["photo"].ToString();
                            address = row["address"].ToString();
                            Lpassword = decryptPassword(row["password"].ToString(), key, iv);
                        }
                        this.Hide();
                        Form1 form1 = new Form1
                        {
                            sourcePage = "login"
                        };
                        form1.Show();
                    }
                    else
                    {
                        MessageBox.Show("password incorrect");
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
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
    }
}
