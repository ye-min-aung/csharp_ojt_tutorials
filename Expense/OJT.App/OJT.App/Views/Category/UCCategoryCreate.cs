using OJT.Services.Expense;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace OJT.App.Views.Category
{
    public partial class UCCategoryCreate : UserControl
    {
        public UCCategoryCreate()
        {
            InitializeComponent();
        }

        ExpenseService service = new ExpenseService();

        private void btnSave_Click(object sender, EventArgs e)
        {
            string categoryName = txtCategoryName.Text;
            
            if (string.IsNullOrEmpty(categoryName) )
            {
                MessageBox.Show("Enter Category Name.", "Fail", MessageBoxButtons.OK);
            }
            else
            {
                bool success = service.InsertCategory(categoryName);
                if (success)
                {
                    MessageBox.Show("Save Success.", "Success", MessageBoxButtons.OK);
                    UCCategotyList list = new UCCategotyList();
                    this.Controls.Clear();
                    this.Controls.Add(list);
                }
            }

        }
    }
}
