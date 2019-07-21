using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Print4 : Form
    {
        List<Qury> _Qury;
        List<QuryDetail> _list;
        public Print4(List<Qury> qry, List<QuryDetail> list)
        {
            InitializeComponent();
            _Qury = qry;
            _list = list;
        }

        private void Print4_Load(object sender, EventArgs e)
        {

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
        public List<Qury> GetHead()
        {

            foreach (var InvDe in _Qury)
            {
                Qury qryD = new Qury();
                qryD.Cus_Name = InvDe.Cus_Name.ToString();
                qryD.Cus_Address = InvDe.Cus_Address.ToString();
                qryD.Inv_ThaiPrice = InvDe.Inv_ThaiPrice.ToString();
                qryD.Inv_No = InvDe.Inv_No.ToString();
                qryD.Inv_Date = InvDe.Inv_Date.ToString();
                qryD.User_Name = InvDe.User_Name.ToString();
                qryD.Inv_AmtPrice = InvDe.Inv_AmtPrice.ToString();
                qryD.Inv_SumItem = InvDe.Inv_SumItem.ToString();
                qryD.Inv_SumCount = InvDe.Inv_SumCount.ToString();
                qryD.Inv_SumWeight = InvDe.Inv_SumWeight.ToString();
                _Qury1.Add(qryD);
            }
            return _Qury1;
        }
    }
}
