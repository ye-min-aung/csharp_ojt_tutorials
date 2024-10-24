using OJT.Entities.Expense;
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
using System.Windows.Forms.VisualStyles;
using System.Xml.Linq;

namespace OJT.App.Views.Expense
{
    public partial class UCExpenseCreate : UserControl
    {
        public UCExpenseCreate()
        {
            InitializeComponent();
        }

        public string ExpenseId { set { txtExpenseId.Text = value; } }
        public ExpenseEntity expense { get; set; }
        ExpenseService service = new ExpenseService();

        private void UCExpenseCreate_Load(object sender, EventArgs e)
        {
            LoadCategory();
            ExpenseDate.Value = DateTime.Now;
            if (expense != null)
            {
                txtExpenseId.Text = expense.expenseId.ToString();
                txtExpenseName.Text = expense.expenseName.ToString();
                cboCategory.SelectedValue = expense.category;
                ExpenseDate.Text = expense.date;
                txtPerson.Text = expense.person.ToString();
                txtAmount.Text = expense.Amount.ToString();
            }

            if (!string.IsNullOrEmpty(txtExpenseId.Text))
            {
                btnSave.Text = "Update";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            AddorUpdate();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void AddorUpdate()
        {
            ExpenseEntity expenseEntity = createExpenseEntity();
            if(expenseEntity == null)
            {
                return;
            }

            bool success = false;

            if (string.IsNullOrEmpty(txtExpenseId.Text))
            {
                success = service.Insert(expenseEntity);
                if (success)
                {
                    MessageBox.Show("Save Success.", "Success", MessageBoxButtons.OK);
                    UCExpenseList list = new UCExpenseList();
                    this.Controls.Clear();
                    this.Controls.Add(list);
                }
            }
            else
            {
                //success = service.Update(expenseEntity);
                if (success)
                {
                    MessageBox.Show("Update Success.", "Success", MessageBoxButtons.OK);
                    UCExpenseList list = new UCExpenseList();
                    this.Controls.Clear();
                    this.Controls.Add(list);
                }
            }

        }

        private ExpenseEntity createExpenseEntity()
        {
            ExpenseEntity expenseEntity = new ExpenseEntity();
            if(String.IsNullOrEmpty(txtExpenseName.Text))
            {
                MessageBox.Show("Enter Expense.", "Fail", MessageBoxButtons.OK);
                return null;
            }
            if (String.IsNullOrEmpty(cboCategory.Text))
            {
                MessageBox.Show("Enter Category.", "Fail", MessageBoxButtons.OK);
                return null;
            }
            if (String.IsNullOrEmpty(ExpenseDate.Text))
            {
                MessageBox.Show("Enter Date.", "Fail", MessageBoxButtons.OK);
                return null;
            }
            if (String.IsNullOrEmpty(txtPerson.Text))
            {
                MessageBox.Show("Enter Person Name.", "Fail", MessageBoxButtons.OK);
                return null;
            }
            if (String.IsNullOrEmpty(txtAmount.Text))
            {
                MessageBox.Show("Enter Amount.", "Fail", MessageBoxButtons.OK);
                return null;
            }
            if (!String.IsNullOrEmpty(txtExpenseId.Text))
            {
                expenseEntity.expenseId = Convert.ToInt32(txtExpenseId.Text);
            }
            

            expenseEntity.expenseName = txtExpenseName.Text;
            expenseEntity.category = cboCategory.SelectedValue.ToString();
            expenseEntity.date = ExpenseDate.Text;
            expenseEntity.person = txtPerson.Text;
            expenseEntity.Amount = Convert.ToInt32(txtAmount.Text);

            return expenseEntity;

        }
        private void LoadCategory()
        {
            DataTable dt = service.GetAllCategory();
            cboCategory.DataSource = dt;
            cboCategory.DisplayMember = "category_name";
            cboCategory.ValueMember = "category_id";
        }
    }
}
