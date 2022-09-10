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
    public partial class PetOrder : Form
    {
     
        public PetOrder()
        {
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OrderDetailsBLL OrderDetailsBLL = new OrderDetailsBLL();
            OrderDetailsDAL OrderDetailsDAL = new OrderDetailsDAL();
            OrderDetailsBLL.username = Login.username; //Login.cs
            OrderDetailsBLL.pet = (string)comboBox1.SelectedItem;
            OrderDetailsBLL.number = int.Parse(textBox2.Text);
            OrderDetailsDAL.PriceCheckPerPet(OrderDetailsBLL);
            OrderDetailsBLL.address = textBox3.Text;
            if (OrderDetailsDAL.OrderDetails(OrderDetailsBLL))
            {
                MessageBox.Show("recorded successfully");
                this.Hide();
                Dashboard Dashboard = new Dashboard();
                Dashboard.Show();
            }
            else
            {
                MessageBox.Show("Unsuccessfull");
            }
            
        }

        private void PetOrder_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
