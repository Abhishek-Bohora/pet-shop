using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToDoList.BusinessLogicLayer;

namespace ToDoList.DataAccessLayer
{
    public class RegisterDAL
    {
        MySqlConnection con = new MySqlConnection(Connection.connectionString);

        #region check if username already exists
        public bool checkUsername(LoginBLL login)
        {
            DataTable dt = new DataTable();
            try
            {
                string query = $"SELECT * FROM login WHERE username='{login.username}'";
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                con.Open();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return false;
        }
        #endregion

        #region User Registration
        public bool registerUser(LoginBLL login)
        {    
            
            bool reg = false;
           try
            {
                string query = $"INSERT INTO login (username,password) values ('{login.username}', '{login.password}')"; ;
                MySqlCommand cmd = new MySqlCommand(query, con);
                //MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                con.Open();
                cmd.ExecuteNonQuery();
                reg = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }

            return reg;
        }
        #endregion
    }

}
