using System.Collections;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Tutorial2_01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            cid.DataPropertyName = "cid";
            name.DataPropertyName = "name";
            email.DataPropertyName = "email";
            phone.DataPropertyName = "phone";

        }

        int id = 1;
        List<Member> list = new List<Member>();

        private void button1_Click(object sender, EventArgs e)
        {

            dataGridView1.AutoGenerateColumns = false;
            string name = txtName.Text;
            string phone = txtPhone.Text;
            string email = txtEmail.Text;

            if (email.Contains("@") && email.Contains("."))
            {

                if (!IsPhone(phone))
                {
                    MessageBox.Show("invalid phone");
                }

                else
                {
                    string data = id + " ,MC-00" + id + " ," + email + " ," + phone;

                    Member mem = new Member();
                    mem.cid = "MC-000" + id;
                    mem.name = name;
                    mem.email = email;
                    mem.phone = phone;
                    
                    list.Add(mem);
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = list;
                    id++;
                }

            }
            else
            {
                MessageBox.Show("invalid email");
            }

            txtName.Text = null;
            txtEmail.Text = null;
            txtPhone.Text = null;

        }

        bool IsPhone(string phone)
        {
            foreach (char c in phone)
            {
                if (!(char.IsDigit(c) || c=='+' || c=='-'))
                {
                    return false;
                }
            }
            return true;
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
    public class Member
    {
        public string cid { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }   
          
    }

}
