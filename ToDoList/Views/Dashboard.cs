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
using ToDoList.DataAccessLayer;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ToDoList.Views
{
    public partial class Dashboard : Form
    {
        public static DataTable dt = new DataTable();
        MySqlConnection con = new MySqlConnection(Connection.connectionString);
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

        private void Dashboard_Load(object sender, EventArgs e)
        {
            button1.PerformClick();     
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OrderDetailsDAL orderDetailsDAL = new OrderDetailsDAL();
            DataTable dt = orderDetailsDAL.GetOrderDetails();
            dataGridView1.DataSource = dt;
        }
    }
}
