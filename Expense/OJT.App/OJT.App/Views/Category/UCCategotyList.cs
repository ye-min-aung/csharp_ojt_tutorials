using OJT.Services.Expense;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OJT.App.Views.Category
{
    public partial class UCCategotyList : UserControl
    {
        public UCCategotyList()
        {
            InitializeComponent();
        }

        ExpenseService service = new ExpenseService();

        private void UCCategotyList_Load(object sender, EventArgs e)
        {
            DataTable dt = service.GetAllCategory();
            dgvCategory.DataSource = dt;
        }
    }
}
