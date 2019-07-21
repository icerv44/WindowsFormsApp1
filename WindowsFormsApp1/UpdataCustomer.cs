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
    public partial class UpdataCustomer : Form
    {
        OleDbConnection bookConn;
        OleDbCommand oleDbCmd;
        OleDbDataReader mdr;
        String connParam = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Invoice\DB\DB_Invoice.mdb;Persist Security Info=True;User ID=admin";

        public UpdataCustomer()
        {
            InitializeComponent();
        }

        private void UpdataCustomer_Load(object sender, EventArgs e)
        {
            SelectCusCode();
        }

        public void Update_Customer()
        {
            Object selectedItem = comboBox_CusCD.SelectedItem;
            //string query = "SELECT Cus_CD FROM customer";

            string query = "UPDATE customer " +
                           "SET Cus_Name ='" + textBox_CusName.Text + "' ," +
                           "Cus_Address ='" + textBox_CusAddress.Text + "' " +
                           "WHERE Cus_CD ='" + selectedItem.ToString() + "' ;"; 
            try
            {
                bookConn = new OleDbConnection(connParam);
                oleDbCmd = new OleDbCommand(query, bookConn);
                bookConn.Open();
                oleDbCmd.ExecuteNonQuery();
            }
            catch (Exception er)
            {

                MessageBox.Show("ERROR : " + er);
                bookConn.Close();
            }
            bookConn.Close();
        }

        public void SelectCusCode()
        {
            string query = "SELECT Cus_CD FROM customer";

            bookConn = new OleDbConnection(connParam);
            bookConn.Open();
            try
            {
                oleDbCmd = new OleDbCommand(query, bookConn);

                mdr = oleDbCmd.ExecuteReader();

                while (mdr.Read())
                {
                    comboBox_CusCD.Items.Add(mdr.GetString(0));
                }
            }
            catch (Exception er)
            {

                MessageBox.Show("ERROR : " + er);
                bookConn.Close();
            }
            bookConn.Close();

        }
        public string Select_Cus_Name(string Name)
        {

            string query = "SELECT  `Cus_Name` FROM `customer` WHERE Cus_CD = '" + Name + "'";
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
        }
        public string Select_Cus_Address(string Name)
        {

            string query = "SELECT  `Cus_Address` FROM `customer` WHERE Cus_CD = '" + Name + "'";
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
        }

        private void comboBox_CusCD_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Object selectedItem = comboBox_CusCD.SelectedItem;

                if (comboBox_CusCD.Text != "Select Code")
                {
                    textBox_CusName.Text = Select_Cus_Name(selectedItem.ToString());
                    textBox_CusAddress.Text = Select_Cus_Address(selectedItem.ToString());
                    
                }
                else
                {
                    textBox_CusName.Text = "";
                    textBox_CusAddress.Text = "";
                }

            }
            catch (Exception er)
            {
                MessageBox.Show("Error : " + er);
            }
        }

        private void button_Update_Click(object sender, EventArgs e)
        {
            Update_Customer();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
