using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class channeling : Form
    {
        public channeling()
        {
            InitializeComponent();
        }
        SqlConnection sqlCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Project\Hospital.mdf;Integrated Security=True;");
        private void button1_Click(object sender, EventArgs e)
        {
            if (textPatient.Text == "" || textMobile.Text == "" || textDoctor.Text == "" || comboCat.Text == "" || dateTimePicker1.Text == "" )
            {
                MessageBox.Show("Please Fill Items");
                return;
            }

            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Project\Project\Hospital.mdf;Integrated Security=True;");
            string query = "INSERT INTO channeling(name,m_no,d_name,cat,date) VALUES('" + textPatient.Text + "','" + textMobile.Text + "','" + textDoctor.Text + "','" + comboCat.Text + "','" + dateTimePicker1.Text + "')";
            SqlCommand cmd = new SqlCommand(query, sqlCon);
            try
            {
                sqlCon.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record inserted Successfully");
            }
            catch (SqlException)
            {
                MessageBox.Show("Error");
            }
            finally
            {
                sqlCon.Close();
                Console.ReadLine();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //SqlConnection sqlCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Project\Project\Hospital.mdf;Integrated Security=True;");
            sqlCon.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter("Select * from channeling", sqlCon);
            DataTable dtbl = new DataTable();
            sqlda.Fill(dtbl);

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = dtbl;
            sqlCon.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textID.Text != "")
            {
                // SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Project\Project\Hospital.mdf;Integrated Security=True;");
                sqlCon.Open();
                SqlDataAdapter sqlda = new SqlDataAdapter("Select * from channeling WHERE Id = " + textID.Text + "", sqlCon);
                DataTable dtbl = new DataTable();
                sqlda.Fill(dtbl);

                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = dtbl;
                sqlCon.Close();
            }
            else
            {
                MessageBox.Show("Put ID");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textID.Text != "")
            {
                if (MessageBox.Show("Are you sure to Delete?", "Delete Record", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Project\Project\Hospital.mdf;Integrated Security=True;");
                    string query = "DELETE FROM channeling WHERE Id = " + textID.Text + "";
                    SqlCommand cmd = new SqlCommand(query, sqlCon);
                    try
                    {
                        sqlCon.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Successsfully Deleted");
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Error");
                    }
                    finally
                    {
                        sqlCon.Close();
                        Console.ReadLine();
                    }
                }
            }
            else
            {
                MessageBox.Show("Put Patient ID");
            }
        }
    }
}
