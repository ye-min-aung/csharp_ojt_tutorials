namespace Tutorial3
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
            btnSave = new Button();
            txtId = new TextBox();
            comboBox1 = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            txtName = new TextBox();
            txtNrc = new TextBox();
            txtAge = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            txtEmail = new TextBox();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            btnUpdate = new Button();
            btnClear = new Button();
            btnDelete = new Button();
            rdoOther = new RadioButton();
            rdoMale = new RadioButton();
            rdoFemale = new RadioButton();
            txtPhone1 = new TextBox();
            txtPhone2 = new TextBox();
            txtAddress = new RichTextBox();
            dataGridView1 = new DataGridView();
            openFileDialog1 = new OpenFileDialog();
            pictureBox1 = new PictureBox();
            btnChooseImage = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(36, 33);
            label1.Name = "label1";
            label1.Size = new Size(89, 20);
            label1.TabIndex = 0;
            label1.Text = "Customer Id";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(450, 379);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 1;
            btnSave.Text = "save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // txtId
            // 
            txtId.Location = new Point(143, 30);
            txtId.Name = "txtId";
            txtId.Size = new Size(220, 27);
            txtId.TabIndex = 2;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Yes", "No" });
            comboBox1.Location = new Point(143, 319);
            comboBox1.MaxLength = 10;
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(220, 28);
            comboBox1.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 88);
            label2.Name = "label2";
            label2.Size = new Size(116, 20);
            label2.TabIndex = 4;
            label2.Text = "Customer Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(36, 148);
            label3.Name = "label3";
            label3.Size = new Size(62, 20);
            label3.TabIndex = 5;
            label3.Text = "NRC No";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(36, 206);
            label4.Name = "label4";
            label4.Size = new Size(94, 20);
            label4.TabIndex = 6;
            label4.Text = "Date of Birth";
            label4.Click += label4_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(36, 266);
            label5.Name = "label5";
            label5.Size = new Size(36, 20);
            label5.TabIndex = 7;
            label5.Text = "Age";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(36, 322);
            label6.Name = "label6";
            label6.Size = new Size(100, 20);
            label6.TabIndex = 8;
            label6.Text = "Member Card";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(36, 377);
            label7.Name = "label7";
            label7.Size = new Size(46, 20);
            label7.TabIndex = 9;
            label7.Text = "Email";
            // 
            // txtName
            // 
            txtName.Location = new Point(143, 85);
            txtName.MaxLength = 100;
            txtName.Name = "txtName";
            txtName.Size = new Size(220, 27);
            txtName.TabIndex = 10;
            // 
            // txtNrc
            // 
            txtNrc.Location = new Point(143, 145);
            txtNrc.MaxLength = 20;
            txtNrc.Name = "txtNrc";
            txtNrc.Size = new Size(220, 27);
            txtNrc.TabIndex = 11;
            // 
            // txtAge
            // 
            txtAge.Location = new Point(143, 263);
            txtAge.MaxLength = 100;
            txtAge.Name = "txtAge";
            txtAge.Size = new Size(220, 27);
            txtAge.TabIndex = 12;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(143, 201);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(220, 27);
            dateTimePicker1.TabIndex = 13;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(143, 374);
            txtEmail.MaxLength = 100;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(220, 27);
            txtEmail.TabIndex = 14;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(450, 33);
            label8.Name = "label8";
            label8.Size = new Size(57, 20);
            label8.TabIndex = 15;
            label8.Text = "Gender";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(450, 88);
            label9.Name = "label9";
            label9.Size = new Size(71, 20);
            label9.TabIndex = 16;
            label9.Text = "Phone no";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(450, 148);
            label10.Name = "label10";
            label10.Size = new Size(71, 20);
            label10.TabIndex = 17;
            label10.Text = "Phone no";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(450, 206);
            label11.Name = "label11";
            label11.Size = new Size(51, 20);
            label11.TabIndex = 18;
            label11.Text = "Image";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(450, 310);
            label12.Name = "label12";
            label12.Size = new Size(62, 20);
            label12.TabIndex = 19;
            label12.Text = "Address";
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(592, 379);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(94, 29);
            btnUpdate.TabIndex = 20;
            btnUpdate.Text = "update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(733, 379);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(94, 29);
            btnClear.TabIndex = 21;
            btnClear.Text = "clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(859, 379);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 22;
            btnDelete.Text = "delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // rdoOther
            // 
            rdoOther.AutoSize = true;
            rdoOther.Location = new Point(582, 31);
            rdoOther.Name = "rdoOther";
            rdoOther.Size = new Size(67, 24);
            rdoOther.TabIndex = 23;
            rdoOther.TabStop = true;
            rdoOther.Text = "Other";
            rdoOther.UseVisualStyleBackColor = true;
            rdoOther.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // rdoMale
            // 
            rdoMale.AutoSize = true;
            rdoMale.Location = new Point(669, 31);
            rdoMale.Name = "rdoMale";
            rdoMale.Size = new Size(63, 24);
            rdoMale.TabIndex = 24;
            rdoMale.TabStop = true;
            rdoMale.Text = "Male";
            rdoMale.UseVisualStyleBackColor = true;
            // 
            // rdoFemale
            // 
            rdoFemale.AutoSize = true;
            rdoFemale.Location = new Point(749, 31);
            rdoFemale.Name = "rdoFemale";
            rdoFemale.Size = new Size(78, 24);
            rdoFemale.TabIndex = 25;
            rdoFemale.TabStop = true;
            rdoFemale.Text = "Female";
            rdoFemale.UseVisualStyleBackColor = true;
            // 
            // txtPhone1
            // 
            txtPhone1.Location = new Point(582, 85);
            txtPhone1.MaxLength = 20;
            txtPhone1.Name = "txtPhone1";
            txtPhone1.Size = new Size(225, 27);
            txtPhone1.TabIndex = 26;
            // 
            // txtPhone2
            // 
            txtPhone2.Location = new Point(582, 145);
            txtPhone2.MaxLength = 20;
            txtPhone2.Name = "txtPhone2";
            txtPhone2.Size = new Size(225, 27);
            txtPhone2.TabIndex = 27;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(582, 307);
            txtAddress.MaxLength = 500;
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(225, 55);
            txtAddress.TabIndex = 28;
            txtAddress.Text = "";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(36, 460);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1342, 283);
            dataGridView1.TabIndex = 29;
            dataGridView1.CellClick += dataGridView1_CellClick;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(557, 182);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(150, 108);
            pictureBox1.TabIndex = 30;
            pictureBox1.TabStop = false;
            // 
            // btnChooseImage
            // 
            btnChooseImage.Location = new Point(713, 178);
            btnChooseImage.Name = "btnChooseImage";
            btnChooseImage.Size = new Size(94, 29);
            btnChooseImage.TabIndex = 31;
            btnChooseImage.Text = "choose File";
            btnChooseImage.UseVisualStyleBackColor = true;
            btnChooseImage.Click += btnChooseImage_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1390, 658);
            Controls.Add(btnChooseImage);
            Controls.Add(pictureBox1);
            Controls.Add(dataGridView1);
            Controls.Add(txtAddress);
            Controls.Add(txtPhone2);
            Controls.Add(txtPhone1);
            Controls.Add(rdoFemale);
            Controls.Add(rdoMale);
            Controls.Add(rdoOther);
            Controls.Add(btnDelete);
            Controls.Add(btnClear);
            Controls.Add(btnUpdate);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(txtEmail);
            Controls.Add(dateTimePicker1);
            Controls.Add(txtAge);
            Controls.Add(txtNrc);
            Controls.Add(txtName);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(comboBox1);
            Controls.Add(txtId);
            Controls.Add(btnSave);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnSave;
        private TextBox txtId;
        private ComboBox comboBox1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox txtName;
        private TextBox txtNrc;
        private TextBox txtAge;
        private DateTimePicker dateTimePicker1;
        private TextBox txtEmail;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Button btnUpdate;
        private Button btnClear;
        private Button btnDelete;
        private RadioButton rdoOther;
        private RadioButton rdoMale;
        private RadioButton rdoFemale;
        private TextBox txtPhone1;
        private TextBox txtPhone2;
        private RichTextBox txtAddress;
        private DataGridView dataGridView1;
        private OpenFileDialog openFileDialog1;
        private PictureBox pictureBox1;
        private Button btnChooseImage;
    }
}
