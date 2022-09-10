using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToDoList.DataAccessLayer;

namespace ToDoList.Views
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            PetOrder petOrder = new PetOrder();
            petOrder.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OrderDetailsDAL orderDetailsDAL = new OrderDetailsDAL();
            DataTable dt = orderDetailsDAL.GetOrderDetails();
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            this.Hide();
            //Dashboard dashboard = new Dashboard();
            //dashboard.Hide();
            login.Show();
        }
    }
}
