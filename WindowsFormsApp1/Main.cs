using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.Office;
//using Excel = Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;
using DataTable = System.Data.DataTable;
using System.Runtime.InteropServices;
using Dapper;

namespace WindowsFormsApp1
{
    public partial class Main : Form
    {

        List<QuryDB.Qury> lt_Exc = new List<QuryDB.Qury>() ;
        OleDbConnection bookConn;
        OleDbCommand oleDbCmd;
        OleDbDataReader mdr;
        String connParam = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Invoice\DB\DB_Invoice.mdb;Persist Security Info=True;User ID=admin";
        //String connParam2 = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Invoice\DB\DB_Invoice.mdb;Persist Security Info=True;User ID=admin";
        List<User> _User;
        public Main(List<User> User)
        {
            InitializeComponent();

            _User = User;
        }

        // MySqlConnection con = new MySqlConnection("server = localhost; database = invoice; username = root; password=; charset=utf8");
       
        private void Form1_Load(object sender, EventArgs e)
        {
            Qury_Select_Goods();
            Qury_Select_Customer();
            Qury_Select_StockIn();
            int level = 0;
            foreach(var user in _User)
            {
                level = user.User_Level;
            }

            if(level == 1)
            {
                button_UpdateCustomer.Visible = false;
                button_UpdateGoods.Visible = false;
            }
            //Qury_Select_InvHead();
        }

        private void Panel_Menu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Panel_Main_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button_Retail_Click(object sender, EventArgs e)
        {
            string userName = "";
            foreach (var user in _User)
            {
                userName = user.User_Name;
            }

            Retail re = new Retail(userName) ;
            re.Show();
        }
        private void button_WholeSale_Click(object sender, EventArgs e)
        {
            string userName = "";
            foreach (var user in _User)
            {
                userName = user.User_Name;
            }

            WholeSale wh = new WholeSale(userName);
            wh.Show();
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public void Qury_Select_InvHead()
        {
            string query = "SELECT  `Inv_No`, `Cus_Name`, `Cus_Address`, `Inv_Date`, `User_Name`, `Thai_Price`, `Amt_Price`, `Amt_Items`, `Amt_Count`, `Amt_Weight` FROM Invoice_Header ";
            bookConn = new OleDbConnection(connParam);
            bookConn.Open();
            try
            {
                OleDbDataAdapter dAdapter = new OleDbDataAdapter(query, connParam);
                DataTable dt = new DataTable();

                dAdapter.Fill(dt);
                // dgv_Warehouse.DataSource = dt;
                

            }
            catch (Exception er)
            {

                MessageBox.Show("ERROR : " + er);
                bookConn.Close();
            }
            bookConn.Close();


            /*
            MySqlDataAdapter data = new MySqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            data.Fill(dt);
            dgv_Warehouse.DataSource = dt;*/

        }
        public void Qury_Select_StockIn()
        {
            string query = "SELECT  `StockInv_No`, `Cus_Name`, `Cus_Address`, `Inv_Date`, `User_Name`, `Thai_Price`, `Amt_Price`, `Amt_Items`, `Amt_Count`, `Amt_Weight` FROM StockIn_Header ";
            bookConn = new OleDbConnection(connParam);
            bookConn.Open();
            try
            {
                OleDbDataAdapter dAdapter = new OleDbDataAdapter(query, connParam);
                DataTable dt = new DataTable();

                dAdapter.Fill(dt);
                dgv_StockIn.DataSource = dt;


            }
            catch (Exception er)
            {

                MessageBox.Show("ERROR : " + er);
                bookConn.Close();
            }
            bookConn.Close();


            /*
            MySqlDataAdapter data = new MySqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            data.Fill(dt);
            dgv_Warehouse.DataSource = dt;*/

        }

        public void Qury_Select_InvHead2()
        {
           
            try
            {
             //   using (IDbConnection db = new SqlConnection(Configuration))


            }
            catch (Exception er)
            {

                MessageBox.Show("ERROR : " + er);
                bookConn.Close();
            }
            bookConn.Close();


          
            

        }

        public void Qury_Select_Customer()
        {
            string query = "SELECT * FROM Invoice_Header";
            bookConn = new OleDbConnection(connParam);
            bookConn.Open();
            try
            {
                OleDbDataAdapter dAdapter = new OleDbDataAdapter(query, connParam);
                DataTable dt = new DataTable();

                dAdapter.Fill(dt);
                dgv_Invoice.DataSource = dt;
            }
            catch (Exception er)
            {

                MessageBox.Show("ERROR : " + er);
                bookConn.Close();
            }
            bookConn.Close();

            /*
            MySqlDataAdapter data = new MySqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            data.Fill(dt);
            dgv_Customer.DataSource = dt;*/


        }
        public void Qury_Select_Goods()
        {
            string query = "SELECT  `Goods_CD`, `Goods_Description`, `Goods_Size`, `Goods_Weight`, `Goods_Whole`, `Goods_Retail`, `Goods_Type`, `Goods_Total` FROM [Goods]; ";
            bookConn = new OleDbConnection(connParam);
            bookConn.Open();
            try
            {
                OleDbDataAdapter dAdapter = new OleDbDataAdapter(query, connParam);
                DataTable dt = new DataTable();

                dAdapter.Fill(dt);
                dgv_Warehouse.DataSource = dt;
            }
            catch (Exception er)
            {

                MessageBox.Show("ERROR : " + er);
                bookConn.Close();
            }
            bookConn.Close();


            /*
            MySqlDataAdapter data = new MySqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            data.Fill(dt);
            dgv_Warehouse.DataSource = dt;*/

        }
        public void Qury_Insert_Customer(string Cus_Name, string Cus_CD, string Address,  string Zip, string Tell, string Note, string Update_Date)
        {
           
            string text1 = "";

            text1 = textBox1.Text;

            string query = "INSERT INTO `Customer`( `Cus_CD`, `Cus_Name`, `Cus_Address`, `Cus_Note`) " +
                                  "VALUES ('"+ Cus_CD + "','"+ Cus_Name + "','"+ Address + "','"+  Note  + "')";

            bookConn = new OleDbConnection(connParam);
            oleDbCmd = new OleDbCommand(query, bookConn);
            bookConn.Open();
            try
            {


                //oleDbCmd.Parameters.AddWithValue("@Year", Year.ToString());
                //oleDbCmd.Parameters.AddWithValue("@Inv_No", InvNo);
                oleDbCmd.ExecuteNonQuery();


            }
            catch (Exception er)
            {
                MessageBox.Show("ERROR : " + er);
                bookConn.Close();
            }
            bookConn.Close();

            /*
            MySqlDataAdapter data = new MySqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            data.Fill(dt);*/

            //Qury_Select_Customer();
        }

       public void Qury_Insert_Goods(string Goods_Code, string Goods_Des, string Size, int Weight, int Cost_price, 
                                     int Whole_Price, int Retail_Price, string Type_Count)
        {
            string text1 = "";

            text1 = textBox1.Text;

            string query = "INSERT INTO `goods`( `Goods_CD`, `Goods_Description`, `Goods_Size`, `Goods_Weight`, `Goods_Cost`, `Goods_Whole`, `Goods_Retail`, `Goods_Type`) " +
                                                "VALUES ('"+ Goods_Code +"','"+ Goods_Des + "','"+ Size + "',"+ Weight + ","+ Cost_price +","+ Whole_Price +","+ Retail_Price + 
                                                ",'"+ Type_Count + "')";

            bookConn = new OleDbConnection(connParam);
            oleDbCmd = new OleDbCommand(query, bookConn);
            bookConn.Open();
            try
            {


                //oleDbCmd.Parameters.AddWithValue("@Year", Year.ToString());
                //oleDbCmd.Parameters.AddWithValue("@Inv_No", InvNo);
                oleDbCmd.ExecuteNonQuery();


            }
            catch (Exception er)
            {
                MessageBox.Show("ERROR : " + er);
                bookConn.Close();
            }
            bookConn.Close();




            /*
            MySqlDataAdapter data = new MySqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            data.Fill(dt);*/

            //Qury_Select_Customer();
        }


        public void GetExcel_Goods()
        {
            string excelFinalPath = @"C:\Users\SoLoRi\Desktop\Excel_Invoice\Goods.xlsx";
            Excel.Application xlApp = new Excel.Application();
            xlApp.DisplayAlerts = false;

            Excel.Workbook excelWorkbook = xlApp.Workbooks.Open(excelFinalPath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
            Excel.Sheets excelSheets = excelWorkbook.Worksheets;
            string currentSheet = "Sheet1";
            Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelSheets.get_Item(currentSheet);

            string Goods_Code = "";
            string Goods_Des = "";
            string Size = "";
            int Weight = 0;
            int Cost_price = 0;
            int Whole_Price = 0;
            int Retail_Price = 0;
            string Type_Count = "";
            int Amount = 0;
            string Update_Date = "";

            Excel.Range xlRange = excelWorksheet.UsedRange;



            int rowCount = xlRange.Rows.Count;


            try
            {
                for (int z = 2; z <= rowCount; z++)
                {

                    Goods_Code = ((string)(excelWorksheet.Cells[z, 1] as Excel.Range).Value) == null ? "" : ((string)(excelWorksheet.Cells[z, 1] as Excel.Range).Value);
                    //xlRange.Cells[z, 1].Value2.toString();
                    Goods_Des = ((string)(excelWorksheet.Cells[z, 2] as Excel.Range).Value) == null ? "" : ((string)(excelWorksheet.Cells[z, 2] as Excel.Range).Value);
                    Size = ((string)(excelWorksheet.Cells[z, 3] as Excel.Range).Value) == null ? "" : ((string)(excelWorksheet.Cells[z, 3] as Excel.Range).Value);
                    Weight = Int32.Parse((excelWorksheet.Cells[z, 4] as Excel.Range).Value.ToString()) == 0 ? 0 : Int32.Parse((excelWorksheet.Cells[z, 4] as Excel.Range).Value.ToString());

                    /*
                    Cost_price = ((string)(excelWorksheet.Cells[z, 5] as Excel.Range).Value.ToString()) == null ? 0 : Int32.Parse((excelWorksheet.Cells[z, 5] as Excel.Range).Value.ToString());
                    Whole_Price = ((string)(excelWorksheet.Cells[z, 6] as Excel.Range).Value.ToString()) == null ? 0 : Int32.Parse((excelWorksheet.Cells[z, 6] as Excel.Range).Value.ToString());
                    Retail_Price = ((string)(excelWorksheet.Cells[z, 7] as Excel.Range).Value.ToString()) == null ? 0 : Int32.Parse((excelWorksheet.Cells[z, 7] as Excel.Range).Value.ToString());
                    */

                    Cost_price = Int32.Parse((excelWorksheet.Cells[z, 4] as Excel.Range).Value.ToString()) == 0 ? 0 : Int32.Parse((excelWorksheet.Cells[z, 5] as Excel.Range).Value.ToString());
                    Whole_Price = Int32.Parse((excelWorksheet.Cells[z, 4] as Excel.Range).Value.ToString()) == 0 ? 0 : Int32.Parse((excelWorksheet.Cells[z, 6] as Excel.Range).Value.ToString());
                    Retail_Price = Int32.Parse((excelWorksheet.Cells[z, 4] as Excel.Range).Value.ToString()) == 0 ? 0 : Int32.Parse((excelWorksheet.Cells[z, 7] as Excel.Range).Value.ToString());

                    Type_Count = ((string)(excelWorksheet.Cells[z, 8] as Excel.Range).Value) == null ? "" : ((string)(excelWorksheet.Cells[z, 8] as Excel.Range).Value);
                    Update_Date = DateTime.Now.ToString("u");




                    Console.WriteLine(Goods_Code + " | " + Goods_Des + " | " + Size + " | " + Weight + " | " + Cost_price + " | " + Whole_Price + " | " + Retail_Price + " | " + Type_Count + " | " + Amount+"|"+ Update_Date);

                    Qury_Insert_Goods(Goods_Code, Goods_Des, Size, Weight, Cost_price, Whole_Price, Retail_Price, Type_Count);
                    Qury_Select_Goods();
                }

                

                excelWorkbook.Close();

                Marshal.ReleaseComObject(xlRange);
                //excelWorkbook.Close();
                Marshal.ReleaseComObject(excelWorksheet);

                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);

                GC.Collect();
                GC.WaitForPendingFinalizers();

            }
            catch (Exception e)
            {
                Console.WriteLine("Error : " + e);

                
                Marshal.ReleaseComObject(xlRange);
                //excelWorkbook.Close();
                Marshal.ReleaseComObject(excelWorksheet);

                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);

                GC.Collect();
                GC.WaitForPendingFinalizers();

            }        
        }


        public void GetExcel_Customer()
        {
            string excelFinalPath = @"C:\Users\SoLoRi\Desktop\Excel_Invoice\Costomers.xlsx";
            Excel.Application xlApp = new Excel.Application();
            xlApp.DisplayAlerts = false;

            Excel.Workbook excelWorkbook = xlApp.Workbooks.Open(excelFinalPath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
            Excel.Sheets excelSheets = excelWorkbook.Worksheets;
            string currentSheet = "Sheet1";
            Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelSheets.get_Item(currentSheet);

            string Cus_Name = "";
            string Cus_CD = "";
            string Address = "";
            //string Country = "";         
            string Zip = "";
            string Tell = "";
            string Note = "";
            string Update_Date = "";

            Excel.Range xlRange = excelWorksheet.UsedRange;

            int rowCount = xlRange.Rows.Count;

            try
            {
                for (int z = 2; z <= rowCount; z++)
                {

                    Cus_Name = ((string)(excelWorksheet.Cells[z, 1] as Excel.Range).Value) == null ? "" : ((string)(excelWorksheet.Cells[z, 1] as Excel.Range).Value);
                    //xlRange.Cells[z, 1].Value2.toString();
                    Cus_CD = ((string)(excelWorksheet.Cells[z, 2] as Excel.Range).Value) == null ? "" : ((string)(excelWorksheet.Cells[z, 2] as Excel.Range).Value);
                    Address = ((string)(excelWorksheet.Cells[z, 3] as Excel.Range).Value) == null ? "" : ((string)(excelWorksheet.Cells[z, 3] as Excel.Range).Value);
                    //Country = ((string)(excelWorksheet.Cells[z, 3] as Excel.Range).Value) == null ? "" : ((string)(excelWorksheet.Cells[z, 3] as Excel.Range).Value);
                    //Zip = ((string)(excelWorksheet.Cells[z, 3] as Excel.Range).Value) == null ? "" : ((string)(excelWorksheet.Cells[z, 3] as Excel.Range).Value);
                    //Tell = ((string)(excelWorksheet.Cells[z, 3] as Excel.Range).Value) == null ? "" : ((string)(excelWorksheet.Cells[z, 3] as Excel.Range).Value);
                    Note = ((string)(excelWorksheet.Cells[z, 4] as Excel.Range).Value) == null ? "" : ((string)(excelWorksheet.Cells[z, 3] as Excel.Range).Value);    
                    Update_Date = DateTime.Now.ToString("u");

                    Console.WriteLine(Cus_Name + " | " + Cus_CD + " | " + Address + " | " + Zip + " | " + Tell + " | " + Note + " | " + Update_Date );


                    Qury_Insert_Customer(Cus_Name, Cus_CD, Address, Zip, Tell, Note, Update_Date);
                    Qury_Select_Customer();


                }
                excelWorkbook.Close();

                Marshal.ReleaseComObject(xlRange);
                //excelWorkbook.Close();
                Marshal.ReleaseComObject(excelWorksheet);

                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);

                GC.Collect();
                GC.WaitForPendingFinalizers();

            }
            catch (Exception e)
            {
                Console.WriteLine("Error : " + e);


                Marshal.ReleaseComObject(xlRange);
                //excelWorkbook.Close();
                Marshal.ReleaseComObject(excelWorksheet);

                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);

                GC.Collect();
                GC.WaitForPendingFinalizers();

            }
        }



        void button1_Click(object sender, EventArgs e)
        {

            GetExcel_Goods();
            GetExcel_Customer();


        }

        void button2_Click(object sender, EventArgs e)
        {
            
        }

      

        private void button_StockIn_Click(object sender, EventArgs e)
        {
            StockIn Si = new StockIn();

            Si.Show();
        }

        private void button_UpdateCustomer_Click(object sender, EventArgs e)
        {
            UpdataCustomer Cus = new UpdataCustomer();

            Cus.Show();
        }

        private void button_UpdateGoods_Click(object sender, EventArgs e)
        {
            UpdateGoods Goods = new UpdateGoods();

            Goods.Show();
        }
    }
}
