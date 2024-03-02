using agroland.agrolandClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace agroland
{
    public partial class ShopAgroland : Form
    {
        public ShopAgroland()
        {
            InitializeComponent();
        }

        clientClass c = new clientClass();

        private void ShopAgroland_Load(object sender, EventArgs e)
        {
            DataTable dataTable = c.Select();
            clientDataGridView.DataSource = dataTable;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged_2(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //get the value from the input fields
            c.FirstName = firstNameTextBox.Text;
            c.LastName = lastNameTextBox.Text;
            c.Address = addressTextBox.Text;
            c.Product = productTextBox.Text;
            c.Quantity = int.Parse(quantityTextBox.Text);
            c.OrderDate = orderDatePicker.Value;

            //insert data into database
            bool success = c.Insert(c);
            if(success == true)
            {
                MessageBox.Show("New client successfully inserted");
                Clear();
            }
            else
            {
                MessageBox.Show("Failed to add new client. Try again");
            }

            //load data in Data Grid View
            DataTable dataTable = c.Select();
            clientDataGridView.DataSource = dataTable;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //method to clear fields
        public void Clear()
        {
            clientTextBox.Text = "";
            firstNameTextBox.Text = "";
            lastNameTextBox.Text = "";
            addressTextBox.Text = "";
            productTextBox.Text = "";
            quantityTextBox.Text = "";
            orderDatePicker.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //get the data from text boxes
            c.ClientID = int.Parse(clientTextBox.Text);
            c.FirstName = firstNameTextBox.Text;
            c.LastName = lastNameTextBox.Text;
            c.Address = addressTextBox.Text;
            c.Product = productTextBox.Text;
            c.Quantity = int.Parse(quantityTextBox.Text);
            c.OrderDate = orderDatePicker.Value;

            //update data in database
            bool success = c.Update(c); 
            if(success == true)
            {
                MessageBox.Show("Client has been updated");
                DataTable dataTable = c.Select();
                clientDataGridView.DataSource = dataTable;
                Clear();
            }
            else
            {
                MessageBox.Show("Failed to update client");
            }
        }

        private void clientDataGridView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //get data from data grid view and load it to the text boxes
            //identify the row on which mouse is clicked
            int rowIndex = e.RowIndex;

            clientTextBox.Text = clientDataGridView.Rows[rowIndex].Cells[0].Value.ToString();
            firstNameTextBox.Text = clientDataGridView.Rows[rowIndex].Cells[1].Value.ToString();
            lastNameTextBox.Text = clientDataGridView.Rows[rowIndex].Cells[2].Value.ToString();
            addressTextBox.Text = clientDataGridView.Rows[rowIndex].Cells[3].Value.ToString();
            productTextBox.Text = clientDataGridView.Rows[rowIndex].Cells[4].Value.ToString();
            quantityTextBox.Text = clientDataGridView.Rows[rowIndex].Cells[5].Value.ToString();
            orderDatePicker.Value = (DateTime)clientDataGridView.Rows[rowIndex].Cells[6].Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //get data from the textboxes
            c.ClientID = int.Parse(clientTextBox.Text);
            bool success = c.Delete(c);
            if(success == true)
            {
                MessageBox.Show("Client successfully deleted");
                DataTable dataTable = c.Select();
                clientDataGridView.DataSource = dataTable;
                Clear();
            }
            else
            {
                MessageBox.Show("Failed to delete client. Try again!");
            }
        }
    }
}
