using OJT.Entities.Product;
using OJT.Services.Product;
using System;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

namespace OJT.App.Views.Product
{
    public partial class ProductCreate : Form
    {

        public ProductEntity Product { get; set; }
        public UnitEntity Unit { get; set; }
        
        public ProductCreate()
        {
            InitializeComponent();
        }
        ProductService service = new ProductService();
        public string ID { set { txtProductId.Text = value; } }

        private void ProductCreate_Load(object sender, EventArgs e)
        {
            if(Product != null)
            {
                txtProductId.Text = Product.Product_Id.ToString();
                txtName.Text = Product.Product_Name.ToString();
                txtPrice.Text = Product.Product_Price.ToString();
            }

            if (Unit != null)
            {
                txtUnit.Text = Unit.unitName.ToString();
            }

            if (!string.IsNullOrEmpty(txtProductId.Text))
            {
                btnSave.Text = "Update";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            AddorUpdate();
            
        }

        private void AddorUpdate()
        {
            ProductEntity product = CreateProduct();
            UnitEntity unit = CreateUnit();

            if(product == null || unit == null)
            {
                return;
            }
            bool success = false;
            
            if(string.IsNullOrEmpty(txtProductId.Text))
            {
                success = service.Insert(product, unit);
                if (success)
                {
                    MessageBox.Show("Save Success.", "Success", MessageBoxButtons.OK);
                    ProductList p = new ProductList();
                    this.Hide();
                    p.Show();
                }
            }
            else
            {
                success = service.Update(product, unit);
                if (success)
                {
                    MessageBox.Show("Update Success.", "Success", MessageBoxButtons.OK);
                    ProductList p = new ProductList();
                    this.Hide();
                    p.Show();
                }
            }
        }

        private ProductEntity CreateProduct()
        {
            ProductEntity productEntity = new ProductEntity(); ;
            if (String.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Enter Name.", "Fail", MessageBoxButtons.OK);
                return null;
            }

            if (String.IsNullOrEmpty(txtPrice.Text))
            {
                MessageBox.Show("Enter Price.", "Fail", MessageBoxButtons.OK);
                return null;
            }
            if (!String.IsNullOrEmpty(txtProductId.Text))
            {
                productEntity.Product_Id = txtProductId.Text;
            }
            productEntity.Product_Name = txtName.Text;
            productEntity.Product_Price = txtPrice.Text;

            return productEntity;
        }

        private UnitEntity CreateUnit()
        {
            UnitEntity unitEntity = new UnitEntity(); ;
            if (String.IsNullOrEmpty(txtUnit.Text))
            {
                MessageBox.Show("Enter Unit.", "Fail", MessageBoxButtons.OK);
                return null;
            }
            unitEntity.unitName = txtUnit.Text;

            return unitEntity;
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            ProductList list = new ProductList();
            this.Hide();
            list.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool success = false;
            if (!String.IsNullOrEmpty(txtProductId.Text))
            {
                success = service.Delete(txtProductId.Text.ToString());
                if(success)
                {
                    MessageBox.Show("Delete Success.", "Success", MessageBoxButtons.OK);
                    ProductList p = new ProductList();
                    this.Hide();
                    p.Show();
                }
            }else
            {
                MessageBox.Show("No Data Selected.", "Warning", MessageBoxButtons.OK);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtProductId.Text = string.Empty;
            txtName.Text = string.Empty;
            txtPrice.Text = string.Empty;
            txtUnit.Text = string.Empty;
        }

        private void ProductCreate_Paint(object sender, PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle,ColorTranslator.FromHtml("#93A5CF ") ,ColorTranslator.FromHtml("#E4EfE9"), 45F))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }
    }
}
