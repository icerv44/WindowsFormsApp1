using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Login : Form
    {

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

            Main MN = new Main();
                
                user = textBox_User.Text;
            pass = textBox_Pass.Text;
           
            //Console.WriteLine(user);
            //Console.WriteLine(pass);

            if(user == "user" && pass == "1234")
            {
                this.Hide();
                MN.Show();
            }
            else
            {
                label_LoginFail.Visible = true;
                label_LoginFail.Text = "Incorrect User Name or Password";
                MessageBox.Show("Incorrect User Name or Password","Login Fail",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }


        }


    }
}
