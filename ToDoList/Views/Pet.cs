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

namespace ToDoList.Views
{
    public partial class Pet : Form
    {
        MySqlConnection con = new MySqlConnection(Connection.connectionString);
        public Pet()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            this.Close();
            login.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Pet_Load(object sender, EventArgs e)
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

        private bool CheckDuplicateBreed(int petId, string breed) {
            bool status = false;
            try
            {
                DataTable dt = new DataTable();
                string query = $"SELECT * FROM breed where PetType={petId} and breed = '{breed}'";
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                con.Open();
                da.Fill(dt);
                if (dt.Rows.Count > 0) {
                    status = true;
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return status;

        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (CheckDuplicateBreed(Convert.ToInt32(comboBoxPetType.SelectedValue), textBox2.Text)) {
                MessageBox.Show("It already exists");
                return;
            
            }
            try
            {
                string query = $"INSERT INTO breed (petType,breed,Price) values ('{comboBoxPetType.SelectedValue}', '{textBox2.Text}','{textBox3.Text}')"; ;
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
        }
    }
}
