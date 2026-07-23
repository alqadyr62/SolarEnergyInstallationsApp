namespace OmranApp
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gunaComboBox1 = new Guna.UI.WinForms.GunaComboBox();
            this.gunaLineTextBox1 = new Guna.UI.WinForms.GunaLineTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gunaGradientButton1 = new Guna.UI.WinForms.GunaGradientButton();
            this.gunaGradientButton2 = new Guna.UI.WinForms.GunaGradientButton();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 16.2F);
            this.label1.Location = new System.Drawing.Point(22, 80);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "اسم المستخدم :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 16.2F);
            this.label2.Location = new System.Drawing.Point(32, 139);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "كلمة السر :";
            // 
            // gunaComboBox1
            // 
            this.gunaComboBox1.BackColor = System.Drawing.Color.Transparent;
            this.gunaComboBox1.BaseColor = System.Drawing.Color.White;
            this.gunaComboBox1.BorderColor = System.Drawing.Color.Black;
            this.gunaComboBox1.BorderSize = 0;
            this.gunaComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.gunaComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gunaComboBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gunaComboBox1.FocusedColor = System.Drawing.Color.Empty;
            this.gunaComboBox1.Font = new System.Drawing.Font("Arial", 13.8F);
            this.gunaComboBox1.ForeColor = System.Drawing.Color.Black;
            this.gunaComboBox1.FormattingEnabled = true;
            this.gunaComboBox1.ItemHeight = 30;
            this.gunaComboBox1.Location = new System.Drawing.Point(142, 80);
            this.gunaComboBox1.Margin = new System.Windows.Forms.Padding(2);
            this.gunaComboBox1.Name = "gunaComboBox1";
            this.gunaComboBox1.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.gunaComboBox1.OnHoverItemForeColor = System.Drawing.Color.White;
            this.gunaComboBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gunaComboBox1.Size = new System.Drawing.Size(261, 36);
            this.gunaComboBox1.TabIndex = 1;
            this.gunaComboBox1.SelectedIndexChanged += new System.EventHandler(this.gunaComboBox1_SelectedIndexChanged);
            // 
            // gunaLineTextBox1
            // 
            this.gunaLineTextBox1.BackColor = System.Drawing.SystemColors.Control;
            this.gunaLineTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.gunaLineTextBox1.Enabled = false;
            this.gunaLineTextBox1.FocusedLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(29)))), ((int)(((byte)(56)))));
            this.gunaLineTextBox1.Font = new System.Drawing.Font("Arial", 13.8F);
            this.gunaLineTextBox1.LineColor = System.Drawing.Color.Gainsboro;
            this.gunaLineTextBox1.Location = new System.Drawing.Point(142, 132);
            this.gunaLineTextBox1.Margin = new System.Windows.Forms.Padding(2);
            this.gunaLineTextBox1.Name = "gunaLineTextBox1";
            this.gunaLineTextBox1.PasswordChar = '\0';
            this.gunaLineTextBox1.SelectedText = "";
            this.gunaLineTextBox1.Size = new System.Drawing.Size(261, 32);
            this.gunaLineTextBox1.TabIndex = 2;
            this.gunaLineTextBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gunaLineTextBox1_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.Location = new System.Drawing.Point(22, 22);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(319, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "الرجاء ادخال اسم المستخدم وكلمة المرور :\r\n";
            // 
            // gunaGradientButton1
            // 
            this.gunaGradientButton1.AnimationHoverSpeed = 0.07F;
            this.gunaGradientButton1.AnimationSpeed = 0.03F;
            this.gunaGradientButton1.BackColor = System.Drawing.Color.Transparent;
            this.gunaGradientButton1.BaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(29)))), ((int)(((byte)(56)))));
            this.gunaGradientButton1.BaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(165)))));
            this.gunaGradientButton1.BorderColor = System.Drawing.Color.Black;
            this.gunaGradientButton1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.gunaGradientButton1.FocusedColor = System.Drawing.Color.Empty;
            this.gunaGradientButton1.Font = new System.Drawing.Font("Times New Roman", 16.2F);
            this.gunaGradientButton1.ForeColor = System.Drawing.Color.White;
            this.gunaGradientButton1.Image = ((System.Drawing.Image)(resources.GetObject("gunaGradientButton1.Image")));
            this.gunaGradientButton1.ImageSize = new System.Drawing.Size(40, 40);
            this.gunaGradientButton1.Location = new System.Drawing.Point(27, 227);
            this.gunaGradientButton1.Margin = new System.Windows.Forms.Padding(2);
            this.gunaGradientButton1.Name = "gunaGradientButton1";
            this.gunaGradientButton1.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(29)))), ((int)(((byte)(56)))));
            this.gunaGradientButton1.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(29)))), ((int)(((byte)(56)))));
            this.gunaGradientButton1.OnHoverBorderColor = System.Drawing.Color.Black;
            this.gunaGradientButton1.OnHoverForeColor = System.Drawing.Color.White;
            this.gunaGradientButton1.OnHoverImage = null;
            this.gunaGradientButton1.OnPressedColor = System.Drawing.Color.Black;
            this.gunaGradientButton1.Radius = 10;
            this.gunaGradientButton1.Size = new System.Drawing.Size(138, 44);
            this.gunaGradientButton1.TabIndex = 3;
            this.gunaGradientButton1.Text = "دخول";
            this.gunaGradientButton1.Click += new System.EventHandler(this.gunaGradientButton1_Click);
            // 
            // gunaGradientButton2
            // 
            this.gunaGradientButton2.AnimationHoverSpeed = 0.07F;
            this.gunaGradientButton2.AnimationSpeed = 0.03F;
            this.gunaGradientButton2.BackColor = System.Drawing.Color.Transparent;
            this.gunaGradientButton2.BaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(29)))), ((int)(((byte)(56)))));
            this.gunaGradientButton2.BaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(165)))));
            this.gunaGradientButton2.BorderColor = System.Drawing.Color.Black;
            this.gunaGradientButton2.DialogResult = System.Windows.Forms.DialogResult.None;
            this.gunaGradientButton2.FocusedColor = System.Drawing.Color.Empty;
            this.gunaGradientButton2.Font = new System.Drawing.Font("Times New Roman", 16.2F);
            this.gunaGradientButton2.ForeColor = System.Drawing.Color.White;
            this.gunaGradientButton2.Image = ((System.Drawing.Image)(resources.GetObject("gunaGradientButton2.Image")));
            this.gunaGradientButton2.ImageSize = new System.Drawing.Size(40, 40);
            this.gunaGradientButton2.Location = new System.Drawing.Point(196, 227);
            this.gunaGradientButton2.Margin = new System.Windows.Forms.Padding(2);
            this.gunaGradientButton2.Name = "gunaGradientButton2";
            this.gunaGradientButton2.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(29)))), ((int)(((byte)(56)))));
            this.gunaGradientButton2.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(29)))), ((int)(((byte)(56)))));
            this.gunaGradientButton2.OnHoverBorderColor = System.Drawing.Color.Black;
            this.gunaGradientButton2.OnHoverForeColor = System.Drawing.Color.White;
            this.gunaGradientButton2.OnHoverImage = null;
            this.gunaGradientButton2.OnPressedColor = System.Drawing.Color.Black;
            this.gunaGradientButton2.Radius = 10;
            this.gunaGradientButton2.Size = new System.Drawing.Size(138, 44);
            this.gunaGradientButton2.TabIndex = 4;
            this.gunaGradientButton2.Text = "خروج";
            this.gunaGradientButton2.Click += new System.EventHandler(this.gunaGradientButton2_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Times New Roman", 16.2F);
            this.checkBox1.Location = new System.Drawing.Point(37, 183);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(150, 29);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "اظهار كلمة السر";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel4});
            this.statusStrip1.Location = new System.Drawing.Point(0, 311);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(10, 0, 1, 0);
            this.statusStrip1.Size = new System.Drawing.Size(554, 30);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Times New Roman", 16.2F);
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(72, 25);
            this.toolStripStatusLabel1.Text = "التاريخ :";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Font = new System.Drawing.Font("Times New Roman", 16.2F);
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(202, 25);
            this.toolStripStatusLabel2.Text = "toolStripStatusLabel2";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Font = new System.Drawing.Font("Times New Roman", 16.2F);
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(16, 25);
            this.toolStripStatusLabel3.Text = "|";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Font = new System.Drawing.Font("Times New Roman", 16.2F);
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(184, 25);
            this.toolStripStatusLabel4.Text = "برنامج محاسبة - عمران";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 341);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.gunaGradientButton2);
            this.Controls.Add(this.gunaGradientButton1);
            this.Controls.Add(this.gunaLineTextBox1);
            this.Controls.Add(this.gunaComboBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تسجيل الدخول";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Guna.UI.WinForms.GunaComboBox gunaComboBox1;
        private Guna.UI.WinForms.GunaLineTextBox gunaLineTextBox1;
        private System.Windows.Forms.Label label3;
        private Guna.UI.WinForms.GunaGradientButton gunaGradientButton1;
        private Guna.UI.WinForms.GunaGradientButton gunaGradientButton2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
    }
}

