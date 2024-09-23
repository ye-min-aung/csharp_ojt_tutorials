namespace Tutorial2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int id = 1;

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

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
                    id++;
                    listBox1.Items.Add(data);
                }

            }
            else
            {
                MessageBox.Show("invalid email");
            }

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
    }
}
