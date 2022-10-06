using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Project
{
    public partial class adnewpatient : Form
    {
        public adnewpatient()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (textName.Text == "" || textAge.Text == "" || textAddress.Text == "" || textContactNumber.Text == "" || comboBoxGender.Text == "" || comboBoxBloodGroup.Text == "")
            {
                MessageBox.Show("Please Fill Items");
                return;
            }

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\asus\source\repos\student\students.mdf;Integrated Security=True");
                string query = "INSERT INTO patient(name,age,address,contact,gender,bgroup,admitr) VALUES('" + textName.Text + "','" + textAge.Text + "','" + textAddress.Text + "','" + textContactNumber.Text + "','" + comboBoxGender.Text + "','" + comboBoxBloodGroup.Text + "','" + textDetails.Text + "')";
                SqlCommand cmd = new SqlCommand(query, con);
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record inserted Successfully");
                }
                catch (SqlException)
                {
                    MessageBox.Show("Error");
                }
                finally
                {
                    con.Close();
                    Console.ReadLine();
                }
            
        }

        private void textName_Validating(object sender, CancelEventArgs e)
        {
           
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            textName.Text = "";
            textAge.Text = "";
            textAddress.Text = "";
            textContactNumber.Text = "";
            comboBoxGender.Text = "";
            comboBoxBloodGroup.Text = "";
            textDetails.Text = "";
        }
    }
}
