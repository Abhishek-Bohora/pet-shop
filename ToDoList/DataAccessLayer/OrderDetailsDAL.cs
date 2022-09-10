using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToDoList.BusinessLogicLayer;

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
                string query = $"INSERT INTO order_details(username,pet,number,totalPrice,address) VALUES ('{OrderDetails.username}','{OrderDetails.pet}','{OrderDetails.number}','{TotalPriceAsPerQuantity}','{OrderDetails.address}')";
                
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

        #region price check per pet
        public int PriceCheckPerPet(OrderDetailsBLL OrderDetails) {
            int PricePerPet = 0;
            
            try
            {
                DataTable dt = new DataTable();
                string query = $"select Price from pet_price where PetType='{OrderDetails.pet}' ";
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                con.Open();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    PricePerPet = dt.Rows[0].Field<int>(0);
                    TotalPriceAsPerQuantity = PricePerPet * OrderDetails.number;
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
            return TotalPriceAsPerQuantity;
        }
        #endregion

        #region order details of the currently logged in user
        public DataTable GetOrderDetails() {
            try
            {
                DataTable dt = new DataTable();
                string query = $"select * from order_details where username='{Login.username}' ";
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
