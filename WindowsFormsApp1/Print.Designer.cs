namespace WindowsFormsApp1
{
    partial class Print
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
            this.components = new System.ComponentModel.Container();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.quryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.invNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cusNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cusAddressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invThaiPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invAmtPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invSumItemDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invSumCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invSumWeightDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quryBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "WindowsFormsApp1.Invoice.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.invNoDataGridViewTextBoxColumn,
            this.cusNameDataGridViewTextBoxColumn,
            this.cusAddressDataGridViewTextBoxColumn,
            this.invDateDataGridViewTextBoxColumn,
            this.userNameDataGridViewTextBoxColumn,
            this.invThaiPriceDataGridViewTextBoxColumn,
            this.invAmtPriceDataGridViewTextBoxColumn,
            this.invSumItemDataGridViewTextBoxColumn,
            this.invSumCountDataGridViewTextBoxColumn,
            this.invSumWeightDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.quryBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(24, 53);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(736, 370);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.Visible = false;
            // 
            // quryBindingSource
            // 
            this.quryBindingSource.DataSource = typeof(WindowsFormsApp1.Qury);
            // 
            // invNoDataGridViewTextBoxColumn
            // 
            this.invNoDataGridViewTextBoxColumn.DataPropertyName = "Inv_No";
            this.invNoDataGridViewTextBoxColumn.HeaderText = "Inv_No";
            this.invNoDataGridViewTextBoxColumn.Name = "invNoDataGridViewTextBoxColumn";
            // 
            // cusNameDataGridViewTextBoxColumn
            // 
            this.cusNameDataGridViewTextBoxColumn.DataPropertyName = "Cus_Name";
            this.cusNameDataGridViewTextBoxColumn.HeaderText = "Cus_Name";
            this.cusNameDataGridViewTextBoxColumn.Name = "cusNameDataGridViewTextBoxColumn";
            // 
            // cusAddressDataGridViewTextBoxColumn
            // 
            this.cusAddressDataGridViewTextBoxColumn.DataPropertyName = "Cus_Address";
            this.cusAddressDataGridViewTextBoxColumn.HeaderText = "Cus_Address";
            this.cusAddressDataGridViewTextBoxColumn.Name = "cusAddressDataGridViewTextBoxColumn";
            // 
            // invDateDataGridViewTextBoxColumn
            // 
            this.invDateDataGridViewTextBoxColumn.DataPropertyName = "Inv_Date";
            this.invDateDataGridViewTextBoxColumn.HeaderText = "Inv_Date";
            this.invDateDataGridViewTextBoxColumn.Name = "invDateDataGridViewTextBoxColumn";
            // 
            // userNameDataGridViewTextBoxColumn
            // 
            this.userNameDataGridViewTextBoxColumn.DataPropertyName = "User_Name";
            this.userNameDataGridViewTextBoxColumn.HeaderText = "User_Name";
            this.userNameDataGridViewTextBoxColumn.Name = "userNameDataGridViewTextBoxColumn";
            // 
            // invThaiPriceDataGridViewTextBoxColumn
            // 
            this.invThaiPriceDataGridViewTextBoxColumn.DataPropertyName = "Inv_ThaiPrice";
            this.invThaiPriceDataGridViewTextBoxColumn.HeaderText = "Inv_ThaiPrice";
            this.invThaiPriceDataGridViewTextBoxColumn.Name = "invThaiPriceDataGridViewTextBoxColumn";
            // 
            // invAmtPriceDataGridViewTextBoxColumn
            // 
            this.invAmtPriceDataGridViewTextBoxColumn.DataPropertyName = "Inv_AmtPrice";
            this.invAmtPriceDataGridViewTextBoxColumn.HeaderText = "Inv_AmtPrice";
            this.invAmtPriceDataGridViewTextBoxColumn.Name = "invAmtPriceDataGridViewTextBoxColumn";
            // 
            // invSumItemDataGridViewTextBoxColumn
            // 
            this.invSumItemDataGridViewTextBoxColumn.DataPropertyName = "Inv_SumItem";
            this.invSumItemDataGridViewTextBoxColumn.HeaderText = "Inv_SumItem";
            this.invSumItemDataGridViewTextBoxColumn.Name = "invSumItemDataGridViewTextBoxColumn";
            // 
            // invSumCountDataGridViewTextBoxColumn
            // 
            this.invSumCountDataGridViewTextBoxColumn.DataPropertyName = "Inv_SumCount";
            this.invSumCountDataGridViewTextBoxColumn.HeaderText = "Inv_SumCount";
            this.invSumCountDataGridViewTextBoxColumn.Name = "invSumCountDataGridViewTextBoxColumn";
            // 
            // invSumWeightDataGridViewTextBoxColumn
            // 
            this.invSumWeightDataGridViewTextBoxColumn.DataPropertyName = "Inv_SumWeight";
            this.invSumWeightDataGridViewTextBoxColumn.HeaderText = "Inv_SumWeight";
            this.invSumWeightDataGridViewTextBoxColumn.Name = "invSumWeightDataGridViewTextBoxColumn";
            // 
            // Print
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Print";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Print";
            this.Load += new System.EventHandler(this.Print_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quryBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn invNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cusNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cusAddressDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn invDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn userNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn invThaiPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn invAmtPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn invSumItemDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn invSumCountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn invSumWeightDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource quryBindingSource;
    }
}