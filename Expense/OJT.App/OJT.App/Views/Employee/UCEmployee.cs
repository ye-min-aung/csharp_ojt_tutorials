using Entities.Employee;
using Services.Employee;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace OJT.App.Views.Employee
{
    public partial class UCEmployee : UserControl
    {
        public string ID
        { set { hdEmployeeId.Text = value; } }
        EmployeeService employeeService = new EmployeeService();
        UCEmployeeList ucEmployeeList = new UCEmployeeList();
        public UCEmployee()
        {
            InitializeComponent();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            AddorUpdate();
        }
        private void AddorUpdate()
        {
            EmployeeService employeeService = new EmployeeService();
            EmployeeEntity employeeEntity = CreateData();
            bool success = false;

            if (String.IsNullOrEmpty(hdEmployeeId.Text))
            {
                success = employeeService.Insert(employeeEntity);
                if (success)
                {
                    MessageBox.Show("Save Success.", "Success", MessageBoxButtons.OK);
                }
            }
            else
            {
                success = employeeService.Update(employeeEntity);
                if (success)
                {
                    MessageBox.Show("Update Success.", "Success", MessageBoxButtons.OK);
                }
            }
            this.Controls.Clear();
            this.Controls.Add(ucEmployeeList);
        }
        private EmployeeEntity CreateData()
        {
            EmployeeEntity employeeEntity = new EmployeeEntity(); ;
            if (!String.IsNullOrEmpty(hdEmployeeId.Text))
            {
                employeeEntity.employeeId = Convert.ToInt32(hdEmployeeId.Text);
            }
            employeeEntity.name = txtName.Text;
            employeeEntity.address = txtAddress.Text;
            employeeEntity.designation = txtDesignation.Text;
            employeeEntity.salary = txtSalary.Text == "" ? 0 : Convert.ToInt32(txtSalary.Text);
            employeeEntity.joiningDate = Convert.ToDateTime(dtpJoiningDate.Text);

            return employeeEntity;
        }

        private void UCEmployee_Load(object sender, EventArgs e)
        {
            BindData();
            BtnControl();
        }
        private void BindData()
        {
            if (!String.IsNullOrEmpty(hdEmployeeId.Text))
            {
                DataTable dt = employeeService.Get(Convert.ToInt32(hdEmployeeId.Text));

                if (dt.Rows.Count > 0)
                {
                    txtName.Text = dt.Rows[0]["Name"].ToString();
                    txtAddress.Text = dt.Rows[0]["Address"].ToString();
                    txtDesignation.Text = dt.Rows[0]["Designation"].ToString();
                    txtSalary.Text = dt.Rows[0]["Salary"].ToString();
                    dtpJoiningDate.Text = dt.Rows[0]["JoiningDate"].ToString();
                }
            }
        }
        private void BtnControl()
        {
            if (String.IsNullOrEmpty(hdEmployeeId.Text))
            {
                btnAddNew.Text = "Add New";
                btnDelete.Enabled = false;
            }
            else
            {
                btnAddNew.Text = "Update";
                btnDelete.Enabled = true;
            }
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            this.Controls.Add(ucEmployeeList);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool success = employeeService.Delete(Convert.ToInt32(hdEmployeeId.Text));
            if (success)
            {
                MessageBox.Show("Delete Success.", "Success", MessageBoxButtons.OK);
            }
            this.Controls.Clear();
            this.Controls.Add(ucEmployeeList);
        }
    }
}
