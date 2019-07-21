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
    public partial class Print5 : Form
    {
        List<Qury> _Qury;
        List<QuryDetail> _list;
        public Print5(List<Qury> qry, List<QuryDetail> list)
        {
            InitializeComponent();
            _Qury = qry;
            _list = list;
        }

        private void Print5_Load(object sender, EventArgs e)
        {

            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Cus_Name", "Cus _name123"));
            this.reportViewer1.LocalReport.DataSources[0].Value = GetDetail();


            //this.reportViewer1.LocalReport.DataSources[1].Value = GetHead();
            
           
            this.reportViewer1.RefreshReport();
        }

        List<QuryDetail> _list1 = new List<QuryDetail>();
        List<Qury> _Qury1 = new List<Qury>();
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
