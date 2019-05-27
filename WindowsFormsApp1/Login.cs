using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace WindowsFormsApp1
{
    public partial class Login : Form
    {

        public Login()
        {
            InitializeComponent();
        }

        MySqlConnection con = new MySqlConnection("server = localhost; database = invoice; username = root; password=; ");



        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void textBox_Pass_TextChanged(object sender, EventArgs e)
        {

        }

        public void button_Login_Click(object sender, EventArgs e)
        {
            String user = "", pass ="" ;

            Main MN = new Main();
                
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

            string query = "select * from user where username = '" + user + "' && password = '" + pass + "' ";

            MySqlDataAdapter data = new MySqlDataAdapter(query,con);

            DataTable dt = new DataTable();

            data.Fill(dt);

            if (dt.Rows.Count == 1)
            {
                this.Hide();
                MN.Show();
            }
            else
            {
                label_LoginFail.Visible = true;
                label_LoginFail.Text = "Incorrect User Name or Password";

                MessageBox.Show("Incorrect User Name or Password", "Login Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);

                textBox_User.Clear();
                textBox_Pass.Clear();
                
            }


        }


    }
}
