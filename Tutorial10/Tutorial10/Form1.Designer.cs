namespace Tutorial10
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges25 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges26 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges27 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges28 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges29 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges30 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges31 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges32 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges33 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges34 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges35 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges36 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            openFileDialog1 = new OpenFileDialog();
            textSender = new Guna.UI2.WinForms.Guna2TextBox();
            textSubject = new Guna.UI2.WinForms.Guna2TextBox();
            textReceiver = new Guna.UI2.WinForms.Guna2TextBox();
            btnChoose = new Guna.UI2.WinForms.Guna2Button();
            btnEmail = new Guna.UI2.WinForms.Guna2GradientButton();
            progressBar = new Guna.UI2.WinForms.Guna2ProgressBar();
            labFileName = new Guna.UI2.WinForms.Guna2HtmlLabel();
            txtRich = new RichTextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(444, 30);
            label1.Name = "label1";
            label1.Size = new Size(147, 31);
            label1.TabIndex = 0;
            label1.Text = "Send Email";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 10.2F);
            label2.Location = new Point(285, 104);
            label2.Name = "label2";
            label2.Size = new Size(49, 21);
            label2.TabIndex = 3;
            label2.Text = "From";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century Gothic", 10.2F);
            label3.Location = new Point(285, 174);
            label3.Name = "label3";
            label3.Size = new Size(29, 21);
            label3.TabIndex = 4;
            label3.Text = "To";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Century Gothic", 10.2F);
            label4.Location = new Point(285, 244);
            label4.Name = "label4";
            label4.Size = new Size(72, 21);
            label4.TabIndex = 5;
            label4.Text = "Subject";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Century Gothic", 10.2F);
            label5.Location = new Point(285, 314);
            label5.Name = "label5";
            label5.Size = new Size(51, 21);
            label5.TabIndex = 6;
            label5.Text = "Body";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.Filter = "All Files (*.*)|*.*";
            openFileDialog1.Title = "Select File to Attach";
            // 
            // textSender
            // 
            textSender.BorderColor = Color.Black;
            textSender.BorderRadius = 10;
            textSender.CustomizableEdges = customizableEdges25;
            textSender.DefaultText = "yeminaung0901@gmail.com";
            textSender.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            textSender.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            textSender.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            textSender.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            textSender.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            textSender.Font = new Font("Segoe UI", 10F);
            textSender.ForeColor = Color.Black;
            textSender.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            textSender.Location = new Point(427, 92);
            textSender.Margin = new Padding(3, 5, 3, 5);
            textSender.Name = "textSender";
            textSender.PasswordChar = '\0';
            textSender.PlaceholderText = "";
            textSender.ReadOnly = true;
            textSender.SelectedText = "";
            textSender.ShadowDecoration.CustomizableEdges = customizableEdges26;
            textSender.Size = new Size(302, 46);
            textSender.TabIndex = 12;
            // 
            // textSubject
            // 
            textSubject.BorderColor = Color.Black;
            textSubject.BorderRadius = 10;
            textSubject.CustomizableEdges = customizableEdges27;
            textSubject.DefaultText = "";
            textSubject.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            textSubject.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            textSubject.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            textSubject.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            textSubject.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            textSubject.Font = new Font("Segoe UI", 10F);
            textSubject.ForeColor = Color.Black;
            textSubject.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            textSubject.Location = new Point(427, 233);
            textSubject.Margin = new Padding(3, 5, 3, 5);
            textSubject.MaxLength = 40;
            textSubject.Name = "textSubject";
            textSubject.PasswordChar = '\0';
            textSubject.PlaceholderText = "";
            textSubject.SelectedText = "";
            textSubject.ShadowDecoration.CustomizableEdges = customizableEdges28;
            textSubject.Size = new Size(302, 46);
            textSubject.TabIndex = 13;
            // 
            // textReceiver
            // 
            textReceiver.BorderColor = Color.Black;
            textReceiver.BorderRadius = 10;
            textReceiver.CustomizableEdges = customizableEdges29;
            textReceiver.DefaultText = "";
            textReceiver.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            textReceiver.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            textReceiver.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            textReceiver.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            textReceiver.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            textReceiver.Font = new Font("Segoe UI", 10F);
            textReceiver.ForeColor = Color.Black;
            textReceiver.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            textReceiver.Location = new Point(427, 161);
            textReceiver.Margin = new Padding(3, 5, 3, 5);
            textReceiver.MaxLength = 40;
            textReceiver.Name = "textReceiver";
            textReceiver.PasswordChar = '\0';
            textReceiver.PlaceholderText = "";
            textReceiver.SelectedText = "";
            textReceiver.ShadowDecoration.CustomizableEdges = customizableEdges30;
            textReceiver.Size = new Size(302, 46);
            textReceiver.TabIndex = 14;
            // 
            // btnChoose
            // 
            btnChoose.BorderRadius = 10;
            btnChoose.CustomizableEdges = customizableEdges31;
            btnChoose.DisabledState.BorderColor = Color.DarkGray;
            btnChoose.DisabledState.CustomBorderColor = Color.DarkGray;
            btnChoose.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnChoose.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnChoose.FillColor = Color.FromArgb(128, 128, 255);
            btnChoose.Font = new Font("Segoe UI", 9F);
            btnChoose.ForeColor = Color.Black;
            btnChoose.Location = new Point(614, 440);
            btnChoose.Name = "btnChoose";
            btnChoose.ShadowDecoration.CustomizableEdges = customizableEdges32;
            btnChoose.Size = new Size(115, 33);
            btnChoose.TabIndex = 15;
            btnChoose.Text = "attach File";
            btnChoose.Click += btnChoose_Click;
            // 
            // btnEmail
            // 
            btnEmail.BorderRadius = 7;
            btnEmail.CustomizableEdges = customizableEdges33;
            btnEmail.DisabledState.BorderColor = Color.DarkGray;
            btnEmail.DisabledState.CustomBorderColor = Color.DarkGray;
            btnEmail.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnEmail.DisabledState.FillColor2 = Color.FromArgb(169, 169, 169);
            btnEmail.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnEmail.Font = new Font("Segoe UI", 9.5F);
            btnEmail.ForeColor = Color.Black;
            btnEmail.Location = new Point(582, 519);
            btnEmail.Name = "btnEmail";
            btnEmail.ShadowDecoration.CustomizableEdges = customizableEdges34;
            btnEmail.Size = new Size(147, 43);
            btnEmail.TabIndex = 16;
            btnEmail.Text = "SendEmail";
            btnEmail.Click += btnEmail_Click;
            // 
            // progressBar
            // 
            progressBar.BorderRadius = 5;
            progressBar.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            progressBar.CustomizableEdges = customizableEdges35;
            progressBar.Location = new Point(427, 488);
            progressBar.Name = "progressBar";
            progressBar.ProgressColor = Color.Orange;
            progressBar.ShadowDecoration.CustomizableEdges = customizableEdges36;
            progressBar.Size = new Size(302, 15);
            progressBar.Style = ProgressBarStyle.Marquee;
            progressBar.TabIndex = 18;
            progressBar.Text = "guna2ProgressBar1";
            progressBar.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // labFileName
            // 
            labFileName.BackColor = Color.Transparent;
            labFileName.Location = new Point(455, 440);
            labFileName.Name = "labFileName";
            labFileName.Size = new Size(3, 2);
            labFileName.TabIndex = 20;
            labFileName.Text = null;
            // 
            // txtRich
            // 
            txtRich.Location = new Point(427, 302);
            txtRich.MaxLength = 10000;
            txtRich.Name = "txtRich";
            txtRich.Size = new Size(302, 120);
            txtRich.TabIndex = 21;
            txtRich.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 245, 240);
            ClientSize = new Size(1115, 597);
            Controls.Add(txtRich);
            Controls.Add(labFileName);
            Controls.Add(progressBar);
            Controls.Add(btnEmail);
            Controls.Add(btnChoose);
            Controls.Add(textReceiver);
            Controls.Add(textSubject);
            Controls.Add(textSender);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            MaximizeBox = false;
            Name = "Form1";
            Text = "Mail";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private OpenFileDialog openFileDialog1;
        private Guna.UI2.WinForms.Guna2TextBox textSender;
        private Guna.UI2.WinForms.Guna2TextBox textSubject;
        private Guna.UI2.WinForms.Guna2TextBox textReceiver;
        private Guna.UI2.WinForms.Guna2Button btnChoose;
        private Guna.UI2.WinForms.Guna2GradientButton btnEmail;
        private Guna.UI2.WinForms.Guna2ProgressBar progressBar;
        private Guna.UI2.WinForms.Guna2HtmlLabel labFileName;
        private RichTextBox txtRich;
    }
}
