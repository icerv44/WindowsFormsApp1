namespace WindowsFormsApp1
{
    partial class Main
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
            this.Panel_Menu = new System.Windows.Forms.Panel();
            this.button_StockIn = new System.Windows.Forms.Button();
            this.button_WholeSale = new System.Windows.Forms.Button();
            this.button_Retail = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Print = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.Panel_Menu.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.SuspendLayout();
            // 
            // Panel_Menu
            // 
            this.Panel_Menu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Panel_Menu.AutoSize = true;
            this.Panel_Menu.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Panel_Menu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Panel_Menu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel_Menu.Controls.Add(this.button_StockIn);
            this.Panel_Menu.Controls.Add(this.button_WholeSale);
            this.Panel_Menu.Controls.Add(this.button_Retail);
            this.Panel_Menu.Controls.Add(this.label1);
            this.Panel_Menu.Controls.Add(this.Print);
            this.Panel_Menu.Location = new System.Drawing.Point(11, 10);
            this.Panel_Menu.Margin = new System.Windows.Forms.Padding(2);
            this.Panel_Menu.Name = "Panel_Menu";
            this.Panel_Menu.Size = new System.Drawing.Size(178, 710);
            this.Panel_Menu.TabIndex = 0;
            this.Panel_Menu.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel_Menu_Paint);
            // 
            // button_StockIn
            // 
            this.button_StockIn.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.button_StockIn.Location = new System.Drawing.Point(16, 140);
            this.button_StockIn.Name = "button_StockIn";
            this.button_StockIn.Size = new System.Drawing.Size(147, 39);
            this.button_StockIn.TabIndex = 3;
            this.button_StockIn.Text = "Stock In";
            this.button_StockIn.UseVisualStyleBackColor = false;
            // 
            // button_WholeSale
            // 
            this.button_WholeSale.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.button_WholeSale.Location = new System.Drawing.Point(16, 95);
            this.button_WholeSale.Name = "button_WholeSale";
            this.button_WholeSale.Size = new System.Drawing.Size(147, 39);
            this.button_WholeSale.TabIndex = 2;
            this.button_WholeSale.Text = "WholeSale";
            this.button_WholeSale.UseVisualStyleBackColor = false;
            // 
            // button_Retail
            // 
            this.button_Retail.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.button_Retail.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.button_Retail.FlatAppearance.BorderSize = 3;
            this.button_Retail.Location = new System.Drawing.Point(16, 50);
            this.button_Retail.Name = "button_Retail";
            this.button_Retail.Size = new System.Drawing.Size(147, 39);
            this.button_Retail.TabIndex = 1;
            this.button_Retail.Text = "Retail";
            this.button_Retail.UseVisualStyleBackColor = false;
            this.button_Retail.Click += new System.EventHandler(this.button_Retail_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(62, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "MENU";
            // 
            // Print
            // 
            this.Print.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.Print.Location = new System.Drawing.Point(16, 184);
            this.Print.Margin = new System.Windows.Forms.Padding(2);
            this.Print.Name = "Print";
            this.Print.Size = new System.Drawing.Size(147, 39);
            this.Print.TabIndex = 0;
            this.Print.Text = "Print Receipt";
            this.Print.UseVisualStyleBackColor = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.tabControl1.Location = new System.Drawing.Point(224, 10);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1199, 710);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.dgv1);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1191, 681);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Invoice";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textBox1.Location = new System.Drawing.Point(548, 42);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(428, 42);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(230, 42);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgv1
            // 
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Location = new System.Drawing.Point(6, 80);
            this.dgv1.Name = "dgv1";
            this.dgv1.Size = new System.Drawing.Size(1179, 595);
            this.dgv1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1191, 681);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "WhereHouse";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1191, 681);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "StockIn";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1434, 731);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.Panel_Menu);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Invoice Program";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Panel_Menu.ResumeLayout(false);
            this.Panel_Menu.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel Panel_Menu;
        private System.Windows.Forms.Button Print;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_WholeSale;
        private System.Windows.Forms.Button button_Retail;
        private System.Windows.Forms.Button button_StockIn;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

