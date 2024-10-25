using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OJT.App.Views.Category;
using OJT.App.Views.Expense;

namespace OJT.App.Views.Menu
{
    public partial class Frame : Form
    {
        public Frame()
        {
            InitializeComponent();
        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UCExpenseCreate uCExpenseCreate = new UCExpenseCreate();
            uCExpenseCreate.Dock = DockStyle.Fill;
            Panal.Controls.Clear();
            Panal.Controls.Add(uCExpenseCreate);
        }

        private void allExpenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UCExpenseList uCExpenseList = new UCExpenseList();
            Panal.Controls.Clear();
            Panal.Controls.Add(uCExpenseList);
        }

        private void createToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            UCCategoryCreate uCCategoryCreate = new UCCategoryCreate();
            Panal.Controls.Clear();
            Panal.Controls.Add(uCCategoryCreate);
        }

        private void listToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UCCategotyList uCCategotyList = new UCCategotyList();
            Panal.Controls.Clear();
            Panal.Controls.Add(uCCategotyList);
        }
    }
}
