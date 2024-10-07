using System.Data;
using System.Text.RegularExpressions;

namespace Tutorial3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            dataGridView1.RowTemplate.Height = 90;

            table.Columns.Add("Customer Id", typeof(string));
            table.Columns.Add("Staff Name", typeof(string));
            table.Columns.Add("Photo", typeof(Image));
            table.Columns.Add("NRC NO", typeof(string));
            table.Columns.Add("Staff Type", typeof(string));
            table.Columns.Add("Email", typeof(string));
            table.Columns.Add("Gender", typeof(string));
            table.Columns.Add("Age", typeof(string));
            table.Columns.Add("Phone No1", typeof(string));
            table.Columns.Add("Phone No2", typeof(string));
            table.Columns.Add("Address  ", typeof(string));
            table.Columns.Add("hidden", typeof(string));

        }
        DataTable table = new DataTable();
        int select;
        string imagePath = "";
        int cid = 0;

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnChooseImage_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                imagePath = openFileDialog1.FileName;
                pictureBox1.Load(openFileDialog1.FileName);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            cid++;
            string id = "C-" + cid.ToString("D4");

            string name = txtName.Text;
            string nrc = txtNrc.Text;
            string type = comboBox1.Text;
            string email = txtEmail.Text;
            string gender = "";
            if (rdoOther.Checked)
            {
                gender = "Other";
            }
            else if (rdoMale.Checked)
            {
                gender = "Male";
            }
            else if (rdoFemale.Checked)
            {
                gender = "Female";
            }
            string age = txtAge.Text;
            string phone1 = txtPhone1.Text;
            string phone2 = txtPhone2.Text;
            string address = txtAddress.Text;

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

            Image image = null;
            string hideData = "";


            if (!string.IsNullOrEmpty(imagePath))
            {
                try
                {
                    string imageFileName = Path.GetFileName(imagePath);
                    string destinationFolder = Path.Combine(Application.StartupPath, "images");
                    string destinationPath = Path.Combine(destinationFolder, imageFileName);

                    if (!Directory.Exists(destinationFolder))
                    {
                        Directory.CreateDirectory(destinationFolder);
                    }

                    if (File.Exists(destinationPath))
                    {
                        string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(imageFileName);
                        string fileExtension = Path.GetExtension(imageFileName);
                        string uniqueFileName = fileNameWithoutExtension + "_" + DateTime.Now.Ticks + fileExtension;

                        destinationPath = Path.Combine(destinationFolder, uniqueFileName);
                        imageFileName = uniqueFileName;
                    }

                    File.Copy(imagePath, destinationPath);

                    image = Image.FromFile(destinationPath);
                    hideData = imageFileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error handling image: " + ex.Message);
                    return;
                }
            }

            table.Rows.Add(id, name, image, nrc, type, email, gender, age, phone1, phone2, address, hideData);

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = table;
            dataGridView1.Columns["hidden"].Visible = false;
            ((DataGridViewImageColumn)dataGridView1.Columns["Photo"]).ImageLayout = DataGridViewImageCellLayout.Stretch;

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        bool IsPhone(string phone)
        {
            foreach (char c in phone)
            {
                if (!(char.IsDigit(c) || c == '+' || c == '-'))
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
            comboBox1.Text = null;
            txtEmail.Text = null;
            rdoOther.Checked = false;
            rdoMale.Checked = false;
            rdoFemale.Checked = false;
            txtAge.Text = null;
            txtPhone1.Text = null;
            txtPhone2.Text = null;
            txtAddress.Text = null;
            pictureBox1.Image = null;

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            if (select > 0)
            {
                string id = txtId.Text;
                string name = txtName.Text;
                string nrc = txtNrc.Text;
                string type = comboBox1.Text;
                string email = txtEmail.Text;
                string gender = rdoOther.Checked ? "Other" : rdoMale.Checked ? "Male" : "Female";
                string age = txtAge.Text;
                string phone1 = txtPhone1.Text;
                string phone2 = txtPhone2.Text;
                string address = txtAddress.Text;

                string imageFileName = Path.GetFileName(imagePath);
                string destinationPath = Path.Combine(Application.StartupPath, "images", imageFileName);

                if (!Directory.Exists(Path.Combine(Application.StartupPath, "images")))
                {
                    Directory.CreateDirectory(Path.Combine(Application.StartupPath, "images"));
                }


                if (File.Exists(destinationPath))
                {
                    string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(imageFileName);
                    string fileExtension = Path.GetExtension(imageFileName);
                    imageFileName = fileNameWithoutExtension + "_" + DateTime.Now.Ticks + fileExtension;

                    destinationPath = Path.Combine(Application.StartupPath, "images", imageFileName);
                }

                File.Copy(imagePath, destinationPath, true);

                Image image = Image.FromFile(destinationPath);
                string hideData = imageFileName;

                table.Rows[select]["Customer Id"] = id;
                table.Rows[select]["Staff Name"] = name;
                table.Rows[select]["NRC NO"] = nrc;
                table.Rows[select]["Staff Type"] = type;
                table.Rows[select]["Email"] = email;
                table.Rows[select]["Gender"] = gender;
                table.Rows[select]["Age"] = age;
                table.Rows[select]["Phone No1"] = phone1;
                table.Rows[select]["Phone No2"] = phone2;
                table.Rows[select]["Address  "] = address;
                table.Rows[select]["Photo"] = image;
                table.Rows[select]["hidden"] = hideData;

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = table;
                ((DataGridViewImageColumn)dataGridView1.Columns["Photo"]).ImageLayout = DataGridViewImageCellLayout.Stretch;
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            select = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectRow = dataGridView1.Rows[e.RowIndex];
                txtId.Text = selectRow.Cells["Customer Id"].Value.ToString();
                txtName.Text = selectRow.Cells["Staff Name"].Value.ToString();
                txtNrc.Text = selectRow.Cells["NRC NO"].Value.ToString();
                comboBox1.Text = selectRow.Cells["Staff Type"].Value.ToString();
                txtEmail.Text = selectRow.Cells["Email"].Value.ToString();

                string gender = selectRow.Cells["Gender"].Value.ToString();
                string img = selectRow.Cells["hidden"].Value.ToString();
                string destination = Path.Combine(Application.StartupPath, "images", img);

                if (File.Exists(destination))
                {
                    pictureBox1.Load(destination);
                }
                else
                {
                    pictureBox1.Image = null;
                    MessageBox.Show("Image not found");
                }

                if (gender == "Male")
                    rdoMale.Checked = true;
                else if (gender == "Female")
                    rdoFemale.Checked = true;
                else
                    rdoOther.Checked = true;

                txtAge.Text = selectRow.Cells["Age"].Value.ToString();
                txtPhone1.Text = selectRow.Cells["Phone No1"].Value.ToString();
                txtPhone2.Text = selectRow.Cells["Phone No2"].Value.ToString();
                txtAddress.Text = selectRow.Cells["Address  "].Value.ToString();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (select > 0)
            {
                table.Rows[select].Delete();
                txtId.Text = null;
                txtName.Text = null;
                txtNrc.Text = null;
                comboBox1.Text = null;
                txtEmail.Text = null;
                rdoOther.Checked = false;
                rdoMale.Checked = false;
                rdoFemale.Checked = false;
                txtAge.Text = null;
                txtPhone1.Text = null;
                txtPhone2.Text = null;
                txtAddress.Text = null;
                pictureBox1.Image = null;
                string imageFileName = Path.GetFileName(imagePath);

                string distination = Path.Combine(Application.StartupPath, "images", imageFileName);
                File.Delete(distination);
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            int age = DateTime.Today.Year - dateTimePicker1.Value.Year;
            txtAge.Text = age.ToString();
        }
    }
}
