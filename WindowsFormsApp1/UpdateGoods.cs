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
    public partial class UpdateGoods : Form
    {

        OleDbConnection bookConn;
        OleDbCommand oleDbCmd;
        OleDbDataReader mdr;
        String connParam = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Invoice\DB\DB_Invoice.mdb;Persist Security Info=True;User ID=admin";

        public UpdateGoods()
        {
            InitializeComponent();
        }

        private void UpdateGoods_Load(object sender, EventArgs e)
        {
            SelectGoodsCode();

        }
        public void SelectGoodsCode()
        {
            string query = "SELECT Goods_CD FROM Goods";

            bookConn = new OleDbConnection(connParam);
            bookConn.Open();
            try
            {
                oleDbCmd = new OleDbCommand(query, bookConn);

                mdr = oleDbCmd.ExecuteReader();

                while (mdr.Read())
                {
                    comboBox_GoodsCD.Items.Add(mdr.GetString(0));
                }
            }
            catch (Exception er)
            {

                MessageBox.Show("ERROR : " + er);
                bookConn.Close();
            }
            bookConn.Close();

        }

        private void comboBox_GoodsCD_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                Object selectedItem = comboBox_GoodsCD.SelectedItem;

                if (comboBox_GoodsCD.Text != "Select Code")
                {
                    textBox_GoodsDes.Text = Select_Goods_Des(selectedItem.ToString());
                    textBox_GoodsSize.Text = Select_Goods_Size(selectedItem.ToString());
                    textBox_GoodsWeight.Text = Select_Goods_Weight(selectedItem.ToString());
                    textBox_GoodsType.Text = Select_Goods_Type(selectedItem.ToString());
                    textBox_GoodsCost.Text = Select_Goods_Cost(selectedItem.ToString());
                    textBox_GoodsWhole.Text = Select_Goods_Whole(selectedItem.ToString());
                    textBox_GoodsRetail.Text = Select_Goods_Retail(selectedItem.ToString());
                    textBox_GoodsTotal.Text = Select_Goods_Total(selectedItem.ToString());
                  
                    

                }
                else
                {
                    textBox_GoodsDes.Text = "";
                    textBox_GoodsSize.Text = "";
                }

            }
            catch (Exception er)
            {
                MessageBox.Show("Error : " + er);
            }

        }

        public string Select_Goods_Des(string Code)
        {
            string query = "SELECT  `Goods_Description` FROM `Goods` WHERE Goods_CD = '" + Code + "'";
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
        public string Select_Goods_Size(string Code)
        {
            string query = "SELECT  `Goods_Size` FROM `Goods` WHERE Goods_CD = '" + Code + "'";
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
        public string Select_Goods_Weight(string Code)
        {
            string query = "SELECT `Goods_Weight` FROM `Goods` WHERE Goods_CD = '" + Code + "'";
            string str = "";
            bookConn = new OleDbConnection(connParam);
            bookConn.Open();
            try
            {
                oleDbCmd = new OleDbCommand(query, bookConn);
                mdr = oleDbCmd.ExecuteReader();
                while (mdr.Read())
                {
                    str = (mdr.GetInt32(0)).ToString();
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
        public string Select_Goods_Type(string Code)
        {
            string query = "SELECT  `Goods_Type` FROM `Goods` WHERE Goods_CD = '" + Code + "'";
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
        public string Select_Goods_Cost(string Code)
        {
            string query = "SELECT `Goods_Cost` FROM `Goods` WHERE Goods_CD = '" + Code + "'";
            string str = "";
            bookConn = new OleDbConnection(connParam);
            bookConn.Open();
            try
            {
                oleDbCmd = new OleDbCommand(query, bookConn);
                mdr = oleDbCmd.ExecuteReader();
                while (mdr.Read())
                {
                    str = (mdr.GetInt32(0)).ToString();
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
        public string Select_Goods_Whole(string Code)
        {
            string query = "SELECT  `Goods_Whole` FROM `Goods` WHERE Goods_CD = '" + Code + "'";
            string str = "";
            bookConn = new OleDbConnection(connParam);
            bookConn.Open();
            try
            {
                oleDbCmd = new OleDbCommand(query, bookConn);
                mdr = oleDbCmd.ExecuteReader();
                while (mdr.Read())
                {
                    str = (mdr.GetInt32(0)).ToString();
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
        public string Select_Goods_Retail(string Code)
        {
            string query = "SELECT  `Goods_Retail` FROM `Goods` WHERE Goods_CD = '" + Code + "'";
            string str = "";
            bookConn = new OleDbConnection(connParam);
            bookConn.Open();
            try
            {
                oleDbCmd = new OleDbCommand(query, bookConn);
                mdr = oleDbCmd.ExecuteReader();
                while (mdr.Read())
                {
                    str = (mdr.GetInt32(0)).ToString();
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
        public string Select_Goods_Total(string Code)
        {
            string query = "SELECT  `Goods_Total` FROM `Goods` WHERE Goods_CD = '" + Code + "'";
            string str = "";
            bookConn = new OleDbConnection(connParam);
            bookConn.Open();
            try
            {
                oleDbCmd = new OleDbCommand(query, bookConn);
                mdr = oleDbCmd.ExecuteReader();
                while (mdr.Read())
                {
                    str = (mdr.GetInt32(0)).ToString();
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
        public void Update_Customer()
        {
            Object selectedItem = comboBox_GoodsCD.SelectedItem;
            //string query = "SELECT Cus_CD FROM customer";
            // UPDATE Goods  SET Goods_Description =  , Goods_Size = , Goods_Weight= , Goods_Cost = , Goods_Whole =  , Goods_Retail =  ,  Goods_Type = , Goods_Total =  WHERE  Goods_CD =  ;
            string query = "UPDATE Goods " +
                           "SET Goods_Description ='" + textBox_GoodsDes.Text + "' ," +
                           "Goods_Size ='" + textBox_GoodsSize.Text + "' ," +
                           "Goods_Weight =" + Int32.Parse(textBox_GoodsWeight.Text) + " ," +
                           "Goods_Cost =" + Int32.Parse(textBox_GoodsCost.Text) + ", " +
                           "Goods_Whole =" + Int32.Parse(textBox_GoodsWhole.Text) + " ," +
                           "Goods_Retail =" + Int32.Parse(textBox_GoodsRetail.Text) + " ," +
                           "Goods_Type ='" + textBox_GoodsType.Text + "' ," +
                           "Goods_Total =" + Int32.Parse(textBox_GoodsTotal.Text) + " " +
                           "WHERE Goods_CD ='" + selectedItem.ToString() + "' ;";
            try
            {
                bookConn = new OleDbConnection(connParam);
                oleDbCmd = new OleDbCommand(query, bookConn);
                bookConn.Open();
                oleDbCmd.ExecuteNonQuery();
                MessageBox.Show("UPDATE COMPLETED");
            }
            catch (Exception er)
            {

                MessageBox.Show("ERROR : " + er);
                bookConn.Close();
            }
            bookConn.Close();
        }

        private void button_Update_Click(object sender, EventArgs e)
        {
            Update_Customer();
        }
    }
}
