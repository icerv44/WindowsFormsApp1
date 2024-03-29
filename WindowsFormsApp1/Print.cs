﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class Print : Form
    {

        List<Qury> _Qury;
        List<QuryDetail> _list;

        
        OleDbConnection bookConn;
        OleDbCommand oleDbCmd;
        OleDbDataReader mdr;
        String connParam = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Invoice\DB\DB_Invoice.mdb;Persist Security Info=True;User ID=admin";
        public Print(List<Qury> qry , List<QuryDetail> list)
        {
            InitializeComponent();
            _Qury = qry;
            _list = list;
        }

        private void Print_Load(object sender, EventArgs e)
        {
            string invNo = "";

            /*
            foreach (var InvHead in _Qury)
            {
                          
                invNo = InvHead.Inv_No.ToString();
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Cus_Name", InvHead.Cus_Name.ToString()));
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Cus_Address", InvHead.Cus_Address.ToString()));
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Inv_ThaiPrice", InvHead.Inv_ThaiPrice.ToString()));
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Inv_No", InvHead.Inv_No.ToString()));
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Inv_Date", InvHead.Inv_Date.ToString()));
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("User_Name", "User1"));
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Inv_AmtPrice", InvHead.Inv_AmtPrice.ToString()));
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Inv_SumItem", InvHead.Inv_SumItem.ToString()));
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Inv_SumCount", InvHead.Inv_SumCount.ToString()));
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Inv_SumWeight", InvHead.Inv_SumWeight.ToString()));

               
               

            }*/
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Cus_Name", "Name 1"));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Cus_Address", "Address 1"));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Inv_ThaiPrice", " Thai Price"));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Inv_No", "5"));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Inv_Date", "17/07/2019"));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("User_Name", "User1"));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Inv_AmtPrice", "Amt price"));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Inv_SumItem", "Amtprice"));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Inv_SumCount", "Sum Count"));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Inv_SumWeight", "Sum Weight"));

            this.reportViewer1.LocalReport.DataSources[0].Value = GetDetail();
            this.reportViewer1.RefreshReport();

            /* Microsoft.Reporting.WinForms.ReportParameter[] p = new Microsoft.Reporting.WinForms.ReportParameter[]
          {
            new Microsoft.Reporting.WinForms.ReportParameter("Cus_Name", InvHead.Cus_Name.ToString()),
            new Microsoft.Reporting.WinForms.ReportParameter("Cus_Address", InvHead.Cus_Address.ToString()),
            new Microsoft.Reporting.WinForms.ReportParameter("Inv_No", InvHead.Inv_No.ToString()),
            new Microsoft.Reporting.WinForms.ReportParameter("Inv_Date", InvHead.Inv_Date.ToString()),
            new Microsoft.Reporting.WinForms.ReportParameter("User_Name", InvHead.User_Name.ToString()),
           // new Microsoft.Reporting.WinForms.ReportParameter("Cus_Name", _Qury.Cus_Name.ToString()),
          };
             this.reportViewer1.LocalReport.SetParameters(p);*/
            // string query = "SELECT  `Inv_No`, `Goods_Code`, `Goods_Description`, `Amt_Piece`, `Goods_Type`, `Goods_Price`, `Amt_Price` FROM Invoice_Detail WHERE Inv_No = " + Int32.Parse(invNo);
            //nwindConn.Open();
            //  bookConn = new OleDbConnection(connParam);
            // bookConn.Open();
            //SqlConnection nwindConn = new SqlConnection(connParam);


            // SqlCommand selectCMD = new SqlCommand(query, nwindConn);
            //oleDbCmd = new OleDbCommand(query, bookConn);
            //SqlDataAdapter customerDA = new SqlDataAdapter(query, nwindConn);
            //customerDA.SelectCommand = selectCMD;
            // nwindConn.Open();
            //DataSet customerDS = new DataSet();
            //customerDA.Fill(customerDS, "Invoice_Header");
            //nwindConn.Close();

            //   OleDbDataAdapter dAdapter = new OleDbDataAdapter(query, connParam);
            //    DataSet dt = new DataSet();

            //    dAdapter.Fill(dt, "Invoice_Detail");
            //    ReportDataSource datasource = new ReportDataSource("QryDetail_DataSet", dt.Tables[0]);

            /*  mdr = oleDbCmd.ExecuteReader();

              while (mdr.Read())
              {
                  int InvNO = mdr.GetInt32(0) + 1;
                  textBox_RetailNo.Text = InvNO.ToString();


              }*/
            /* try
             {

                 using (DB_InvoiceDataSet db = new DB_InvoiceDataSet())
                 {


                 }
             }
             catch (Exception er)
             {

                 MessageBox.Show("ERROR : " + er);
                 bookConn.Close();
             }
             bookConn.Close();*/

            //this.reportViewer1.LocalReport.DataSources[0].Value = GetDetail();

        }

        List<QuryDetail> _list1 = new List<QuryDetail>();
        public List<QuryDetail> GetDetail()
        {

            foreach (var InvDe in _list)
            {
                QuryDetail qryD = new QuryDetail();
                qryD.Goods_Code = InvDe.Goods_Code.ToString() ;
                qryD.Goods_Des  = InvDe.Goods_Des.ToString();
                qryD.Goods_SumCount = InvDe.Goods_SumCount.ToString();
                qryD.Goods_Price = InvDe.Goods_Price.ToString();
                qryD.Goods_SumPrice = InvDe.Goods_SumPrice.ToString();
                _list1.Add(qryD);
            }
                return _list1;
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void quryBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
