namespace Tutorial4
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            txtId = new TextBox();
            txtName = new TextBox();
            txtNrc = new TextBox();
            txtAge = new TextBox();
            memberDate = new DateTimePicker();
            txtMemberCard = new ComboBox();
            txtEmail = new TextBox();
            txtPhone1 = new TextBox();
            txtPhone2 = new TextBox();
            rdoOther = new RadioButton();
            rdoMale = new RadioButton();
            rdoFemale = new RadioButton();
            pictureBox1 = new PictureBox();
            txtAddress = new RichTextBox();
            dataGridView1 = new DataGridView();
            btnSave = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            label13 = new Label();
            label14 = new Label();
            label15 = new Label();
            label16 = new Label();
            label17 = new Label();
            btnChooseImage = new Button();
            openFileDialog1 = new OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(65, 50);
            label1.Name = "label1";
            label1.Size = new Size(89, 20);
            label1.TabIndex = 0;
            label1.Text = "Customer Id";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(609, 110);
            label2.Name = "label2";
            label2.Size = new Size(74, 20);
            label2.TabIndex = 1;
            label2.Text = "Phone No";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(609, 50);
            label3.Name = "label3";
            label3.Size = new Size(57, 20);
            label3.TabIndex = 2;
            label3.Text = "Gender";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(65, 110);
            label4.Name = "label4";
            label4.Size = new Size(116, 20);
            label4.TabIndex = 3;
            label4.Text = "Customer Name";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(65, 170);
            label5.Name = "label5";
            label5.Size = new Size(62, 20);
            label5.TabIndex = 4;
            label5.Text = "NRC No";
            label5.Click += label5_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(65, 230);
            label6.Name = "label6";
            label6.Size = new Size(94, 20);
            label6.TabIndex = 5;
            label6.Text = "Date of Birth";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(65, 290);
            label7.Name = "label7";
            label7.Size = new Size(36, 20);
            label7.TabIndex = 6;
            label7.Text = "Age";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(65, 350);
            label8.Name = "label8";
            label8.Size = new Size(100, 20);
            label8.TabIndex = 7;
            label8.Text = "Member Card";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(65, 410);
            label9.Name = "label9";
            label9.Size = new Size(46, 20);
            label9.TabIndex = 8;
            label9.Text = "Email";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(609, 170);
            label10.Name = "label10";
            label10.Size = new Size(74, 20);
            label10.TabIndex = 9;
            label10.Text = "Phone No";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(609, 350);
            label11.Name = "label11";
            label11.Size = new Size(62, 20);
            label11.TabIndex = 10;
            label11.Text = "Address";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(609, 230);
            label12.Name = "label12";
            label12.Size = new Size(51, 20);
            label12.TabIndex = 11;
            label12.Text = "Image";
            // 
            // txtId
            // 
            txtId.Enabled = false;
            txtId.Location = new Point(198, 47);
            txtId.Name = "txtId";
            txtId.Size = new Size(215, 27);
            txtId.TabIndex = 12;
            // 
            // txtName
            // 
            txtName.Location = new Point(198, 107);
            txtName.Name = "txtName";
            txtName.Size = new Size(215, 27);
            txtName.TabIndex = 13;
            // 
            // txtNrc
            // 
            txtNrc.Location = new Point(198, 167);
            txtNrc.Name = "txtNrc";
            txtNrc.Size = new Size(215, 27);
            txtNrc.TabIndex = 14;
            txtNrc.TextChanged += textBox3_TextChanged;
            // 
            // txtAge
            // 
            txtAge.Enabled = false;
            txtAge.Location = new Point(198, 287);
            txtAge.Name = "txtAge";
            txtAge.Size = new Size(215, 27);
            txtAge.TabIndex = 15;
            // 
            // memberDate
            // 
            memberDate.Location = new Point(198, 225);
            memberDate.Name = "memberDate";
            memberDate.Size = new Size(215, 27);
            memberDate.TabIndex = 16;
            // 
            // txtMemberCard
            // 
            txtMemberCard.FormattingEnabled = true;
            txtMemberCard.Items.AddRange(new object[] { "Yes", "No" });
            txtMemberCard.Location = new Point(198, 347);
            txtMemberCard.Name = "txtMemberCard";
            txtMemberCard.Size = new Size(215, 28);
            txtMemberCard.TabIndex = 17;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(198, 407);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(215, 27);
            txtEmail.TabIndex = 18;
            // 
            // txtPhone1
            // 
            txtPhone1.Location = new Point(706, 107);
            txtPhone1.Name = "txtPhone1";
            txtPhone1.Size = new Size(215, 27);
            txtPhone1.TabIndex = 19;
            // 
            // txtPhone2
            // 
            txtPhone2.Location = new Point(706, 167);
            txtPhone2.Name = "txtPhone2";
            txtPhone2.Size = new Size(215, 27);
            txtPhone2.TabIndex = 20;
            // 
            // rdoOther
            // 
            rdoOther.AutoSize = true;
            rdoOther.Location = new Point(706, 48);
            rdoOther.Name = "rdoOther";
            rdoOther.Size = new Size(67, 24);
            rdoOther.TabIndex = 22;
            rdoOther.TabStop = true;
            rdoOther.Text = "Other";
            rdoOther.UseVisualStyleBackColor = true;
            // 
            // rdoMale
            // 
            rdoMale.AutoSize = true;
            rdoMale.Location = new Point(786, 48);
            rdoMale.Name = "rdoMale";
            rdoMale.Size = new Size(63, 24);
            rdoMale.TabIndex = 23;
            rdoMale.TabStop = true;
            rdoMale.Text = "Male";
            rdoMale.UseVisualStyleBackColor = true;
            // 
            // rdoFemale
            // 
            rdoFemale.AutoSize = true;
            rdoFemale.Location = new Point(856, 48);
            rdoFemale.Name = "rdoFemale";
            rdoFemale.Size = new Size(78, 24);
            rdoFemale.TabIndex = 24;
            rdoFemale.TabStop = true;
            rdoFemale.Text = "Female";
            rdoFemale.UseVisualStyleBackColor = true;
            rdoFemale.CheckedChanged += radioButton3_CheckedChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(706, 225);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(215, 89);
            pictureBox1.TabIndex = 25;
            pictureBox1.TabStop = false;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(706, 350);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(215, 84);
            txtAddress.TabIndex = 26;
            txtAddress.Text = "";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 502);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1582, 188);
            dataGridView1.TabIndex = 27;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(198, 452);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 28;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(402, 452);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(94, 29);
            btnUpdate.TabIndex = 29;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(616, 452);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 30;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(827, 452);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(94, 29);
            btnClear.TabIndex = 31;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.ForeColor = Color.Red;
            label13.Location = new Point(419, 110);
            label13.Name = "label13";
            label13.Size = new Size(15, 20);
            label13.TabIndex = 32;
            label13.Text = "*";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.ForeColor = Color.Red;
            label14.Location = new Point(419, 170);
            label14.Name = "label14";
            label14.Size = new Size(15, 20);
            label14.TabIndex = 33;
            label14.Text = "*";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.ForeColor = Color.Red;
            label15.Location = new Point(419, 350);
            label15.Name = "label15";
            label15.Size = new Size(15, 20);
            label15.TabIndex = 34;
            label15.Text = "*";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.ForeColor = Color.Red;
            label16.Location = new Point(419, 410);
            label16.Name = "label16";
            label16.Size = new Size(15, 20);
            label16.TabIndex = 35;
            label16.Text = "*";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.ForeColor = Color.Red;
            label17.Location = new Point(937, 110);
            label17.Name = "label17";
            label17.Size = new Size(15, 20);
            label17.TabIndex = 36;
            label17.Text = "*";
            // 
            // btnChooseImage
            // 
            btnChooseImage.Location = new Point(937, 225);
            btnChooseImage.Name = "btnChooseImage";
            btnChooseImage.Size = new Size(94, 29);
            btnChooseImage.TabIndex = 37;
            btnChooseImage.Text = "chooseFile";
            btnChooseImage.UseVisualStyleBackColor = true;
            btnChooseImage.Click += btnChooseImage_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1607, 772);
            Controls.Add(btnChooseImage);
            Controls.Add(label17);
            Controls.Add(label16);
            Controls.Add(label15);
            Controls.Add(label14);
            Controls.Add(label13);
            Controls.Add(btnClear);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnSave);
            Controls.Add(dataGridView1);
            Controls.Add(txtAddress);
            Controls.Add(pictureBox1);
            Controls.Add(rdoFemale);
            Controls.Add(rdoMale);
            Controls.Add(rdoOther);
            Controls.Add(txtPhone2);
            Controls.Add(txtPhone1);
            Controls.Add(txtEmail);
            Controls.Add(txtMemberCard);
            Controls.Add(memberDate);
            Controls.Add(txtAge);
            Controls.Add(txtNrc);
            Controls.Add(txtName);
            Controls.Add(txtId);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private TextBox txtId;
        private TextBox txtName;
        private TextBox txtNrc;
        private TextBox txtAge;
        private DateTimePicker memberDate;
        private ComboBox txtMemberCard;
        private TextBox txtEmail;
        private TextBox txtPhone1;
        private TextBox txtPhone2;
        private RadioButton rdoOther;
        private RadioButton rdoMale;
        private RadioButton rdoFemale;
        private PictureBox pictureBox1;
        private RichTextBox txtAddress;
        private DataGridView dataGridView1;
        private Button btnSave;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label16;
        private Label label17;
        private Button btnChooseImage;
        private OpenFileDialog openFileDialog1;
    }
}
