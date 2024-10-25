using OJT.Services.Expense;
using System;
using System.Windows.Forms;
using OJT.Entities.Expense;
using System.Windows.Forms.VisualStyles;

namespace OJT.App.Views.Category
{
    public partial class UCCategoryCreate : UserControl
    {
        public UCCategoryCreate()
        {
            InitializeComponent();
        }

        public CategoryEntity category { get; set;}

        ExpenseService service = new ExpenseService();

        private void btnSave_Click(object sender, EventArgs e)
        {
            AddorUpdate();
        }

        private void AddorUpdate()
        {
            if(category == null)
            {
                string categoryName = txtCategoryName.Text;

                if (string.IsNullOrEmpty(categoryName))
                {
                    MessageBox.Show("Enter Category Name.", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    bool success = service.InsertCategory(categoryName);
                    if (success)
                    {
                        MessageBox.Show("Save Success.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        UCCategotyList list = new UCCategotyList();
                        this.Controls.Clear();
                        this.Controls.Add(list);
                    }
                }
            }
            else
            {
                if (string.IsNullOrEmpty(txtCategoryName.Text))
                {
                    MessageBox.Show("Enter Category Name.", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    CategoryEntity categoryEntity = new CategoryEntity();
                    categoryEntity.categoryId = Convert.ToInt32(txtCategoryId.Text);
                    categoryEntity.categoryName = txtCategoryName.Text;
                    bool success = service.UpdateCategory(categoryEntity);
                    if (success)
                    {
                        MessageBox.Show("Update Success.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        UCCategotyList list = new UCCategotyList();
                        this.Controls.Clear();
                        this.Controls.Add(list);
                    }
                }
                

            }
        }

        private void UCCategoryCreate_Load(object sender, EventArgs e)
        {
            if (category != null)
            {
                btnSave.Text = "Update";
                txtCategoryId.Text = category.categoryId.ToString();
                txtCategoryName.Text = category.categoryName.ToString();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtCategoryName.Text = string.Empty;
            txtCategoryId.Text = null;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(txtCategoryId.Text))
            {
                MessageBox.Show("No Category Selected.", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int id = Convert.ToInt32(txtCategoryId.Text);
            bool success = service.DeleteCategory(id);
            if (success)
            {
                MessageBox.Show("Delete Success.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UCCategotyList list = new UCCategotyList();
                this.Controls.Clear();
                this.Controls.Add(list);
            }
            else
            {
                MessageBox.Show("Delete Fail.", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
