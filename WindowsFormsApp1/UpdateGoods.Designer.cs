namespace WindowsFormsApp1
{
    partial class UpdateGoods
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
            this.button_Update = new System.Windows.Forms.Button();
            this.textBox_GoodsSize = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_GoodsDes = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_GoodsCD = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_GoodsWeight = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_GoodsType = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_GoodsCost = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_GoodsWhole = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_GoodsRetail = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_GoodsTotal = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_Update
            // 
            this.button_Update.Location = new System.Drawing.Point(106, 353);
            this.button_Update.Name = "button_Update";
            this.button_Update.Size = new System.Drawing.Size(115, 32);
            this.button_Update.TabIndex = 14;
            this.button_Update.Text = "Update";
            this.button_Update.UseVisualStyleBackColor = true;
            this.button_Update.Click += new System.EventHandler(this.button_Update_Click);
            // 
            // textBox_GoodsSize
            // 
            this.textBox_GoodsSize.Location = new System.Drawing.Point(170, 93);
            this.textBox_GoodsSize.Name = "textBox_GoodsSize";
            this.textBox_GoodsSize.Size = new System.Drawing.Size(155, 20);
            this.textBox_GoodsSize.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.Location = new System.Drawing.Point(12, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 18);
            this.label4.TabIndex = 12;
            this.label4.Text = "ขนาดสินค้า  : ";
            // 
            // textBox_GoodsDes
            // 
            this.textBox_GoodsDes.Location = new System.Drawing.Point(170, 56);
            this.textBox_GoodsDes.Name = "textBox_GoodsDes";
            this.textBox_GoodsDes.Size = new System.Drawing.Size(155, 20);
            this.textBox_GoodsDes.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(12, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 18);
            this.label2.TabIndex = 10;
            this.label2.Text = "รายการสินค้า     : ";
            // 
            // comboBox_GoodsCD
            // 
            this.comboBox_GoodsCD.FormattingEnabled = true;
            this.comboBox_GoodsCD.Items.AddRange(new object[] {
            "Select Code"});
            this.comboBox_GoodsCD.Location = new System.Drawing.Point(170, 21);
            this.comboBox_GoodsCD.Name = "comboBox_GoodsCD";
            this.comboBox_GoodsCD.Size = new System.Drawing.Size(155, 21);
            this.comboBox_GoodsCD.TabIndex = 8;
            this.comboBox_GoodsCD.Text = "Select Code";
            this.comboBox_GoodsCD.SelectedIndexChanged += new System.EventHandler(this.comboBox_GoodsCD_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 18);
            this.label1.TabIndex = 9;
            this.label1.Text = "รหัสสินค้า     :";
            // 
            // textBox_GoodsWeight
            // 
            this.textBox_GoodsWeight.Location = new System.Drawing.Point(170, 124);
            this.textBox_GoodsWeight.Name = "textBox_GoodsWeight";
            this.textBox_GoodsWeight.Size = new System.Drawing.Size(155, 20);
            this.textBox_GoodsWeight.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.Location = new System.Drawing.Point(12, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 18);
            this.label3.TabIndex = 15;
            this.label3.Text = "น้ำหนักสินค้า  : ";
            // 
            // textBox_GoodsType
            // 
            this.textBox_GoodsType.Location = new System.Drawing.Point(170, 160);
            this.textBox_GoodsType.Name = "textBox_GoodsType";
            this.textBox_GoodsType.Size = new System.Drawing.Size(155, 20);
            this.textBox_GoodsType.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label5.Location = new System.Drawing.Point(12, 159);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 18);
            this.label5.TabIndex = 17;
            this.label5.Text = "ชนิดสินค้า   : ";
            // 
            // textBox_GoodsCost
            // 
            this.textBox_GoodsCost.Location = new System.Drawing.Point(170, 195);
            this.textBox_GoodsCost.Name = "textBox_GoodsCost";
            this.textBox_GoodsCost.Size = new System.Drawing.Size(155, 20);
            this.textBox_GoodsCost.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label6.Location = new System.Drawing.Point(12, 194);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 18);
            this.label6.TabIndex = 19;
            this.label6.Text = "ต้นทุนสินค้า   : ";
            // 
            // textBox_GoodsWhole
            // 
            this.textBox_GoodsWhole.Location = new System.Drawing.Point(170, 231);
            this.textBox_GoodsWhole.Name = "textBox_GoodsWhole";
            this.textBox_GoodsWhole.Size = new System.Drawing.Size(155, 20);
            this.textBox_GoodsWhole.TabIndex = 22;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label7.Location = new System.Drawing.Point(12, 230);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 18);
            this.label7.TabIndex = 21;
            this.label7.Text = "ราคาขายส่ง   : ";
            // 
            // textBox_GoodsRetail
            // 
            this.textBox_GoodsRetail.Location = new System.Drawing.Point(170, 266);
            this.textBox_GoodsRetail.Name = "textBox_GoodsRetail";
            this.textBox_GoodsRetail.Size = new System.Drawing.Size(155, 20);
            this.textBox_GoodsRetail.TabIndex = 24;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label8.Location = new System.Drawing.Point(12, 265);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 18);
            this.label8.TabIndex = 23;
            this.label8.Text = "ราคาขายปลีก   : ";
            // 
            // textBox_GoodsTotal
            // 
            this.textBox_GoodsTotal.Location = new System.Drawing.Point(170, 302);
            this.textBox_GoodsTotal.Name = "textBox_GoodsTotal";
            this.textBox_GoodsTotal.Size = new System.Drawing.Size(155, 20);
            this.textBox_GoodsTotal.TabIndex = 26;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label9.Location = new System.Drawing.Point(12, 301);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(112, 18);
            this.label9.TabIndex = 25;
            this.label9.Text = "จำนวนรวมสินค้า : ";
            // 
            // UpdateGoods
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 428);
            this.Controls.Add(this.textBox_GoodsTotal);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBox_GoodsRetail);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox_GoodsWhole);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox_GoodsCost);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox_GoodsType);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox_GoodsWeight);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button_Update);
            this.Controls.Add(this.textBox_GoodsSize);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_GoodsDes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox_GoodsCD);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "UpdateGoods";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UpdateGoods";
            this.Load += new System.EventHandler(this.UpdateGoods_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Update;
        private System.Windows.Forms.TextBox textBox_GoodsSize;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_GoodsDes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_GoodsCD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_GoodsWeight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_GoodsType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_GoodsCost;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_GoodsWhole;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_GoodsRetail;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox_GoodsTotal;
        private System.Windows.Forms.Label label9;
    }
}