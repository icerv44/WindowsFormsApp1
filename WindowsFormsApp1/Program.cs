using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
   static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            List<Qury> _Qury = new List<Qury>();
            List<QuryDetail> _list = new List<QuryDetail>();
            //Application.Run(new Print7(_Qury, _list));
            //Application.Run(new UpdateGoods());
            //Application.Run(new WholeSale ("User1"));
            //Application.Run(new Main( ));
            Application.Run(new Loadding());
        }
    }
}
