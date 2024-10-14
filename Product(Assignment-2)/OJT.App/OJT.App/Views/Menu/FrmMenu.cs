using OJT.App.Views.Employee;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OJT.App.Views.Menu
{
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }

        private void employeeListingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UCEmployeeList ucEmployeeList = new UCEmployeeList();
            pnUC.Controls.Clear();
            pnUC.Controls.Add(ucEmployeeList);
        }

        private void employeeCRUDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UCEmployee ucEmployee = new UCEmployee();
            pnUC.Controls.Clear();
            pnUC.Controls.Add(ucEmployee);
        }
    }
}
