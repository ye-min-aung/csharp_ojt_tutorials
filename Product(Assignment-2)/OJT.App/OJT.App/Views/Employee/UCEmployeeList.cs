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

namespace OJT.App.Views.Employee
{
    public partial class UCEmployeeList : UserControl
    {
        private EmployeeService employeeService = new EmployeeService();
        public UCEmployeeList()
        {
            InitializeComponent();
        }

        private void UCEmployeeList_Load(object sender, EventArgs e)
        {
            BindGrid();
        }
        private void BindGrid()
        {
            DataTable dt = employeeService.GetAll();
            dgvEmployeeList.DataSource = dt;
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            UCEmployee ucEmployee = new UCEmployee();
            this.Controls.Clear();
            this.Controls.Add(ucEmployee);
        }

        private void dgvEmployeeList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                int employeeID = Convert.ToInt32(dgvEmployeeList.Rows[e.RowIndex].Cells["gcEmployeeID"].Value);
                if (e.ColumnIndex == dgvEmployeeList.Columns["gcEmployeeID"].Index)
                {
                    UCEmployee ucEmployee = new UCEmployee();
                    ucEmployee.ID = employeeID.ToString();
                    this.Controls.Clear();
                    this.Controls.Add(ucEmployee);
                    
                }
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {

        }
    }
}
