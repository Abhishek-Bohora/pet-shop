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
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text == String.Empty && textBox2.Text == String.Empty)
            {
                MessageBox.Show("Please enter username and password", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }else if(textBox1.Text == String.Empty)
            {
                MessageBox.Show("Please enter username", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (textBox2.Text == String.Empty)
            {
                MessageBox.Show("Please enter password", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }else if(textBox2.Text != textBox3.Text)
            {
                MessageBox.Show("Please match the both passwords", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
            textBox3.PasswordChar = '*';
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Pet pet = new Pet();
            this.Hide();
            pet.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Login Login = new Login();
            this.Close();
            Login.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PetType petType = new PetType();
            this.Hide();
            petType.Show();
        }
    }
}
