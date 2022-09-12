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

namespace ToDoList.Views
{
    public partial class PetOrder : Form
    {

        MySqlConnection con = new MySqlConnection(Connection.connectionString);
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
            OrderDetailsBLL.number = int.Parse(textBox2.Text);
            OrderDetailsBLL.address = textBox3.Text;           
            var petId = comboBoxPetType.SelectedValue;
            OrderDetailsBLL.petId = Convert.ToInt32(petId);
            var breedId = comboBoxBreed.SelectedValue;
            OrderDetailsBLL.breedId = Convert.ToInt32(breedId);
            OrderDetailsBLL.totalPrice = TotalPrice(Convert.ToInt32(breedId), OrderDetailsBLL.number);

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

        #region Pet Price Per breed
        public int TotalPrice(int breedId, int quantity)
        {
            int total = 0;
            try
            {
                DataTable dt = new DataTable();
                string query = $"SELECT Price from breed WHERE id = {breedId}";
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                con.Open();
                da.Fill(dt);
                total = quantity * Convert.ToInt32(dt.Rows[0][0]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return total;
        } 
        
        #endregion

        private void PetOrder_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                string query = $"SELECT * FROM pet_type";
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                con.Open();
                da.Fill(dt);

                comboBoxPetType.ValueMember = "id";
                comboBoxPetType.DisplayMember = "PetType";
                comboBoxPetType.DataSource = dt;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            BreedDAL breedDAL = new BreedDAL();
            int petType = int.Parse(comboBoxPetType.SelectedValue.ToString());
            comboBoxBreed.DataSource = breedDAL.SelectBreedByPetType(petType);
            comboBoxBreed.DisplayMember = "breed";
            comboBoxBreed.ValueMember = "id";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
         
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
