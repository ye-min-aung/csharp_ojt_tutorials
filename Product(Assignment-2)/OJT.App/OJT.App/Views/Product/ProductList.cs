using OJT.Entities.Product;
using OJT.Services.Product;
using System;
using System.Data;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

namespace OJT.App.Views.Product
{
    public partial class ProductList : Form
    {
        public ProductList()
        {
            InitializeComponent();
        }

        ProductService service = new ProductService();

        private void ProductList_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            DataTable dt = service.getAllData();

            guna2DataGridView1.DataSource = dt;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ProductCreate p = new ProductCreate();
            p.Show();
            this.Hide();
        }

      

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
                        unitName = selectedRow.Cells["unit_name"].Value.ToString()
                    };

                    ProductCreate p = new ProductCreate()
                    {
                        Product = product,
                        Unit = unit
                    };
                    this.Hide();
                    p.Show();
                }
            }

        }

        private void ProductList_Paint(object sender, PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, ColorTranslator.FromHtml("#93A5CF "), ColorTranslator.FromHtml("#E4EfE9"), 45F))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }
    }
}
