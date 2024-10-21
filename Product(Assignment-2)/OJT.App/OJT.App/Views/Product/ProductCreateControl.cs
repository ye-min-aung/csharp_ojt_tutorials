using OJT.Entities.Product;
using OJT.Services.Product;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace OJT.App.Views.Product
{
    public partial class ProductCreateControl : UserControl
    {
        public ProductCreateControl()
        {
            InitializeComponent();
        }
        ProductService service = new ProductService();
        public string ID { set { txtProductId.Text = value; } }

        public ProductEntity Product { get; set; }
        public UnitEntity Unit { get; set; }

        private void btnSave_Click(object sender, EventArgs e)
        {
            AddorUpdate();
        }

        private void ProductCreateControl_Load(object sender, EventArgs e)
        {
            LoadUnit();
            if (Product != null)
            {
                txtProductId.Text = Product.Product_Id.ToString();
                txtName.Text = Product.Product_Name.ToString();
                txtPrice.Text = Product.Product_Price.ToString();
            }

            if (Unit != null)
            {
                cboUnit.SelectedValue = Unit.unitId.ToString();
            }

            if (!string.IsNullOrEmpty(txtProductId.Text))
            {
                btnSave.Text = "Update";
            }
        }

        private void LoadUnit()
        {
            DataTable dataTable = service.GetAllUnit();
            cboUnit.DataSource = dataTable;
            cboUnit.DisplayMember = "unit_name";
            cboUnit.ValueMember = "unit_id";
        }

        private void AddorUpdate()
        {
            ProductEntity product = CreateProduct();
            //UnitEntity unit = CreateUnit();

            //if (product == null || unit == null)
            if (product == null)
            {
                return;
            }
            string unitId = cboUnit.SelectedValue.ToString();
            bool success = false;

            if (string.IsNullOrEmpty(txtProductId.Text))
            {
                success = service.Insert(product, unitId);
                if (success)
                {
                    MessageBox.Show("Save Success.", "Success", MessageBoxButtons.OK);
                    ProductListControl p = new ProductListControl();
                    this.Controls.Clear();
                    this.Controls.Add(p);
                }
            }
            else
            {
                success = service.Update(product, unitId);
                if (success)
                {
                    MessageBox.Show("Update Success.", "Success", MessageBoxButtons.OK);
                    ProductListControl p = new ProductListControl();
                    this.Controls.Clear();
                    this.Controls.Add(p);
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
            foreach (char c in txtPrice.Text)
            {
                if (!Char.IsDigit(c))
                {
                    MessageBox.Show("Enter Valid Price (number only).", "Fail", MessageBoxButtons.OK);
                    return null;
                }
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
            if (String.IsNullOrEmpty(cboUnit.Text))
            {
                MessageBox.Show("Enter Unit.", "Fail", MessageBoxButtons.OK);
                return null;
            }
            unitEntity.unitName = cboUnit.Text;

            return unitEntity;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool success = false;
            if (!String.IsNullOrEmpty(txtProductId.Text))
            {
                success = service.Delete(txtProductId.Text.ToString());
                if (success)
                {
                    MessageBox.Show("Delete Success.", "Success", MessageBoxButtons.OK);
                    ProductListControl p = new ProductListControl();
                    this.Controls.Clear();
                    this.Controls.Add(p);
                }
            }
            else
            {
                MessageBox.Show("No Data Selected.", "Warning", MessageBoxButtons.OK);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtProductId.Text = string.Empty;
            txtName.Text = string.Empty;
            txtPrice.Text = string.Empty;
            cboUnit.Text = string.Empty;
        }

        private void ProductCreate_Paint(object sender, PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, ColorTranslator.FromHtml("#93A5CF "), ColorTranslator.FromHtml("#E4EfE9"), 45F))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }
    }
}
