using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToDoList.BusinessLogicLayer;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ToDoList.DataAccessLayer
{
    public class OrderDetailsDAL         
    {
        public int TotalPriceAsPerQuantity = 0;
        MySqlConnection con = new MySqlConnection(Connection.connectionString);
        #region Order Details
        public bool OrderDetails(OrderDetailsBLL OrderDetails) {
            bool DetailsRecorded = false;
            try
            {               
                DataTable dt = new DataTable();
                string query = $"INSERT INTO order_detail(username,quantity,totalPrice,address, petId, breedId) VALUES ('{OrderDetails.username}','{OrderDetails.number}','{OrderDetails.totalPrice}','{OrderDetails.address}',{OrderDetails.petId}, {OrderDetails.breedId})";
                
                MySqlCommand cmd = new MySqlCommand(query, con);
            
                con.Open();
                cmd.ExecuteNonQuery();
                DetailsRecorded = true;
            } 

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return DetailsRecorded;
        }
        #endregion

        #region order details of the currently logged in user
        public DataTable GetOrderDetails() {
            try
            {
                DataTable dt = new DataTable();
                string query = $"SELECT od.username, ptyp.PetType, bd.breed,od.quantity,od.totalPrice,od.address" +
                    $" from order_detail od " +
                    $"JOIN pet_type ptyp on od.petId = ptyp.id " +
                    $"JOIN breed bd on od.breedId = bd.id " +
                    $"HAVING od.username = \"{Login.username}\";";

                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                con.Open();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    return dt;
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

            return null;
        }
        #endregion
    }
}
