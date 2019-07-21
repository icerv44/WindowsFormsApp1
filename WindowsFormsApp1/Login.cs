using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql.Data;
using DataTable = System.Data.DataTable;
using System.Data.OleDb;
using System.Data.SqlClient;
using Microsoft.Reporting.WinForms;


namespace WindowsFormsApp1
{
    public partial class Login : Form
    {
        OleDbConnection bookConn;
        OleDbCommand oleDbCmd;
        OleDbDataReader mdr;
        //String connParam = @"Data Source=C:\Invoice\DB\DB_Invoice.mdb;Persist Security Info=True;User ID=admin";
        String connParam = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Invoice\DB\DB_Invoice.mdb;Persist Security Info=True;User ID=admin";

        List<User> User1 = new List<User>();

        public Login()
        {
            InitializeComponent();
        }

        



        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void textBox_Pass_TextChanged(object sender, EventArgs e)
        {

        }

        public void button_Login_Click(object sender, EventArgs e)
        {
            String user = "", pass ="" ;

          //  Main MN = new Main();
                
            user = textBox_User.Text;
            pass = textBox_Pass.Text;

            //Console.WriteLine(user);
            //Console.WriteLine(pass);

            //if(user == "user" && pass == "1234")
            //{
            //    this.Hide();
            //    MN.Show();
            //}
            //else
            //{
            //    label_LoginFail.Visible = true;
            //    label_LoginFail.Text = "Incorrect User Name or Password";
            //    MessageBox.Show("Incorrect User Name or Password","Login Fail",MessageBoxButtons.OK,MessageBoxIcon.Error);
            //}
            int tmp = 0;
            string userName = "";
            string NickName = "";
            string query = "SELECT User_Level,User_Name,User_Nick FROM [User] WHERE User_Name = '" + user + "' AND User_Pass = '" + pass + "' ;";
            bookConn = new OleDbConnection(connParam);
            bookConn.Open();
            User u = new User();
            try
            {
                oleDbCmd = new OleDbCommand(query, bookConn);

                mdr = oleDbCmd.ExecuteReader();

                while (mdr.Read())
                {
                    tmp = mdr.GetInt32(0);
                    userName = mdr.GetString(1);
                    NickName = mdr.GetString(2);
                    u.User_Level = tmp ;
                    u.User_Name = userName;
                    u.User_NickName = NickName;
                    User1.Add(u);

                }

                // MySqlDataAdapter data = new MySqlDataAdapter(query, connParam);
                /*OleDbDataAdapter dAdapter = new OleDbDataAdapter(query, connParam);

                DataTable dt = new DataTable();+

                dAdapter.Fill(dt);*/

                if (tmp != 0)
                {
                    this.Hide();
                    Main MN = new Main(User1);
                    MN.Show();
                    using (Main prt = new Main(User1))
                    {
                        //prt.ShowDialog();
                        prt.Show();
                    }
                }
                else
                {
                    label_Fail.Visible = true;
                    label_Fail.Text = "ใส่ User Name หริอ Password ผิด";

                    MessageBox.Show("ใส่ User Name หริอ Password ผิด", "Login Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    textBox_User.Clear();
                    textBox_Pass.Clear();

                }

            }
            catch (Exception er)
            {
                MessageBox.Show("ERROR : " + er);
                bookConn.Close();
            }
            bookConn.Close();


        }


    }
}
