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
            if (Convert.ToDouble(bahtTxt) == 0)
                bahtTH = "ศูนย์บาทถ้วน";
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

        public void combo_Retail_Item1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Object selectedItem = combo_Retail_Item1.SelectedItem;
            textBox_Retail_item1.Text = Select_Des_Item(selectedItem.ToString()) +" "+ Select_Size_Item(selectedItem.ToString());
            textBox_Retail_Price1.Text = Select_Price_Item(selectedItem.ToString());
            textBox_Retail_Type1.Text = Select_Type_Item(selectedItem.ToString());

        }
        private void textBox_Retail_Count1_TextChanged(object sender, EventArgs e)
        {
            string textPrice ="";
            double douPrice, amount , Count;
            try
            {
                textPrice = textBox_Retail_Price1.Text.ToString() == "" ? "0.00" : textBox_Retail_Price1.Text.ToString();
                douPrice = Double.Parse(textPrice);
                Count = textBox_Retail_Count1.Text.ToString() == "" ? 0.00 : Double.Parse(textBox_Retail_Count1.Text.ToString());
                amount = Count * douPrice;
                textBox_Retail_PriceAmount1.Text = amount.ToString("N2");
            }
            catch(Exception er)
            {
                MessageBox.Show("Error :  " + er);
            }
        }

        private void combo_Retail_Item2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Object selectedItem = combo_Retail_Item2.SelectedItem;
            textBox_Retail_item2.Text = Select_Des_Item(selectedItem.ToString()) + " " + Select_Size_Item(selectedItem.ToString());
            textBox_Retail_Price2.Text = Select_Price_Item(selectedItem.ToString());
            textBox_Retail_Type2.Text = Select_Type_Item(selectedItem.ToString());
        }
        private void textBox_Retail_Count2_TextChanged(object sender, EventArgs e)
        {
            string textPrice = "";
            double douPrice, amount, Count;
            try
            {
                textPrice = textBox_Retail_Price2.Text.ToString() == "" ? "0.00" : textBox_Retail_Price2.Text.ToString();
                douPrice = Double.Parse(textPrice);
                Count = textBox_Retail_Count2.Text.ToString() == "" ? 0.00 : Double.Parse(textBox_Retail_Count2.Text.ToString());
                amount = Count * douPrice;
                textBox_Retail_PriceAmount2.Text = amount.ToString("N2");
            }
            catch (Exception er)
            {
                MessageBox.Show("Error :  " + er);
            }
        }

        private void combo_Retail_Item3_SelectedIndexChanged(object sender, EventArgs e)
        {
            Object selectedItem = combo_Retail_Item3.SelectedItem;
            textBox_Retail_item3.Text = Select_Des_Item(selectedItem.ToString()) + " " + Select_Size_Item(selectedItem.ToString());
            textBox_Retail_Price3.Text = Select_Price_Item(selectedItem.ToString());
            textBox_Retail_Type3.Text = Select_Type_Item(selectedItem.ToString());
        }

        private void textBox_Retail_Count3_TextChanged(object sender, EventArgs e)
        {
            string textPrice = "";
            double douPrice, amount, Count;
            try
            {
                textPrice = textBox_Retail_Price3.Text.ToString() == "" ? "0.00" : textBox_Retail_Price3.Text.ToString();
                douPrice = Double.Parse(textPrice);
                Count = textBox_Retail_Count3.Text.ToString() == "" ? 0.00 : Double.Parse(textBox_Retail_Count3.Text.ToString());
                amount = Count * douPrice;
                textBox_Retail_PriceAmount3.Text = amount.ToString("N2");
            }
            catch (Exception er)
            {
                MessageBox.Show("Error :  " + er);
            }
        }

        private void combo_Retail_Item4_SelectedIndexChanged(object sender, EventArgs e)
        {
            Object selectedItem = combo_Retail_Item4.SelectedItem;
            textBox_Retail_item4.Text = Select_Des_Item(selectedItem.ToString()) + " " + Select_Size_Item(selectedItem.ToString());
            textBox_Retail_Price4.Text = Select_Price_Item(selectedItem.ToString());
            textBox_Retail_Type4.Text = Select_Type_Item(selectedItem.ToString());
        }

        private void textBox_Retail_Count4_TextChanged(object sender, EventArgs e)
        {
            string textPrice = "";
            double douPrice, amount, Count;
            try
            {
                textPrice = textBox_Retail_Price4.Text.ToString() == "" ? "0.00" : textBox_Retail_Price4.Text.ToString();
                douPrice = Double.Parse(textPrice);
                Count = textBox_Retail_Count4.Text.ToString() == "" ? 0.00 : Double.Parse(textBox_Retail_Count4.Text.ToString());
                amount = Count * douPrice;
                textBox_Retail_PriceAmount4.Text = amount.ToString("N2");
            }
            catch (Exception er)
            {
                MessageBox.Show("Error :  " + er);
            }
        }

        private void combo_Retail_Item5_SelectedIndexChanged(object sender, EventArgs e)
        {
            Object selectedItem = combo_Retail_Item5.SelectedItem;
            textBox_Retail_item5.Text = Select_Des_Item(selectedItem.ToString()) + " " + Select_Size_Item(selectedItem.ToString());
            textBox_Retail_Price5.Text = Select_Price_Item(selectedItem.ToString());
            textBox_Retail_Type5.Text = Select_Type_Item(selectedItem.ToString());
        }

        private void textBox_Retail_Count5_TextChanged(object sender, EventArgs e)
        {
            string textPrice = "";
            double douPrice, amount, Count;
            try
            {
                textPrice = textBox_Retail_Price5.Text.ToString() == "" ? "0.00" : textBox_Retail_Price5.Text.ToString();
                douPrice = Double.Parse(textPrice);
                Count = textBox_Retail_Count5.Text.ToString() == "" ? 0.00 : Double.Parse(textBox_Retail_Count5.Text.ToString());
                amount = Count * douPrice;
                textBox_Retail_PriceAmount5.Text = amount.ToString("N2");
            }
            catch (Exception er)
            {
                MessageBox.Show("Error :  " + er);
            }
        }

        private void combo_Retail_Item6_SelectedIndexChanged(object sender, EventArgs e)
        {
            Object selectedItem = combo_Retail_Item6.SelectedItem;
            textBox_Retail_item6.Text = Select_Des_Item(selectedItem.ToString()) + " " + Select_Size_Item(selectedItem.ToString());
            textBox_Retail_Price6.Text = Select_Price_Item(selectedItem.ToString());
            textBox_Retail_Type6.Text = Select_Type_Item(selectedItem.ToString());
        }

        private void textBox_Retail_Count6_TextChanged(object sender, EventArgs e)
        {
            string textPrice = "";
            double douPrice, amount, Count;
            try
            {
                textPrice = textBox_Retail_Price6.Text.ToString() == "" ? "0.00" : textBox_Retail_Price6.Text.ToString();
                douPrice = Double.Parse(textPrice);
                Count = textBox_Retail_Count6.Text.ToString() == "" ? 0.00 : Double.Parse(textBox_Retail_Count6.Text.ToString());
                amount = Count * douPrice;
                textBox_Retail_PriceAmount6.Text = amount.ToString("N2");
            }
            catch (Exception er)
            {
                MessageBox.Show("Error :  " + er);
            }
        }

        private void combo_Retail_Item7_SelectedIndexChanged(object sender, EventArgs e)
        {
            Object selectedItem = combo_Retail_Item7.SelectedItem;
            textBox_Retail_item7.Text = Select_Des_Item(selectedItem.ToString()) + " " + Select_Size_Item(selectedItem.ToString());
            textBox_Retail_Price7.Text = Select_Price_Item(selectedItem.ToString());
            textBox_Retail_Type7.Text = Select_Type_Item(selectedItem.ToString());
        }

        private void textBox_Retail_Count7_TextChanged(object sender, EventArgs e)
        {
            string textPrice = "";
            double douPrice, amount, Count;
            try
            {
                textPrice = textBox_Retail_Price7.Text.ToString() == "" ? "0.00" : textBox_Retail_Price7.Text.ToString();
                douPrice = Double.Parse(textPrice);
                Count = textBox_Retail_Count7.Text.ToString() == "" ? 0.00 : Double.Parse(textBox_Retail_Count7.Text.ToString());
                amount = Count * douPrice;
                textBox_Retail_PriceAmount7.Text = amount.ToString("N2");
            }
            catch (Exception er)
            {
                MessageBox.Show("Error :  " + er);
            }
        }
        private void combo_Retail_Item8_SelectedIndexChanged(object sender, EventArgs e)
        {
            Object selectedItem = combo_Retail_Item8.SelectedItem;
            textBox_Retail_item8.Text = Select_Des_Item(selectedItem.ToString()) + " " + Select_Size_Item(selectedItem.ToString());
            textBox_Retail_Price8.Text = Select_Price_Item(selectedItem.ToString());
            textBox_Retail_Type8.Text = Select_Type_Item(selectedItem.ToString());
        }
        private void textBox_Retail_Count8_TextChanged(object sender, EventArgs e)
        {
            string textPrice = "";
            double douPrice, amount, Count;
            try
            {
                textPrice = textBox_Retail_Price8.Text.ToString() == "" ? "0.00" : textBox_Retail_Price8.Text.ToString();
                douPrice = Double.Parse(textPrice);
                Count = textBox_Retail_Count8.Text.ToString() == "" ? 0.00 : Double.Parse(textBox_Retail_Count8.Text.ToString());
                amount = Count * douPrice;
                textBox_Retail_PriceAmount8.Text = amount.ToString("N2");
            }
            catch (Exception er)
            {
                MessageBox.Show("Error :  " + er);
            }
        }
        private void combo_Retail_Item9_SelectedIndexChanged(object sender, EventArgs e)
        {
            Object selectedItem = combo_Retail_Item9.SelectedItem;
            textBox_Retail_item9.Text = Select_Des_Item(selectedItem.ToString()) + " " + Select_Size_Item(selectedItem.ToString());
            textBox_Retail_Price9.Text = Select_Price_Item(selectedItem.ToString());
            textBox_Retail_Type9.Text = Select_Type_Item(selectedItem.ToString());
        }
        private void textBox_Retail_Count9_TextChanged(object sender, EventArgs e)
        {
            string textPrice = "";
            double douPrice, amount, Count;
            try
            {
                textPrice = textBox_Retail_Price9.Text.ToString() == "" ? "0.00" : textBox_Retail_Price9.Text.ToString();
                douPrice = Double.Parse(textPrice);
                Count = textBox_Retail_Count9.Text.ToString() == "" ? 0.00 : Double.Parse(textBox_Retail_Count9.Text.ToString());
                amount = Count * douPrice;
                textBox_Retail_PriceAmount9.Text = amount.ToString("N2");
            }
            catch (Exception er)
            {
                MessageBox.Show("Error :  " + er);
            }
        }
        private void combo_Retail_Item10_SelectedIndexChanged(object sender, EventArgs e)
        {
            Object selectedItem = combo_Retail_Item10.SelectedItem;
            textBox_Retail_item10.Text = Select_Des_Item(selectedItem.ToString()) + " " + Select_Size_Item(selectedItem.ToString());
            textBox_Retail_Price10.Text = Select_Price_Item(selectedItem.ToString());
            textBox_Retail_Type10.Text = Select_Type_Item(selectedItem.ToString());
        }
        private void textBox_Retail_Count10_TextChanged(object sender, EventArgs e)
        {
            string textPrice = "";
            double douPrice, amount, Count;
            try
            {
                textPrice = textBox_Retail_Price10.Text.ToString() == "" ? "0.00" : textBox_Retail_Price10.Text.ToString();
                douPrice = Double.Parse(textPrice);
                Count = textBox_Retail_Count10.Text.ToString() == "" ? 0.00 : Double.Parse(textBox_Retail_Count10.Text.ToString());
                amount = Count * douPrice;
                textBox_Retail_PriceAmount10.Text = amount.ToString("N2");
            }
            catch (Exception er)
            {
                MessageBox.Show("Error :  " + er);
            }
        }

        private void combo_Retail_Item11_SelectedIndexChanged(object sender, EventArgs e)
        {
            Object selectedItem = combo_Retail_Item11.SelectedItem;
            textBox_Retail_item11.Text = Select_Des_Item(selectedItem.ToString()) + " " + Select_Size_Item(selectedItem.ToString());
            textBox_Retail_Price11.Text = Select_Price_Item(selectedItem.ToString());
            textBox_Retail_Type11.Text = Select_Type_Item(selectedItem.ToString());
        }

        private void textBox_Retail_Count11_TextChanged(object sender, EventArgs e)
        {
            string textPrice = "";
            double douPrice, amount, Count;
            try
            {
                textPrice = textBox_Retail_Price11.Text.ToString() == "" ? "0.00" : textBox_Retail_Price11.Text.ToString();
                douPrice = Double.Parse(textPrice);
                Count = textBox_Retail_Count11.Text.ToString() == "" ? 0.00 : Double.Parse(textBox_Retail_Count11.Text.ToString());
                amount = Count * douPrice;
                textBox_Retail_PriceAmount11.Text = amount.ToString("N2");
            }
            catch (Exception er)
            {
                MessageBox.Show("Error :  " + er);
            }
        }

        private void combo_Retail_Item12_SelectedIndexChanged(object sender, EventArgs e)
        {
            Object selectedItem = combo_Retail_Item12.SelectedItem;
            textBox_Retail_item12.Text = Select_Des_Item(selectedItem.ToString()) + " " + Select_Size_Item(selectedItem.ToString());
            textBox_Retail_Price12.Text = Select_Price_Item(selectedItem.ToString());
            textBox_Retail_Type12.Text = Select_Type_Item(selectedItem.ToString());
        }

        private void textBox_Retail_Count12_TextChanged(object sender, EventArgs e)
        {
            string textPrice = "";
            double douPrice, amount, Count;
            try
            {
                textPrice = textBox_Retail_Price12.Text.ToString() == "" ? "0.00" : textBox_Retail_Price12.Text.ToString();
                douPrice = Double.Parse(textPrice);
                Count = textBox_Retail_Count12.Text.ToString() == "" ? 0.00 : Double.Parse(textBox_Retail_Count12.Text.ToString());
                amount = Count * douPrice;
                textBox_Retail_PriceAmount12.Text = amount.ToString("N2");
            }
            catch (Exception er)
            {
                MessageBox.Show("Error :  " + er);
            }
        }

        private void combo_Retail_Item13_SelectedIndexChanged(object sender, EventArgs e)
        {
            Object selectedItem = combo_Retail_Item13.SelectedItem;
            textBox_Retail_item13.Text = Select_Des_Item(selectedItem.ToString()) + " " + Select_Size_Item(selectedItem.ToString());
            textBox_Retail_Price13.Text = Select_Price_Item(selectedItem.ToString());
            textBox_Retail_Type13.Text = Select_Type_Item(selectedItem.ToString());
        }

        private void textBox_Retail_Count13_TextChanged(object sender, EventArgs e)
        {
            string textPrice = "";
            double douPrice, amount, Count;
            try
            {
                textPrice = textBox_Retail_Price13.Text.ToString() == "" ? "0.00" : textBox_Retail_Price13.Text.ToString();
                douPrice = Double.Parse(textPrice);
                Count = textBox_Retail_Count13.Text.ToString() == "" ? 0.00 : Double.Parse(textBox_Retail_Count13.Text.ToString());
                amount = Count * douPrice;
                textBox_Retail_PriceAmount13.Text = amount.ToString("N2");
            }
            catch (Exception er)
            {
                MessageBox.Show("Error :  " + er);
            }
        }

        private void combo_Retail_Item14_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            Object selectedItem = combo_Retail_Item14.SelectedItem;
            textBox_Retail_item14.Text = Select_Des_Item(selectedItem.ToString()) + " " + Select_Size_Item(selectedItem.ToString());
            textBox_Retail_Price14.Text = Select_Price_Item(selectedItem.ToString());
            textBox_Retail_Type14.Text = Select_Type_Item(selectedItem.ToString());
        }

        private void textBox_Retail_Count14_TextChanged(object sender, EventArgs e)
        {
            string textPrice = "";
            double douPrice, amount, Count;
            try
            {
                textPrice = textBox_Retail_Price14.Text.ToString() == "" ? "0.00" : textBox_Retail_Price14.Text.ToString();
                douPrice = Double.Parse(textPrice);
                Count = textBox_Retail_Count14.Text.ToString() == "" ? 0.00 : Double.Parse(textBox_Retail_Count14.Text.ToString());
                amount = Count * douPrice;
                textBox_Retail_PriceAmount14.Text = amount.ToString("N2");
            }
            catch (Exception er)
            {
                MessageBox.Show("Error :  " + er);
            }
        }

        private void combo_Retail_Item15_SelectedIndexChanged(object sender, EventArgs e)
        {
            Object selectedItem = combo_Retail_Item15.SelectedItem;
            textBox_Retail_item15.Text = Select_Des_Item(selectedItem.ToString()) + " " + Select_Size_Item(selectedItem.ToString());
            textBox_Retail_Price15.Text = Select_Price_Item(selectedItem.ToString());
            textBox_Retail_Type15.Text = Select_Type_Item(selectedItem.ToString());
        }

        private void textBox_Retail_Count15_TextChanged(object sender, EventArgs e)
        {
            string textPrice = "";
            double douPrice, amount, Count;
            try
            {
                textPrice = textBox_Retail_Price15.Text.ToString() == "" ? "0.00" : textBox_Retail_Price15.Text.ToString();
                douPrice = Double.Parse(textPrice);
                Count = textBox_Retail_Count15.Text.ToString() == "" ? 0.00 : Double.Parse(textBox_Retail_Count15.Text.ToString());
                amount = Count * douPrice;
                textBox_Retail_PriceAmount15.Text = amount.ToString("N2");
            }
            catch (Exception er)
            {
                MessageBox.Show("Error :  " + er);
            }
        }
    }
    
    
}
