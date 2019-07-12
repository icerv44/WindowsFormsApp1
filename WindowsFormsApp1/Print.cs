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
    public partial class Print : Form
    {

        List<Qury> _Qury;
        List<QuryDetail> _list;
        public Print(List<Qury> qry , List<QuryDetail> list)
        {
            InitializeComponent();
            _Qury = qry;
            _list = list;
        }

        private void Print_Load(object sender, EventArgs e)
        {
            foreach (var InvHead in _Qury)
            {
                Microsoft.Reporting.WinForms.ReportParameter[] p = new Microsoft.Reporting.WinForms.ReportParameter[]
             {
               new Microsoft.Reporting.WinForms.ReportParameter("Cus_Name", InvHead.Cus_Name.ToString()),
               new Microsoft.Reporting.WinForms.ReportParameter("Cus_Address", InvHead.Cus_Address.ToString()),
               new Microsoft.Reporting.WinForms.ReportParameter("Inv_No", InvHead.Inv_No.ToString()),
               new Microsoft.Reporting.WinForms.ReportParameter("Inv_Date", InvHead.Inv_Date.ToString()),
               new Microsoft.Reporting.WinForms.ReportParameter("User_Name", InvHead.User_Name.ToString()),
              // new Microsoft.Reporting.WinForms.ReportParameter("Cus_Name", _Qury.Cus_Name.ToString()),
             };
                this.reportViewer1.LocalReport.SetParameters(p);
                this.reportViewer1.RefreshReport();
            }
              
           
        }
    }
}
