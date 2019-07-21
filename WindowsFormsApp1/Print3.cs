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
using System.Data.OleDb;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class Print3 : Form
    {
        List<Qury> _Qury;
        List<QuryDetail> _list;
        public Print3(List<Qury> qry, List<QuryDetail> list)
        {
            InitializeComponent();
            _Qury = qry;
            _list = list;
        }

        private void Print3_Load(object sender, EventArgs e)
        {
            /* foreach (var InvHead in _Qury)
             {
                 Microsoft.Reporting.WinForms.ReportParameter[] p = new Microsoft.Reporting.WinForms.ReportParameter[] {

                 new Microsoft.Reporting.WinForms.ReportParameter("Cus_Name", InvHead.Cus_Name.ToString()),
                 new Microsoft.Reporting.WinForms.ReportParameter("Cus_Address", InvHead.Cus_Address.ToString()),
                 new Microsoft.Reporting.WinForms.ReportParameter("Inv_ThaiPrice", InvHead.Inv_ThaiPrice.ToString()),
                 new Microsoft.Reporting.WinForms.ReportParameter("Inv_No", InvHead.Inv_No.ToString()),
                 new Microsoft.Reporting.WinForms.ReportParameter("Inv_Date", InvHead.Inv_Date.ToString()),
                 new Microsoft.Reporting.WinForms.ReportParameter("User_Name", InvHead.User_Name.ToString()),
                 new Microsoft.Reporting.WinForms.ReportParameter("Inv_AmtPrice", InvHead.Inv_AmtPrice.ToString()),
                 new Microsoft.Reporting.WinForms.ReportParameter("Inv_SumItem", InvHead.Inv_SumItem.ToString()),
                 new Microsoft.Reporting.WinForms.ReportParameter("Inv_SumCount", InvHead.Inv_SumCount.ToString()),
                 new Microsoft.Reporting.WinForms.ReportParameter("Inv_SumWeight", InvHead.Inv_SumWeight.ToString())

            };
                 this.reportViewer1.LocalReport.SetParameters(p);
             }*/
           /* try
            {
                foreach (var InvHead in _Qury)
                {
                    this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Cus_Name", InvHead.Cus_Name.ToString()));
                    this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Cus_Address", InvHead.Cus_Address.ToString()));
                    this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Inv_ThaiPrice", InvHead.Inv_ThaiPrice.ToString()));
                    this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Inv_No", InvHead.Inv_No.ToString()));
                    this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Inv_Date", InvHead.Inv_Date.ToString()));
                    this.reportViewer1.LocalReport.SetParameters(new ReportParameter("User_Name", InvHead.User_Name.ToString()));
                    this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Inv_AmtPrice", InvHead.Inv_AmtPrice.ToString()));
                    this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Inv_SumItem", InvHead.Inv_SumItem.ToString()));
                    this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Inv_SumCount", InvHead.Inv_SumCount.ToString()));
                    this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Inv_SumWeight", InvHead.Inv_SumWeight.ToString()));

                }

            }
            catch(Exception ex)
            {
                
                MessageBox.Show("ERROR : " + ex);

            }*/
           

            this.reportViewer1.LocalReport.DataSources[0].Value = GetDetail();
            
            this.reportViewer1.RefreshReport();
        }
        List<QuryDetail> qry = new List<QuryDetail>();
        /* public List<QuryDetail> GetDetail()
         {
             for (int i = 1; i <= 5; i++)
             {
                 QuryDetail qry1 = new QuryDetail();
                 qry1.Goods_Code = "Goods_Code " + i;
                 qry1.Goods_Des = "Goods_Des " + i;
                 qry1.Goods_Price = "Goods_Price " + i;
                 qry1.Goods_SumCount = "Goods_SumCount " + i;
                 qry1.Goods_SumPrice = "Goods_SumPrice " + i;

                 qry.Add(qry1);
             }


             return qry;
         }*/
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
                _list1.Add(qryD);
            }
            return _list1;
        }



    }
}
