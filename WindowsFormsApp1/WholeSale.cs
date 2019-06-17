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
    public partial class WholeSale : Form
    {
        MySqlConnection con = new MySqlConnection("server = localhost; database = invoice; username = root; password=; charset=utf8");
        MySqlCommand command;
        MySqlDataReader mdr;
        bool Check_PriceWhole = true;
        public WholeSale()
        {
            InitializeComponent();
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

        public string Select_Price_Item(string Code)
        {
            con.Open();
            string query = "SELECT  `Whole_Price` FROM `goods` WHERE Code = '" + Code + "'";
            string str = "";
            try
            {
                command = new MySqlCommand(query, con);
                mdr = command.ExecuteReader();
                while (mdr.Read())
                {
                    // comboBox_Name.Items.Add(mdr.GetString("Name"));
                    str = mdr.GetString("Whole_Price") == "" ? "0" : mdr.GetString("Whole_Price");
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
        public static string ThaiBaht(string txt)
        {
            string bahtTxt, n, bahtTH = "";
            double amount;
            try { amount = Convert.ToDouble(txt); }
            catch { amount = 0; }
            bahtTxt = amount.ToString("####.00");
            string[] num = { "ศูนย์", "หนึ่ง", "สอง", "สาม", "สี่", "ห้า", "หก", "เจ็ด", "แปด", "เก้า", "สิบ" };
            string[] rank = { "", "สิบ", "ร้อย", "พัน", "หมื่น", "แสน", "ล้าน", "สิบล้าน", "ร้อยล้าน" };
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
        public void AmountChanged()
        {
            double Amount1, Amount2, Amount3, Amount4, Amount5;
            double Amount6, Amount7, Amount8, Amount9, Amount10;
            double Amount11, Amount12, Amount13, Amount14, Amount15;
            double SumAmount;
            try
            {
                Amount1 = textBox_Whole_PriceAmount1.Text == "" ? 0.00 : Double.Parse(textBox_Whole_PriceAmount1.Text);
                Amount2 = textBox_Whole_PriceAmount2.Text == "" ? 0.00 : Double.Parse(textBox_Whole_PriceAmount2.Text);
                Amount3 = textBox_Whole_PriceAmount3.Text == "" ? 0.00 : Double.Parse(textBox_Whole_PriceAmount3.Text);
                Amount4 = textBox_Whole_PriceAmount4.Text == "" ? 0.00 : Double.Parse(textBox_Whole_PriceAmount4.Text);
                Amount5 = textBox_Whole_PriceAmount5.Text == "" ? 0.00 : Double.Parse(textBox_Whole_PriceAmount5.Text);
                Amount6 = textBox_Whole_PriceAmount6.Text == "" ? 0.00 : Double.Parse(textBox_Whole_PriceAmount6.Text);
                Amount7 = textBox_Whole_PriceAmount7.Text == "" ? 0.00 : Double.Parse(textBox_Whole_PriceAmount7.Text);
                Amount8 = textBox_Whole_PriceAmount8.Text == "" ? 0.00 : Double.Parse(textBox_Whole_PriceAmount8.Text);
                Amount9 = textBox_Whole_PriceAmount9.Text == "" ? 0.00 : Double.Parse(textBox_Whole_PriceAmount9.Text);
                Amount10 = textBox_Whole_PriceAmount10.Text == "" ? 0.00 : Double.Parse(textBox_Whole_PriceAmount10.Text);
                Amount11 = textBox_Whole_PriceAmount11.Text == "" ? 0.00 : Double.Parse(textBox_Whole_PriceAmount11.Text);
                Amount12 = textBox_Whole_PriceAmount12.Text == "" ? 0.00 : Double.Parse(textBox_Whole_PriceAmount12.Text);
                Amount13 = textBox_Whole_PriceAmount13.Text == "" ? 0.00 : Double.Parse(textBox_Whole_PriceAmount13.Text);
                Amount14 = textBox_Whole_PriceAmount14.Text == "" ? 0.00 : Double.Parse(textBox_Whole_PriceAmount14.Text);
                Amount15 = textBox_Whole_PriceAmount15.Text == "" ? 0.00 : Double.Parse(textBox_Whole_PriceAmount15.Text);
                SumAmount = Amount1 + Amount2 + Amount3 + Amount4 + Amount5 + Amount6 + Amount7 + Amount8 +
                            Amount9 + Amount10 + Amount11 + Amount12 + Amount13 + Amount14 + Amount15;
                textBox_Whole_Amount.Text = SumAmount.ToString("N2");
                textBox_Whole_ThaiPrice.Text = ThaiBaht(textBox_Whole_Amount.Text);
            }
            catch (Exception er)
            {
                MessageBox.Show("Error : " + er);
            }
        }
        public void Qury_Address_Customer(string name)
        {
            con.Open();
            string query = "SELECT address  FROM customers where Name ='" + name + "'";
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
        public void FillComboboxItem()
        {
            string query = "SELECT `ID`, `Code`, `Description`, `Size`, `Weight`, `Cost_price`, `Whole_Price`, `Whole_Price`, `Type_Count`, `Amount`, `Update_Date` " +
                           "FROM `goods`";
            try
            {

                con.Open();
                command = new MySqlCommand(query, con);
                mdr = command.ExecuteReader();

                while (mdr.Read())
                {
                    combo_Whole_Item1.Items.Add(mdr.GetString("Code"));
                    combo_Whole_Item2.Items.Add(mdr.GetString("Code"));
                    combo_Whole_Item3.Items.Add(mdr.GetString("Code"));
                    combo_Whole_Item4.Items.Add(mdr.GetString("Code"));
                    combo_Whole_Item5.Items.Add(mdr.GetString("Code"));
                    combo_Whole_Item6.Items.Add(mdr.GetString("Code"));
                    combo_Whole_Item7.Items.Add(mdr.GetString("Code"));
                    combo_Whole_Item8.Items.Add(mdr.GetString("Code"));
                    combo_Whole_Item9.Items.Add(mdr.GetString("Code"));
                    combo_Whole_Item10.Items.Add(mdr.GetString("Code"));
                    combo_Whole_Item11.Items.Add(mdr.GetString("Code"));
                    combo_Whole_Item12.Items.Add(mdr.GetString("Code"));
                    combo_Whole_Item13.Items.Add(mdr.GetString("Code"));
                    combo_Whole_Item14.Items.Add(mdr.GetString("Code"));
                    combo_Whole_Item15.Items.Add(mdr.GetString("Code"));
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
        public void SumItem()
        {
            int i = 0;
            if (combo_Whole_Item1.Text != "Select Item")
            {
                i = i + 1;
            }
            if (combo_Whole_Item2.Text != "Select Item")
            {
                i = i + 1;
            }
            if (combo_Whole_Item3.Text != "Select Item")
            {
                i = i + 1;
            }
            if (combo_Whole_Item4.Text != "Select Item")
            {
                i = i + 1;
            }
            if (combo_Whole_Item5.Text != "Select Item")
            {
                i = i + 1;
            }
            if (combo_Whole_Item6.Text != "Select Item")
            {
                i = i + 1;
            }
            if (combo_Whole_Item7.Text != "Select Item")
            {
                i = i + 1;
            }
            if (combo_Whole_Item8.Text != "Select Item")
            {
                i = i + 1;
            }
            if (combo_Whole_Item9.Text != "Select Item")
            {
                i = i + 1;
            }
            if (combo_Whole_Item10.Text != "Select Item")
            {
                i = i + 1;
            }
            if (combo_Whole_Item11.Text != "Select Item")
            {
                i = i + 1;
            }
            if (combo_Whole_Item12.Text != "Select Item")
            {
                i = i + 1;
            }
            if (combo_Whole_Item13.Text != "Select Item")
            {
                i = i + 1;
            }
            if (combo_Whole_Item14.Text != "Select Item")
            {
                i = i + 1;
            }
            if (combo_Whole_Item15.Text != "Select Item")
            {
                i = i + 1;
            }
            textBox_Whole_SumItem.Text = i.ToString();

        }
        public int Select_Weight(string Item)
        {
            int weight = 0;

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
            Item1 = Select_Weight(combo_Whole_Item1.Text);
            Count1 = textBox_Whole_Count1.Text.ToString() == "" ? 0 : Int32.Parse(textBox_Whole_Count1.Text.ToString());

            Sum = (Item1 * Count1);

            textBox_Whole_SumWeight.Text = Sum.ToString();

        }


        private void combo_Whole_Item1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Object selectedItem = combo_Whole_Item1.SelectedItem;

                if (combo_Whole_Item1.Text != "Select Item")
                {
                    textBox_Whole_item1.Text = Select_Des_Item(selectedItem.ToString()) + " " + Select_Size_Item(selectedItem.ToString());

                    textBox_Whole_Price1.Text = Select_Price_Item(selectedItem.ToString());
                    textBox_Whole_Type1.Text = Select_Type_Item(selectedItem.ToString());
                    AmountChanged();
                    SumItem();
                    SumWeight();
                }
                else
                {
                    textBox_Whole_item1.Text = "";
                    textBox_Whole_Price1.Text = "";
                    textBox_Whole_Type1.Text = "";
                    textBox_Whole_PriceAmount1.Text = "";
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
        public void SumCount()
        {
            int Count = 0;
            int C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15;
            C1 = textBox_Whole_Count1.Text.ToString() == "" ? 0 : Int32.Parse(textBox_Whole_Count1.Text.ToString());
            C2 = textBox_Whole_Count2.Text.ToString() == "" ? 0 : Int32.Parse(textBox_Whole_Count2.Text.ToString());
            C3 = textBox_Whole_Count3.Text.ToString() == "" ? 0 : Int32.Parse(textBox_Whole_Count3.Text.ToString());
            C4 = textBox_Whole_Count4.Text.ToString() == "" ? 0 : Int32.Parse(textBox_Whole_Count4.Text.ToString());
            C5 = textBox_Whole_Count5.Text.ToString() == "" ? 0 : Int32.Parse(textBox_Whole_Count5.Text.ToString());
            C6 = textBox_Whole_Count6.Text.ToString() == "" ? 0 : Int32.Parse(textBox_Whole_Count6.Text.ToString());
            C7 = textBox_Whole_Count7.Text.ToString() == "" ? 0 : Int32.Parse(textBox_Whole_Count7.Text.ToString());
            C8 = textBox_Whole_Count8.Text.ToString() == "" ? 0 : Int32.Parse(textBox_Whole_Count8.Text.ToString());
            C9 = textBox_Whole_Count9.Text.ToString() == "" ? 0 : Int32.Parse(textBox_Whole_Count9.Text.ToString());
            C10 = textBox_Whole_Count10.Text.ToString() == "" ? 0 : Int32.Parse(textBox_Whole_Count10.Text.ToString());
            C11 = textBox_Whole_Count11.Text.ToString() == "" ? 0 : Int32.Parse(textBox_Whole_Count11.Text.ToString());
            C12 = textBox_Whole_Count12.Text.ToString() == "" ? 0 : Int32.Parse(textBox_Whole_Count12.Text.ToString());
            C13 = textBox_Whole_Count13.Text.ToString() == "" ? 0 : Int32.Parse(textBox_Whole_Count13.Text.ToString());
            C14 = textBox_Whole_Count14.Text.ToString() == "" ? 0 : Int32.Parse(textBox_Whole_Count14.Text.ToString());
            C15 = textBox_Whole_Count15.Text.ToString() == "" ? 0 : Int32.Parse(textBox_Whole_Count15.Text.ToString());
            Count = C1 + C2 + C3 + C4 + C5 + C6 + C7 + C8 + C9 + C10 + C11 + C12 + C13 + C14 + C15;

            textBox_Whole_SumCount.Text = Count.ToString();
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
            integer = str == "" ? 0 : Int32.Parse(str);

            return integer.ToString("N2");
        }

        private void comboBox_Name_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            int selectedIndex = comboBox_Name.SelectedIndex;
            Object selectedItem = comboBox_Name.SelectedItem;

            string cusName = selectedItem.ToString();

            Qury_Address_Customer(selectedItem.ToString());
        }

        private void textBox_Whole_Count1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string textPrice = "";
                double douPrice, amount;
                int Count;
                textPrice = textBox_Whole_Price1.Text.ToString() == "" ? "0.00" : textBox_Whole_Price1.Text.ToString();
                douPrice = Double.Parse(textPrice);
                Count = textBox_Whole_Count1.Text.ToString() == "" ? 0 : Int32.Parse(textBox_Whole_Count1.Text.ToString());
                amount = Count * douPrice;
                textBox_Whole_PriceAmount1.Text = amount.ToString("N2");
                AmountChanged();
                SumCount();
                SumWeight();
            }
            catch (Exception er)
            {

                MessageBox.Show("Error :  " + er);
            }
        }

        private void textBox_Whole_Price1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Object selectedItem = combo_Whole_Item1.SelectedItem;
                string textCount = "";
                double douCount, amount, Price;
                double costPrice;
                costPrice = Select_Cost_Price(selectedItem.ToString()) == "" ? 0.00 : Double.Parse(Select_Cost_Price(selectedItem.ToString()));
                textCount = textBox_Whole_Count1.Text.ToString() == "" ? "0.00" : textBox_Whole_Count1.Text.ToString();
                douCount = Double.Parse(textCount);
                Price = textBox_Whole_Price1.Text.ToString() == "" ? 0.00 : Double.Parse(textBox_Whole_Price1.Text.ToString());
                amount = douCount * Price;
                if (Price >= costPrice)
                {
                    amount = douCount * Price;
                    textBox_Whole_PriceAmount1.Text = amount.ToString("N2");
                }
                else
                {
                    MessageBox.Show("*****ราคาขายห้ามต่ำกว่าต้นทุน*****");
                    Check_PriceWhole = false;
                }
                AmountChanged();

            }
            catch (Exception er)
            {
                MessageBox.Show("Error : " + er);
            }
        }

        private void WholeSale_Load(object sender, EventArgs e)
        {
            FillCombobox();
            FillComboboxItem();
        }

        private void combo_Whole_Item2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Object selectedItem = combo_Whole_Item2.SelectedItem;

                if (combo_Whole_Item2.Text != "Select Item")
                {
                    textBox_Whole_item2.Text = Select_Des_Item(selectedItem.ToString()) + " " + Select_Size_Item(selectedItem.ToString());

                    textBox_Whole_Price2.Text = Select_Price_Item(selectedItem.ToString());
                    textBox_Whole_Type2.Text = Select_Type_Item(selectedItem.ToString());
                    AmountChanged();
                    SumItem();
                    SumWeight();
                }
                else
                {
                    textBox_Whole_item2.Text = "";
                    textBox_Whole_Price2.Text = "";
                    textBox_Whole_Type2.Text = "";
                    textBox_Whole_PriceAmount2.Text = "";
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

        private void combo_Whole_Item3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Object selectedItem = combo_Whole_Item3.SelectedItem;

                if (combo_Whole_Item3.Text != "Select Item")
                {
                    textBox_Whole_item3.Text = Select_Des_Item(selectedItem.ToString()) + " " + Select_Size_Item(selectedItem.ToString());

                    textBox_Whole_Price3.Text = Select_Price_Item(selectedItem.ToString());
                    textBox_Whole_Type3.Text = Select_Type_Item(selectedItem.ToString());
                    AmountChanged();
                    SumItem();
                    SumWeight();
                }
                else
                {
                    textBox_Whole_item3.Text = "";
                    textBox_Whole_Price3.Text = "";
                    textBox_Whole_Type3.Text = "";
                    textBox_Whole_PriceAmount3.Text = "";
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

        private void combo_Whole_Item4_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Object selectedItem = combo_Whole_Item4.SelectedItem;

                if (combo_Whole_Item4.Text != "Select Item")
                {
                    textBox_Whole_item4.Text = Select_Des_Item(selectedItem.ToString()) + " " + Select_Size_Item(selectedItem.ToString());

                    textBox_Whole_Price4.Text = Select_Price_Item(selectedItem.ToString());
                    textBox_Whole_Type4.Text = Select_Type_Item(selectedItem.ToString());
                    AmountChanged();
                    SumItem();
                    SumWeight();
                }
                else
                {
                    textBox_Whole_item4.Text = "";
                    textBox_Whole_Price4.Text = "";
                    textBox_Whole_Type4.Text = "";
                    textBox_Whole_PriceAmount4.Text = "";
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

        private void combo_Whole_Item5_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Object selectedItem = combo_Whole_Item5.SelectedItem;

                if (combo_Whole_Item5.Text != "Select Item")
                {
                    textBox_Whole_item5.Text = Select_Des_Item(selectedItem.ToString()) + " " + Select_Size_Item(selectedItem.ToString());

                    textBox_Whole_Price5.Text = Select_Price_Item(selectedItem.ToString());
                    textBox_Whole_Type5.Text = Select_Type_Item(selectedItem.ToString());
                    AmountChanged();
                    SumItem();
                    SumWeight();
                }
                else
                {
                    textBox_Whole_item5.Text = "";
                    textBox_Whole_Price5.Text = "";
                    textBox_Whole_Type5.Text = "";
                    textBox_Whole_PriceAmount5.Text = "";
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

        private void combo_Whole_Item6_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Object selectedItem = combo_Whole_Item6.SelectedItem;

                if (combo_Whole_Item6.Text != "Select Item")
                {
                    textBox_Whole_item6.Text = Select_Des_Item(selectedItem.ToString()) + " " + Select_Size_Item(selectedItem.ToString());

                    textBox_Whole_Price6.Text = Select_Price_Item(selectedItem.ToString());
                    textBox_Whole_Type6.Text = Select_Type_Item(selectedItem.ToString());
                    AmountChanged();
                    SumItem();
                    SumWeight();
                }
                else
                {
                    textBox_Whole_item6.Text = "";
                    textBox_Whole_Price6.Text = "";
                    textBox_Whole_Type6.Text = "";
                    textBox_Whole_PriceAmount6.Text = "";
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

        private void combo_Whole_Item7_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Object selectedItem = combo_Whole_Item7.SelectedItem;

                if (combo_Whole_Item7.Text != "Select Item")
                {
                    textBox_Whole_item7.Text = Select_Des_Item(selectedItem.ToString()) + " " + Select_Size_Item(selectedItem.ToString());

                    textBox_Whole_Price7.Text = Select_Price_Item(selectedItem.ToString());
                    textBox_Whole_Type7.Text = Select_Type_Item(selectedItem.ToString());
                    AmountChanged();
                    SumItem();
                    SumWeight();
                }
                else
                {
                    textBox_Whole_item7.Text = "";
                    textBox_Whole_Price7.Text = "";
                    textBox_Whole_Type7.Text = "";
                    textBox_Whole_PriceAmount7.Text = "";
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

        private void combo_Whole_Item8_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Object selectedItem = combo_Whole_Item8.SelectedItem;

                if (combo_Whole_Item8.Text != "Select Item")
                {
                    textBox_Whole_item8.Text = Select_Des_Item(selectedItem.ToString()) + " " + Select_Size_Item(selectedItem.ToString());

                    textBox_Whole_Price8.Text = Select_Price_Item(selectedItem.ToString());
                    textBox_Whole_Type8.Text = Select_Type_Item(selectedItem.ToString());
                    AmountChanged();
                    SumItem();
                    SumWeight();
                }
                else
                {
                    textBox_Whole_item8.Text = "";
                    textBox_Whole_Price8.Text = "";
                    textBox_Whole_Type8.Text = "";
                    textBox_Whole_PriceAmount8.Text = "";
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

        private void combo_Whole_Item9_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Object selectedItem = combo_Whole_Item9.SelectedItem;

                if (combo_Whole_Item9.Text != "Select Item")
                {
                    textBox_Whole_item9.Text = Select_Des_Item(selectedItem.ToString()) + " " + Select_Size_Item(selectedItem.ToString());

                    textBox_Whole_Price9.Text = Select_Price_Item(selectedItem.ToString());
                    textBox_Whole_Type9.Text = Select_Type_Item(selectedItem.ToString());
                    AmountChanged();
                    SumItem();
                    SumWeight();
                }
                else
                {
                    textBox_Whole_item9.Text = "";
                    textBox_Whole_Price9.Text = "";
                    textBox_Whole_Type9.Text = "";
                    textBox_Whole_PriceAmount9.Text = "";
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

        private void combo_Whole_Item10_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Object selectedItem = combo_Whole_Item10.SelectedItem;

                if (combo_Whole_Item10.Text != "Select Item")
                {
                    textBox_Whole_item10.Text = Select_Des_Item(selectedItem.ToString()) + " " + Select_Size_Item(selectedItem.ToString());

                    textBox_Whole_Price10.Text = Select_Price_Item(selectedItem.ToString());
                    textBox_Whole_Type10.Text = Select_Type_Item(selectedItem.ToString());
                    AmountChanged();
                    SumItem();
                    SumWeight();
                }
                else
                {
                    textBox_Whole_item10.Text = "";
                    textBox_Whole_Price10.Text = "";
                    textBox_Whole_Type10.Text = "";
                    textBox_Whole_PriceAmount10.Text = "";
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

        private void combo_Whole_Item11_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Object selectedItem = combo_Whole_Item11.SelectedItem;

                if (combo_Whole_Item11.Text != "Select Item")
                {
                    textBox_Whole_item11.Text = Select_Des_Item(selectedItem.ToString()) + " " + Select_Size_Item(selectedItem.ToString());

                    textBox_Whole_Price11.Text = Select_Price_Item(selectedItem.ToString());
                    textBox_Whole_Type11.Text = Select_Type_Item(selectedItem.ToString());
                    AmountChanged();
                    SumItem();
                    SumWeight();
                }
                else
                {
                    textBox_Whole_item11.Text = "";
                    textBox_Whole_Price11.Text = "";
                    textBox_Whole_Type11.Text = "";
                    textBox_Whole_PriceAmount11.Text = "";
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

        private void combo_Whole_Item12_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Object selectedItem = combo_Whole_Item12.SelectedItem;

                if (combo_Whole_Item12.Text != "Select Item")
                {
                    textBox_Whole_item12.Text = Select_Des_Item(selectedItem.ToString()) + " " + Select_Size_Item(selectedItem.ToString());

                    textBox_Whole_Price12.Text = Select_Price_Item(selectedItem.ToString());
                    textBox_Whole_Type12.Text = Select_Type_Item(selectedItem.ToString());
                    AmountChanged();
                    SumItem();
                    SumWeight();
                }
                else
                {
                    textBox_Whole_item12.Text = "";
                    textBox_Whole_Price12.Text = "";
                    textBox_Whole_Type12.Text = "";
                    textBox_Whole_PriceAmount12.Text = "";
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

        private void combo_Whole_Item13_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Object selectedItem = combo_Whole_Item13.SelectedItem;

                if (combo_Whole_Item13.Text != "Select Item")
                {
                    textBox_Whole_item13.Text = Select_Des_Item(selectedItem.ToString()) + " " + Select_Size_Item(selectedItem.ToString());

                    textBox_Whole_Price13.Text = Select_Price_Item(selectedItem.ToString());
                    textBox_Whole_Type13.Text = Select_Type_Item(selectedItem.ToString());
                    AmountChanged();
                    SumItem();
                    SumWeight();
                }
                else
                {
                    textBox_Whole_item13.Text = "";
                    textBox_Whole_Price13.Text = "";
                    textBox_Whole_Type13.Text = "";
                    textBox_Whole_PriceAmount13.Text = "";
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

        private void combo_Whole_Item14_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Object selectedItem = combo_Whole_Item14.SelectedItem;

                if (combo_Whole_Item14.Text != "Select Item")
                {
                    textBox_Whole_item14.Text = Select_Des_Item(selectedItem.ToString()) + " " + Select_Size_Item(selectedItem.ToString());

                    textBox_Whole_Price14.Text = Select_Price_Item(selectedItem.ToString());
                    textBox_Whole_Type14.Text = Select_Type_Item(selectedItem.ToString());
                    AmountChanged();
                    SumItem();
                    SumWeight();
                }
                else
                {
                    textBox_Whole_item14.Text = "";
                    textBox_Whole_Price14.Text = "";
                    textBox_Whole_Type14.Text = "";
                    textBox_Whole_PriceAmount14.Text = "";
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

        private void combo_Whole_Item15_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Object selectedItem = combo_Whole_Item15.SelectedItem;

                if (combo_Whole_Item15.Text != "Select Item")
                {
                    textBox_Whole_item15.Text = Select_Des_Item(selectedItem.ToString()) + " " + Select_Size_Item(selectedItem.ToString());

                    textBox_Whole_Price15.Text = Select_Price_Item(selectedItem.ToString());
                    textBox_Whole_Type15.Text = Select_Type_Item(selectedItem.ToString());
                    AmountChanged();
                    SumItem();
                    SumWeight();
                }
                else
                {
                    textBox_Whole_item15.Text = "";
                    textBox_Whole_Price15.Text = "";
                    textBox_Whole_Type15.Text = "";
                    textBox_Whole_PriceAmount15.Text = "";
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

        private void textBox_Whole_Count2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string textPrice = "";
                double douPrice, amount;
                int Count;
                textPrice = textBox_Whole_Price2.Text.ToString() == "" ? "0.00" : textBox_Whole_Price2.Text.ToString();
                douPrice = Double.Parse(textPrice);
                Count = textBox_Whole_Count2.Text.ToString() == "" ? 0 : Int32.Parse(textBox_Whole_Count2.Text.ToString());
                amount = Count * douPrice;
                textBox_Whole_PriceAmount2.Text = amount.ToString("N2");
                AmountChanged();
                SumCount();
                SumWeight();
            }
            catch (Exception er)
            {

                MessageBox.Show("Error :  " + er);
            }
        }

        private void textBox_Whole_Count3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string textPrice = "";
                double douPrice, amount;
                int Count;
                textPrice = textBox_Whole_Price3.Text.ToString() == "" ? "0.00" : textBox_Whole_Price3.Text.ToString();
                douPrice = Double.Parse(textPrice);
                Count = textBox_Whole_Count3.Text.ToString() == "" ? 0 : Int32.Parse(textBox_Whole_Count3.Text.ToString());
                amount = Count * douPrice;
                textBox_Whole_PriceAmount3.Text = amount.ToString("N2");
                AmountChanged();
                SumCount();
                SumWeight();
            }
            catch (Exception er)
            {

                MessageBox.Show("Error :  " + er);
            }
        }

        private void textBox_Whole_Count4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string textPrice = "";
                double douPrice, amount;
                int Count;
                textPrice = textBox_Whole_Price4.Text.ToString() == "" ? "0.00" : textBox_Whole_Price4.Text.ToString();
                douPrice = Double.Parse(textPrice);
                Count = textBox_Whole_Count4.Text.ToString() == "" ? 0 : Int32.Parse(textBox_Whole_Count4.Text.ToString());
                amount = Count * douPrice;
                textBox_Whole_PriceAmount4.Text = amount.ToString("N2");
                AmountChanged();
                SumCount();
                SumWeight();
            }
            catch (Exception er)
            {

                MessageBox.Show("Error :  " + er);
            }
        }

        private void textBox_Whole_Count5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string textPrice = "";
                double douPrice, amount;
                int Count;
                textPrice = textBox_Whole_Price5.Text.ToString() == "" ? "0.00" : textBox_Whole_Price5.Text.ToString();
                douPrice = Double.Parse(textPrice);
                Count = textBox_Whole_Count5.Text.ToString() == "" ? 0 : Int32.Parse(textBox_Whole_Count5.Text.ToString());
                amount = Count * douPrice;
                textBox_Whole_PriceAmount5.Text = amount.ToString("N2");
                AmountChanged();
                SumCount();
                SumWeight();
            }
            catch (Exception er)
            {

                MessageBox.Show("Error :  " + er);
            }
        }

        private void textBox_Whole_Count6_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string textPrice = "";
                double douPrice, amount;
                int Count;
                textPrice = textBox_Whole_Price6.Text.ToString() == "" ? "0.00" : textBox_Whole_Price6.Text.ToString();
                douPrice = Double.Parse(textPrice);
                Count = textBox_Whole_Count6.Text.ToString() == "" ? 0 : Int32.Parse(textBox_Whole_Count6.Text.ToString());
                amount = Count * douPrice;
                textBox_Whole_PriceAmount6.Text = amount.ToString("N2");
                AmountChanged();
                SumCount();
                SumWeight();
            }
            catch (Exception er)
            {

                MessageBox.Show("Error :  " + er);
            }
        }

        private void textBox_Whole_Count7_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string textPrice = "";
                double douPrice, amount;
                int Count;
                textPrice = textBox_Whole_Price7.Text.ToString() == "" ? "0.00" : textBox_Whole_Price7.Text.ToString();
                douPrice = Double.Parse(textPrice);
                Count = textBox_Whole_Count7.Text.ToString() == "" ? 0 : Int32.Parse(textBox_Whole_Count7.Text.ToString());
                amount = Count * douPrice;
                textBox_Whole_PriceAmount7.Text = amount.ToString("N2");
                AmountChanged();
                SumCount();
                SumWeight();
            }
            catch (Exception er)
            {

                MessageBox.Show("Error :  " + er);
            }
        }

        private void textBox_Whole_Count8_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string textPrice = "";
                double douPrice, amount;
                int Count;
                textPrice = textBox_Whole_Price8.Text.ToString() == "" ? "0.00" : textBox_Whole_Price8.Text.ToString();
                douPrice = Double.Parse(textPrice);
                Count = textBox_Whole_Count8.Text.ToString() == "" ? 0 : Int32.Parse(textBox_Whole_Count8.Text.ToString());
                amount = Count * douPrice;
                textBox_Whole_PriceAmount8.Text = amount.ToString("N2");
                AmountChanged();
                SumCount();
                SumWeight();
            }
            catch (Exception er)
            {

                MessageBox.Show("Error :  " + er);
            }
        }

        private void textBox_Whole_Count9_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string textPrice = "";
                double douPrice, amount;
                int Count;
                textPrice = textBox_Whole_Price9.Text.ToString() == "" ? "0.00" : textBox_Whole_Price9.Text.ToString();
                douPrice = Double.Parse(textPrice);
                Count = textBox_Whole_Count9.Text.ToString() == "" ? 0 : Int32.Parse(textBox_Whole_Count9.Text.ToString());
                amount = Count * douPrice;
                textBox_Whole_PriceAmount9.Text = amount.ToString("N2");
                AmountChanged();
                SumCount();
                SumWeight();
            }
            catch (Exception er)
            {

                MessageBox.Show("Error :  " + er);
            }
        }

        private void textBox_Whole_Count10_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string textPrice = "";
                double douPrice, amount;
                int Count;
                textPrice = textBox_Whole_Price10.Text.ToString() == "" ? "0.00" : textBox_Whole_Price10.Text.ToString();
                douPrice = Double.Parse(textPrice);
                Count = textBox_Whole_Count10.Text.ToString() == "" ? 0 : Int32.Parse(textBox_Whole_Count10.Text.ToString());
                amount = Count * douPrice;
                textBox_Whole_PriceAmount10.Text = amount.ToString("N2");
                AmountChanged();
                SumCount();
                SumWeight();
            }
            catch (Exception er)
            {

                MessageBox.Show("Error :  " + er);
            }
        }

        private void textBox_Whole_Count11_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string textPrice = "";
                double douPrice, amount;
                int Count;
                textPrice = textBox_Whole_Price11.Text.ToString() == "" ? "0.00" : textBox_Whole_Price11.Text.ToString();
                douPrice = Double.Parse(textPrice);
                Count = textBox_Whole_Count11.Text.ToString() == "" ? 0 : Int32.Parse(textBox_Whole_Count11.Text.ToString());
                amount = Count * douPrice;
                textBox_Whole_PriceAmount11.Text = amount.ToString("N2");
                AmountChanged();
                SumCount();
                SumWeight();
            }
            catch (Exception er)
            {

                MessageBox.Show("Error :  " + er);
            }
        }

        private void textBox_Whole_Count12_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string textPrice = "";
                double douPrice, amount;
                int Count;
                textPrice = textBox_Whole_Price12.Text.ToString() == "" ? "0.00" : textBox_Whole_Price12.Text.ToString();
                douPrice = Double.Parse(textPrice);
                Count = textBox_Whole_Count12.Text.ToString() == "" ? 0 : Int32.Parse(textBox_Whole_Count12.Text.ToString());
                amount = Count * douPrice;
                textBox_Whole_PriceAmount12.Text = amount.ToString("N2");
                AmountChanged();
                SumCount();
                SumWeight();
            }
            catch (Exception er)
            {

                MessageBox.Show("Error :  " + er);
            }
        }

        private void textBox_Whole_Count13_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string textPrice = "";
                double douPrice, amount;
                int Count;
                textPrice = textBox_Whole_Price13.Text.ToString() == "" ? "0.00" : textBox_Whole_Price13.Text.ToString();
                douPrice = Double.Parse(textPrice);
                Count = textBox_Whole_Count13.Text.ToString() == "" ? 0 : Int32.Parse(textBox_Whole_Count13.Text.ToString());
                amount = Count * douPrice;
                textBox_Whole_PriceAmount13.Text = amount.ToString("N2");
                AmountChanged();
                SumCount();
                SumWeight();
            }
            catch (Exception er)
            {

                MessageBox.Show("Error :  " + er);
            }
        }

        private void textBox_Whole_Count14_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string textPrice = "";
                double douPrice, amount;
                int Count;
                textPrice = textBox_Whole_Price14.Text.ToString() == "" ? "0.00" : textBox_Whole_Price14.Text.ToString();
                douPrice = Double.Parse(textPrice);
                Count = textBox_Whole_Count14.Text.ToString() == "" ? 0 : Int32.Parse(textBox_Whole_Count14.Text.ToString());
                amount = Count * douPrice;
                textBox_Whole_PriceAmount14.Text = amount.ToString("N2");
                AmountChanged();
                SumCount();
                SumWeight();
            }
            catch (Exception er)
            {

                MessageBox.Show("Error :  " + er);
            }
        }

        private void textBox_Whole_Count15_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string textPrice = "";
                double douPrice, amount;
                int Count;
                textPrice = textBox_Whole_Price15.Text.ToString() == "" ? "0.00" : textBox_Whole_Price15.Text.ToString();
                douPrice = Double.Parse(textPrice);
                Count = textBox_Whole_Count15.Text.ToString() == "" ? 0 : Int32.Parse(textBox_Whole_Count15.Text.ToString());
                amount = Count * douPrice;
                textBox_Whole_PriceAmount15.Text = amount.ToString("N2");
                AmountChanged();
                SumCount();
                SumWeight();
            }
            catch (Exception er)
            {

                MessageBox.Show("Error :  " + er);
            }
        }

        private void textBox_Whole_Price2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Object selectedItem = combo_Whole_Item2.SelectedItem;
                string textCount = "";
                double douCount, amount, Price;
                double costPrice;
                costPrice = Select_Cost_Price(selectedItem.ToString()) == "" ? 0.00 : Double.Parse(Select_Cost_Price(selectedItem.ToString()));
                textCount = textBox_Whole_Count2.Text.ToString() == "" ? "0.00" : textBox_Whole_Count2.Text.ToString();
                douCount = Double.Parse(textCount);
                Price = textBox_Whole_Price2.Text.ToString() == "" ? 0.00 : Double.Parse(textBox_Whole_Price2.Text.ToString());
                amount = douCount * Price;
                if (Price >= costPrice)
                {
                    amount = douCount * Price;
                    textBox_Whole_PriceAmount2.Text = amount.ToString("N2");
                }
                else
                {
                    MessageBox.Show("*****ราคาขายห้ามต่ำกว่าต้นทุน*****");
                    Check_PriceWhole = false;
                }
                AmountChanged();

            }
            catch (Exception er)
            {
                MessageBox.Show("Error : " + er);
            }
        }

        private void textBox_Whole_Price3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Object selectedItem = combo_Whole_Item3.SelectedItem;
                string textCount = "";
                double douCount, amount, Price;
                double costPrice;
                costPrice = Select_Cost_Price(selectedItem.ToString()) == "" ? 0.00 : Double.Parse(Select_Cost_Price(selectedItem.ToString()));
                textCount = textBox_Whole_Count3.Text.ToString() == "" ? "0.00" : textBox_Whole_Count3.Text.ToString();
                douCount = Double.Parse(textCount);
                Price = textBox_Whole_Price3.Text.ToString() == "" ? 0.00 : Double.Parse(textBox_Whole_Price3.Text.ToString());
                amount = douCount * Price;
                if (Price >= costPrice)
                {
                    amount = douCount * Price;
                    textBox_Whole_PriceAmount3.Text = amount.ToString("N2");
                }
                else
                {
                    MessageBox.Show("*****ราคาขายห้ามต่ำกว่าต้นทุน*****");
                    Check_PriceWhole = false;
                }
                AmountChanged();

            }
            catch (Exception er)
            {
                MessageBox.Show("Error : " + er);
            }
        }

        private void textBox_Whole_Price4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Object selectedItem = combo_Whole_Item4.SelectedItem;
                string textCount = "";
                double douCount, amount, Price;
                double costPrice;
                costPrice = Select_Cost_Price(selectedItem.ToString()) == "" ? 0.00 : Double.Parse(Select_Cost_Price(selectedItem.ToString()));
                textCount = textBox_Whole_Count4.Text.ToString() == "" ? "0.00" : textBox_Whole_Count4.Text.ToString();
                douCount = Double.Parse(textCount);
                Price = textBox_Whole_Price4.Text.ToString() == "" ? 0.00 : Double.Parse(textBox_Whole_Price4.Text.ToString());
                amount = douCount * Price;
                if (Price >= costPrice)
                {
                    amount = douCount * Price;
                    textBox_Whole_PriceAmount4.Text = amount.ToString("N2");
                }
                else
                {
                    MessageBox.Show("*****ราคาขายห้ามต่ำกว่าต้นทุน*****");
                    Check_PriceWhole = false;
                }
                AmountChanged();

            }
            catch (Exception er)
            {
                MessageBox.Show("Error : " + er);
            }
        }

        private void textBox_Whole_Price5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Object selectedItem = combo_Whole_Item5.SelectedItem;
                string textCount = "";
                double douCount, amount, Price;
                double costPrice;
                costPrice = Select_Cost_Price(selectedItem.ToString()) == "" ? 0.00 : Double.Parse(Select_Cost_Price(selectedItem.ToString()));
                textCount = textBox_Whole_Count5.Text.ToString() == "" ? "0.00" : textBox_Whole_Count5.Text.ToString();
                douCount = Double.Parse(textCount);
                Price = textBox_Whole_Price5.Text.ToString() == "" ? 0.00 : Double.Parse(textBox_Whole_Price5.Text.ToString());
                amount = douCount * Price;
                if (Price >= costPrice)
                {
                    amount = douCount * Price;
                    textBox_Whole_PriceAmount5.Text = amount.ToString("N2");
                }
                else
                {
                    MessageBox.Show("*****ราคาขายห้ามต่ำกว่าต้นทุน*****");
                    Check_PriceWhole = false;
                }
                AmountChanged();

            }
            catch (Exception er)
            {
                MessageBox.Show("Error : " + er);
            }
        }

        private void textBox_Whole_Price6_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Object selectedItem = combo_Whole_Item6.SelectedItem;
                string textCount = "";
                double douCount, amount, Price;
                double costPrice;
                costPrice = Select_Cost_Price(selectedItem.ToString()) == "" ? 0.00 : Double.Parse(Select_Cost_Price(selectedItem.ToString()));
                textCount = textBox_Whole_Count6.Text.ToString() == "" ? "0.00" : textBox_Whole_Count6.Text.ToString();
                douCount = Double.Parse(textCount);
                Price = textBox_Whole_Price6.Text.ToString() == "" ? 0.00 : Double.Parse(textBox_Whole_Price6.Text.ToString());
                amount = douCount * Price;
                if (Price >= costPrice)
                {
                    amount = douCount * Price;
                    textBox_Whole_PriceAmount6.Text = amount.ToString("N2");
                }
                else
                {
                    MessageBox.Show("*****ราคาขายห้ามต่ำกว่าต้นทุน*****");
                    Check_PriceWhole = false;
                }
                AmountChanged();

            }
            catch (Exception er)
            {
                MessageBox.Show("Error : " + er);
            }
        }

        private void textBox_Whole_Price7_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Object selectedItem = combo_Whole_Item7.SelectedItem;
                string textCount = "";
                double douCount, amount, Price;
                double costPrice;
                costPrice = Select_Cost_Price(selectedItem.ToString()) == "" ? 0.00 : Double.Parse(Select_Cost_Price(selectedItem.ToString()));
                textCount = textBox_Whole_Count7.Text.ToString() == "" ? "0.00" : textBox_Whole_Count7.Text.ToString();
                douCount = Double.Parse(textCount);
                Price = textBox_Whole_Price7.Text.ToString() == "" ? 0.00 : Double.Parse(textBox_Whole_Price7.Text.ToString());
                amount = douCount * Price;
                if (Price >= costPrice)
                {
                    amount = douCount * Price;
                    textBox_Whole_PriceAmount7.Text = amount.ToString("N2");
                }
                else
                {
                    MessageBox.Show("*****ราคาขายห้ามต่ำกว่าต้นทุน*****");
                    Check_PriceWhole = false;
                }
                AmountChanged();

            }
            catch (Exception er)
            {
                MessageBox.Show("Error : " + er);
            }
        }

        private void textBox_Whole_Price8_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Object selectedItem = combo_Whole_Item8.SelectedItem;
                string textCount = "";
                double douCount, amount, Price;
                double costPrice;
                costPrice = Select_Cost_Price(selectedItem.ToString()) == "" ? 0.00 : Double.Parse(Select_Cost_Price(selectedItem.ToString()));
                textCount = textBox_Whole_Count8.Text.ToString() == "" ? "0.00" : textBox_Whole_Count8.Text.ToString();
                douCount = Double.Parse(textCount);
                Price = textBox_Whole_Price8.Text.ToString() == "" ? 0.00 : Double.Parse(textBox_Whole_Price8.Text.ToString());
                amount = douCount * Price;
                if (Price >= costPrice)
                {
                    amount = douCount * Price;
                    textBox_Whole_PriceAmount8.Text = amount.ToString("N2");
                }
                else
                {
                    MessageBox.Show("*****ราคาขายห้ามต่ำกว่าต้นทุน*****");
                    Check_PriceWhole = false;
                }
                AmountChanged();

            }
            catch (Exception er)
            {
                MessageBox.Show("Error : " + er);
            }
        }

        private void textBox_Whole_Price9_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Object selectedItem = combo_Whole_Item9.SelectedItem;
                string textCount = "";
                double douCount, amount, Price;
                double costPrice;
                costPrice = Select_Cost_Price(selectedItem.ToString()) == "" ? 0.00 : Double.Parse(Select_Cost_Price(selectedItem.ToString()));
                textCount = textBox_Whole_Count9.Text.ToString() == "" ? "0.00" : textBox_Whole_Count9.Text.ToString();
                douCount = Double.Parse(textCount);
                Price = textBox_Whole_Price9.Text.ToString() == "" ? 0.00 : Double.Parse(textBox_Whole_Price9.Text.ToString());
                amount = douCount * Price;
                if (Price >= costPrice)
                {
                    amount = douCount * Price;
                    textBox_Whole_PriceAmount9.Text = amount.ToString("N2");
                }
                else
                {
                    MessageBox.Show("*****ราคาขายห้ามต่ำกว่าต้นทุน*****");
                    Check_PriceWhole = false;
                }
                AmountChanged();

            }
            catch (Exception er)
            {
                MessageBox.Show("Error : " + er);
            }
        }

        private void textBox_Whole_Price10_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Object selectedItem = combo_Whole_Item10.SelectedItem;
                string textCount = "";
                double douCount, amount, Price;
                double costPrice;
                costPrice = Select_Cost_Price(selectedItem.ToString()) == "" ? 0.00 : Double.Parse(Select_Cost_Price(selectedItem.ToString()));
                textCount = textBox_Whole_Count10.Text.ToString() == "" ? "0.00" : textBox_Whole_Count10.Text.ToString();
                douCount = Double.Parse(textCount);
                Price = textBox_Whole_Price10.Text.ToString() == "" ? 0.00 : Double.Parse(textBox_Whole_Price10.Text.ToString());
                amount = douCount * Price;
                if (Price >= costPrice)
                {
                    amount = douCount * Price;
                    textBox_Whole_PriceAmount10.Text = amount.ToString("N2");
                }
                else
                {
                    MessageBox.Show("*****ราคาขายห้ามต่ำกว่าต้นทุน*****");
                    Check_PriceWhole = false;
                }
                AmountChanged();

            }
            catch (Exception er)
            {
                MessageBox.Show("Error : " + er);
            }
        }

        private void textBox_Whole_Price11_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Object selectedItem = combo_Whole_Item11.SelectedItem;
                string textCount = "";
                double douCount, amount, Price;
                double costPrice;
                costPrice = Select_Cost_Price(selectedItem.ToString()) == "" ? 0.00 : Double.Parse(Select_Cost_Price(selectedItem.ToString()));
                textCount = textBox_Whole_Count11.Text.ToString() == "" ? "0.00" : textBox_Whole_Count11.Text.ToString();
                douCount = Double.Parse(textCount);
                Price = textBox_Whole_Price11.Text.ToString() == "" ? 0.00 : Double.Parse(textBox_Whole_Price11.Text.ToString());
                amount = douCount * Price;
                if (Price >= costPrice)
                {
                    amount = douCount * Price;
                    textBox_Whole_PriceAmount11.Text = amount.ToString("N2");
                }
                else
                {
                    MessageBox.Show("*****ราคาขายห้ามต่ำกว่าต้นทุน*****");
                    Check_PriceWhole = false;
                }
                AmountChanged();

            }
            catch (Exception er)
            {
                MessageBox.Show("Error : " + er);
            }
        }

        private void textBox_Whole_Price12_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Object selectedItem = combo_Whole_Item12.SelectedItem;
                string textCount = "";
                double douCount, amount, Price;
                double costPrice;
                costPrice = Select_Cost_Price(selectedItem.ToString()) == "" ? 0.00 : Double.Parse(Select_Cost_Price(selectedItem.ToString()));
                textCount = textBox_Whole_Count12.Text.ToString() == "" ? "0.00" : textBox_Whole_Count12.Text.ToString();
                douCount = Double.Parse(textCount);
                Price = textBox_Whole_Price12.Text.ToString() == "" ? 0.00 : Double.Parse(textBox_Whole_Price12.Text.ToString());
                amount = douCount * Price;
                if (Price >= costPrice)
                {
                    amount = douCount * Price;
                    textBox_Whole_PriceAmount12.Text = amount.ToString("N2");
                }
                else
                {
                    MessageBox.Show("*****ราคาขายห้ามต่ำกว่าต้นทุน*****");
                    Check_PriceWhole = false;
                }
                AmountChanged();

            }
            catch (Exception er)
            {
                MessageBox.Show("Error : " + er);
            }
        }

        private void textBox_Whole_Price13_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Object selectedItem = combo_Whole_Item13.SelectedItem;
                string textCount = "";
                double douCount, amount, Price;
                double costPrice;
                costPrice = Select_Cost_Price(selectedItem.ToString()) == "" ? 0.00 : Double.Parse(Select_Cost_Price(selectedItem.ToString()));
                textCount = textBox_Whole_Count13.Text.ToString() == "" ? "0.00" : textBox_Whole_Count13.Text.ToString();
                douCount = Double.Parse(textCount);
                Price = textBox_Whole_Price13.Text.ToString() == "" ? 0.00 : Double.Parse(textBox_Whole_Price13.Text.ToString());
                amount = douCount * Price;
                if (Price >= costPrice)
                {
                    amount = douCount * Price;
                    textBox_Whole_PriceAmount13.Text = amount.ToString("N2");
                }
                else
                {
                    MessageBox.Show("*****ราคาขายห้ามต่ำกว่าต้นทุน*****");
                    Check_PriceWhole = false;
                }
                AmountChanged();

            }
            catch (Exception er)
            {
                MessageBox.Show("Error : " + er);
            }
        }

        private void textBox_Whole_Price14_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Object selectedItem = combo_Whole_Item14.SelectedItem;
                string textCount = "";
                double douCount, amount, Price;
                double costPrice;
                costPrice = Select_Cost_Price(selectedItem.ToString()) == "" ? 0.00 : Double.Parse(Select_Cost_Price(selectedItem.ToString()));
                textCount = textBox_Whole_Count14.Text.ToString() == "" ? "0.00" : textBox_Whole_Count14.Text.ToString();
                douCount = Double.Parse(textCount);
                Price = textBox_Whole_Price14.Text.ToString() == "" ? 0.00 : Double.Parse(textBox_Whole_Price14.Text.ToString());
                amount = douCount * Price;
                if (Price >= costPrice)
                {
                    amount = douCount * Price;
                    textBox_Whole_PriceAmount14.Text = amount.ToString("N2");
                }
                else
                {
                    MessageBox.Show("*****ราคาขายห้ามต่ำกว่าต้นทุน*****");
                    Check_PriceWhole = false;
                }
                AmountChanged();

            }
            catch (Exception er)
            {
                MessageBox.Show("Error : " + er);
            }
        }

        private void textBox_Whole_Price15_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Object selectedItem = combo_Whole_Item15.SelectedItem;
                string textCount = "";
                double douCount, amount, Price;
                double costPrice;
                costPrice = Select_Cost_Price(selectedItem.ToString()) == "" ? 0.00 : Double.Parse(Select_Cost_Price(selectedItem.ToString()));
                textCount = textBox_Whole_Count15.Text.ToString() == "" ? "0.00" : textBox_Whole_Count15.Text.ToString();
                douCount = Double.Parse(textCount);
                Price = textBox_Whole_Price15.Text.ToString() == "" ? 0.00 : Double.Parse(textBox_Whole_Price15.Text.ToString());
                amount = douCount * Price;
                if (Price >= costPrice)
                {
                    amount = douCount * Price;
                    textBox_Whole_PriceAmount15.Text = amount.ToString("N2");
                }
                else
                {
                    MessageBox.Show("*****ราคาขายห้ามต่ำกว่าต้นทุน*****");
                    Check_PriceWhole = false;
                }
                AmountChanged();

            }
            catch (Exception er)
            {
                MessageBox.Show("Error : " + er);
            }
        }
    }
}
