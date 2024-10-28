using iTextSharp.text;
using iTextSharp.text.pdf;
using OJT.Entities.Expense;
using OJT.Services.Expense;
using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace OJT.App.Views.Expense
{
    public partial class UCExpenseList : UserControl
    {
        public UCExpenseList()
        {
            InitializeComponent();
        }
        private DataTable initialData;
        private int currentPage = 1;
        private int totalPages = 1;
        private int pageSize = 10;


        ExpenseService expenseService = new ExpenseService();

        private void UCExpenseList_Load(object sender, EventArgs e)
        {
            cboCagtegory.DropDownStyle = ComboBoxStyle.DropDown;
            cboItems.Text = "5";
            dtpFromDate.Value = DateTime.Now;
            dtpToDate.Value = DateTime.Now;
            LoadCategory();
            cboCagtegory.SelectedValue = -1;
            LoadExpenses();
        }

        private void LoadExpenses()
        {
            DateTime? fromDate = dtpFromDate.Value.Date != DateTime.MinValue ? dtpFromDate.Value.Date : (DateTime?)null;
            DateTime? toDate = dtpToDate.Value.Date != DateTime.MinValue ? dtpToDate.Value.Date : (DateTime?)null;
            string person = txtPerson.Text;
            int? categoryId = cboCagtegory.SelectedValue as int?;

            DataTable dt = expenseService.GetAllExpense(fromDate, toDate, person, categoryId, pageSize, currentPage);
            dgvExpense.DataSource = dt;

            int totalCount = expenseService.GetTotalExpensesCount(fromDate, toDate, person, categoryId);
            totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

            UpdatePaginationControls();
        }
        private void UpdatePaginationControls()
        {
            label6.Text = $"page {currentPage} of {totalPages}";
            btnNext.Enabled = currentPage < totalPages;
            btnPrevious.Enabled = currentPage > 1;
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
            currentPage = 1;
            LoadExpenses();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dtpFromDate.ResetText();
            dtpToDate.ResetText();
            txtPerson.Text = string.Empty;
            cboCagtegory.SelectedIndex = -1;

            if (dgvExpense.DataSource is DataTable expenseDataTable)
            {
                expenseDataTable.Clear();
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string[] ColumsToSave = { "expense_name", "category_name", "date", "person", "Amount" };
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
                        object cellValue = row.Cells[column.Index].Value;

                        if (cellValue is DateTime dateTime)
                        {
                            PdfPCell cell = new PdfPCell(new Phrase(dateTime.ToString("dd/MM/yyyy")));
                            pdfTable.AddCell(cell);
                        }
                        else
                        {
                            PdfPCell cell = new PdfPCell(new Phrase(cellValue?.ToString() ?? string.Empty));
                            pdfTable.AddCell(cell);
                        }
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
            if (e.ColumnIndex >= 0)
            {
                if (e.RowIndex >= 0 && e.RowIndex < dgvExpense.Rows.Count)
                {
                    var selectedRow = dgvExpense.Rows[e.RowIndex];

                    string dateString = selectedRow.Cells["date"].Value.ToString();
                    DateTime dateValue;

                    if (DateTime.TryParse(dateString, out dateValue))
                    {
                        var expense = new ExpenseEntity
                        {
                            expenseId = Convert.ToInt32(selectedRow.Cells["expense_id"].Value),
                            expenseName = selectedRow.Cells["expense_name"].Value.ToString(),
                            category = selectedRow.Cells["category_id"].Value.ToString(),
                            date = dateValue,
                            person = selectedRow.Cells["person"].Value.ToString(),
                            Amount = Convert.ToInt64(selectedRow.Cells["Amount"].Value),
                        };

                        UCExpenseCreate ucExpenseCreate = new UCExpenseCreate()
                        {
                            expense = expense,
                        };
                        this.Controls.Clear();
                        this.Controls.Add(ucExpenseCreate);
                    }
                    else
                    {
                        MessageBox.Show("Invalid date format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadExpenses();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;  
                LoadExpenses();
            }
        }

        private void cboItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            pageSize = Convert.ToInt32(cboItems.SelectedItem);
            currentPage = 1;
            LoadExpenses();

        }

        private void dgvExpense_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvExpense.Columns[e.ColumnIndex].Name == "date") 
            {
                if (e.Value != null && e.Value is DateTime dateTimeValue)
                {
                    e.Value = dateTimeValue.ToString("dd/MM/yyyy");
                    e.FormattingApplied = true;
                }
            }
        }
    }
}
