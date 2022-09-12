using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToDoList.BusinessLogicLayer;

namespace ToDoList.DataAccessLayer
{
    public class BreedDAL
    {
        MySqlConnection con = new MySqlConnection(Connection.connectionString);

        #region Select Breed Type
        public DataTable SelectBreedByPetType(int petType)
        {
            DataTable dt = new DataTable();
            try
            {
                string query = $"select * from breed where petType = {petType}";
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                con.Open();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return dt;
        }
        #endregion
    }
}
