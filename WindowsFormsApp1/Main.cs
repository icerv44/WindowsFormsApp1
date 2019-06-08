using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Microsoft.Office;
//using Excel = Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;
using DataTable = System.Data.DataTable;
using System.Runtime.InteropServices;


namespace WindowsFormsApp1
{
    public partial class Main : Form
    {

        List<WindowsFormsApp1.Qury> lt_Exc = new List<WindowsFormsApp1.Qury>() ;



        public Main()
        {
            InitializeComponent();
        }

        MySqlConnection con = new MySqlConnection("server = localhost; database = invoice; username = root; password=; ");
        private void Form1_Load(object sender, EventArgs e)
        {
            Qury_Select_Customer();
        }

        private void Panel_Menu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Panel_Main_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button_Retail_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        public void Qury_Select_Customer()
        {
            string query = "SELECT * FROM customer";

            MySqlDataAdapter data = new MySqlDataAdapter(query, con);

            DataTable dt = new DataTable();

            data.Fill(dt);

            dgv1.DataSource = dt;
        }
        public void Qury_Select_Goods()
        {
            string query = "SELECT * FROM Goods";

            MySqlDataAdapter data = new MySqlDataAdapter(query, con);

            DataTable dt = new DataTable();

            data.Fill(dt);

            dgv1.DataSource = dt;
        }
        public void Qury_Insert_Customer()
        {
            string text1 = "";

            text1 = textBox1.Text;

            string query = "INSERT INTO `customer`(`Name`) VALUES ('" + text1 + "')";

            MySqlDataAdapter data = new MySqlDataAdapter(query, con);

            DataTable dt = new DataTable();

            data.Fill(dt);

            Qury_Select_Customer();
        }

       public void Qury_Insert_Goods()
        {
            string text1 = "";

            text1 = textBox1.Text;

            string query = "INSERT INTO `Goods`(`Code`) VALUES ('" + text1 + "')";

            MySqlDataAdapter data = new MySqlDataAdapter(query, con);

            DataTable dt = new DataTable();

            data.Fill(dt);

            Qury_Select_Customer();
        }


        public void GetExcel_Goods()
        {
             string excelFinalPath = @"C:\Users\SoLoRi\Desktop\Excel_Invoice\Goods.xlsx";
             Excel.Application xlApp = new Excel.Application();
             xlApp.DisplayAlerts = false;

             Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(excelFinalPath);
             Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
             Console.WriteLine(xlWorkbook.Sheets[1].name);
             Excel.Range xlRange = xlWorksheet.UsedRange ;


             int rowCount = xlRange.Rows.Count ;
             int colCount = xlRange.Columns.Count;
            try
            {
                for (int z = 2; z <= rowCount; z++)
                {

                    Goods_Code = xlRange.Cells[z, 1].Value2.toString();
                    Goods_Des = xlRange.Cells[z, 2].Value2.toString();
                    Size = xlRange.Cells[z, 3].Value2.toString();
                    Weight = xlRange.Cells[z, 4].Value2.toString();
                    Cost_price = xlRange.Cells[z, 5].Value2.toString();
                    Whole_Price = xlRange.Cells[z, 6].Value2.toString();
                    Retail_Price = xlRange.Cells[z, 7].Value2.toString();
                    Type_Count = xlRange.Cells[z, 8].Value2.toString();
                    Update_Date = DateTime.Now.ToString("{0:G}");




                    Console.WriteLine(Goods_Code + " | " + Goods_Des + " | " + Size + " | " + Weight + " | " + Cost_price + " | " + Whole_Price + " | " + Retail_Price + " | " + Type_Count + " | " + Amount);

                }










                xlWorkbook.Close();

                Marshal.ReleaseComObject(xlRange);

                Marshal.ReleaseComObject(xlWorksheet);

                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);

                GC.Collect();
                GC.WaitForPendingFinalizers();

            }
            catch (Exception e)
            {
                Console.WriteLine("Error : " + e);



                xlWorkbook.Close();
                xlApp.Quit();

                GC.Collect();
                GC.WaitForPendingFinalizers();
            }

            /*
                        Excel.Application oExcelApp = new Excel.Application();
                        object readOnly = false;
                        object isVisible = true;
                        object missing = System.Reflection.Missing.Value;

                        Excel.Workbook oExcelWorkBook = oExcelApp.Workbooks.Open(excelFinalPath,
                                            missing, readOnly,
                                            missing, missing, missing,
                                            missing, missing, missing,
                                            missing, missing, missing,
                                            missing, missing, missing);

                        int numSheets = oExcelWorkBook.Sheets.Count;


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

                        Excel.Worksheet sheet = (Excel.Worksheet)oExcelWorkBook.Sheets[1];
                       // for (int sheetNum = 1; sheetNum < numSheets + 1; sheetNum++)
                       // {


                            //
                            // Take the used range of the sheet. 
                            //
                            Excel.Range excelRange = sheet.UsedRange;
                            int RowCount = excelRange.Rows.Count;
                            int ColumnCount = excelRange.Columns.Count;
                            for (int r = 1; r <= RowCount; r++)
                            {
                                for (int c = 1; c <= ColumnCount; c++)
                                {
                                    dynamic cell = excelRange.Cells[r, c];
                                    try
                                    {
                                        string content = cell.Value2;
                                        if (cell.Locked == true)
                                        {
                                            //string content = cell.Value2;
                                            if (content != null && !content.Trim().Equals(""))
                                            {
                                                //content = content.Trim();
                                                //cell.Value2 = cell.Value2 + " - This is a test";


                                            }
                                        }
                                        if (ColumnCount == 1)
                                        {
                                            Goods_Code = content;
                                        }
                                        else if (ColumnCount == 2)
                                        {
                                            Goods_Des = content;
                                        }
                                        else if (ColumnCount == 3)
                                        {
                                            Size = content;
                                        }
                                        else if (ColumnCount == 4)
                                        {
                                            Weight = Int32.Parse(content);
                                        }
                                        else if (ColumnCount == 5)
                                        {
                                            Cost_price = Int32.Parse(content);
                                        }
                                        else if (ColumnCount == 6)
                                        {
                                            Whole_Price = Int32.Parse(content);
                                        }
                                        else if (ColumnCount == 7)
                                        {
                                            Retail_Price = Int32.Parse(content);
                                        }
                                        else if (ColumnCount == 8)
                                        {
                                            Type_Count = content;
                                        }

                                    }

                                    catch (Exception)
                                    {
                                    // we are using dynamic type for cell variable so
                                    // the variable might not have all the properties we used in our code
                                    oExcelWorkBook.Close();
                                    Marshal.ReleaseComObject(oExcelWorkBook);
                                    Marshal.ReleaseComObject(sheet);

                                    oExcelApp.Application.Quit();
                                    Marshal.ReleaseComObject(oExcelApp);


                                    GC.Collect();
                                    GC.WaitForPendingFinalizers();
                                }
                                    Console.WriteLine(Goods_Code + " | " + Goods_Des + " | " + Size + " | " + Weight + " | " + Cost_price + " | " + Whole_Price + " | " + Retail_Price + " | " + Type_Count + " | " + Amount);

                                }
                            }

                        // }


                        oExcelWorkBook.Close();
                        Marshal.ReleaseComObject(oExcelWorkBook);
                        Marshal.ReleaseComObject(sheet);

                        oExcelApp.Application.Quit();
                        Marshal.ReleaseComObject(oExcelApp);


                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                        /*

                        */

        }


        void button1_Click(object sender, EventArgs e)
        {

            GetExcel_Goods();



        }

        void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
