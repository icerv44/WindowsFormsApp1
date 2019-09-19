using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql.Data;
using DataTable = System.Data.DataTable;
using System.Data.OleDb;
using System.Data.SqlClient;
using Microsoft.Reporting.WinForms;

namespace WindowsFormsApp1
{
    public partial class Retail : Form
    {
        /*MySqlConnection con = new MySqlConnection("server = localhost; database = invoice; username = root; password=; charset=utf8");
        MySqlCommand command;
        MySqlDataReader mdr;*/

        List<Qury> Inv_QryHead = new List<Qury>();
        List<QuryDetail> Inv_QryDetail = new List<QuryDetail>();
        string userName = "";
        OleDbConnection bookConn;
        OleDbCommand oleDbCmd;
        OleDbDataReader mdr;
        String connParam = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Invoice\DB\DB_Invoice.mdb;Persist Security Info=True;User ID=admin";

        public Retail(string user)
        {
            InitializeComponent();
            userName = user;
        }

        public void SelectInvNo()
        {
            string query = "SELECT max(Inv_No) FROM Invoice_Header";

            bookConn = new OleDbConnection(connParam);
            bookConn.Open();
            try
            {
                oleDbCmd = new OleDbCommand(query, bookConn);

                mdr = oleDbCmd.ExecuteReader();

                while (mdr.Read())
                {
                    int InvNO = mdr.GetInt32(0)+1;

                    textBox_RetailNo.Text = InvNO.ToString();

                    
                }
            }
            catch (Exception er)
            {

                MessageBox.Show("ERROR : " + er);
                bookConn.Close();
            }
            bookConn.Close();

        }

        public void InsertQryInvHeader()
        {


            Qury qry = new Qury();
            qry.Cus_Name = comboBox_Name.Text;
            qry.Cus_Address = textBox_CusAddress.Text;
            qry.Inv_No = textBox_RetailNo.Text;
            qry.Inv_ThaiPrice = textBox_Retail_ThaiPrice.Text;
            qry.Inv_AmtPrice = textBox_Retail_Amount.Text;
            qry.Inv_SumItem = textBox_Retail_SumItem.Text;
            qry.Inv_SumCount = textBox_Retail_SumCount.Text;
            qry.Inv_SumWeight = textBox_Retail_SumWeight.Text;
            qry.Inv_Date = dateTimePickerRetail.Text;
            qry.User_Name = textBox_UserName.Text;
            Inv_QryHead.Add(qry);


        }

        public void InsertQryInvDetail()
        {
            

           // qry.Inv_No = textBox_RetailNo.Text;
            if (combo_Retail_Item1.Text != "Select Item" && combo_Retail_Item1.Text != "")
            {
                QuryDetail qry = new QuryDetail();
                qry.Inv_No = textBox_RetailNo.Text;
                qry.Goods_Code = combo_Retail_Item1.Text;
                qry.Goods_Des = textBox_Retail_item1.Text;
                qry.Goods_SumCount = textBox_Retail_Count1.Text;
                qry.Goods_Type = textBox_Retail_Type1.Text;
                qry.Goods_Price = textBox_Retail_Price1.Text;
                qry.Goods_SumPrice = textBox_Retail_PriceAmount1.Text;
                Inv_QryDetail.Add(qry);
            }
            if (combo_Retail_Item2.Text != "Select Item" && combo_Retail_Item2.Text != "")
            {
                QuryDetail qry = new QuryDetail();
                qry.Inv_No = textBox_RetailNo.Text;
                qry.Goods_Code = combo_Retail_Item2.Text;
                qry.Goods_Des = textBox_Retail_item2.Text;
                qry.Goods_SumCount = textBox_Retail_Count2.Text;
                qry.Goods_Type = textBox_Retail_Type2.Text;
                qry.Goods_Price = textBox_Retail_Price2.Text;
                qry.Goods_SumPrice = textBox_Retail_PriceAmount2.Text;
                Inv_QryDetail.Add(qry);
            }
            if (combo_Retail_Item3.Text != "Select Item" && combo_Retail_Item3.Text != "")
            {
                QuryDetail qry = new QuryDetail();
                qry.Inv_No = textBox_RetailNo.Text;
                qry.Goods_Code = combo_Retail_Item3.Text;
                qry.Goods_Des = textBox_Retail_item3.Text;
                qry.Goods_SumCount = textBox_Retail_Count3.Text;
                qry.Goods_Type = textBox_Retail_Type3.Text;
                qry.Goods_Price = textBox_Retail_Price3.Text;
                qry.Goods_SumPrice = textBox_Retail_PriceAmount3.Text;
                Inv_QryDetail.Add(qry);
            }
            if (combo_Retail_Item4.Text != "Select Item" && combo_Retail_Item4.Text != "")
            {
                QuryDetail qry = new QuryDetail();
                qry.Inv_No = textBox_RetailNo.Text;
                qry.Goods_Code = combo_Retail_Item4.Text;
                qry.Goods_Des = textBox_Retail_item4.Text;
                qry.Goods_SumCount = textBox_Retail_Count4.Text;
                qry.Goods_Type = textBox_Retail_Type4.Text;
                qry.Goods_Price = textBox_Retail_Price4.Text;
                qry.Goods_SumPrice = textBox_Retail_PriceAmount4.Text;
                Inv_QryDetail.Add(qry);
            }
            if (combo_Retail_Item5.Text != "Select Item" && combo_Retail_Item5.Text != "")
            {
                QuryDetail qry = new QuryDetail();
                qry.Inv_No = textBox_RetailNo.Text;
                qry.Goods_Code = combo_Retail_Item5.Text;
                qry.Goods_Des = textBox_Retail_item5.Text;
                qry.Goods_SumCount = textBox_Retail_Count5.Text;
                qry.Goods_Type = textBox_Retail_Type5.Text;
                qry.Goods_Price = textBox_Retail_Price5.Text;
                qry.Goods_SumPrice = textBox_Retail_PriceAmount5.Text;
                Inv_QryDetail.Add(qry);
            }
            if (combo_Retail_Item6.Text != "Select Item" && combo_Retail_Item6.Text != "")
            {
                QuryDetail qry = new QuryDetail();
                qry.Inv_No = textBox_RetailNo.Text;
                qry.Goods_Code = combo_Retail_Item6.Text;
                qry.Goods_Des = textBox_Retail_item6.Text;
                qry.Goods_SumCount = textBox_Retail_Count6.Text;
                qry.Goods_Type = textBox_Retail_Type6.Text;
                qry.Goods_Price = textBox_Retail_Price6.Text;
                qry.Goods_SumPrice = textBox_Retail_PriceAmount6.Text;
                Inv_QryDetail.Add(qry);
            }
            if (combo_Retail_Item7.Text != "Select Item" && combo_Retail_Item7.Text != "")
            {
                QuryDetail qry = new QuryDetail();
                qry.Inv_No = textBox_RetailNo.Text;
                qry.Goods_Code = combo_Retail_Item7.Text;
                qry.Goods_Des = textBox_Retail_item7.Text;
                qry.Goods_SumCount = textBox_Retail_Count7.Text;
                qry.Goods_Type = textBox_Retail_Type7.Text;
                qry.Goods_Price = textBox_Retail_Price7.Text;
                qry.Goods_SumPrice = textBox_Retail_PriceAmount7.Text;
                Inv_QryDetail.Add(qry);
            }
            if (combo_Retail_Item8.Text != "Select Item" && combo_Retail_Item8.Text != "")
            {
                QuryDetail qry = new QuryDetail();
                qry.Inv_No = textBox_RetailNo.Text;
                qry.Goods_Code = combo_Retail_Item8.Text;
                qry.Goods_Des = textBox_Retail_item8.Text;
                qry.Goods_SumCount = textBox_Retail_Count8.Text;
                qry.Goods_Type = textBox_Retail_Type8.Text;
                qry.Goods_Price = textBox_Retail_Price8.Text;
                qry.Goods_SumPrice = textBox_Retail_PriceAmount8.Text;
                Inv_QryDetail.Add(qry);
            }
            if (combo_Retail_Item9.Text != "Select Item" && combo_Retail_Item9.Text != "")
            {
                QuryDetail qry = new QuryDetail();
                qry.Inv_No = textBox_RetailNo.Text;
                qry.Goods_Code = combo_Retail_Item9.Text;
                qry.Goods_Des = textBox_Retail_item9.Text;
                qry.Goods_SumCount = textBox_Retail_Count9.Text;
                qry.Goods_Type = textBox_Retail_Type9.Text;
                qry.Goods_Price = textBox_Retail_Price9.Text;
                qry.Goods_SumPrice = textBox_Retail_PriceAmount9.Text;
                Inv_QryDetail.Add(qry);
            }
            if (combo_Retail_Item10.Text != "Select Item" && combo_Retail_Item10.Text != "")
            {
                QuryDetail qry = new QuryDetail();
                qry.Inv_No = textBox_RetailNo.Text;
                qry.Goods_Code = combo_Retail_Item10.Text;
                qry.Goods_Des = textBox_Retail_item10.Text;
                qry.Goods_SumCount = textBox_Retail_Count10.Text;
                qry.Goods_Type = textBox_Retail_Type10.Text;
                qry.Goods_Price = textBox_Retail_Price10.Text;
                qry.Goods_SumPrice = textBox_Retail_PriceAmount10.Text;
                Inv_QryDetail.Add(qry);
            }
            if (combo_Retail_Item11.Text != "Select Item" && combo_Retail_Item11.Text != "")
            {
                QuryDetail qry = new QuryDetail();
                qry.Inv_No = textBox_RetailNo.Text;
                qry.Goods_Code = combo_Retail_Item11.Text;
                qry.Goods_Des = textBox_Retail_item11.Text;
                qry.Goods_SumCount = textBox_Retail_Count11.Text;
                qry.Goods_Type = textBox_Retail_Type11.Text;
                qry.Goods_Price = textBox_Retail_Price11.Text;
                qry.Goods_SumPrice = textBox_Retail_PriceAmount11.Text;
                Inv_QryDetail.Add(qry);
            }
            if (combo_Retail_Item12.Text != "Select Item" && combo_Retail_Item12.Text != "")
            {
                QuryDetail qry = new QuryDetail();
                qry.Inv_No = textBox_RetailNo.Text;
                qry.Goods_Code = combo_Retail_Item12.Text;
                qry.Goods_Des = textBox_Retail_item12.Text;
                qry.Goods_SumCount = textBox_Retail_Count12.Text;
                qry.Goods_Type = textBox_Retail_Type12.Text;
                qry.Goods_Price = textBox_Retail_Price12.Text;
                qry.Goods_SumPrice = textBox_Retail_PriceAmount12.Text;
                Inv_QryDetail.Add(qry);
            }
            if (combo_Retail_Item13.Text != "Select Item" && combo_Retail_Item13.Text != "")
            {
                QuryDetail qry = new QuryDetail();
                qry.Inv_No = textBox_RetailNo.Text;
                qry.Goods_Code = combo_Retail_Item13.Text;
                qry.Goods_Des = textBox_Retail_item13.Text;
                qry.Goods_SumCount = textBox_Retail_Count13.Text;
                qry.Goods_Type = textBox_Retail_Type13.Text;
                qry.Goods_Price = textBox_Retail_Price13.Text;
                qry.Goods_SumPrice = textBox_Retail_PriceAmount13.Text;
                Inv_QryDetail.Add(qry);
            }
            if (combo_Retail_Item14.Text != "Select Item" && combo_Retail_Item14.Text != "")
            {
                QuryDetail qry = new QuryDetail();
                qry.Inv_No = textBox_RetailNo.Text;
                qry.Goods_Code = combo_Retail_Item14.Text;
                qry.Goods_Des = textBox_Retail_item14.Text;
                qry.Goods_SumCount = textBox_Retail_Count14.Text;
                qry.Goods_Type = textBox_Retail_Type14.Text;
                qry.Goods_Price = textBox_Retail_Price14.Text;
                qry.Goods_SumPrice = textBox_Retail_PriceAmount14.Text;
                Inv_QryDetail.Add(qry);
            }
            if (combo_Retail_Item15.Text != "Select Item" && combo_Retail_Item15.Text != "")
            {
                QuryDetail qry = new QuryDetail();
                qry.Inv_No = textBox_RetailNo.Text;
                qry.Goods_Code = combo_Retail_Item15.Text;
                qry.Goods_Des = textBox_Retail_item15.Text;
                qry.Goods_SumCount = textBox_Retail_Count15.Text;
                qry.Goods_Type = textBox_Retail_Type15.Text;
                qry.Goods_Price = textBox_Retail_Price15.Text;
                qry.Goods_SumPrice = textBox_Retail_PriceAmount15.Text;
                Inv_QryDetail.Add(qry);
            }


            Console.WriteLine("");

        }

        public void InsertINV()
        {
            string query = "";
            try
            {


                 foreach (var InvHead in Inv_QryHead)
                 {
                     Console.WriteLine("Inv No :" + InvHead.Inv_No);
                     Console.WriteLine("Cus Name :" + InvHead.Cus_Name);
                     Console.WriteLine("Cus address :" + InvHead.Cus_Address);
                     Console.WriteLine("Date :" + InvHead.Inv_Date);
                     Console.WriteLine("User :" + InvHead.User_Name);
                     Console.WriteLine("Thai Price :" + InvHead.Inv_ThaiPrice);
                     Console.WriteLine("Total Price :" + InvHead.Inv_AmtPrice);
                     Console.WriteLine("Sum Item :" + InvHead.Inv_SumItem);
                     Console.WriteLine("Sum Count :" + InvHead.Inv_SumCount);
                     Console.WriteLine("Sum Weight :" + InvHead.Inv_SumWeight);

                     query = "INSERT INTO `Invoice_Header`( `Inv_No`, `Cus_Name`, `Cus_Address`, `Inv_Date`, `User_Name`, `Thai_Price`, `Amt_Price`, `Amt_Items`, `Amt_Count`, `Amt_Weight`) " +
                                   "VALUES ('" + InvHead.Inv_No + "','" + InvHead.Cus_Name + "','" + InvHead.Cus_Address + "','" + InvHead.Inv_Date + "','" + InvHead.User_Name + "','" 
                                   + InvHead.Inv_ThaiPrice + "','" + InvHead.Inv_AmtPrice + "','" + InvHead.Inv_SumItem + "','" + InvHead.Inv_SumCount + "','" + InvHead.Inv_SumWeight + "')";

                    bookConn = new OleDbConnection(connParam);
                    oleDbCmd = new OleDbCommand(query, bookConn);
                    bookConn.Open();
                    oleDbCmd.ExecuteNonQuery();
                }

               /* query = "INSERT INTO `Invoice_Header`( `Inv_No`, `Cus_Name`, `Cus_Address`, `Inv_Date`, `User_Name`, `Thai_Price`, `Amt_Price`, `Amt_Items`, `Amt_Count`, `Amt_Weight`) " +
                                 "VALUES ('" + Inv_QryHead.Inv_No + "','" + Inv_QryHead.Cus_Name + "','" + Inv_QryHead.Cus_Address + "','" + Inv_QryHead.Inv_Date + "','" + Inv_QryHead.User_Name + "','"
                                 + Inv_QryHead.Inv_ThaiPrice + "','" + Inv_QryHead.Inv_AmtPrice + "','" + Inv_QryHead.Inv_SumItem + "','" + Inv_QryHead.Inv_SumCount + "','" + Inv_QryHead.Inv_SumWeight + "')";
*/
               
            }
            catch(Exception er)
            {
                MessageBox.Show("Error : " + er);
                bookConn.Close();
            }
            bookConn.Close();
        }

        public void InsertINVDetail()
        {
            try
            {
                foreach (var InvDetail in Inv_QryDetail)
                {
                    Console.WriteLine("ItemCD  : " + InvDetail.Goods_Code + " DesCrip : " + InvDetail.Goods_Des + " Count : " + InvDetail.Goods_SumCount +
                                      " Type : " + InvDetail.Goods_Type + " Price : " + InvDetail.Goods_Price + " SumPrice : " + InvDetail.Goods_SumPrice);

                  string query = "INSERT INTO `Invoice_Detail`( `Inv_No`, `Goods_Code`, `Goods_Description`, `Amt_Piece`, `Goods_Type`, `Goods_Price`, `Amt_Price`) " +
                                 "VALUES ('" + InvDetail.Inv_No + "','" + InvDetail.Goods_Code + "','" + InvDetail.Goods_Des + "','" + InvDetail.Goods_SumCount + "','" + InvDetail.Goods_Type 
                                 + "','"+ InvDetail.Goods_Price + "','" + InvDetail.Goods_SumPrice + "')";


                    bookConn = new OleDbConnection(connParam);
                    oleDbCmd = new OleDbCommand(query, bookConn);
                    bookConn.Open();
                    oleDbCmd.ExecuteNonQuery();
                }
            }
            catch (Exception er)
            {
                MessageBox.Show("Error : " + er);
                bookConn.Close();
            }
            bookConn.Close();

        }




       // List<Qury> Inv_Qry = new List<Qury>();
       /*public void Set_InvHead()
       {
           string query = "SELECT  `Inv_No`, `Cus_CD`, `Date`, `User_ID`, `Amt_Price`, `Amt_Goods`, `Amt_Piece`, `Amt_Weight` FROM `invoice_hearder` ";
           con.Open();
           command = new MySqlCommand(query, con);
           mdr = command.ExecuteReader();

           Qury qry = new Qury() ;
           while (mdr.Read())
           {
               qry.Inv_No = mdr.GetString("Inv_No");
               qry.Cus_Name = mdr.GetString("Cus_CD");
               qry.Inv_Date = mdr.GetString("Date");
               qry.User_Name = mdr.GetString("User_ID");
               qry.Inv_AmtPrice = mdr.GetString("Amt_Price");
               qry.Inv_SumItem = mdr.GetString("Amt_Goods");
               qry.Inv_SumCount = mdr.GetString("Amt_Piece");
               qry.Inv_SumWeight = mdr.GetString("Amt_Weight");


           }


           }*/

        public void FillCombobox()
        { 
            string query = "SELECT Cus_Name FROM customer";

            bookConn = new OleDbConnection(connParam);
            bookConn.Open();
            try
            {
                oleDbCmd = new OleDbCommand(query, bookConn);

                mdr = oleDbCmd.ExecuteReader();

                while (mdr.Read())
                {
                    comboBox_Name.Items.Add(mdr.GetString(0));
                }
            }
            catch (Exception er)
            {

                MessageBox.Show("ERROR : " + er);
                bookConn.Close();
            }
            bookConn.Close();
            /*
                        try
                        {

                            con.Open();
                            command = new MySqlCommand(query, con);
                            mdr = command.ExecuteReader();

                            while (mdr.Read())
                            {
                                comboBox_Name.Items.Add(mdr.GetString("Name"));
                            }
                        }
                        catch (Exception er)
                        {
                            Console.WriteLine("ERROR : " + er);
                        }
                        finally
                        {
                            con.Close();
                            con.Dispose();
                        }*/
        }
        public void FillComboboxItem()
        {
            string query = "SELECT `Goods_CD` FROM `goods`";

            bookConn = new OleDbConnection(connParam);
            bookConn.Open();
            try
            {
                oleDbCmd = new OleDbCommand(query, bookConn);

                mdr = oleDbCmd.ExecuteReader();

                while (mdr.Read())
                {
                    combo_Retail_Item1.Items.Add(mdr.GetString(0));
                    combo_Retail_Item2.Items.Add(mdr.GetString(0));
                    combo_Retail_Item3.Items.Add(mdr.GetString(0));
                    combo_Retail_Item4.Items.Add(mdr.GetString(0));
                    combo_Retail_Item5.Items.Add(mdr.GetString(0));
                    combo_Retail_Item6.Items.Add(mdr.GetString(0));
                    combo_Retail_Item7.Items.Add(mdr.GetString(0));
                    combo_Retail_Item8.Items.Add(mdr.GetString(0));
                    combo_Retail_Item9.Items.Add(mdr.GetString(0));
                    combo_Retail_Item10.Items.Add(mdr.GetString(0));
                    combo_Retail_Item11.Items.Add(mdr.GetString(0));
                    combo_Retail_Item12.Items.Add(mdr.GetString(0));
                    combo_Retail_Item13.Items.Add(mdr.GetString(0));
                    combo_Retail_Item14.Items.Add(mdr.GetString(0));
                    combo_Retail_Item15.Items.Add(mdr.GetString(0));
                }
            }
            catch (Exception er)
            {

                MessageBox.Show("ERROR : " + er);
                bookConn.Close();
            }
            bookConn.Close();

            /*
            try
            {

                con.Open();
                command = new MySqlCommand(query, con);
                mdr = command.ExecuteReader();

                while (mdr.Read())
                {
                    combo_Retail_Item1.Items.Add(mdr.GetString("Code"));
                    combo_Retail_Item2.Items.Add(mdr.GetString("Code"));
                    combo_Retail_Item3.Items.Add(mdr.GetString("Code"));
                    combo_Retail_Item4.Items.Add(mdr.GetString("Code"));
                    combo_Retail_Item5.Items.Add(mdr.GetString("Code"));
                    combo_Retail_Item6.Items.Add(mdr.GetString("Code"));
                    combo_Retail_Item7.Items.Add(mdr.GetString("Code"));
                    combo_Retail_Item8.Items.Add(mdr.GetString("Code"));
                    combo_Retail_Item9.Items.Add(mdr.GetString("Code"));
                    combo_Retail_Item10.Items.Add(mdr.GetString("Code"));
                    combo_Retail_Item11.Items.Add(mdr.GetString("Code"));
                    combo_Retail_Item12.Items.Add(mdr.GetString("Code"));
                    combo_Retail_Item13.Items.Add(mdr.GetString("Code"));
                    combo_Retail_Item14.Items.Add(mdr.GetString("Code"));
                    combo_Retail_Item15.Items.Add(mdr.GetString("Code"));
                }
            }
            catch (Exception er)
            {
                Console.WriteLine("ERROR : " + er);
            }
            finally
            {
                con.Close();
                con.Dispose();
            }*/
        }

        public void Qury_Select_Customer()
        {
            string query = "SELECT Cus_Name  FROM customer";

            bookConn = new OleDbConnection(connParam);
            bookConn.Open();
            try
            {
                OleDbDataAdapter dAdapter = new OleDbDataAdapter(query, connParam);
                DataTable dt = new DataTable();

                dAdapter.Fill(dt);
                comboBox_Name.Items.Add("");
            }
            catch (Exception er)
            {

                MessageBox.Show("ERROR : " + er);
                bookConn.Close();
            }
            bookConn.Close();

            /* MySqlDataAdapter data = new MySqlDataAdapter(query, con);

             DataTable dt = new DataTable();

             data.Fill(dt);

             comboBox_Name.Items.Add("");*/

        }

        public string Qry_Date()
        {
            string date = "";
           // dateTimePickerRetail.CustomFormat = "dd/MM/yyyy";
           // dateTimePickerRetail.Format = DateTimePickerFormat.Custom;
             date = dateTimePickerRetail.Text;

            return date;
        }
        private void Retail_Load(object sender, EventArgs e)
        {
            Inv_QryHead.Clear();
            Inv_QryDetail.Clear();
            textBox_UserName.Text = userName;
            FillCombobox();
            FillComboboxItem();
            SelectInvNo();

            dateTimePickerRetail.Value = DateTime.Now;
            //Console.WriteLine(Qry_Date());
            //MessageBox.Show(ThaiBaht("153,456,200"));
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }
        private void label31_Click(object sender, EventArgs e)
        {

        }
        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label41_Click(object sender, EventArgs e)
        {

        }

        public void Select_Customers(string select)
        {



        }
        public void Qury_Address_Customer(string name )
        {
           
            string query = "SELECT Cus_Address  FROM customer where Cus_Name ='" + name+"'";

            bookConn = new OleDbConnection(connParam);
            bookConn.Open();
            try
            {
                oleDbCmd = new OleDbCommand(query, bookConn);

                mdr = oleDbCmd.ExecuteReader();
             
                if (mdr.Read())
                {
                    textBox_CusAddress.Text = mdr.GetString(0);
                    
                }
                else
                {
                    MessageBox.Show("Do not for this id ");
                }
            }
            catch (Exception er)
            {

                MessageBox.Show("ERROR : " + er);
                bookConn.Close();
            }
            bookConn.Close();

            /*
              con.Open();
            MySqlDataAdapter data = new MySqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            data.Fill(dt);
            textBox_CusAddress.Text = data.ToString();
            command = new MySqlCommand(query, con);
            mdr = command.ExecuteReader();

            if (mdr.Read())
            {
                textBox_CusAddress.Text = mdr.GetString("address");
                con.Close();
            }
            else
            {
                MessageBox.Show("Do not for this id ");
            }
            */
        }

        private void comboBox_Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = comboBox_Name.SelectedIndex;
            Object selectedItem = comboBox_Name.SelectedItem;
            
            string cusName = selectedItem.ToString();

            Qury_Address_Customer(selectedItem.ToString());
        }

        public static string ThaiBaht(string txt)
        {
            string bahtTxt, n, bahtTH = "";
            double amount;
            try { amount = Convert.ToDouble(txt); }
            catch { amount = 0; }
            bahtTxt = amount.ToString("####.00");
            string[] num = { "ศูนย์", "หนึ่ง", "สอง", "สาม", "สี่", "ห้า", "หก", "เจ็ด", "แปด", "เก้า", "สิบ" };
            string[] rank = { "", "สิบ", "ร้อย", "พัน", "หมื่น", "แสน", "ล้าน","สิบล้าน","ร้อยล้าน" };
            string[] temp = bahtTxt.Split('.');
            string intVal = temp[0];
            string decVal = temp[1];
            bahtTH = "**";
            if (Convert.ToDouble(bahtTxt) == 0)
                bahtTH += "ศูนย์บาทถ้วน";
            else
            {
                for (int i = 0; i < intVal.Length; i++)
                {
                    n = intVal.Substring(i, 1);
                    if (n != "0")
                    {
                        if ((i == (intVal.Length - 1)) && (n == "1"))
                            bahtTH += "เอ็ด";
                        else if ((i == (intVal.Length - 2)) && (n == "2"))
                            bahtTH += "ยี่";
                        else if ((i == (intVal.Length - 2)) && (n == "1"))
                            bahtTH += "";
                        else
                            bahtTH += num[Convert.ToInt32(n)];
                        bahtTH += rank[(intVal.Length - i) - 1];
                    }
                }
                bahtTH += "บาท";
                if (decVal == "00")
                    bahtTH += "ถ้วน";
                else
                {
                    for (int i = 0; i < decVal.Length; i++)
                    {
                        n = decVal.Substring(i, 1);
                        if (n != "0")
                        {
                            if ((i == decVal.Length - 1) && (n == "1"))
                                bahtTH += "เอ็ด";
                            else if ((i == (decVal.Length - 2)) && (n == "2"))
                                bahtTH += "ยี่";
                            else if ((i == (decVal.Length - 2)) && (n == "1"))
                                bahtTH += "";
                            else
                                bahtTH += num[Convert.ToInt32(n)];
                            bahtTH += rank[(decVal.Length - i) - 1];
                        }
                    }
                    bahtTH += "สตางค์";
                }
            }
            bahtTH += "**";
            return bahtTH;
        }
        public string Select_Des_Item(string Des)
        {
           
            string query = "SELECT  `Goods_Description` FROM `goods` WHERE Goods_CD = '" + Des + "'";
            string str = "";
            bookConn = new OleDbConnection(connParam);
            bookConn.Open();
            try
            {
                oleDbCmd = new OleDbCommand(query, bookConn);

                mdr = oleDbCmd.ExecuteReader();

                while (mdr.Read())
                {
                    str = mdr.GetString(0);

                }
            }
            catch (Exception er)
            {

                MessageBox.Show("ERROR : " + er);
                bookConn.Close();
                bookConn.Dispose();
            }
            bookConn.Close();
            bookConn.Dispose();
            return (str);
            /* try
             {
                 command = new MySqlCommand(query, con);
                 mdr = command.ExecuteReader();
                 while (mdr.Read())
                 {
                     //comboBox_Name.Items.Add(mdr.GetString("Name"));
                     str = mdr.GetString("Description");
                 }
             }
             catch (Exception er)
             {
                 Console.WriteLine("ERROR : " + er);

                 con.Close();
                 con.Dispose();
             }

             con.Close();
             con.Dispose();
             return (str);*/

        }
        public string Select_Price_Item(string Code)
        {
            
            string query = "SELECT  Goods_Retail FROM `goods` WHERE Goods_CD = '" + Code + "'";
            string str = "";

            bookConn = new OleDbConnection(connParam);
            bookConn.Open();
            try
            {
                oleDbCmd = new OleDbCommand(query, bookConn);

                mdr = oleDbCmd.ExecuteReader();

                while (mdr.Read())
                {
                    //str = mdr.GetString(0);
                    // str = mdr.GetString(0) == "" ? "0" : mdr.GetString(0);
                    str = mdr.GetInt32(0).ToString();
                }
            }
            catch (Exception er)
            {

                MessageBox.Show("ERROR : " + er);
                bookConn.Close();
                bookConn.Dispose();
            }
            bookConn.Close();
            bookConn.Dispose();

            int integer = 0;

            integer = Int32.Parse(str); //.ToString() == "" ? 0 : Int32.Parse(str);

            return integer.ToString("N2");




            /*try
            {
                con.Open();
                command = new MySqlCommand(query, con);
                mdr = command.ExecuteReader();
                while (mdr.Read())
                {
                    // comboBox_Name.Items.Add(mdr.GetString("Name"));
                    str = mdr.GetString("Retail_Price") == "" ? "0" : mdr.GetString("Retail_Price");
                }
            }
            catch (Exception er)
            {
                Console.WriteLine("ERROR : " + er);

                con.Close();
                con.Dispose();
            }
            con.Close();
            con.Dispose();
            int integer = 0;
            integer = Int32.Parse(str);

            return integer.ToString("N2");*/
        }
        public string Select_Size_Item(string Code)
        {
           
            string query = "SELECT  `Goods_Size` FROM `goods` WHERE Goods_CD = '" + Code + "'";
            string str = "";

            bookConn = new OleDbConnection(connParam);
            bookConn.Open();
            try
            {
                oleDbCmd = new OleDbCommand(query, bookConn);

                mdr = oleDbCmd.ExecuteReader();

                while (mdr.Read())
                {
                    //str = mdr.GetString(0);
                    str = mdr.GetString(0) == "" ? "" : mdr.GetString(0);
                }
            }
            catch (Exception er)
            {

                MessageBox.Show("ERROR : " + er);
                bookConn.Close();
                bookConn.Dispose();
            }
            bookConn.Close();
            bookConn.Dispose();
            return str;

            /*try
            {
                con.Open();
                command = new MySqlCommand(query, con);
                mdr = command.ExecuteReader();
                while (mdr.Read())
                {
                    // comboBox_Name.Items.Add(mdr.GetString("Name"));
                    str = mdr.GetString("Size") == "" ? "" : mdr.GetString("Size");
                }
            }
            catch (Exception er)
            {
                Console.WriteLine("ERROR : " + er);

                con.Close();
                con.Dispose();
            }
            con.Close();
            con.Dispose();
            return str;*/
        }

        public string Select_Type_Item(string Code)
        {
           
            string query = "SELECT  `Goods_Type` FROM `goods` WHERE Goods_CD = '" + Code + "'";
            string str = "";

            bookConn = new OleDbConnection(connParam);
            bookConn.Open();
            try
            {
                oleDbCmd = new OleDbCommand(query, bookConn);

                mdr = oleDbCmd.ExecuteReader();

                while (mdr.Read())
                {
                    //str = mdr.GetString(0);
                    str = mdr.GetString(0) == "" ? "" : mdr.GetString(0);
                }
            }
            catch (Exception er)
            {

                MessageBox.Show("ERROR : " + er);
                bookConn.Close();
                bookConn.Dispose();
            }
            bookConn.Close();
            bookConn.Dispose();
            return str;

            /*try
            {
                con.Open();
                command = new MySqlCommand(query, con);
                mdr = command.ExecuteReader();
                while (mdr.Read())
                {
                    // comboBox_Name.Items.Add(mdr.GetString("Name"));
                    str = mdr.GetString("Type_Count") == "" ? "" : mdr.GetString("Type_Count");
                }
            }
            catch (Exception er)
            {
                Console.WriteLine("ERROR : " + er);

                con.Close();
                con.Dispose();
            }
            con.Close();
            con.Dispose();
            return str;*/
        }
        public string Select_Cost_Price(string Code)
        {
           
            string query = "SELECT  `Goods_Cost` FROM `goods` WHERE Goods_CD = '" + Code + "'";
            string str = "";

            bookConn = new OleDbConnection(connParam);
            bookConn.Open();
            try
            {
                oleDbCmd = new OleDbCommand(query, bookConn);

                mdr = oleDbCmd.ExecuteReader();

                while (mdr.Read())
                {
                    //str = mdr.GetString(0);
                    //str = mdr.GetString(0) == "" ? "0" : mdr.GetString(0);
                    str = mdr.GetInt32(0).ToString();
                }
            }
            catch (Exception er)
            {

                MessageBox.Show("ERROR : " + er);
                bookConn.Close();
                bookConn.Dispose();
            }
            bookConn.Close();
            bookConn.Dispose();
            int integer = 0;
            integer = str == "" ? 0 : Int32.Parse(str);

            return integer.ToString("N2");


            /* try
             {
                 con.Open();
                 command = new MySqlCommand(query, con);
                 mdr = command.ExecuteReader();
                 while (mdr.Read())
                 {
                     // comboBox_Name.Items.Add(mdr.GetString("Name"));
                     str = mdr.GetString("Cost_price") == "" ? "0" : mdr.GetString("Cost_price");
                 }
             }
             catch (Exception er)
             {
                 Console.WriteLine("ERROR : " + er);

                 con.Close();
                 con.Dispose();
             }
             con.Close();
             con.Dispose();
             int integer = 0;
             integer =  str == "" ? 0 : Int32.Parse(str);

             return integer.ToString("N2");*/
        }


        public int Select_Weight(string Item)
        {
            int weight=0;

            if (Item != "Select Item")
            {
                string query = "SELECT Goods_Weight FROM `goods` WHERE Goods_CD = '" + Item + "'";
                string str = "";
                bookConn = new OleDbConnection(connParam);
                bookConn.Open();
                try
                {
                    oleDbCmd = new OleDbCommand(query, bookConn);

                    mdr = oleDbCmd.ExecuteReader();

                    while (mdr.Read())
                    {
                        //str = mdr.GetString(0);
                        //str = mdr.GetString(0) == "" ? "0" : mdr.GetString(0);
                        str = mdr.GetInt32(0).ToString();
                    }
                }
                catch (Exception er)
                {

                    MessageBox.Show("ERROR : " + er);
                    bookConn.Close();
                    bookConn.Dispose();
                }
                bookConn.Close();
                bookConn.Dispose();
                weight = str == "" ? 0 : Int32.Parse(str);

                /* con.Open();
                 string query = "SELECT Weight FROM `goods` WHERE Code = '" + Item + "'";
                 string str = "";
                 try
                 {
                     command = new MySqlCommand(query, con);
                     mdr = command.ExecuteReader();
                     while (mdr.Read())
                     {
                         // comboBox_Name.Items.Add(mdr.GetString("Name"));
                         str = mdr.GetString("Weight") == "" ? "0" : mdr.GetString("Weight");
                     }
                 }
                 catch (Exception er)
                 {
                     Console.WriteLine("ERROR : " + er);

                     con.Close();
                     con.Dispose();
                 }
                 con.Close();
                 con.Dispose();

                 weight = str == "" ? 0 : Int32.Parse(str);*/


            }

            return weight;

           
        }
        

        public void SumWeight()
        {
            int Item1, Item2, Item3, Item4, Item5, Item6, Item7, Item8, Item9, Item10, Item11, Item12, Item13, Item14, Item15;
            int Sum;
            int Count1, Count2, Count3, Count4, Count5, Count6, Count7, Count8, Count9, Count10, Count11, Count12, Count13, Count14, Count15;
            Item1 = Select_Weight(combo_Retail_Item1.Text);
            Count1 = textBox_Retail_Count1.Text.ToString() == "" ? 0 : Int32.Parse(textBox_Retail_Count1.Text.ToString());
            Item2 = Select_Weight(combo_Retail_Item2.Text);
            Count2 = textBox_Retail_Count2.Text.ToString() == "" ? 0 : Int32.Parse(textBox_Retail_Count2.Text.ToString());
            Item3 = Select_Weight(combo_Retail_Item3.Text);
            Count3 = textBox_Retail_Count3.Text.ToString() == "" ? 0 : Int32.Parse(textBox_Retail_Count3.Text.ToString());
            Item4 = Select_Weight(combo_Retail_Item4.Text);
            Count4 = textBox_Retail_Count4.Text.ToString() == "" ? 0 : Int32.Parse(textBox_Retail_Count4.Text.ToString());
            Item5 = Select_Weight(combo_Retail_Item5.Text);
            Count5 = textBox_Retail_Count5.Text.ToString() == "" ? 0 : Int32.Parse(textBox_Retail_Count5.Text.ToString());
            Item6 = Select_Weight(combo_Retail_Item6.Text);
            Count6 = textBox_Retail_Count6.Text.ToString() == "" ? 0 : Int32.Parse(textBox_Retail_Count6.Text.ToString());
            Item7 = Select_Weight(combo_Retail_Item7.Text);
            Count7 = textBox_Retail_Count7.Text.ToString() == "" ? 0 : Int32.Parse(textBox_Retail_Count7.Text.ToString());
            Item8 = Select_Weight(combo_Retail_Item8.Text);
            Count8 = textBox_Retail_Count8.Text.ToString() == "" ? 0 : Int32.Parse(textBox_Retail_Count8.Text.ToString());
            Item9 = Select_Weight(combo_Retail_Item9.Text);
            Count9 = textBox_Retail_Count9.Text.ToString() == "" ? 0 : Int32.Parse(textBox_Retail_Count9.Text.ToString());
            Item10 = Select_Weight(combo_Retail_Item10.Text);
            Count10 = textBox_Retail_Count10.Text.ToString() == "" ? 0 : Int32.Parse(textBox_Retail_Count10.Text.ToString());
            Item11 = Select_Weight(combo_Retail_Item11.Text);
            Count11 = textBox_Retail_Count11.Text.ToString() == "" ? 0 : Int32.Parse(textBox_Retail_Count11.Text.ToString());
            Item12 = Select_Weight(combo_Retail_Item12.Text);
            Count12 = textBox_Retail_Count12.Text.ToString() == "" ? 0 : Int32.Parse(textBox_Retail_Count12.Text.ToString());
            Item13 = Select_Weight(combo_Retail_Item13.Text);
            Count13 = textBox_Retail_Count13.Text.ToString() == "" ? 0 : Int32.Parse(textBox_Retail_Count13.Text.ToString());
            Item14 = Select_Weight(combo_Retail_Item14.Text);
            Count14 = textBox_Retail_Count14.Text.ToString() == "" ? 0 : Int32.Parse(textBox_Retail_Count14.Text.ToString());
            Item15 = Select_Weight(combo_Retail_Item15.Text);
            Count15 = textBox_Retail_Count15.Text.ToString() == "" ? 0 : Int32.Parse(textBox_Retail_Count15.Text.ToString());

            Sum = (Item1 * Count1) + (Item2 * Count2) + (Item3 * Count3) + (Item4 * Count4) + (Item5 * Count5) 
                + (Item6 * Count6) + (Item7 * Count7) + (Item8 * Count8) + (Item9 * Count9) + (Item10 * Count10)
                + (Item11 * Count11) + (Item12 * Count12) + (Item13 * Count13) + (Item14 * Count14) + (Item15 * Count15);

            textBox_Retail_SumWeight.Text = Sum.ToString();

        }


        public void AmountChanged()
        {
            double Amount1,Amount2, Amount3, Amount4, Amount5;
            double Amount6, Amount7, Amount8, Amount9, Amount10;
            double Amount11, Amount12, Amount13, Amount14, Amount15;
            double SumAmount;
            try
            {
                Amount1 = textBox_Retail_PriceAmount1.Text == "" ? 0.00 : Double.Parse(textBox_Retail_PriceAmount1.Text);
                Amount2 = textBox_Retail_PriceAmount2.Text == "" ? 0.00 : Double.Parse(textBox_Retail_PriceAmount2.Text);
                Amount3 = textBox_Retail_PriceAmount3.Text == "" ? 0.00 : Double.Parse(textBox_Retail_PriceAmount3.Text);
                Amount4 = textBox_Retail_PriceAmount4.Text == "" ? 0.00 : Double.Parse(textBox_Retail_PriceAmount4.Text);
                Amount5 = textBox_Retail_PriceAmount5.Text == "" ? 0.00 : Double.Parse(textBox_Retail_PriceAmount5.Text);
                Amount6 = textBox_Retail_PriceAmount6.Text == "" ? 0.00 : Double.Parse(textBox_Retail_PriceAmount6.Text);
                Amount7 = textBox_Retail_PriceAmount7.Text == "" ? 0.00 : Double.Parse(textBox_Retail_PriceAmount7.Text);
                Amount8 = textBox_Retail_PriceAmount8.Text == "" ? 0.00 : Double.Parse(textBox_Retail_PriceAmount8.Text);
                Amount9 = textBox_Retail_PriceAmount9.Text == "" ? 0.00 : Double.Parse(textBox_Retail_PriceAmount9.Text);
                Amount10 = textBox_Retail_PriceAmount10.Text == "" ? 0.00 : Double.Parse(textBox_Retail_PriceAmount10.Text);
                Amount11 = textBox_Retail_PriceAmount11.Text == "" ? 0.00 : Double.Parse(textBox_Retail_PriceAmount11.Text);
                Amount12 = textBox_Retail_PriceAmount12.Text == "" ? 0.00 : Double.Parse(textBox_Retail_PriceAmount12.Text);
                Amount13 = textBox_Retail_PriceAmount13.Text == "" ? 0.00 : Double.Parse(textBox_Retail_PriceAmount13.Text);
                Amount14 = textBox_Retail_PriceAmount14.Text == "" ? 0.00 : Double.Parse(textBox_Retail_PriceAmount14.Text);
                Amount15 = textBox_Retail_PriceAmount15.Text == "" ? 0.00 : Double.Parse(textBox_Retail_PriceAmount15.Text);
                SumAmount = Amount1 + Amount2 + Amount3 + Amount4 + Amount5 + Amount6 + Amount7 + Amount8 +
                            Amount9 + Amount10 + Amount11 + Amount12 + Amount13 + Amount14 + Amount15;
                textBox_Retail_Amount.Text = SumAmount.ToString("N2");
                textBox_Retail_ThaiPrice.Text =  ThaiBaht(textBox_Retail_Amount.Text);
            }
            catch (Exception er)
            {
                MessageBox.Show("Error : " + er);
            }
        }

       

        public void SumItem()
        {
            int i = 0;
            if (combo_Retail_Item1.Text != "Select Item" && combo_Retail_Item1.Text != "")
            {
                i = i + 1;
            }
            if (combo_Retail_Item2.Text != "Select Item" && combo_Retail_Item2.Text != "")
            {
                i = i + 1;
            }
            if (combo_Retail_Item3.Text != "Select Item" && combo_Retail_Item3.Text != "")
            {
                i = i + 1;
            }
            if (combo_Retail_Item4.Text != "Select Item" && combo_Retail_Item4.Text != "")
            {
                i = i + 1;
            }
            if (combo_Retail_Item5.Text != "Select Item" && combo_Retail_Item5.Text != "")
            {
                i = i + 1;
            }
            if (combo_Retail_Item6.Text != "Select Item" && combo_Retail_Item6.Text != "")
            {
                i = i + 1;
            }
            if (combo_Retail_Item7.Text != "Select Item" && combo_Retail_Item7.Text != "")
            {
                i = i + 1;
            }
            if (combo_Retail_Item8.Text != "Select Item" && combo_Retail_Item8.Text != "")
            {
                i = i + 1;
            }
            if (combo_Retail_Item9.Text != "Select Item" && combo_Retail_Item9.Text != "")
            {
                i = i + 1;
            }
            if (combo_Retail_Item10.Text != "Select Item" && combo_Retail_Item10.Text != "")
            {
                i = i + 1;
            }
            if (combo_Retail_Item11.Text != "Select Item" && combo_Retail_Item11.Text != "")
            {
                i = i + 1;
            }
            if (combo_Retail_Item12.Text != "Select Item" && combo_Retail_Item12.Text != "")
            {
                i = i + 1;
            }
            if (combo_Retail_Item13.Text != "Select Item" && combo_Retail_Item13.Text != "")
            {
                i = i + 1;
            }
            if (combo_Retail_Item14.Text != "Select Item" && combo_Retail_Item14.Text != "")
            {
                i = i + 1;
            }
            if (combo_Retail_Item15.Text != "Select Item" && combo_Retail_Item15.Text != "")
            {
                i = i + 1;
            }
            textBox_Retail_SumItem.Text = i.ToString();

        }

        public void combo_Retail_Item1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Object selectedItem = combo_Retail_Item1.SelectedItem;
                 
                if (combo_Retail_Item1.Text != "Select Item")
                {
                    textBox_Retail_item1.Text = Select_Des_Item(selectedItem.ToString()) + " " + Select_Size_Item(selectedItem.ToString());

                    textBox_Retail_Price1.Text = Select_Price_Item(selectedItem.ToString());
                    textBox_Retail_Type1.Text = Select_Type_Item(selectedItem.ToString());
                    combo_Retail_Item2.Enabled = true;
                    textBox_Retail_item2.Enabled = true;
                    textBox_Retail_Count2.Enabled = true;
                    textBox_Retail_Type2.Enabled = true;
                    textBox_Retail_Price2.Enabled = true;
                    textBox_Retail_PriceAmount2.Enabled = true;
                    AmountChanged();
                    SumItem();
                    SumWeight();

                }
                else
                {
                    textBox_Retail_item1.Text = "";
                    textBox_Retail_Price1.Text = "";
                    textBox_Retail_Type1.Text = "";
                    textBox_Retail_PriceAmount1.Text = "";
                    AmountChanged();
                    SumItem();
                    SumWeight();
                    combo_Retail_Item2.Enabled = false;
                    textBox_Retail_item2.Enabled = false;
                    textBox_Retail_Count2.Enabled = false;
                    textBox_Retail_Type2.Enabled = false;
                    textBox_Retail_Price2.Enabled = false;
                    textBox_Retail_PriceAmount2.Enabled = false;
                }
               
            }
            catch(Exception er)
            {
                MessageBox.Show("Error : "+er);
            }
        }
        
       

        public void SumCount()
        {
            int Count = 0;
            int C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15;
            C1 = textBox_Retail_Count1.Text.ToString() == "" ? 0 : Int32.Parse(textBox_Retail_Count1.Text.ToString());
            C2 = textBox_Retail_Count2.Text.ToString() == "" ? 0 : Int32.Parse(textBox_Retail_Count2.Text.ToString());
            C3 = textBox_Retail_Count3.Text.ToString() == "" ? 0 : Int32.Parse(textBox_Retail_Count3.Text.ToString());
            C4 = textBox_Retail_Count4.Text.ToString() == "" ? 0 : Int32.Parse(textBox_Retail_Count4.Text.ToString());
            C5 = textBox_Retail_Count5.Text.ToString() == "" ? 0 : Int32.Parse(textBox_Retail_Count5.Text.ToString());
            C6 = textBox_Retail_Count6.Text.ToString() == "" ? 0 : Int32.Parse(textBox_Retail_Count6.Text.ToString());
            C7 = textBox_Retail_Count7.Text.ToString() == "" ? 0 : Int32.Parse(textBox_Retail_Count7.Text.ToString());
            C8 = textBox_Retail_Count8.Text.ToString() == "" ? 0 : Int32.Parse(textBox_Retail_Count8.Text.ToString());
            C9 = textBox_Retail_Count9.Text.ToString() == "" ? 0 : Int32.Parse(textBox_Retail_Count9.Text.ToString());
            C10 = textBox_Retail_Count10.Text.ToString() == "" ? 0 : Int32.Parse(textBox_Retail_Count10.Text.ToString());        
            C11 = textBox_Retail_Count11.Text.ToString() == "" ? 0 : Int32.Parse(textBox_Retail_Count11.Text.ToString());
            C12 = textBox_Retail_Count12.Text.ToString() == "" ? 0 : Int32.Parse(textBox_Retail_Count12.Text.ToString());
            C13 = textBox_Retail_Count13.Text.ToString() == "" ? 0 : Int32.Parse(textBox_Retail_Count13.Text.ToString());
            C14 = textBox_Retail_Count14.Text.ToString() == "" ? 0 : Int32.Parse(textBox_Retail_Count14.Text.ToString());
            C15 = textBox_Retail_Count15.Text.ToString() == "" ? 0 : Int32.Parse(textBox_Retail_Count15.Text.ToString());
            Count = C1 + C2 + C3 + C4 + C5 + C6 + C7 + C8 + C9 + C10 + C11 + C12 + C13 + C14 + C15;

            textBox_Retail_SumCount.Text = Count.ToString();
        }
        private void textBox_Retail_Count1_TextChanged(object sender, EventArgs e)
        {
           
            try
            {
                string textPrice = "";
                double douPrice, amount ;
                int Count; 
                textPrice = textBox_Retail_Price1.Text.ToString() == "" ? "0.00" : textBox_Retail_Price1.Text.ToString();
                douPrice = Double.Parse(textPrice);
                Count = textBox_Retail_Count1.Text.ToString() == "" ? 0 : Int32.Parse(textBox_Retail_Count1.Text.ToString());
                amount = Count * douPrice;
                textBox_Retail_PriceAmount1.Text = amount.ToString("N2");
                AmountChanged();
                SumCount();
                SumWeight();
            }
            catch(Exception er)
            {
                
                MessageBox.Show("Error :  " + er);
            }
        }
        bool Check_PriceRetail = true;
        public void textBox_Retail_Price1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Object selectedItem = combo_Retail_Item1.SelectedItem;
                string textCount = "";
                double douCount, amount, Price;
                double costPrice;
                costPrice = Select_Cost_Price(selectedItem.ToString()) == "" ? 0.00 : Double.Parse(Select_Cost_Price(selectedItem.ToString()));
                textCount = textBox_Retail_Count1.Text.ToString() == "" ? "0.00" : textBox_Retail_Count1.Text.ToString();
                douCount = Double.Parse(textCount);
                Price = textBox_Retail_Price1.Text.ToString() == "" ? 0.00 : Double.Parse(textBox_Retail_Price1.Text.ToString());
                amount = douCount * Price;               
                 if(Price >= costPrice)
                 {
                     amount = douCount * Price;
                     textBox_Retail_PriceAmount1.Text = amount.ToString("N2");
                 }
                 else
                 {
                     MessageBox.Show("*****ราคาขายห้ามต่ำกว่าต้นทุน*****");
                    textBox_Retail_Price1.Text = Select_Price_Item(selectedItem.ToString());
                    Check_PriceRetail = false;
                 }
                AmountChanged();

            }
            catch(Exception er)
            {
                MessageBox.Show("Error : " + er);
            }
        }

        private void combo_Retail_Item2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Object selectedItem = combo_Retail_Item2.SelectedItem;

                if (combo_Retail_Item2.Text != "Select Item")
                {
                    textBox_Retail_item2.Text = Select_Des_Item(selectedItem.ToString()) + " " + Select_Size_Item(selectedItem.ToString());

                    textBox_Retail_Price2.Text = Select_Price_Item(selectedItem.ToString());
                    textBox_Retail_Type2.Text = Select_Type_Item(selectedItem.ToString());
                    combo_Retail_Item3.Enabled = true;
                    textBox_Retail_item3.Enabled = true;
                    textBox_Retail_Count3.Enabled = true;
                    textBox_Retail_Type3.Enabled = true;
                    textBox_Retail_Price3.Enabled = true;
                    textBox_Retail_PriceAmount3.Enabled = true;
                    AmountChanged();
                    SumItem();
                    SumWeight();
                }
                else
                {
                    textBox_Retail_item2.Text = "";
                    textBox_Retail_Price2.Text = "";
                    textBox_Retail_Type2.Text = "";
                    textBox_Retail_PriceAmount2.Text = "";
                    combo_Retail_Item3.Enabled = false;
                    textBox_Retail_item3.Enabled = false ;
                    textBox_Retail_Count3.Enabled = false ;
                    textBox_Retail_Type3.Enabled = false ;
                    textBox_Retail_Price3.Enabled = false ;
                    textBox_Retail_PriceAmount3.Enabled = false ;
                    AmountChanged();
                    SumItem();
                    SumWeight();
                }

            }
            catch (Exception er)
            {
                MessageBox.Show("Error : " + er);
            }


        }
        private void textBox_Retail_Count2_TextChanged(object sender, EventArgs e)
        {

            try
            {
                string textPrice = "";
                double douPrice, amount;
                int Count;
                textPrice = textBox_Retail_Price2.Text.ToString() == "" ? "0.00" : textBox_Retail_Price2.Text.ToString();
                douPrice = Double.Parse(textPrice);
                Count = textBox_Retail_Count2.Text.ToString() == "" ? 0 : Int32.Parse(textBox_Retail_Count2.Text.ToString());
                amount = Count * douPrice;
                textBox_Retail_PriceAmount2.Text = amount.ToString("N2");
                AmountChanged();
                SumCount();
                SumWeight();
            }
            catch (Exception er)
            {

                MessageBox.Show("Error :  " + er);
            }
        }

        private void combo_Retail_Item3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Object selectedItem = combo_Retail_Item3.SelectedItem;

                if (combo_Retail_Item3.Text != "Select Item")
                {
                    textBox_Retail_item3.Text = Select_Des_Item(selectedItem.ToString()) + " " + Select_Size_Item(selectedItem.ToString());

                    textBox_Retail_Price3.Text = Select_Price_Item(selectedItem.ToString());
                    textBox_Retail_Type3.Text = Select_Type_Item(selectedItem.ToString());
                    combo_Retail_Item4.Enabled = true;
                    textBox_Retail_item4.Enabled = true;
                    textBox_Retail_Count4.Enabled = true;
                    textBox_Retail_Type4.Enabled = true;
                    textBox_Retail_Price4.Enabled = true;
                    textBox_Retail_PriceAmount4.Enabled = true;
                    AmountChanged();
                    SumItem();
                    SumWeight();
                }
                else
                {
                    textBox_Retail_item3.Text = "";
                    textBox_Retail_Price3.Text = "";
                    textBox_Retail_Type3.Text = "";
                    textBox_Retail_PriceAmount3.Text = "";
                    combo_Retail_Item4.Enabled = false ;
                    textBox_Retail_item4.Enabled = false ;
                    textBox_Retail_Count4.Enabled = false ;
                    textBox_Retail_Type4.Enabled =  false ;
                    textBox_Retail_Price4.Enabled = false ;
                    textBox_Retail_PriceAmount4.Enabled = false ;
                    AmountChanged();
                    SumItem();
                    SumWeight();
                }

            }
            catch (Exception er)
            {
                MessageBox.Show("Error : " + er);
            }

        }

        private void textBox_Retail_Count3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string textPrice = "";
                double douPrice, amount;
                int Count;
                textPrice = textBox_Retail_Price3.Text.ToString() == "" ? "0.00" : textBox_Retail_Price3.Text.ToString();
                douPrice = Double.Parse(textPrice);
                Count = textBox_Retail_Count3.Text.ToString() == "" ? 0 : Int32.Parse(textBox_Retail_Count3.Text.ToString());
                amount = Count * douPrice;
                textBox_Retail_PriceAmount3.Text = amount.ToString("N2");
                AmountChanged();
                SumCount();
                SumWeight();
            }
            catch (Exception er)
            {

                MessageBox.Show("Error :  " + er);
            }
        }

        private void combo_Retail_Item4_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Object selectedItem = combo_Retail_Item4.SelectedItem;

                if (combo_Retail_Item4.Text != "Select Item")
                {
                    textBox_Retail_item4.Text = Select_Des_Item(selectedItem.ToString()) + " " + Select_Size_Item(selectedItem.ToString());

                    textBox_Retail_Price4.Text = Select_Price_Item(selectedItem.ToString());
                    textBox_Retail_Type4.Text = Select_Type_Item(selectedItem.ToString());
                    combo_Retail_Item5.Enabled = true;
                    textBox_Retail_item5.Enabled = true;
                    textBox_Retail_Count5.Enabled = true;
                    textBox_Retail_Type5.Enabled = true;
                    textBox_Retail_Price5.Enabled = true;
                    textBox_Retail_PriceAmount5.Enabled = true;
                    AmountChanged();
                    SumItem();
                    SumWeight();
                }
                else
                {
                    textBox_Retail_item4.Text = "";
                    textBox_Retail_Price4.Text = "";
                    textBox_Retail_Type4.Text = "";
                    textBox_Retail_PriceAmount4.Text = "";
                    combo_Retail_Item5.Enabled = false ;
                    textBox_Retail_item5.Enabled = false ;
                    textBox_Retail_Count5.Enabled = false ;
                    textBox_Retail_Type5.Enabled = false ;
                    textBox_Retail_Price5.Enabled = false ;
                    textBox_Retail_PriceAmount5.Enabled = false ;
                    AmountChanged();
                    SumItem();
                    SumWeight();
                }

            }
            catch (Exception er)
            {
                MessageBox.Show("Error : " + er);
            }

        }

        private void textBox_Retail_Count4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string textPrice = "";
                double douPrice, amount;
                int Count;
                textPrice = textBox_Retail_Price4.Text.ToString() == "" ? "0.00" : textBox_Retail_Price4.Text.ToString();
                douPrice = Double.Parse(textPrice);
                Count = textBox_Retail_Count4.Text.ToString() == "" ? 0 : Int32.Parse(textBox_Retail_Count4.Text.ToString());
                amount = Count * douPrice;
                textBox_Retail_PriceAmount4.Text = amount.ToString("N2");
                AmountChanged();
                SumCount();
                SumWeight();
            }
            catch (Exception er)
            {

                MessageBox.Show("Error :  " + er);
            }
        }

        private void combo_Retail_Item5_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Object selectedItem = combo_Retail_Item5.SelectedItem;

                if (combo_Retail_Item5.Text != "Select Item")
                {
                    textBox_Retail_item5.Text = Select_Des_Item(selectedItem.ToString()) + " " + Select_Size_Item(selectedItem.ToString());

                    textBox_Retail_Price5.Text = Select_Price_Item(selectedItem.ToString());
                    textBox_Retail_Type5.Text = Select_Type_Item(selectedItem.ToString());
                    combo_Retail_Item6.Enabled = true;
                    textBox_Retail_item6.Enabled = true;
                    textBox_Retail_Count6.Enabled = true;
                    textBox_Retail_Type6.Enabled = true;
                    textBox_Retail_Price6.Enabled = true;
                    textBox_Retail_PriceAmount6.Enabled = true;
                    AmountChanged();
                    SumItem();
                    SumWeight();
                }
                else
                {
                    textBox_Retail_item5.Text = "";
                    textBox_Retail_Price5.Text = "";
                    textBox_Retail_Type5.Text = "";
                    textBox_Retail_PriceAmount5.Text = "";
                    combo_Retail_Item6.Enabled = false ;
                    textBox_Retail_item6.Enabled = false ;
                    textBox_Retail_Count6.Enabled = false ;
                    textBox_Retail_Type6.Enabled = false ;
                    textBox_Retail_Price6.Enabled = false ;
                    textBox_Retail_PriceAmount6.Enabled = false ;
                    AmountChanged();
                    SumItem();
                    SumWeight();
                }

            }
            catch (Exception er)
            {
                MessageBox.Show("Error : " + er);
            }

        }

        private void textBox_Retail_Count5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string textPrice = "";
                double douPrice, amount;
                int Count;
                textPrice = textBox_Retail_Price5.Text.ToString() == "" ? "0.00" : textBox_Retail_Price5.Text.ToString();
                douPrice = Double.Parse(textPrice);
                Count = textBox_Retail_Count5.Text.ToString() == "" ? 0 : Int32.Parse(textBox_Retail_Count5.Text.ToString());
                amount = Count * douPrice;
                textBox_Retail_PriceAmount5.Text = amount.ToString("N2");
                AmountChanged();
                SumCount();
                SumWeight();
            }
            catch (Exception er)
            {

                MessageBox.Show("Error :  " + er);
            }
        }

        private void combo_Retail_Item6_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Object selectedItem = combo_Retail_Item6.SelectedItem;

                if (combo_Retail_Item6.Text != "Select Item")
                {
                    textBox_Retail_item6.Text = Select_Des_Item(selectedItem.ToString()) + " " + Select_Size_Item(selectedItem.ToString());

                    textBox_Retail_Price6.Text = Select_Price_Item(selectedItem.ToString());
                    textBox_Retail_Type6.Text = Select_Type_Item(selectedItem.ToString());
                    combo_Retail_Item7.Enabled = true;
                    textBox_Retail_item7.Enabled = true;
                    textBox_Retail_Count7.Enabled = true;
                    textBox_Retail_Type7.Enabled = true;
                    textBox_Retail_Price7.Enabled = true;
                    textBox_Retail_PriceAmount7.Enabled = true;
                    AmountChanged();
                    SumItem();
                    SumWeight();
                }
                else
                {
                    textBox_Retail_item6.Text = "";
                    textBox_Retail_Price6.Text = "";
                    textBox_Retail_Type6.Text = "";
                    textBox_Retail_PriceAmount6.Text = "";
                    combo_Retail_Item7.Enabled = false ;
                    textBox_Retail_item7.Enabled = false ;
                    textBox_Retail_Count7.Enabled = false ;
                    textBox_Retail_Type7.Enabled = false ;
                    textBox_Retail_Price7.Enabled = false ;
                    textBox_Retail_PriceAmount7.Enabled = false ;
                    AmountChanged();
                    SumItem();
                    SumWeight();
                }

            }
            catch (Exception er)
            {
                MessageBox.Show("Error : " + er);
            }

        }

        private void textBox_Retail_Count6_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string textPrice = "";
                double douPrice, amount;
                int Count;
                textPrice = textBox_Retail_Price6.Text.ToString() == "" ? "0.00" : textBox_Retail_Price6.Text.ToString();
                douPrice = Double.Parse(textPrice);
                Count = textBox_Retail_Count6.Text.ToString() == "" ? 0 : Int32.Parse(textBox_Retail_Count6.Text.ToString());
                amount = Count * douPrice;
                textBox_Retail_PriceAmount6.Text = amount.ToString("N2");
                AmountChanged();
                SumCount();
                SumWeight();
            }
            catch (Exception er)
            {

                MessageBox.Show("Error :  " + er);
            }
        }

        private void combo_Retail_Item7_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                Object selectedItem = combo_Retail_Item7.SelectedItem;

                if (combo_Retail_Item7.Text != "Select Item")
                {
                    textBox_Retail_item7.Text = Select_Des_Item(selectedItem.ToString()) + " " + Select_Size_Item(selectedItem.ToString());

                    textBox_Retail_Price7.Text = Select_Price_Item(selectedItem.ToString());
                    textBox_Retail_Type7.Text = Select_Type_Item(selectedItem.ToString());
                    combo_Retail_Item8.Enabled = true;
                    textBox_Retail_item8.Enabled = true;
                    textBox_Retail_Count8.Enabled = true;
                    textBox_Retail_Type8.Enabled = true;
                    textBox_Retail_Price8.Enabled = true;
                    textBox_Retail_PriceAmount8.Enabled = true;
                    AmountChanged();
                    SumItem();
                    SumWeight();
                }
                else
                {
                    textBox_Retail_item7.Text = "";
                    textBox_Retail_Price7.Text = "";
                    textBox_Retail_Type7.Text = "";
                    textBox_Retail_PriceAmount7.Text = "";
                    combo_Retail_Item8.Enabled = false ;
                    textBox_Retail_item8.Enabled = false ;
                    textBox_Retail_Count8.Enabled = false ;
                    textBox_Retail_Type8.Enabled = false ;
                    textBox_Retail_Price8.Enabled = false ;
                    textBox_Retail_PriceAmount8.Enabled = false ;
                    AmountChanged();
                    SumItem();
                    SumWeight();
                }

            }
            catch (Exception er)
            {
                MessageBox.Show("Error : " + er);
            }

        }

        private void textBox_Retail_Count7_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string textPrice = "";
                double douPrice, amount;
                int Count;
                textPrice = textBox_Retail_Price7.Text.ToString() == "" ? "0.00" : textBox_Retail_Price7.Text.ToString();
                douPrice = Double.Parse(textPrice);
                Count = textBox_Retail_Count7.Text.ToString() == "" ? 0 : Int32.Parse(textBox_Retail_Count7.Text.ToString());
                amount = Count * douPrice;
                textBox_Retail_PriceAmount7.Text = amount.ToString("N2");
                AmountChanged();
                SumCount();
                SumWeight();
            }
            catch (Exception er)
            {

                MessageBox.Show("Error :  " + er);
            }
        }
        private void combo_Retail_Item8_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                Object selectedItem = combo_Retail_Item8.SelectedItem;

                if (combo_Retail_Item8.Text != "Select Item")
                {
                    textBox_Retail_item8.Text = Select_Des_Item(selectedItem.ToString()) + " " + Select_Size_Item(selectedItem.ToString());

                    textBox_Retail_Price8.Text = Select_Price_Item(selectedItem.ToString());
                    textBox_Retail_Type8.Text = Select_Type_Item(selectedItem.ToString());
                    combo_Retail_Item9.Enabled = true;
                    textBox_Retail_item9.Enabled = true;
                    textBox_Retail_Count9.Enabled = true;
                    textBox_Retail_Type9.Enabled = true;
                    textBox_Retail_Price9.Enabled = true;
                    textBox_Retail_PriceAmount9.Enabled = true;
                    AmountChanged();
                    SumItem();
                    SumWeight();
                }
                else
                {
                    textBox_Retail_item8.Text = "";
                    textBox_Retail_Price8.Text = "";
                    textBox_Retail_Type8.Text = "";
                    textBox_Retail_PriceAmount8.Text = "";
                    combo_Retail_Item9.Enabled = false ;
                    textBox_Retail_item9.Enabled = false ;
                    textBox_Retail_Count9.Enabled = false ;
                    textBox_Retail_Type9.Enabled = false ;
                    textBox_Retail_Price9.Enabled = false ;
                    textBox_Retail_PriceAmount9.Enabled = false ;
                    AmountChanged();
                    SumItem();
                    SumWeight();
                }

            }
            catch (Exception er)
            {
                MessageBox.Show("Error : " + er);
            }

        }
        private void textBox_Retail_Count8_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string textPrice = "";
                double douPrice, amount;
                int Count;
                textPrice = textBox_Retail_Price8.Text.ToString() == "" ? "0.00" : textBox_Retail_Price8.Text.ToString();
                douPrice = Double.Parse(textPrice);
                Count = textBox_Retail_Count8.Text.ToString() == "" ? 0 : Int32.Parse(textBox_Retail_Count8.Text.ToString());
                amount = Count * douPrice;
                textBox_Retail_PriceAmount8.Text = amount.ToString("N2");
                AmountChanged();
                SumCount();
                SumWeight();
            }
            catch (Exception er)
            {

                MessageBox.Show("Error :  " + er);
            }
        }
        private void combo_Retail_Item9_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                Object selectedItem = combo_Retail_Item9.SelectedItem;

                if (combo_Retail_Item9.Text != "Select Item")
                {
                    textBox_Retail_item9.Text = Select_Des_Item(selectedItem.ToString()) + " " + Select_Size_Item(selectedItem.ToString());

                    textBox_Retail_Price9.Text = Select_Price_Item(selectedItem.ToString());
                    textBox_Retail_Type9.Text = Select_Type_Item(selectedItem.ToString());
                    combo_Retail_Item10.Enabled = true;
                    textBox_Retail_item10.Enabled = true;
                    textBox_Retail_Count10.Enabled = true;
                    textBox_Retail_Type10.Enabled = true;
                    textBox_Retail_Price10.Enabled = true;
                    textBox_Retail_PriceAmount10.Enabled = true;
                    AmountChanged();
                    SumItem();
                    SumWeight();
                }
                else
                {
                    textBox_Retail_item9.Text = "";
                    textBox_Retail_Price9.Text = "";
                    textBox_Retail_Type9.Text = "";
                    textBox_Retail_PriceAmount9.Text = "";
                    combo_Retail_Item10.Enabled = false ;
                    textBox_Retail_item10.Enabled = false ;
                    textBox_Retail_Count10.Enabled = false ;
                    textBox_Retail_Type10.Enabled = false ;
                    textBox_Retail_Price10.Enabled = false ;
                    textBox_Retail_PriceAmount10.Enabled = false ;
                    AmountChanged();
                    SumItem();
                    SumWeight();
                }

            }
            catch (Exception er)
            {
                MessageBox.Show("Error : " + er);
            }

        }
        private void textBox_Retail_Count9_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string textPrice = "";
                double douPrice, amount;
                int Count;
                textPrice = textBox_Retail_Price9.Text.ToString() == "" ? "0.00" : textBox_Retail_Price9.Text.ToString();
                douPrice = Double.Parse(textPrice);
                Count = textBox_Retail_Count9.Text.ToString() == "" ? 0 : Int32.Parse(textBox_Retail_Count9.Text.ToString());
                amount = Count * douPrice;
                textBox_Retail_PriceAmount9.Text = amount.ToString("N2");
                AmountChanged();
                SumCount();
                SumWeight();
            }
            catch (Exception er)
            {

                MessageBox.Show("Error :  " + er);
            }
        }
        private void combo_Retail_Item10_SelectedIndexChanged(object sender, EventArgs e)
        {
          
            try
            {
                Object selectedItem = combo_Retail_Item10.SelectedItem;

                if (combo_Retail_Item10.Text != "Select Item")
                {
                    textBox_Retail_item10.Text = Select_Des_Item(selectedItem.ToString()) + " " + Select_Size_Item(selectedItem.ToString());

                    textBox_Retail_Price10.Text = Select_Price_Item(selectedItem.ToString());
                    textBox_Retail_Type10.Text = Select_Type_Item(selectedItem.ToString());
                    combo_Retail_Item11.Enabled = true;
                    textBox_Retail_item11.Enabled = true;
                    textBox_Retail_Count11.Enabled = true;
                    textBox_Retail_Type11.Enabled = true;
                    textBox_Retail_Price11.Enabled = true;
                    textBox_Retail_PriceAmount11.Enabled = true;
                    AmountChanged();
                    SumItem();
                    SumWeight();
                }
                else
                {
                    textBox_Retail_item10.Text = "";
                    textBox_Retail_Price10.Text = "";
                    textBox_Retail_Type10.Text = "";
                    textBox_Retail_PriceAmount10.Text = "";
                    combo_Retail_Item11.Enabled = false ;
                    textBox_Retail_item11.Enabled = false ;
                    textBox_Retail_Count11.Enabled = false ;
                    textBox_Retail_Type11.Enabled = false ;
                    textBox_Retail_Price11.Enabled = false ;
                    textBox_Retail_PriceAmount11.Enabled = false ;
                    AmountChanged();
                    SumItem();
                    SumWeight();
                }

            }
            catch (Exception er)
            {
                MessageBox.Show("Error : " + er);
            }
            
        }
        private void textBox_Retail_Count10_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string textPrice = "";
                double douPrice, amount;
                int Count;
                textPrice = textBox_Retail_Price10.Text.ToString() == "" ? "0.00" : textBox_Retail_Price10.Text.ToString();
                douPrice = Double.Parse(textPrice);
                Count = textBox_Retail_Count10.Text.ToString() == "" ? 0 : Int32.Parse(textBox_Retail_Count10.Text.ToString());
                amount = Count * douPrice;
                textBox_Retail_PriceAmount10.Text = amount.ToString("N2");
                AmountChanged();
                SumCount();
                SumWeight();
            }
            catch (Exception er)
            {

                MessageBox.Show("Error :  " + er);
            }
        }

        private void combo_Retail_Item11_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Object selectedItem = combo_Retail_Item11.SelectedItem;

                if (combo_Retail_Item11.Text != "Select Item")
                {
                    textBox_Retail_item11.Text = Select_Des_Item(selectedItem.ToString()) + " " + Select_Size_Item(selectedItem.ToString());

                    textBox_Retail_Price11.Text = Select_Price_Item(selectedItem.ToString());
                    textBox_Retail_Type11.Text = Select_Type_Item(selectedItem.ToString());
                    combo_Retail_Item12.Enabled = true;
                    textBox_Retail_item12.Enabled = true;
                    textBox_Retail_Count12.Enabled = true;
                    textBox_Retail_Type12.Enabled = true;
                    textBox_Retail_Price12.Enabled = true;
                    textBox_Retail_PriceAmount12.Enabled = true;
                    AmountChanged();
                    SumItem();
                    SumWeight();
                }
                else
                {
                    textBox_Retail_item11.Text = "";
                    textBox_Retail_Price11.Text = "";
                    textBox_Retail_Type11.Text = "";
                    textBox_Retail_PriceAmount11.Text = "";
                    combo_Retail_Item12.Enabled = false ;
                    textBox_Retail_item12.Enabled = false ;
                    textBox_Retail_Count12.Enabled = false ;
                    textBox_Retail_Type12.Enabled = false ;
                    textBox_Retail_Price12.Enabled = false ;
                    textBox_Retail_PriceAmount12.Enabled = false ;
                    AmountChanged();
                    SumItem();
                    SumWeight();
                }

            }
            catch (Exception er)
            {
                MessageBox.Show("Error : " + er);
            }

        }

        private void textBox_Retail_Count11_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string textPrice = "";
                double douPrice, amount;
                int Count;
                textPrice = textBox_Retail_Price11.Text.ToString() == "" ? "0.00" : textBox_Retail_Price11.Text.ToString();
                douPrice = Double.Parse(textPrice);
                Count = textBox_Retail_Count11.Text.ToString() == "" ? 0 : Int32.Parse(textBox_Retail_Count11.Text.ToString());
                amount = Count * douPrice;
                textBox_Retail_PriceAmount11.Text = amount.ToString("N2");
                AmountChanged();
                SumCount();
                SumWeight();
            }
            catch (Exception er)
            {

                MessageBox.Show("Error :  " + er);
            }
        }

        private void combo_Retail_Item12_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Object selectedItem = combo_Retail_Item12.SelectedItem;

                if (combo_Retail_Item12.Text != "Select Item")
                {
                    textBox_Retail_item12.Text = Select_Des_Item(selectedItem.ToString()) + " " + Select_Size_Item(selectedItem.ToString());

                    textBox_Retail_Price12.Text = Select_Price_Item(selectedItem.ToString());
                    textBox_Retail_Type12.Text = Select_Type_Item(selectedItem.ToString());
                    combo_Retail_Item13.Enabled = true;
                    textBox_Retail_item13.Enabled = true;
                    textBox_Retail_Count13.Enabled = true;
                    textBox_Retail_Type13.Enabled = true;
                    textBox_Retail_Price13.Enabled = true;
                    textBox_Retail_PriceAmount13.Enabled = true;
                    AmountChanged();
                    SumItem();
                    SumWeight();
                }
                else
                {
                    textBox_Retail_item12.Text = "";
                    textBox_Retail_Price12.Text = "";
                    textBox_Retail_Type12.Text = "";
                    textBox_Retail_PriceAmount12.Text = "";
                    combo_Retail_Item13.Enabled = false ;
                    textBox_Retail_item13.Enabled = false ;
                    textBox_Retail_Count13.Enabled = false ;
                    textBox_Retail_Type13.Enabled = false ;
                    textBox_Retail_Price13.Enabled = false ;
                    textBox_Retail_PriceAmount13.Enabled = false ;
                    AmountChanged();
                    SumItem();
                    SumWeight();
                }

            }
            catch (Exception er)
            {
                MessageBox.Show("Error : " + er);
            }

        }

        private void textBox_Retail_Count12_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string textPrice = "";
                double douPrice, amount;
                int Count;
                textPrice = textBox_Retail_Price12.Text.ToString() == "" ? "0.00" : textBox_Retail_Price12.Text.ToString();
                douPrice = Double.Parse(textPrice);
                Count = textBox_Retail_Count12.Text.ToString() == "" ? 0 : Int32.Parse(textBox_Retail_Count12.Text.ToString());
                amount = Count * douPrice;
                textBox_Retail_PriceAmount12.Text = amount.ToString("N2");
                AmountChanged();
                SumCount();
                SumWeight();
            }
            catch (Exception er)
            {

                MessageBox.Show("Error :  " + er);
            }
        }

        private void combo_Retail_Item13_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Object selectedItem = combo_Retail_Item13.SelectedItem;

                if (combo_Retail_Item13.Text != "Select Item")
                {
                    textBox_Retail_item13.Text = Select_Des_Item(selectedItem.ToString()) + " " + Select_Size_Item(selectedItem.ToString());

                    textBox_Retail_Price13.Text = Select_Price_Item(selectedItem.ToString());
                    textBox_Retail_Type13.Text = Select_Type_Item(selectedItem.ToString());
                    combo_Retail_Item14.Enabled = true;
                    textBox_Retail_item14.Enabled = true;
                    textBox_Retail_Count14.Enabled = true;
                    textBox_Retail_Type14.Enabled = true;
                    textBox_Retail_Price14.Enabled = true;
                    textBox_Retail_PriceAmount14.Enabled = true;
                    AmountChanged();
                    SumItem();
                    SumWeight();
                }
                else
                {
                    textBox_Retail_item13.Text = "";
                    textBox_Retail_Price13.Text = "";
                    textBox_Retail_Type13.Text = "";
                    textBox_Retail_PriceAmount13.Text = "";
                    combo_Retail_Item14.Enabled = false ;
                    textBox_Retail_item14.Enabled = false ;
                    textBox_Retail_Count14.Enabled = false ;
                    textBox_Retail_Type14.Enabled = false ;
                    textBox_Retail_Price14.Enabled = false ;
                    textBox_Retail_PriceAmount14.Enabled = false ;
                    AmountChanged();
                    SumItem();
                    SumWeight();
                }

            }
            catch (Exception er)
            {
                MessageBox.Show("Error : " + er);
            }

        }

        private void textBox_Retail_Count13_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string textPrice = "";
                double douPrice, amount;
                int Count;
                textPrice = textBox_Retail_Price13.Text.ToString() == "" ? "0.00" : textBox_Retail_Price13.Text.ToString();
                douPrice = Double.Parse(textPrice);
                Count = textBox_Retail_Count13.Text.ToString() == "" ? 0 : Int32.Parse(textBox_Retail_Count13.Text.ToString());
                amount = Count * douPrice;
                textBox_Retail_PriceAmount13.Text = amount.ToString("N2");
                AmountChanged();
                SumCount();
                SumWeight();
            }
            catch (Exception er)
            {

                MessageBox.Show("Error :  " + er);
            }
        }

        private void combo_Retail_Item14_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Object selectedItem = combo_Retail_Item14.SelectedItem;

                if (combo_Retail_Item14.Text != "Select Item")
                {
                    textBox_Retail_item14.Text = Select_Des_Item(selectedItem.ToString()) + " " + Select_Size_Item(selectedItem.ToString());

                    textBox_Retail_Price14.Text = Select_Price_Item(selectedItem.ToString());
                    textBox_Retail_Type14.Text = Select_Type_Item(selectedItem.ToString());
                    combo_Retail_Item15.Enabled = true;
                    textBox_Retail_item15.Enabled = true;
                    textBox_Retail_Count15.Enabled = true;
                    textBox_Retail_Type15.Enabled = true;
                    textBox_Retail_Price15.Enabled = true;
                    textBox_Retail_PriceAmount15.Enabled = true;
                    AmountChanged();
                    SumItem();
                    SumWeight();
                }
                else
                {
                    textBox_Retail_item14.Text = "";
                    textBox_Retail_Price14.Text = "";
                    textBox_Retail_Type14.Text = "";
                    textBox_Retail_PriceAmount14.Text = "";
                    combo_Retail_Item15.Enabled = false ;
                    textBox_Retail_item15.Enabled = false ;
                    textBox_Retail_Count15.Enabled = false ;
                    textBox_Retail_Type15.Enabled = false ;
                    textBox_Retail_Price15.Enabled = false ;
                    textBox_Retail_PriceAmount15.Enabled = false ;
                    AmountChanged();
                    SumItem();
                    SumWeight();
                }

            }
            catch (Exception er)
            {
                MessageBox.Show("Error : " + er);
            }

        }

        private void textBox_Retail_Count14_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string textPrice = "";
                double douPrice, amount;
                int Count;
                textPrice = textBox_Retail_Price14.Text.ToString() == "" ? "0.00" : textBox_Retail_Price14.Text.ToString();
                douPrice = Double.Parse(textPrice);
                Count = textBox_Retail_Count14.Text.ToString() == "" ? 0 : Int32.Parse(textBox_Retail_Count14.Text.ToString());
                amount = Count * douPrice;
                textBox_Retail_PriceAmount14.Text = amount.ToString("N2");
                AmountChanged();
                SumCount();
                SumWeight();
            }
            catch (Exception er)
            {

                MessageBox.Show("Error :  " + er);
            }
        }

        private void combo_Retail_Item15_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Object selectedItem = combo_Retail_Item15.SelectedItem;

                if (combo_Retail_Item15.Text != "Select Item")
                {
                    textBox_Retail_item15.Text = Select_Des_Item(selectedItem.ToString()) + " " + Select_Size_Item(selectedItem.ToString());

                    textBox_Retail_Price15.Text = Select_Price_Item(selectedItem.ToString());
                    textBox_Retail_Type15.Text = Select_Type_Item(selectedItem.ToString());
                    AmountChanged();
                    SumItem();
                    SumWeight();
                }
                else
                {
                    textBox_Retail_item15.Text = "";
                    textBox_Retail_Price15.Text = "";
                    textBox_Retail_Type15.Text = "";
                    textBox_Retail_PriceAmount15.Text = "";
                    AmountChanged();
                    SumItem();
                    SumWeight();
                }

            }
            catch (Exception er)
            {
                MessageBox.Show("Error : " + er);
            }

        }

        private void textBox_Retail_Count15_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string textPrice = "";
                double douPrice, amount;
                int Count;
                textPrice = textBox_Retail_Price15.Text.ToString() == "" ? "0.00" : textBox_Retail_Price15.Text.ToString();
                douPrice = Double.Parse(textPrice);
                Count = textBox_Retail_Count15.Text.ToString() == "" ? 0 : Int32.Parse(textBox_Retail_Count15.Text.ToString());
                amount = Count * douPrice;
                textBox_Retail_PriceAmount15.Text = amount.ToString("N2");
                AmountChanged();
                SumCount();
                SumWeight();
            }
            catch (Exception er)
            {

                MessageBox.Show("Error :  " + er);
            }
        }

        private void textBox_Retail_Price2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Object selectedItem = combo_Retail_Item2.SelectedItem;
                string textCount = "";
                double douCount, amount, Price;
                double costPrice;
                costPrice = Select_Cost_Price(selectedItem.ToString()) == "" ? 0.00 : Double.Parse(Select_Cost_Price(selectedItem.ToString()));
                textCount = textBox_Retail_Count2.Text.ToString() == "" ? "0.00" : textBox_Retail_Count2.Text.ToString();
                douCount = Double.Parse(textCount);
                Price = textBox_Retail_Price2.Text.ToString() == "" ? 0.00 : Double.Parse(textBox_Retail_Price2.Text.ToString());
                amount = douCount * Price;
                if (Price >= costPrice)
                {
                    amount = douCount * Price;
                    textBox_Retail_PriceAmount2.Text = amount.ToString("N2");
                }
                else
                {
                    MessageBox.Show("*****ราคาขายห้ามต่ำกว่าต้นทุน*****");
                    textBox_Retail_Price2.Text = Select_Price_Item(selectedItem.ToString());
                    Check_PriceRetail = false;
                }
                AmountChanged();

            }
            catch (Exception er)
            {
                MessageBox.Show("Error : " + er);
            }
        }

        private void textBox_Retail_Price3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Object selectedItem = combo_Retail_Item3.SelectedItem;
                string textCount = "";
                double douCount, amount, Price;
                double costPrice;
                costPrice = Select_Cost_Price(selectedItem.ToString()) == "" ? 0.00 : Double.Parse(Select_Cost_Price(selectedItem.ToString()));
                textCount = textBox_Retail_Count3.Text.ToString() == "" ? "0.00" : textBox_Retail_Count3.Text.ToString();
                douCount = Double.Parse(textCount);
                Price = textBox_Retail_Price3.Text.ToString() == "" ? 0.00 : Double.Parse(textBox_Retail_Price3.Text.ToString());
                amount = douCount * Price;
                if (Price >= costPrice)
                {
                    amount = douCount * Price;
                    textBox_Retail_PriceAmount3.Text = amount.ToString("N2");
                }
                else
                {
                    MessageBox.Show("*****ราคาขายห้ามต่ำกว่าต้นทุน*****");
                    textBox_Retail_Price3.Text = Select_Price_Item(selectedItem.ToString());
                    Check_PriceRetail = false;
                }
                AmountChanged();

            }
            catch (Exception er)
            {
                MessageBox.Show("Error : " + er);
            }
        }

        private void textBox_Retail_Price4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Object selectedItem = combo_Retail_Item4.SelectedItem;
                string textCount = "";
                double douCount, amount, Price;
                double costPrice;
                costPrice = Select_Cost_Price(selectedItem.ToString()) == "" ? 0.00 : Double.Parse(Select_Cost_Price(selectedItem.ToString()));
                textCount = textBox_Retail_Count4.Text.ToString() == "" ? "0.00" : textBox_Retail_Count4.Text.ToString();
                douCount = Double.Parse(textCount);
                Price = textBox_Retail_Price4.Text.ToString() == "" ? 0.00 : Double.Parse(textBox_Retail_Price4.Text.ToString());
                amount = douCount * Price;
                if (Price >= costPrice)
                {
                    amount = douCount * Price;
                    textBox_Retail_PriceAmount4.Text = amount.ToString("N2");
                }
                else
                {
                    MessageBox.Show("*****ราคาขายห้ามต่ำกว่าต้นทุน*****");
                    textBox_Retail_Price4.Text = Select_Price_Item(selectedItem.ToString());
                    Check_PriceRetail = false;
                }
                AmountChanged();

            }
            catch (Exception er)
            {
                MessageBox.Show("Error : " + er);
            }
        }

        private void textBox_Retail_Price5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Object selectedItem = combo_Retail_Item5.SelectedItem;
                string textCount = "";
                double douCount, amount, Price;
                double costPrice;
                costPrice = Select_Cost_Price(selectedItem.ToString()) == "" ? 0.00 : Double.Parse(Select_Cost_Price(selectedItem.ToString()));
                textCount = textBox_Retail_Count5.Text.ToString() == "" ? "0.00" : textBox_Retail_Count5.Text.ToString();
                douCount = Double.Parse(textCount);
                Price = textBox_Retail_Price5.Text.ToString() == "" ? 0.00 : Double.Parse(textBox_Retail_Price5.Text.ToString());
                amount = douCount * Price;
                if (Price >= costPrice)
                {
                    amount = douCount * Price;
                    textBox_Retail_PriceAmount5.Text = amount.ToString("N2");
                }
                else
                {
                    MessageBox.Show("*****ราคาขายห้ามต่ำกว่าต้นทุน*****");
                    textBox_Retail_Price5.Text = Select_Price_Item(selectedItem.ToString());
                    Check_PriceRetail = false;
                }
                AmountChanged();

            }
            catch (Exception er)
            {
                MessageBox.Show("Error : " + er);
            }
        }

        private void textBox_Retail_Price6_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Object selectedItem = combo_Retail_Item6.SelectedItem;
                string textCount = "";
                double douCount, amount, Price;
                double costPrice;
                costPrice = Select_Cost_Price(selectedItem.ToString()) == "" ? 0.00 : Double.Parse(Select_Cost_Price(selectedItem.ToString()));
                textCount = textBox_Retail_Count6.Text.ToString() == "" ? "0.00" : textBox_Retail_Count6.Text.ToString();
                douCount = Double.Parse(textCount);
                Price = textBox_Retail_Price6.Text.ToString() == "" ? 0.00 : Double.Parse(textBox_Retail_Price6.Text.ToString());
                amount = douCount * Price;
                if (Price >= costPrice)
                {
                    amount = douCount * Price;
                    textBox_Retail_PriceAmount6.Text = amount.ToString("N2");
                }
                else
                {
                    MessageBox.Show("*****ราคาขายห้ามต่ำกว่าต้นทุน*****");
                    textBox_Retail_Price6.Text = Select_Price_Item(selectedItem.ToString());
                    Check_PriceRetail = false;
                }
                AmountChanged();

            }
            catch (Exception er)
            {
                MessageBox.Show("Error : " + er);
            }
        }

        private void textBox_Retail_Price7_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Object selectedItem = combo_Retail_Item7.SelectedItem;
                string textCount = "";
                double douCount, amount, Price;
                double costPrice;
                costPrice = Select_Cost_Price(selectedItem.ToString()) == "" ? 0.00 : Double.Parse(Select_Cost_Price(selectedItem.ToString()));
                textCount = textBox_Retail_Count7.Text.ToString() == "" ? "0.00" : textBox_Retail_Count7.Text.ToString();
                douCount = Double.Parse(textCount);
                Price = textBox_Retail_Price7.Text.ToString() == "" ? 0.00 : Double.Parse(textBox_Retail_Price7.Text.ToString());
                amount = douCount * Price;
                if (Price >= costPrice)
                {
                    amount = douCount * Price;
                    textBox_Retail_PriceAmount7.Text = amount.ToString("N2");
                }
                else
                {
                    MessageBox.Show("*****ราคาขายห้ามต่ำกว่าต้นทุน*****");
                    textBox_Retail_Price7.Text = Select_Price_Item(selectedItem.ToString());
                    Check_PriceRetail = false;
                }
                AmountChanged();

            }
            catch (Exception er)
            {
                MessageBox.Show("Error : " + er);
            }
        }

        private void textBox_Retail_Price8_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Object selectedItem = combo_Retail_Item8.SelectedItem;
                string textCount = "";
                double douCount, amount, Price;
                double costPrice;
                costPrice = Select_Cost_Price(selectedItem.ToString()) == "" ? 0.00 : Double.Parse(Select_Cost_Price(selectedItem.ToString()));
                textCount = textBox_Retail_Count8.Text.ToString() == "" ? "0.00" : textBox_Retail_Count8.Text.ToString();
                douCount = Double.Parse(textCount);
                Price = textBox_Retail_Price8.Text.ToString() == "" ? 0.00 : Double.Parse(textBox_Retail_Price8.Text.ToString());
                amount = douCount * Price;
                if (Price >= costPrice)
                {
                    amount = douCount * Price;
                    textBox_Retail_PriceAmount8.Text = amount.ToString("N2");
                }
                else
                {
                    MessageBox.Show("*****ราคาขายห้ามต่ำกว่าต้นทุน*****");
                    textBox_Retail_Price8.Text = Select_Price_Item(selectedItem.ToString());
                    Check_PriceRetail = false;
                }
                AmountChanged();

            }
            catch (Exception er)
            {
                MessageBox.Show("Error : " + er);
            }
        }

        private void textBox_Retail_Price9_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Object selectedItem = combo_Retail_Item9.SelectedItem;
                string textCount = "";
                double douCount, amount, Price;
                double costPrice;
                costPrice = Select_Cost_Price(selectedItem.ToString()) == "" ? 0.00 : Double.Parse(Select_Cost_Price(selectedItem.ToString()));
                textCount = textBox_Retail_Count9.Text.ToString() == "" ? "0.00" : textBox_Retail_Count9.Text.ToString();
                douCount = Double.Parse(textCount);
                Price = textBox_Retail_Price9.Text.ToString() == "" ? 0.00 : Double.Parse(textBox_Retail_Price9.Text.ToString());
                amount = douCount * Price;
                if (Price >= costPrice)
                {
                    amount = douCount * Price;
                    textBox_Retail_PriceAmount9.Text = amount.ToString("N2");
                }
                else
                {
                    MessageBox.Show("*****ราคาขายห้ามต่ำกว่าต้นทุน*****");
                    textBox_Retail_Price9.Text = Select_Price_Item(selectedItem.ToString());
                    Check_PriceRetail = false;
                }
                AmountChanged();

            }
            catch (Exception er)
            {
                MessageBox.Show("Error : " + er);
            }
        }

        private void textBox_Retail_Price10_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Object selectedItem = combo_Retail_Item10.SelectedItem;
                string textCount = "";
                double douCount, amount, Price;
                double costPrice;
                costPrice = Select_Cost_Price(selectedItem.ToString()) == "" ? 0.00 : Double.Parse(Select_Cost_Price(selectedItem.ToString()));
                textCount = textBox_Retail_Count10.Text.ToString() == "" ? "0.00" : textBox_Retail_Count10.Text.ToString();
                douCount = Double.Parse(textCount);
                Price = textBox_Retail_Price10.Text.ToString() == "" ? 0.00 : Double.Parse(textBox_Retail_Price10.Text.ToString());
                amount = douCount * Price;
                if (Price >= costPrice)
                {
                    amount = douCount * Price;
                    textBox_Retail_PriceAmount10.Text = amount.ToString("N2");
                }
                else
                {
                    MessageBox.Show("*****ราคาขายห้ามต่ำกว่าต้นทุน*****");
                    textBox_Retail_Price10.Text = Select_Price_Item(selectedItem.ToString());
                    Check_PriceRetail = false;
                }
                AmountChanged();

            }
            catch (Exception er)
            {
                MessageBox.Show("Error : " + er);
            }
        }

        private void textBox_Retail_Price11_TextChanged(object sender, EventArgs e)
        {

            try
            {
                Object selectedItem = combo_Retail_Item11.SelectedItem;
                string textCount = "";
                double douCount, amount, Price;
                double costPrice;
                costPrice = Select_Cost_Price(selectedItem.ToString()) == "" ? 0.00 : Double.Parse(Select_Cost_Price(selectedItem.ToString()));
                textCount = textBox_Retail_Count11.Text.ToString() == "" ? "0.00" : textBox_Retail_Count11.Text.ToString();
                douCount = Double.Parse(textCount);
                Price = textBox_Retail_Price11.Text.ToString() == "" ? 0.00 : Double.Parse(textBox_Retail_Price11.Text.ToString());
                amount = douCount * Price;
                if (Price >= costPrice)
                {
                    amount = douCount * Price;
                    textBox_Retail_PriceAmount11.Text = amount.ToString("N2");
                }
                else
                {
                    MessageBox.Show("*****ราคาขายห้ามต่ำกว่าต้นทุน*****");
                    textBox_Retail_Price11.Text = Select_Price_Item(selectedItem.ToString());
                    Check_PriceRetail = false;
                }
                AmountChanged();

            }
            catch (Exception er)
            {
                MessageBox.Show("Error : " + er);
            }
        }

        private void textBox_Retail_Price12_TextChanged(object sender, EventArgs e)
        {

            try
            {
                Object selectedItem = combo_Retail_Item12.SelectedItem;
                string textCount = "";
                double douCount, amount, Price;
                double costPrice;
                costPrice = Select_Cost_Price(selectedItem.ToString()) == "" ? 0.00 : Double.Parse(Select_Cost_Price(selectedItem.ToString()));
                textCount = textBox_Retail_Count12.Text.ToString() == "" ? "0.00" : textBox_Retail_Count12.Text.ToString();
                douCount = Double.Parse(textCount);
                Price = textBox_Retail_Price12.Text.ToString() == "" ? 0.00 : Double.Parse(textBox_Retail_Price12.Text.ToString());
                amount = douCount * Price;
                if (Price >= costPrice)
                {
                    amount = douCount * Price;
                    textBox_Retail_PriceAmount12.Text = amount.ToString("N2");
                }
                else
                {
                    MessageBox.Show("*****ราคาขายห้ามต่ำกว่าต้นทุน*****");
                    textBox_Retail_Price12.Text = Select_Price_Item(selectedItem.ToString());
                    Check_PriceRetail = false;
                }
                AmountChanged();

            }
            catch (Exception er)
            {
                MessageBox.Show("Error : " + er);
            }
        }

        private void textBox_Retail_Price13_TextChanged(object sender, EventArgs e)
        {

            try
            {
                Object selectedItem = combo_Retail_Item13.SelectedItem;
                string textCount = "";
                double douCount, amount, Price;
                double costPrice;
                costPrice = Select_Cost_Price(selectedItem.ToString()) == "" ? 0.00 : Double.Parse(Select_Cost_Price(selectedItem.ToString()));
                textCount = textBox_Retail_Count13.Text.ToString() == "" ? "0.00" : textBox_Retail_Count13.Text.ToString();
                douCount = Double.Parse(textCount);
                Price = textBox_Retail_Price13.Text.ToString() == "" ? 0.00 : Double.Parse(textBox_Retail_Price13.Text.ToString());
                amount = douCount * Price;
                if (Price >= costPrice)
                {
                    amount = douCount * Price;
                    textBox_Retail_PriceAmount13.Text = amount.ToString("N2");
                }
                else
                {
                    MessageBox.Show("*****ราคาขายห้ามต่ำกว่าต้นทุน*****");
                    textBox_Retail_Price13.Text = Select_Price_Item(selectedItem.ToString());
                    Check_PriceRetail = false;
                }
                AmountChanged();

            }
            catch (Exception er)
            {
                MessageBox.Show("Error : " + er);
            }
        }

        private void textBox_Retail_Price14_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Object selectedItem = combo_Retail_Item14.SelectedItem;
                string textCount = "";
                double douCount, amount, Price;
                double costPrice;
                costPrice = Select_Cost_Price(selectedItem.ToString()) == "" ? 0.00 : Double.Parse(Select_Cost_Price(selectedItem.ToString()));
                textCount = textBox_Retail_Count14.Text.ToString() == "" ? "0.00" : textBox_Retail_Count14.Text.ToString();
                douCount = Double.Parse(textCount);
                Price = textBox_Retail_Price14.Text.ToString() == "" ? 0.00 : Double.Parse(textBox_Retail_Price14.Text.ToString());
                amount = douCount * Price;
                if (Price >= costPrice)
                {
                    amount = douCount * Price;
                    textBox_Retail_PriceAmount14.Text = amount.ToString("N2");
                }
                else
                {
                    MessageBox.Show("*****ราคาขายห้ามต่ำกว่าต้นทุน*****");
                    textBox_Retail_Price14.Text = Select_Price_Item(selectedItem.ToString());
                    Check_PriceRetail = false;
                }
                AmountChanged();

            }
            catch (Exception er)
            {
                MessageBox.Show("Error : " + er);
            }
        }

        private void textBox_Retail_Price15_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Object selectedItem = combo_Retail_Item15.SelectedItem;
                string textCount = "";
                double douCount, amount, Price;
                double costPrice;
                costPrice = Select_Cost_Price(selectedItem.ToString()) == "" ? 0.00 : Double.Parse(Select_Cost_Price(selectedItem.ToString()));
                textCount = textBox_Retail_Count15.Text.ToString() == "" ? "0.00" : textBox_Retail_Count15.Text.ToString();
                douCount = Double.Parse(textCount);
                Price = textBox_Retail_Price15.Text.ToString() == "" ? 0.00 : Double.Parse(textBox_Retail_Price15.Text.ToString());
                amount = douCount * Price;
                if (Price >= costPrice)
                {
                    amount = douCount * Price;
                    textBox_Retail_PriceAmount15.Text = amount.ToString("N2");
                }
                else
                {
                    MessageBox.Show("*****ราคาขายห้ามต่ำกว่าต้นทุน*****");
                    textBox_Retail_Price15.Text = Select_Price_Item(selectedItem.ToString());
                    Check_PriceRetail = false;
                }
                AmountChanged();

            }
            catch (Exception er)
            {
                MessageBox.Show("Error : " + er);
            }
        }




        private void button_Print_Click(object sender, EventArgs e)
        {
            InsertQryInvHeader();
            InsertQryInvDetail();
            InsertINV();
            InsertINVDetail();
            
            using(Print prt = new Print(Inv_QryHead,Inv_QryDetail))
            {
                prt.ShowDialog();
            }
        }

        private void textBox_Retail_PriceAmount5_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePickerRetail_ValueChanged(object sender, EventArgs e)
        {
           Console.WriteLine(Qry_Date());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            InsertQryInvHeader();
            InsertQryInvDetail();
            InsertINV();
            InsertINVDetail();

            using (Print7 prt = new Print7(Inv_QryHead, Inv_QryDetail))
            {
                prt.ShowDialog();
            }

            Inv_QryHead.Clear();
            Inv_QryDetail.Clear();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }
    }

}
