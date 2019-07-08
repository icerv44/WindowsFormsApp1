using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace WindowsFormsApp1
{
    public class Qury
    {
        public string Inv_No { get; set; }
        public string Cus_Name { get; set; }
        public string Cus_Address { get; set; }
        public string Inv_Date { get; set; }
        public string User_Name { get; set; }
        
        public string Inv_ThaiPrice { get; set; }
        public string Inv_AmtPrice { get; set; }
        public string Inv_SumItem { get; set; }
        public string Inv_SumCount { get; set; }
        public string Inv_SumWeight { get; set; }


       
    }
}
