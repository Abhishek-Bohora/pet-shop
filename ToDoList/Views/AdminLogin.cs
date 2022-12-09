using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDoList.Views
{
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Login Login = new Login();
            this.Close();
            Login.Show();     
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            //Check this into database
            if (textBox1.Text == "admin" && textBox2.Text == "admin")
            {
                AdminDashboard AdminDashboard = new AdminDashboard();
                AdminDashboard.Show();
                this.Hide();
            }
            else {  
                MessageBox.Show("Username and Password did not match", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void AdminLogin_Load(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
