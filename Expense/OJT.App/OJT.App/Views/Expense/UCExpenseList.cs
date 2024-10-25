using iTextSharp.text;
using iTextSharp.text.pdf;
using OJT.Entities.Expense;
using OJT.Services.Expense;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace OJT.App.Views.Expense
{
    public partial class UCExpenseList : UserControl
    {
        public UCExpenseList()
        {
            InitializeComponent();
        }

        ExpenseService expenseService = new ExpenseService();

        private void UCExpenseList_Load(object sender, EventArgs e)
        {
            cboCagtegory.DropDownStyle = ComboBoxStyle.DropDown;
            cboItems.Text = "10";
            dtpFromDate.Value = DateTime.Now;
            dtpToDate.Value = DateTime.Now;
            LoadCategory();
            DataTable dt = expenseService.GetAllExpenseNOFit();
            dgvExpense.DataSource = dt;
        }

        private void LoadCategory()
        {
            DataTable dt = expenseService.GetAllCategory();
            cboCagtegory.DataSource = dt;
            cboCagtegory.DisplayMember = "category_name";
            cboCagtegory.ValueMember = "category_id";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            DateTime? fromDate = dtpFromDate.Value != DateTime.MinValue ? dtpFromDate.Value : (DateTime?)null;
            DateTime? toDate = dtpToDate.Value != DateTime.MinValue ? dtpToDate.Value : (DateTime?)null;
            string person = txtPerson.Text;
            int? categoryId = cboCagtegory.SelectedValue as int?;
            int pageSize = Convert.ToInt32(cboItems.SelectedItem);
            int pageNumber = 1;

            DataTable dt = expenseService.GetAllExpense(fromDate, toDate, person, categoryId, pageSize, pageNumber);
            dgvExpense.DataSource = dt;
            //LoadCategory();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dtpFromDate.ResetText();
            dtpToDate.ResetText();
            txtPerson.Text = string.Empty;
            cboCagtegory.Text = string.Empty;
            cboItems.Text = string.Empty;

            if (dgvExpense.DataSource is DataTable expenseDataTable)
            {
                expenseDataTable.Clear();
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string[] ColumsToSave = { "expense_id", "expense_name", "category_name", "date", "person", "Amount" };
                saveAsPDF(dgvExpense, saveFileDialog1.FileName, ColumsToSave);

            }
        }

        private void saveAsPDF(DataGridView dgv, string filePath, string[] ColumsToSave)
        {
            try
            {
                Document pdfDoc = new Document(PageSize.A4);
                PdfWriter.GetInstance(pdfDoc, new FileStream(filePath, FileMode.Create));
                pdfDoc.Open();

                var selectedColumns = dgv.Columns.Cast<DataGridViewColumn>().Where(col => ColumsToSave.Contains(col.Name)).ToList();

                PdfPTable pdfTable = new PdfPTable(selectedColumns.Count);

                foreach (DataGridViewColumn column in selectedColumns)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                    pdfTable.AddCell(cell);
                }

                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.IsNewRow) continue;

                    foreach (DataGridViewColumn column in selectedColumns)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(row.Cells[column.Index].Value?.ToString() ?? string.Empty));
                        pdfTable.AddCell(cell);
                    }
                }

                pdfDoc.Add(pdfTable);
                pdfDoc.Close();

                MessageBox.Show("PDF file saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: "+ ex.Message,"Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvExpense_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                if (e.RowIndex >= 0 && e.RowIndex < dgvExpense.Rows.Count - 1)
                {
                    var selectedRow = dgvExpense.Rows[e.RowIndex];
                    var expense = new ExpenseEntity
                    {
                        expenseId = Convert.ToInt32(selectedRow.Cells["expense_id"].Value),
                        expenseName = selectedRow.Cells["expense_name"].Value.ToString(),
                        category = selectedRow.Cells["category_id"].Value.ToString(),
                        date = selectedRow.Cells["date"].Value.ToString(),
                        person = selectedRow.Cells["person"].Value.ToString(),
                        Amount = Convert.ToInt32(selectedRow.Cells["Amount"].Value),
                    };

                    UCExpenseCreate ucExpenseCreate = new UCExpenseCreate()
                    {
                        expense = expense,
                    };
                    this.Controls.Clear();
                    this.Controls.Add(ucExpenseCreate);
                }
            }
        }
    }
}
