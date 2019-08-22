using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace WindowsFormsApp1
{
    public partial class Print7 : Form
    {
        List<Qury> _Qury;
        List<QuryDetail> _list;
        public Print7(List<Qury> qry, List<QuryDetail> list)
        {
            InitializeComponent();
            _Qury = qry;
            _list = list;
        }

        private void Print7_Load(object sender, EventArgs e)
        {
            QuryDetailBindingSource.DataSource = GetDetail();
            //this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Cus_Name","CusName123"));
             try
             {
                 string inv = "",tmpinv;
                 string Date = "", tmp ;
                 foreach (var InvHead in _Qury)
                 {
                     this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Cus_Name", InvHead.Cus_Name.ToString()));
                     this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Cus_Address", InvHead.Cus_Address.ToString()));
                     this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Inv_ThaiPrice", InvHead.Inv_ThaiPrice.ToString()));

                     inv = InvHead.Inv_No.ToString();
                     Date = InvHead.Inv_Date.ToString();
                     //this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Inv_No", InvHead.Inv_No.ToString()));
                     this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Inv_Date", InvHead.Inv_Date.ToString()));
                     this.reportViewer1.LocalReport.SetParameters(new ReportParameter("User_Name", InvHead.User_Name.ToString()));
                     this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Inv_AmtPrice", InvHead.Inv_AmtPrice.ToString()));
                     this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Inv_SumItem", InvHead.Inv_SumItem.ToString()));
                     this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Inv_SumCount", InvHead.Inv_SumCount.ToString()));
                     this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Inv_SumWeight", InvHead.Inv_SumWeight.ToString()));

                 }
                 tmp = Date.Substring(8, 2);
                 tmpinv = tmp + "/" + inv;
                 this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Inv_No", tmpinv));

             }
             catch (Exception ex)
             {

                 MessageBox.Show("ERROR : " + ex);

             }
           /* this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Cus_Name", "Name"));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Cus_Address", "Name"));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Inv_ThaiPrice", "ThaiPrice"));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Inv_Date", "Date"));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("User_Name", "Name"));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Inv_AmtPrice", "AmtPrice"));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Inv_SumItem", "SumItem"));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Inv_SumCount", "SumCount"));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Inv_SumWeight", "SumWeight"));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Inv_No", "No"));
            */



            this.reportViewer1.RefreshReport();
        }
/*
        List<QuryDetail> qry = new List<QuryDetail>();
        public List<QuryDetail> GetDetail()
        {
            for (int i = 1; i <= 25; i++)
            {
                QuryDetail qry1 = new QuryDetail();
                qry1.Goods_Code = "Code " + i;
                qry1.Goods_Des = "Des " + i;
                qry1.Goods_Price = "Price " + i;
                qry1.Goods_SumCount = "SumCount " + i;
                qry1.Goods_SumPrice = "SumPrice " + i;
                qry1.Goods_Type = "Ty" + i;

                qry.Add(qry1);
            }


            return qry;
        }
 */
        List<QuryDetail> _list1 = new List<QuryDetail>();
        public List<QuryDetail> GetDetail()
        {

            foreach (var InvDe in _list)
            {
                QuryDetail qryD = new QuryDetail();
                qryD.Goods_Code = InvDe.Goods_Code.ToString();
                qryD.Goods_Des = InvDe.Goods_Des.ToString();
                qryD.Goods_SumCount = InvDe.Goods_SumCount.ToString();
                qryD.Goods_Price = InvDe.Goods_Price.ToString();
                qryD.Goods_SumPrice = InvDe.Goods_SumPrice.ToString();
                qryD.Goods_Type = InvDe.Goods_Type.ToString();
                _list1.Add(qryD);
            }
            return _list1;
        }
    }
}
