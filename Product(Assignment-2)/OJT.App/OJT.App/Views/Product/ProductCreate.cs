using System;
using System.Windows.Forms;
using OJT.Entities.Product;
using OJT.Services.Product;

namespace OJT.App.Views.Product
{
    public partial class ProductCreate : Form
    {
        public ProductCreate()
        {
            InitializeComponent();
        }
        ProductService service = new ProductService();
        public string ID { set { txtProductId.Text = value; } }

        private void ProductCreate_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool inserted = AddorUpdate();

            if (inserted)
            {
                    MessageBox.Show("Save Success.", "Success", MessageBoxButtons.OK);
            }
        }

        private bool AddorUpdate()
        {
            ProductEntity product = CreateProduct();
            UnitEntity unit = CreateUnit();

            if(product == null || unit == null)
            {
                return false;
            }
            bool success = false;
            
            if(string.IsNullOrEmpty(txtProductId.Text))
            {
                success = service.Insert(product, unit);
            }
            return success;
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
    }
}
