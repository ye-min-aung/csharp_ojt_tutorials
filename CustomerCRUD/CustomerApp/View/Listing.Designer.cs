namespace CustomerApp.View
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
            label1 = new Label();
            btnNew = new Button();
            txtSearch = new TextBox();
            dataGridView1 = new DataGridView();
            customer_id = new DataGridViewTextBoxColumn();
            customer_name = new DataGridViewTextBoxColumn();
            photo = new DataGridViewTextBoxColumn();
            gender = new DataGridViewTextBoxColumn();
            nrc_number = new DataGridViewTextBoxColumn();
            dob = new DataGridViewTextBoxColumn();
            email = new DataGridViewTextBoxColumn();
            phone_no_1 = new DataGridViewTextBoxColumn();
            phone_no_2 = new DataGridViewTextBoxColumn();
            address = new DataGridViewTextBoxColumn();
            member_card = new DataGridViewTextBoxColumn();
            password = new DataGridViewTextBoxColumn();
            btnSearch = new Button();
            btnFirst = new Button();
            btnPrevious = new Button();
            btnNext = new Button();
            btnLast = new Button();
            menuStrip1 = new MenuStrip();
            customerToolStripMenuItem = new ToolStripMenuItem();
            entryToolStripMenuItem = new ToolStripMenuItem();
            listingToolStripMenuItem = new ToolStripMenuItem();
            logoutToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(687, 13);
            label1.Name = "label1";
            label1.Size = new Size(126, 21);
            label1.TabIndex = 0;
            label1.Text = "Customer List";
            // 
            // btnNew
            // 
            btnNew.Location = new Point(367, 71);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(94, 29);
            btnNew.TabIndex = 1;
            btnNew.Text = "New";
            btnNew.UseVisualStyleBackColor = true;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(485, 73);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(261, 27);
            txtSearch.TabIndex = 2;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { customer_id, customer_name, photo, gender, nrc_number, dob, email, phone_no_1, phone_no_2, address, member_card, password });
            dataGridView1.Location = new Point(25, 138);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1511, 423);
            dataGridView1.TabIndex = 3;
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;
            // 
            // customer_id
            // 
            customer_id.DataPropertyName = "customer_id";
            customer_id.HeaderText = "Customer Id";
            customer_id.MinimumWidth = 6;
            customer_id.Name = "customer_id";
            customer_id.Width = 125;
            // 
            // customer_name
            // 
            customer_name.DataPropertyName = "customer_name";
            customer_name.HeaderText = "customer_name";
            customer_name.MinimumWidth = 6;
            customer_name.Name = "customer_name";
            customer_name.Width = 125;
            // 
            // photo
            // 
            photo.DataPropertyName = "photo";
            photo.HeaderText = "Photo Image";
            photo.MinimumWidth = 6;
            photo.Name = "photo";
            photo.Width = 125;
            // 
            // gender
            // 
            gender.DataPropertyName = "gender";
            gender.HeaderText = "Gender";
            gender.MinimumWidth = 6;
            gender.Name = "gender";
            gender.Width = 125;
            // 
            // nrc_number
            // 
            nrc_number.DataPropertyName = "nrc_number";
            nrc_number.HeaderText = "Nrc Number";
            nrc_number.MinimumWidth = 6;
            nrc_number.Name = "nrc_number";
            nrc_number.Width = 125;
            // 
            // dob
            // 
            dob.DataPropertyName = "dob";
            dob.HeaderText = "Date Of Birth";
            dob.MinimumWidth = 6;
            dob.Name = "dob";
            dob.Width = 125;
            // 
            // email
            // 
            email.DataPropertyName = "email";
            email.HeaderText = "Email";
            email.MinimumWidth = 6;
            email.Name = "email";
            email.Width = 125;
            // 
            // phone_no_1
            // 
            phone_no_1.DataPropertyName = "phone_no_1";
            phone_no_1.HeaderText = "Phone1";
            phone_no_1.MinimumWidth = 6;
            phone_no_1.Name = "phone_no_1";
            phone_no_1.Width = 125;
            // 
            // phone_no_2
            // 
            phone_no_2.DataPropertyName = "phone_no_2";
            phone_no_2.HeaderText = "Phone2";
            phone_no_2.MinimumWidth = 6;
            phone_no_2.Name = "phone_no_2";
            phone_no_2.Width = 125;
            // 
            // address
            // 
            address.DataPropertyName = "address";
            address.HeaderText = "Address";
            address.MinimumWidth = 6;
            address.Name = "address";
            address.Width = 125;
            // 
            // member_card
            // 
            member_card.DataPropertyName = "member_card";
            member_card.HeaderText = "Member";
            member_card.MinimumWidth = 6;
            member_card.Name = "member_card";
            member_card.Width = 125;
            // 
            // password
            // 
            password.DataPropertyName = "password";
            password.HeaderText = "Password";
            password.MinimumWidth = 6;
            password.Name = "password";
            password.Width = 125;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(816, 73);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(94, 29);
            btnSearch.TabIndex = 4;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // btnFirst
            // 
            btnFirst.Location = new Point(100, 599);
            btnFirst.Name = "btnFirst";
            btnFirst.Size = new Size(94, 29);
            btnFirst.TabIndex = 5;
            btnFirst.Text = "First";
            btnFirst.UseVisualStyleBackColor = true;
            // 
            // btnPrevious
            // 
            btnPrevious.Location = new Point(240, 599);
            btnPrevious.Name = "btnPrevious";
            btnPrevious.Size = new Size(94, 29);
            btnPrevious.TabIndex = 6;
            btnPrevious.Text = "<<previous";
            btnPrevious.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            btnNext.Location = new Point(380, 599);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(94, 29);
            btnNext.TabIndex = 7;
            btnNext.Text = "next>>";
            btnNext.UseVisualStyleBackColor = true;
            // 
            // btnLast
            // 
            btnLast.Location = new Point(520, 599);
            btnLast.Name = "btnLast";
            btnLast.Size = new Size(94, 29);
            btnLast.TabIndex = 8;
            btnLast.Text = "Last";
            btnLast.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { customerToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1610, 28);
            menuStrip1.TabIndex = 9;
            menuStrip1.Text = "menuStrip1";
            // 
            // customerToolStripMenuItem
            // 
            customerToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { entryToolStripMenuItem, listingToolStripMenuItem, logoutToolStripMenuItem });
            customerToolStripMenuItem.Name = "customerToolStripMenuItem";
            customerToolStripMenuItem.Size = new Size(86, 24);
            customerToolStripMenuItem.Text = "Customer";
            // 
            // entryToolStripMenuItem
            // 
            entryToolStripMenuItem.Name = "entryToolStripMenuItem";
            entryToolStripMenuItem.Size = new Size(139, 26);
            entryToolStripMenuItem.Text = "Entry";
            // 
            // listingToolStripMenuItem
            // 
            listingToolStripMenuItem.Name = "listingToolStripMenuItem";
            listingToolStripMenuItem.Size = new Size(139, 26);
            listingToolStripMenuItem.Text = "Listing";
            // 
            // logoutToolStripMenuItem
            // 
            logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            logoutToolStripMenuItem.Size = new Size(139, 26);
            logoutToolStripMenuItem.Text = "Logout";
            // 
            // Listing
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1610, 694);
            Controls.Add(btnLast);
            Controls.Add(btnNext);
            Controls.Add(btnPrevious);
            Controls.Add(btnFirst);
            Controls.Add(btnSearch);
            Controls.Add(dataGridView1);
            Controls.Add(txtSearch);
            Controls.Add(btnNew);
            Controls.Add(label1);
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

        private Label label1;
        private Button btnNew;
        private TextBox txtSearch;
        private DataGridView dataGridView1;
        private Button btnSearch;
        private Button btnFirst;
        private Button btnPrevious;
        private Button btnNext;
        private Button btnLast;
        private DataGridViewTextBoxColumn customer_id;
        private DataGridViewTextBoxColumn customer_name;
        private DataGridViewTextBoxColumn photo;
        private DataGridViewTextBoxColumn gender;
        private DataGridViewTextBoxColumn nrc_number;
        private DataGridViewTextBoxColumn dob;
        private DataGridViewTextBoxColumn email;
        private DataGridViewTextBoxColumn phone_no_1;
        private DataGridViewTextBoxColumn phone_no_2;
        private DataGridViewTextBoxColumn address;
        private DataGridViewTextBoxColumn member_card;
        private DataGridViewTextBoxColumn password;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem customerToolStripMenuItem;
        private ToolStripMenuItem entryToolStripMenuItem;
        private ToolStripMenuItem listingToolStripMenuItem;
        private ToolStripMenuItem logoutToolStripMenuItem;
    }
}