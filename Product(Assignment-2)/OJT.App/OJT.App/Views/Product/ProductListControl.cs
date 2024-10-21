using OJT.Entities.Product;
using OJT.Services.Product;
using System;
using System.Data;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace OJT.App.Views.Product
{
    public partial class ProductListControl : UserControl
    {
        public ProductListControl()
        {
            InitializeComponent();
        }
        ProductService service = new ProductService();


        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (e.RowIndex >= 0 && e.RowIndex < guna2DataGridView1.Rows.Count - 1)
                {
                    var selectedRow = guna2DataGridView1.Rows[e.RowIndex];
                    var product = new ProductEntity
                    {
                        Product_Id = selectedRow.Cells["product_id"].Value.ToString(),
                        Product_Name = selectedRow.Cells["product_name"].Value.ToString(),
                        Product_Price = selectedRow.Cells["product_price"].Value.ToString()
                    };

                    var unit = new UnitEntity
                    {
                        unitName = selectedRow.Cells["unit_name"].Value.ToString(),
                        unitId = selectedRow.Cells["unit_id"].Value.ToString()
                    };

                    ProductCreateControl p = new ProductCreateControl()
                    {
                        Product = product,
                        Unit = unit
                    };
                    this.Controls.Clear();
                    this.Controls.Add(p);
                }
            }
        }

        private void ProductListControl_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            DataTable dt = service.getAllData();

            guna2DataGridView1.DataSource = dt;
        }
    }
}
