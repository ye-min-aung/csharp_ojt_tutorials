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

namespace OJT.App.Views.Expense
{
    public partial class UCExpenseList : UserControl
    {
        public UCExpenseList()
        {
            InitializeComponent();
        }

        ExpenseService expenseService = new ExpenseService();

        private void UCExpenseList_Load(object sender, EventArgs e)
        {
            DataTable dt = expenseService.GetAllExpenseNOFit();
            dgvExpense.DataSource = dt;
        }

        private void LoadCategory()
        {
            DataTable dt = expenseService.GetAllCategory();
            cboCagtegory.DataSource = dt;
            cboCagtegory.DisplayMember = "category_name";
            cboCagtegory.ValueMember = "category_id";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadCategory();
            DateTime? fromDate = dtpFromDate.Value != DateTime.MinValue ? dtpFromDate.Value : (DateTime?)null;
            DateTime? toDate = dtpToDate.Value != DateTime.MinValue ? dtpToDate.Value : (DateTime?)null;
            string person = txtPerson.Text;
            int? categoryId = cboCagtegory.SelectedValue as int?;
            int pageSize = Convert.ToInt32(cboItems.SelectedItem);
            int pageNumber = 1;

            DataTable dt = expenseService.GetAllExpense(fromDate, toDate, person, categoryId, pageSize, pageNumber);
            dgvExpense.DataSource = dt;
        }
    }
}
