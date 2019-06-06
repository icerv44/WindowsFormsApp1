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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        MySqlConnection con = new MySqlConnection("server = localhost; database = invoice; username = root; password=; ");
        private void Form1_Load(object sender, EventArgs e)
        {
            Qury_Customer();
        }

        private void Panel_Menu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Panel_Main_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button_Retail_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        void Qury_Customer()
        {
            string query = "SELECT * FROM customer";

            MySqlDataAdapter data = new MySqlDataAdapter(query, con);

            DataTable dt = new DataTable();

            data.Fill(dt);

            dgv1.DataSource = dt;
        }

         void button1_Click(object sender, EventArgs e)
        {
            string text1 = "";

            text1 = textBox1.Text;

            string query = "INSERT INTO `customer`(`Name`) VALUES ('" + text1  + "')";

            MySqlDataAdapter data = new MySqlDataAdapter(query, con);

            DataTable dt = new DataTable();

            data.Fill(dt);

            Qury_Customer();




        }

        void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
