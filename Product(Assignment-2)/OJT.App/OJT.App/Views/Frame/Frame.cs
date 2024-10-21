using OJT.App.Views.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OJT.App.Views.Frame
{
    public partial class Frame : Form
    {
        public Frame()
        {
            InitializeComponent();
        }

        private void productCreateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void productListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void unitCreateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductCreateControl productCreateControl = new ProductCreateControl();
            panel1.Controls.Clear();
            panel1.Controls.Add(productCreateControl);
        }

        private void listToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductListControl productListControl = new ProductListControl();
            panel1.Controls.Clear();
            panel1.Controls.Add(productListControl);
        }

        private void createToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            UnitCreateControl unitCreateControl = new UnitCreateControl();
            panel1.Controls.Clear();
            panel1.Controls.Add(unitCreateControl);
        }

        private void listToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            UnitListControl unitListControl = new UnitListControl();
            panel1.Controls.Clear();
            panel1.Controls.Add(unitListControl);
        }
    }
}
