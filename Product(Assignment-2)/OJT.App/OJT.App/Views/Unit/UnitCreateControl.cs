using OJT.Entities.Product;
using OJT.Services.Product;
using System;
using System.Windows.Forms;

namespace OJT.App.Views.Product
{
    public partial class UnitCreateControl : UserControl
    {
        public UnitCreateControl()
        {
            InitializeComponent();
        }
        public string unitName { get; set; }
        public string unitId { get; set; }

        ProductService service = new ProductService();

        private void btnSave_Click(object sender, EventArgs e)
        {
            AddUnit();
        }

        public void AddUnit()
        {
            UnitEntity unit = CreateUnit();
            if(unit == null )
            {
                return;
            }

            bool success = false;

            if(String.IsNullOrEmpty(txtUnitId.Text))
            {
                success = service.AddUnit(unit);

                if (success)
                {
                    MessageBox.Show("Success.", "Success", MessageBoxButtons.OK);
                    txtUnitName.Text = String.Empty;
                    txtUnitName.Focus();
                }
            }else
            {
                success = service.UpdateUnit(unit);

                if (success)
                {
                    MessageBox.Show("Success.", "Success", MessageBoxButtons.OK);
                    txtUnitName.Text = String.Empty;
                    txtUnitName.Focus();
                }
            }
        }

        private UnitEntity CreateUnit()
        {
            UnitEntity unitEntity = new UnitEntity(); ;
            if (String.IsNullOrEmpty(txtUnitName.Text))
            {
                MessageBox.Show("Enter Unit.", "Fail", MessageBoxButtons.OK);
                return null;
            }
            unitEntity.unitName = txtUnitName.Text;

            if(!String.IsNullOrEmpty(txtUnitId.Text))
            {
                unitEntity.unitId = txtUnitId.Text;
            }

            return unitEntity;
        }

        private void UnitCreateControl_Load(object sender, EventArgs e)
        {
            if(unitName != null)
            {
                txtUnitId.Text = unitId.ToString();
                txtUnitName.Text = unitName.ToString();
            }
            if(!String.IsNullOrEmpty(txtUnitId.Text))
            {
                btnSave.Text = "Update";
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtUnitId.Text))
            {
                service.DeleteUnit(txtUnitId.Text);
                UnitListControl unitList = new UnitListControl();
                this.Controls.Clear();
                this.Controls.Add(unitList);
            }
            else
            {
                MessageBox.Show("No unit selected", "Fail", MessageBoxButtons.OK);
            }
        }
    }
}
