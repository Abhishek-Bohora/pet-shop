using ToDoList.BusinessLogicLayer;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using ToDoList.Views;

namespace ToDoList.DataAccessLayer
{
    public class LoginDAL
    {
        MySqlConnection con = new MySqlConnection(Connection.connectionString);

        #region Check Login
        public bool loginCheck(LoginBLL login) {
            DataTable dt = new DataTable();
            try
            {
                string query = $"SELECT * FROM login WHERE username='{login.username}' AND password='{login.password}'";
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                con.Open();
                da.Fill(dt);

                if(dt.Rows.Count > 0)
                {                
                    return true;               
                }
               return false;
            }catch(Exception ex)
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

        #region Get Username
        public string getUsername(LoginBLL login)
        {
            string username = "";
            DataTable dt = new DataTable();
            try
            {
                string query = $"SELECT username from login where username='{login.username}'";
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataAdapter da = new MySqlDataAdapter();
                con.Open();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    username = dt.Rows[0][0].ToString();
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
            return username;
        }
        #endregion
    }
}
 