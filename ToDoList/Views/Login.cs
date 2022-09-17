using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToDoList.BusinessLogicLayer;
using ToDoList.DataAccessLayer;
using ToDoList.Views;
namespace ToDoList
{
    public partial class Login : Form
    {
        public static string username; //to pass the username to other places
        public Login()
        {
            InitializeComponent();
        }

        MySqlConnection con = new MySqlConnection(Connection.connectionString);

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == String.Empty && textBox2.Text == String.Empty)
            {
                MessageBox.Show("Please enter username and password", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (textBox1.Text == String.Empty)
            {
                MessageBox.Show("Please enter username", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (textBox2.Text == String.Empty)
            {
                MessageBox.Show("Please enter password", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else {
                LoginBLL login = new LoginBLL();
                LoginDAL loginDAL = new LoginDAL();
                login.username = textBox1.Text;
                login.password = textBox2.Text;
                bool result = loginDAL.loginCheck(login);
                if (result)
                {
                    username = textBox1.Text;
                    Dashboard dashboard = new Dashboard();
                    dashboard.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid username or password");
                }
            }
           
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminDashboard register = new AdminDashboard();
            register.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            AdminLogin AdminLogin = new AdminLogin();
            this.Hide();
            AdminLogin.Show();
            
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
