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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ToDoList.Views
{
    public partial class PetType : Form
    {
        MySqlConnection con = new MySqlConnection(Connection.connectionString);
        public PetType()
        {
            InitializeComponent();
        }

        private void PetType_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                string query = $"INSERT INTO pet_type (PetType) values ( '{textBox1.Text}')"; ;
                MySqlCommand cmd = new MySqlCommand(query, con);
                //MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                con.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            MessageBox.Show("Inserted");
            this.Close();
            AdminDashboard adminDashboard = new AdminDashboard();
            adminDashboard.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login Login = new Login();
            this.Close();
            Login.Show();
        }
    }
}
