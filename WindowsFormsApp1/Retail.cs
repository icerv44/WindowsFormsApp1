﻿using System;
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

namespace WindowsFormsApp1
{
    public partial class Retail : Form
    {
        MySqlConnection con = new MySqlConnection("server = localhost; database = invoice; username = root; password=; charset=utf8");
        MySqlCommand command;
        MySqlDataReader mdr;

        public Retail()
        {
            InitializeComponent();
        }
        List<Qury> Inv_Qry = new List<Qury>();
        public void Set_Inv()
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


            }

        public void FillCombobox()
        { 
            string query = "SELECT ID,Name,Address  FROM customers";
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
            }
        }
        public void FillComboboxItem()
        {
            string query = "SELECT `ID`, `Code`, `Description`, `Size`, `Weight`, `Cost_price`, `Whole_Price`, `Retail_Price`, `Type_Count`, `Amount`, `Update_Date` " +
                           "FROM `goods`";
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
            }
        }

        public void Qury_Select_Customer()
        {
            string query = "SELECT Name  FROM customers";

            MySqlDataAdapter data = new MySqlDataAdapter(query, con);

            DataTable dt = new DataTable();

            data.Fill(dt);

            comboBox_Name.Items.Add("");

        }
        private void Retail_Load(object sender, EventArgs e)
        {

            FillCombobox();
            FillComboboxItem();
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
            con.Open();
            string query = "SELECT address  FROM customers where Name ='"+ name+"'";
            /*
            MySqlDataAdapter data = new MySqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            data.Fill(dt);
            textBox_CusAddress.Text = data.ToString();*/
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
            con.Open();
            string query = "SELECT  `Description` FROM `goods` WHERE Code = '" + Des + "'";
            string str = "";
            try
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
            return (str);

        }
        public string Select_Price_Item(string Code)
        {
            con.Open();
            string query = "SELECT  `Retail_Price` FROM `goods` WHERE Code = '" + Code + "'";
            string str = "";
            try
            {
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

            return integer.ToString("N2");
        }
        public string Select_Size_Item(string Code)
        {
            con.Open();
            string query = "SELECT  `Size` FROM `goods` WHERE Code = '" + Code + "'";
            string str = "";
            try
            {
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
            return str;
        }

        public string Select_Type_Item(string Code)
        {
            con.Open();
            string query = "SELECT  `Type_Count` FROM `goods` WHERE Code = '" + Code + "'";
            string str = "";
            try
            {
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
            return str;
        }
        public string Select_Cost_Price(string Code)
        {
            con.Open();
            string query = "SELECT  `Cost_price` FROM `goods` WHERE Code = '" + Code + "'";
            string str = "";
            try
            {
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

            return integer.ToString("N2");
        }


        public int Select_Weight(string Item)
        {
            int weight=0;

            if (Item != "Select Item")
            {
                con.Open();
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
               
                weight = str == "" ? 0 : Int32.Parse(str);

                
            }

            return weight;

           
        }


        public void SumWeight()
        {
            int Item1;
            int Sum;
            int Count1;
            Item1 = Select_Weight(combo_Retail_Item1.Text);
            Count1 = textBox_Retail_Count1.Text.ToString() == "" ? 0 : Int32.Parse(textBox_Retail_Count1.Text.ToString());

            Sum = (Item1 * Count1);

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
            if (combo_Retail_Item1.Text != "Select Item")
            {
                i = i + 1;
            }  if (combo_Retail_Item2.Text != "Select Item")
            {
                i = i + 1;
            } if (combo_Retail_Item3.Text != "Select Item")
            {
                i = i + 1;
            } if (combo_Retail_Item4.Text != "Select Item")
            {
                i = i + 1;
            } if (combo_Retail_Item5.Text != "Select Item")
            {
                i = i + 1;
            } if (combo_Retail_Item6.Text != "Select Item")
            {
                i = i + 1;
            } if (combo_Retail_Item7.Text != "Select Item")
            {
                i = i + 1;
            } if (combo_Retail_Item8.Text != "Select Item")
            {
                i = i + 1;
            } if (combo_Retail_Item9.Text != "Select Item")
            {
                i = i + 1;
            } if (combo_Retail_Item10.Text != "Select Item")
            {
                i = i + 1;
            } if (combo_Retail_Item11.Text != "Select Item")
            {
                i = i + 1;
            } if (combo_Retail_Item12.Text != "Select Item")
            {
                i = i + 1;
            } if (combo_Retail_Item13.Text != "Select Item")
            {
                i = i + 1;
            } if (combo_Retail_Item14.Text != "Select Item")
            {
                i = i + 1;
            } if (combo_Retail_Item15.Text != "Select Item")
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
                Object selectedItem = combo_Retail_Item1.SelectedItem;
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
            string str1 = "str123";
            string str2 = "str234";

            

        }
    }

}
