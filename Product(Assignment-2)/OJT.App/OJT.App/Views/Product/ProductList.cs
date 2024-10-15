using OJT.Entities.Product;
using OJT.Services.Product;
using System;
using System.Data;
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

            dataGridView1.DataSource = dt;
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 0 )
            {
                if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count-1)
                {
                    var selectedRow = dataGridView1.Rows[e.RowIndex];
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
    }
}
