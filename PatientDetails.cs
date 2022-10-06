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
    public partial class PatientDetails : Form
    {
        public PatientDetails()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtNIC.Text == "" || textTel.Text == "" || textDet.Text == "" || dateTimePicker1.Text == "" || textBlood.Text == "")
            {
                MessageBox.Show("Please Fill Items");
                return;
            }

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Project\Project\Hospital.mdf;Integrated Security=True;");
            string query = "INSERT INTO PatientDetails(pa_name,i_no,te_no,adm_reason,adm_date,b_grp) VALUES('" + txtName.Text + "','" + txtNIC.Text + "','" + textTel.Text + "','" + textDet.Text + "','" + dateTimePicker1.Text + "','" + textBlood.Text + "')";
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

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Project\Project\Hospital.mdf;Integrated Security=True;");
            sqlCon.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter("Select * from PatientDetails", sqlCon);
            DataTable dtbl = new DataTable();
            sqlda.Fill(dtbl);

            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.DataSource = dtbl;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "")
            {
                SqlConnection sqlCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Project\Project\Hospital.mdf;Integrated Security=True;");

                //string query = "UPDATE PatientDetails SET pa_id='" + txtID.Text + "',pa_name='" + txtName.Text + "',i_no='" + txtNIC.Text + "',te_no='" + textTel.Text + "',b_grp='" + textBlood.Text + "' where pa_id='" + int.Parse(txtID.Text) + "'";

                string query = "UPDATE PatientDetails SET pa_name = '" + txtName.Text + "',i_no='" + txtNIC.Text + "',te_no='" + textTel.Text + "',b_grp='" + textBlood.Text + "' WHERE pa_id = " + txtID.Text + "";
                SqlCommand cmd = new SqlCommand(query, sqlCon);
                try
                {
                    sqlCon.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Successsfully updated");
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
            else
            {
                MessageBox.Show("Put Patient ID");
            }
            //cmd.ExecuteNonQuery();
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtID.Text !="") {
                if (MessageBox.Show("Are you sure to Delete?", "Delete Record", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Project\Project\Hospital.mdf;Integrated Security=True;");
                    string query = "DELETE FROM PatientDetails WHERE pa_id = " + txtID.Text + "";
                    SqlCommand cmd = new SqlCommand(query, con);
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Successsfully Deleted");
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
                } }
            else
            {
                MessageBox.Show("Put Patient ID");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Project\Project\Hospital.mdf;Integrated Security=True;");
            con.Open();
            if (txtID.Text != "")
            {
                 SqlCommand cmd = new SqlCommand("Select pa_name,i_no,te_no,b_grp from PatientDetails WHERE pa_id = " + txtID.Text + " ",con);
                 SqlDataReader da = cmd.ExecuteReader();
                 while (da.Read())
                 {
                     txtName.Text = da.GetValue(0).ToString();
                     txtNIC.Text = da.GetValue(1).ToString();
                    textTel.Text = da.GetValue(2).ToString();
                    textBlood.Text = da.GetValue(3).ToString();
                 }
                con.Close();
                con.Open();
                SqlDataAdapter sqlda = new SqlDataAdapter("Select * from PatientDetails WHERE pa_id = " + txtID.Text + "", con);
                DataTable dtbl = new DataTable();
                sqlda.Fill(dtbl);

                dataGridView2.AutoGenerateColumns = false;
                dataGridView2.DataSource = dtbl;
                con.Close();
            }
            else
            {
                MessageBox.Show("Put Patient ID");
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            txtName.Text = "";
            txtNIC.Text = "";
            textBlood.Text = "";
            textDet.Text = "";
            textTel.Text = "";
                    }
    }
}
