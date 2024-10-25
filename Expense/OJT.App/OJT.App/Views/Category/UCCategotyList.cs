using OJT.Entities.Expense;
using OJT.Services.Expense;
using System;
using System.Data;
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

        private void dgvCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 0)
            {
                if(e.RowIndex >= 0 && e.RowIndex < dgvCategory.Rows.Count-1)
                {
                    var selectedRow = dgvCategory.Rows[e.RowIndex];
                    CategoryEntity categoryEntity = new CategoryEntity();
                    categoryEntity.categoryId = Convert.ToInt32(selectedRow.Cells["category_id"].Value);
                    categoryEntity.categoryName = selectedRow.Cells["category_name"].Value.ToString();
                    UCCategoryCreate uCCategoryCreate = new UCCategoryCreate()
                    {
                        category = categoryEntity
                    };
                    this.Controls.Clear();
                    this.Controls.Add(uCCategoryCreate);
                }
            }
        }
    }
}
