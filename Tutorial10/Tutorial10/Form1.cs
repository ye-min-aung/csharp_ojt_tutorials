using System.Net;
using System.Net.Mail;

namespace Tutorial10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            progressBar.Visible = false;
        }
        string attachFile = "";

        private async void btnEmail_Click(object sender, EventArgs e)
        {
            string recerverEmail = textReceiver.Text;
            if (!recerverEmail.Equals(""))
            {
                if (!recerverEmail.Contains("@") || !recerverEmail.Contains("."))
                {
                    MessageBox.Show("invalid Receiver Email");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Enter Receiver Email");
                return;
            }
            progressBar.Visible = true;

            try
            {

                MailMessage msg = new MailMessage();
                msg.From = new MailAddress(textSender.Text);
                msg.To.Add(recerverEmail);
                msg.Subject = textSubject.Text;
                msg.Body = txtRich.Text;

                if (!string.IsNullOrEmpty(attachFile))
                {
                    msg.Attachments.Add(new Attachment(attachFile));
                    MessageBox.Show("File got!");
                }

                SmtpClient smpt = new SmtpClient("smtp.gmail.com", 587);
                smpt.Credentials = new NetworkCredential("yeminaung0901@gmail.com", "bgok owry pyqu oyva");
                smpt.EnableSsl = true;
                await Task.Run(() => smpt.Send(msg));
                MessageBox.Show("Email sent ! ");
            }
            catch (Exception ex)
            {
                progressBar.Visible = false;
                MessageBox.Show("Error got ! " + ex.Message);
            }
            finally { progressBar.Visible = false; }
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileInfo fileInfo = new FileInfo(openFileDialog1.FileName);
                if (fileInfo.Length > 5 * 1024 * 1014)
                {
                    MessageBox.Show("File size exceed than 5MB");
                    attachFile = "";
                    labFileName.Text = null;
                }
                else
                {
                    attachFile = openFileDialog1.FileName;
                    labFileName.Text = fileInfo.Name;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

