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
        protected void FillCombobox()
        {
            
            string query = "SELECT ID,Name,Address  FROM customers";

           

            
            try
            {
                /* MySqlDataAdapter data = new MySqlDataAdapter(query, con);

                 DataSet ds = new DataSet();
                 data.Fill(ds);
                 comboBox_Name.DisplayMember = "Name";
                 comboBox_Name.ValueMember = "ID";
                 comboBox_Name.DataSource = ds.Tables[0];
                 comboBox_Name.Items.Add(ds.Tables[0]);
                 **/
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
                //Exception Message
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
    }
}
