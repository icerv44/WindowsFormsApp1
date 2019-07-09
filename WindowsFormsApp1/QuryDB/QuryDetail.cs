using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
   public class QuryDetail
    {

        public string Goods_Code { get; set; }
        public string Goods_Des { get; set; }
        public string Goods_SumCount { get; set; }
        public string Goods_Price { get; set; }
        public string Goods_Type { get; set; }
        public string Goods_SumPrice { get; set; }
        public string Inv_No { get; set; }

    }
}
