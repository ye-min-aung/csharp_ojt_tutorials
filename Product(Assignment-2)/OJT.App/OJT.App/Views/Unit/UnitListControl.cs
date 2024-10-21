using Guna.UI2.WinForms;
using OJT.App.Views.Product;
using OJT.Entities.Product;
using OJT.Services.Product;
using System;
using System.Data;
using System.Windows.Forms;

namespace OJT.App.Views
{
    public partial class UnitListControl : UserControl
    {
        public UnitListControl()
        {
            InitializeComponent();
        }
        ProductService service = new ProductService();
        private void UnitListControl_Load(object sender, EventArgs e)
        {
            DataTable dataTable = service.GetAllUnit();
            dgvUnit.DataSource = dataTable;
        }

        private void dgvUnit_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (e.RowIndex >= 0 && e.RowIndex < dgvUnit.Rows.Count - 1)
                {
                    var selectedRow = dgvUnit.Rows[e.RowIndex];
                    UnitCreateControl unitCreateControl = new UnitCreateControl();
                    unitCreateControl.unitId = selectedRow.Cells["unit_id"].Value.ToString();
                    unitCreateControl.unitName = selectedRow.Cells["unit_name"].Value.ToString();

                    this.Controls.Clear();
                    this.Controls.Add(unitCreateControl);
                }
            }
        }
    }
}
