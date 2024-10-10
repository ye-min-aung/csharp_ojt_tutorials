using System.Data;
using System.Security.Cryptography;
using CustomerService.CService;

namespace CustomerApp.View
{
    public partial class Listing : Form
    {
        int select;
        string imagePath = "";
        int num = 0;
        int pageSize = 5;
        int currentPageIndex = 1;
        int totalPage = 0;
        string searchKeyword = "";

        private byte[] key = Convert.FromBase64String("k1rZt6cU5fD9G2dIbZRZksQ2pZJfw6PzfvA1wfg3Zb8=");
        private byte[] iv = Convert.FromBase64String("9vHdlrZ7QwJwU4r1cqls2g==");

        //public Service s = new Service();
        public Listing()
        {
            InitializeComponent();
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

        private void Listing_Load(object sender, EventArgs e)
        {
            //Load_Data();
        }

        //Service 
        //public void Load_Data()
        //{
        //    DataTable dt = 
        //}
    }
}
