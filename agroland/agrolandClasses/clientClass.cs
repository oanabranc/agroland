using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace agroland.agrolandClasses
{
    class clientClass
    {
        //getter setter properties
        //acts as data carrier in our application

        public int ClientID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Product { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderDate { get; set; }

        static string myConnection = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;

        //selecting data from database
        public DataTable Select()
        {
            //database connection
            SqlConnection connection = new SqlConnection(myConnection);
            DataTable dataTable = new DataTable();
            try
            {
                //writing SQL query
                string sql = "SELECT * FROM clients";

                //creating command using sql and connection
                SqlCommand command = new SqlCommand(sql, connection);

                //creating SQL DataAdapter using command
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                connection.Open();
                adapter.Fill(dataTable);

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return dataTable;
        }

        //method for inserting data into database
        public bool Insert(clientClass c)
        {
            //creating a default return type and setting its value to false
            bool isSuccess = false;

            //connect database 
            SqlConnection connection = new SqlConnection(myConnection); 

            try
            {
                //create a SQL query to insert data
                string sql = "INSERT INTO clients (FirstName, LastName, Address, Product, Quantity, OrderDate) VALUES (@FirstName, @LastName, @Address, @Product, @Quantity, @OrderDate)";

                //create SQL Command using sql and connection 
                SqlCommand command = new SqlCommand(sql, connection);

                //create parameters to add data 
                command.Parameters.AddWithValue("@FirstName", c.FirstName);
                command.Parameters.AddWithValue("@LastName", c.LastName);
                command.Parameters.AddWithValue("@Address", c.Address);
                command.Parameters.AddWithValue("@Product", c.Product);
                command.Parameters.AddWithValue("@Quantity", c.Quantity);
                command.Parameters.AddWithValue("@OrderDate", c.OrderDate);

                //connection open
                connection.Open();
                int rows = command.ExecuteNonQuery();

                //if the query runs successfully then the value of rows will be greater than zero else its value will be 0
                if(rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //close connection
                connection.Close();
            }

            return isSuccess;
        }

        //method for updating data in database
        public bool Update(clientClass c)
        {
            //create a default value return type and set its default value to false 
            bool isSuccess = false;

            //create SQL connection
            SqlConnection connection = new SqlConnection(myConnection);
            try
            {
                //SQL to update data in database 
                string sql = "UPDATE clients SET FirstName=@FirstName, LastName=@LastName, Address=@Address, Product=@Product, Quantity=@Quantity, OrderDate=@OrderDate WHERE ClientID=@ClientID";

                //creating SQL Command 
                SqlCommand command = new SqlCommand(sql, connection);

                //create parameters to add value 
                command.Parameters.AddWithValue("@FirstName", c.FirstName);
                command.Parameters.AddWithValue("@LastName", c.LastName);
                command.Parameters.AddWithValue("@Address", c.Address);
                command.Parameters.AddWithValue("@Product", c.Product);
                command.Parameters.AddWithValue("@Quantity", c.Quantity);
                command.Parameters.AddWithValue("@OrderDate", c.OrderDate);
                command.Parameters.AddWithValue("ClientID", c.ClientID);

                //open database connection
                connection.Open();

                int rows = command.ExecuteNonQuery();

                //if the query runs successfully then the value of rows will be greater than zero else its value will be 0
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //close connection
                connection.Close();
            }

            return isSuccess;
        }

        //method to delete data from database
        public bool Delete(clientClass c)
        {
            //create a default value return type and set its default value to false 
            bool isSuccess = false;

            //create SQL connection
            SqlConnection connection = new SqlConnection(myConnection);

            try
            {
                //SQL query to delete data
                string sql = "DELETE FROM clients WHERE ClientID=@ClientID";

                //creating SQL Command
                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@ClientID", c.ClientID);

                //open connection
                connection.Open();

                int rows = command.ExecuteNonQuery();

                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //close connection
                connection.Close();
            }

            return isSuccess;
        }
    }
}
