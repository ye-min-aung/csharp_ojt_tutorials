namespace OJT.App.Views.Employee
{
    partial class UCEmployeeList
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnTitle = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.dgvEmployeeList = new System.Windows.Forms.DataGridView();
            this.gcJoiningDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gcSalary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gcDesignation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gcAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gcName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gcEmployeeID = new System.Windows.Forms.DataGridViewLinkColumn();
            this.btnDownload = new System.Windows.Forms.Button();
            this.pnTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployeeList)).BeginInit();
            this.SuspendLayout();
            // 
            // pnTitle
            // 
            this.pnTitle.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.pnTitle.Controls.Add(this.lblTitle);
            this.pnTitle.Location = new System.Drawing.Point(0, 0);
            this.pnTitle.Name = "pnTitle";
            this.pnTitle.Size = new System.Drawing.Size(1190, 48);
            this.pnTitle.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(12, 11);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(160, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Employee Listing";
            // 
            // btnAddNew
            // 
            this.btnAddNew.Location = new System.Drawing.Point(15, 60);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(142, 40);
            this.btnAddNew.TabIndex = 1;
            this.btnAddNew.Text = "Add New";
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // dgvEmployeeList
            // 
            this.dgvEmployeeList.AllowUserToAddRows = false;
            this.dgvEmployeeList.AllowUserToResizeColumns = false;
            this.dgvEmployeeList.AllowUserToResizeRows = false;
            this.dgvEmployeeList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployeeList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gcEmployeeID,
            this.gcName,
            this.gcAddress,
            this.gcDesignation,
            this.gcSalary,
            this.gcJoiningDate});
            this.dgvEmployeeList.Location = new System.Drawing.Point(17, 111);
            this.dgvEmployeeList.Name = "dgvEmployeeList";
            this.dgvEmployeeList.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEmployeeList.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvEmployeeList.RowHeadersVisible = false;
            this.dgvEmployeeList.RowHeadersWidth = 51;
            this.dgvEmployeeList.RowTemplate.Height = 24;
            this.dgvEmployeeList.Size = new System.Drawing.Size(1135, 328);
            this.dgvEmployeeList.TabIndex = 2;
            this.dgvEmployeeList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEmployeeList_CellContentClick);
            // 
            // gcJoiningDate
            // 
            this.gcJoiningDate.DataPropertyName = "JoiningDate";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.gcJoiningDate.DefaultCellStyle = dataGridViewCellStyle7;
            this.gcJoiningDate.HeaderText = "JoiningDate";
            this.gcJoiningDate.MinimumWidth = 6;
            this.gcJoiningDate.Name = "gcJoiningDate";
            this.gcJoiningDate.ReadOnly = true;
            this.gcJoiningDate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.gcJoiningDate.Width = 125;
            // 
            // gcSalary
            // 
            this.gcSalary.DataPropertyName = "Salary";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.gcSalary.DefaultCellStyle = dataGridViewCellStyle6;
            this.gcSalary.HeaderText = "Salary";
            this.gcSalary.MinimumWidth = 6;
            this.gcSalary.Name = "gcSalary";
            this.gcSalary.ReadOnly = true;
            this.gcSalary.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.gcSalary.Width = 125;
            // 
            // gcDesignation
            // 
            this.gcDesignation.DataPropertyName = "Designation";
            this.gcDesignation.HeaderText = "Designation";
            this.gcDesignation.MinimumWidth = 6;
            this.gcDesignation.Name = "gcDesignation";
            this.gcDesignation.ReadOnly = true;
            this.gcDesignation.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.gcDesignation.Width = 125;
            // 
            // gcAddress
            // 
            this.gcAddress.DataPropertyName = "Address";
            this.gcAddress.HeaderText = "Address";
            this.gcAddress.MinimumWidth = 6;
            this.gcAddress.Name = "gcAddress";
            this.gcAddress.ReadOnly = true;
            this.gcAddress.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.gcAddress.Width = 125;
            // 
            // gcName
            // 
            this.gcName.DataPropertyName = "Name";
            this.gcName.HeaderText = "Name";
            this.gcName.MinimumWidth = 6;
            this.gcName.Name = "gcName";
            this.gcName.ReadOnly = true;
            this.gcName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.gcName.Width = 125;
            // 
            // gcEmployeeID
            // 
            this.gcEmployeeID.DataPropertyName = "EmployeeId";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.gcEmployeeID.DefaultCellStyle = dataGridViewCellStyle5;
            this.gcEmployeeID.HeaderText = "Employee ID";
            this.gcEmployeeID.MinimumWidth = 6;
            this.gcEmployeeID.Name = "gcEmployeeID";
            this.gcEmployeeID.ReadOnly = true;
            this.gcEmployeeID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.gcEmployeeID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.gcEmployeeID.Width = 125;
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(163, 60);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(142, 40);
            this.btnDownload.TabIndex = 1;
            this.btnDownload.Text = "Download";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // UCEmployeeList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvEmployeeList);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.btnAddNew);
            this.Controls.Add(this.pnTitle);
            this.Name = "UCEmployeeList";
            this.Size = new System.Drawing.Size(1175, 473);
            this.Load += new System.EventHandler(this.UCEmployeeList_Load);
            this.pnTitle.ResumeLayout(false);
            this.pnTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployeeList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.DataGridView dgvEmployeeList;
        private System.Windows.Forms.DataGridViewLinkColumn gcEmployeeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gcName;
        private System.Windows.Forms.DataGridViewTextBoxColumn gcAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn gcDesignation;
        private System.Windows.Forms.DataGridViewTextBoxColumn gcSalary;
        private System.Windows.Forms.DataGridViewTextBoxColumn gcJoiningDate;
        private System.Windows.Forms.Button btnDownload;
    }
}
