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

namespace ToDoList.Views
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //checking if the username already exists or not
            LoginBLL login = new LoginBLL();
            RegisterDAL registerDAL = new RegisterDAL();
            login.username = textBox1.Text;
            login.password = textBox2.Text;
            bool result = registerDAL.checkUsername(login);
            if (result)
            {
                MessageBox.Show("Username already exists please try another one");
            }
            else
            {
                bool register = registerDAL.registerUser(login);
                if (register)
                {
                    MessageBox.Show("User registered successfully");
                    this.Hide();
                    Login Login = new Login();
                    Login.Show();
                }
                else
                {
                    MessageBox.Show("Registration failed");
                }
            }

        }
    }
}
