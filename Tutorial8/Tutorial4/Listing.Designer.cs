namespace Tutorial4
{
    partial class Listing
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            customer_id = new DataGridViewTextBoxColumn();
            customer_name = new DataGridViewTextBoxColumn();
            photo = new DataGridViewImageColumn();
            nrc_number = new DataGridViewTextBoxColumn();
            gender = new DataGridViewTextBoxColumn();
            dob = new DataGridViewTextBoxColumn();
            email = new DataGridViewTextBoxColumn();
            phone_no_1 = new DataGridViewTextBoxColumn();
            phone_no_2 = new DataGridViewTextBoxColumn();
            address = new DataGridViewTextBoxColumn();
            member_card = new DataGridViewTextBoxColumn();
            password = new DataGridViewTextBoxColumn();
            txtSearch = new TextBox();
            btnSearch = new Button();
            btnNew = new Button();
            btnPrevious = new Button();
            btnNext = new Button();
            btnLast = new Button();
            button1 = new Button();
            saveFileDialog1 = new SaveFileDialog();
            btnFirst = new Button();
            label1 = new Label();
            menuStrip1 = new MenuStrip();
            customerToolStripMenuItem = new ToolStripMenuItem();
            listingToolStripMenuItem = new ToolStripMenuItem();
            listingToolStripMenuItem1 = new ToolStripMenuItem();
            logoutToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { customer_id, customer_name, photo, nrc_number, gender, dob, email, phone_no_1, phone_no_2, address, member_card, password });
            dataGridView1.Location = new Point(93, 165);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1553, 460);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellClick += dataGridView1_CellClick;
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;
            dataGridView1.DataError += dataGridView1_DataError;
            dataGridView1.Click += dataGridView1_Click;
            // 
            // customer_id
            // 
            customer_id.DataPropertyName = "customer_id";
            customer_id.HeaderText = "Customer Id";
            customer_id.MinimumWidth = 6;
            customer_id.Name = "customer_id";
            customer_id.SortMode = DataGridViewColumnSortMode.NotSortable;
            customer_id.Width = 125;
            // 
            // customer_name
            // 
            customer_name.DataPropertyName = "customer_name";
            customer_name.HeaderText = "Name";
            customer_name.MinimumWidth = 6;
            customer_name.Name = "customer_name";
            customer_name.SortMode = DataGridViewColumnSortMode.NotSortable;
            customer_name.Width = 125;
            // 
            // photo
            // 
            photo.DataPropertyName = "photo";
            photo.HeaderText = "Photo";
            photo.MinimumWidth = 6;
            photo.Name = "photo";
            photo.Resizable = DataGridViewTriState.True;
            photo.Width = 125;
            // 
            // nrc_number
            // 
            nrc_number.DataPropertyName = "nrc_number";
            nrc_number.HeaderText = "Nrc";
            nrc_number.MinimumWidth = 6;
            nrc_number.Name = "nrc_number";
            nrc_number.SortMode = DataGridViewColumnSortMode.NotSortable;
            nrc_number.Width = 125;
            // 
            // gender
            // 
            gender.DataPropertyName = "gender";
            gender.HeaderText = "Gender";
            gender.MinimumWidth = 6;
            gender.Name = "gender";
            gender.SortMode = DataGridViewColumnSortMode.NotSortable;
            gender.Width = 125;
            // 
            // dob
            // 
            dob.DataPropertyName = "dob";
            dob.HeaderText = "Date Of Birth";
            dob.MinimumWidth = 6;
            dob.Name = "dob";
            dob.SortMode = DataGridViewColumnSortMode.NotSortable;
            dob.Width = 125;
            // 
            // email
            // 
            email.DataPropertyName = "email";
            email.HeaderText = "Email";
            email.MinimumWidth = 6;
            email.Name = "email";
            email.SortMode = DataGridViewColumnSortMode.NotSortable;
            email.Width = 125;
            // 
            // phone_no_1
            // 
            phone_no_1.DataPropertyName = "phone_no_1";
            phone_no_1.HeaderText = "Phone 1";
            phone_no_1.MinimumWidth = 6;
            phone_no_1.Name = "phone_no_1";
            phone_no_1.SortMode = DataGridViewColumnSortMode.NotSortable;
            phone_no_1.Width = 125;
            // 
            // phone_no_2
            // 
            phone_no_2.DataPropertyName = "phone_no_2";
            phone_no_2.HeaderText = "Phone 2";
            phone_no_2.MinimumWidth = 6;
            phone_no_2.Name = "phone_no_2";
            phone_no_2.SortMode = DataGridViewColumnSortMode.NotSortable;
            phone_no_2.Width = 125;
            // 
            // address
            // 
            address.DataPropertyName = "address";
            address.HeaderText = "Address";
            address.MinimumWidth = 6;
            address.Name = "address";
            address.SortMode = DataGridViewColumnSortMode.NotSortable;
            address.Width = 125;
            // 
            // member_card
            // 
            member_card.DataPropertyName = "member_card";
            member_card.HeaderText = "Member";
            member_card.MinimumWidth = 6;
            member_card.Name = "member_card";
            member_card.SortMode = DataGridViewColumnSortMode.NotSortable;
            member_card.Width = 125;
            // 
            // password
            // 
            password.DataPropertyName = "password";
            password.HeaderText = "Password";
            password.MinimumWidth = 6;
            password.Name = "password";
            password.SortMode = DataGridViewColumnSortMode.NotSortable;
            password.Width = 125;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(642, 110);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(193, 27);
            txtSearch.TabIndex = 1;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(869, 108);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(94, 29);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnNew
            // 
            btnNew.Location = new Point(508, 108);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(94, 29);
            btnNew.TabIndex = 3;
            btnNew.Text = "New";
            btnNew.UseVisualStyleBackColor = true;
            btnNew.Click += btnNew_Click;
            // 
            // btnPrevious
            // 
            btnPrevious.Location = new Point(217, 643);
            btnPrevious.Name = "btnPrevious";
            btnPrevious.Size = new Size(94, 29);
            btnPrevious.TabIndex = 4;
            btnPrevious.Text = "<<previous";
            btnPrevious.UseVisualStyleBackColor = true;
            btnPrevious.Click += btnPrevious_Click;
            // 
            // btnNext
            // 
            btnNext.Location = new Point(346, 643);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(94, 29);
            btnNext.TabIndex = 5;
            btnNext.Text = "next>>";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // btnLast
            // 
            btnLast.Location = new Point(484, 643);
            btnLast.Name = "btnLast";
            btnLast.Size = new Size(94, 29);
            btnLast.TabIndex = 6;
            btnLast.Text = "Last";
            btnLast.UseVisualStyleBackColor = true;
            btnLast.Click += btnLast_Click;
            // 
            // button1
            // 
            button1.Location = new Point(1032, 109);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 7;
            button1.Text = "download";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // saveFileDialog1
            // 
            saveFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx";
            saveFileDialog1.Title = "Save File as Excle";
            // 
            // btnFirst
            // 
            btnFirst.Location = new Point(93, 643);
            btnFirst.Name = "btnFirst";
            btnFirst.Size = new Size(94, 29);
            btnFirst.TabIndex = 8;
            btnFirst.Text = "First";
            btnFirst.UseVisualStyleBackColor = true;
            btnFirst.Click += btnFirst_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(782, 28);
            label1.Name = "label1";
            label1.Size = new Size(126, 21);
            label1.TabIndex = 9;
            label1.Text = "Customer List";
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { customerToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1746, 28);
            menuStrip1.TabIndex = 10;
            menuStrip1.Text = "menuStrip1";
            // 
            // customerToolStripMenuItem
            // 
            customerToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { listingToolStripMenuItem, listingToolStripMenuItem1, logoutToolStripMenuItem });
            customerToolStripMenuItem.Name = "customerToolStripMenuItem";
            customerToolStripMenuItem.Size = new Size(86, 24);
            customerToolStripMenuItem.Text = "Customer";
            // 
            // listingToolStripMenuItem
            // 
            listingToolStripMenuItem.Name = "listingToolStripMenuItem";
            listingToolStripMenuItem.Size = new Size(139, 26);
            listingToolStripMenuItem.Text = "Entry";
            listingToolStripMenuItem.Click += listingToolStripMenuItem_Click;
            // 
            // listingToolStripMenuItem1
            // 
            listingToolStripMenuItem1.Name = "listingToolStripMenuItem1";
            listingToolStripMenuItem1.Size = new Size(139, 26);
            listingToolStripMenuItem1.Text = "Listing";
            listingToolStripMenuItem1.Click += listingToolStripMenuItem1_Click;
            // 
            // logoutToolStripMenuItem
            // 
            logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            logoutToolStripMenuItem.Size = new Size(139, 26);
            logoutToolStripMenuItem.Text = "Logout";
            logoutToolStripMenuItem.Click += logoutToolStripMenuItem_Click;
            // 
            // Listing
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1746, 696);
            Controls.Add(label1);
            Controls.Add(btnFirst);
            Controls.Add(button1);
            Controls.Add(btnLast);
            Controls.Add(btnNext);
            Controls.Add(btnPrevious);
            Controls.Add(btnNew);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(dataGridView1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Listing";
            Text = "Listing";
            Load += Listing_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnNew;
        private Button btnPrevious;
        private Button btnNext;
        private Button btnLast;
        private Button button1;
        private SaveFileDialog saveFileDialog1;
        private Button btnFirst;
        private Label label1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem customerToolStripMenuItem;
        private ToolStripMenuItem listingToolStripMenuItem;
        private ToolStripMenuItem listingToolStripMenuItem1;
        private ToolStripMenuItem logoutToolStripMenuItem;
        private DataGridViewTextBoxColumn customer_id;
        private DataGridViewTextBoxColumn customer_name;
        private DataGridViewImageColumn photo;
        private DataGridViewTextBoxColumn nrc_number;
        private DataGridViewTextBoxColumn gender;
        private DataGridViewTextBoxColumn dob;
        private DataGridViewTextBoxColumn email;
        private DataGridViewTextBoxColumn phone_no_1;
        private DataGridViewTextBoxColumn phone_no_2;
        private DataGridViewTextBoxColumn address;
        private DataGridViewTextBoxColumn member_card;
        private DataGridViewTextBoxColumn password;
    }
}