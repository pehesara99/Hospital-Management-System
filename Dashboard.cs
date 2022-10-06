using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();

        }
       
        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel1.Controls.Add(childForm);
            panel1.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void btnFullHistoryOfThePatient_Click(object sender, EventArgs e)
        {
            /*PatientDetails ds = new PatientDetails();
            ds.ShowDialog();*/
            openChildForm(new PatientDetails());
        }

        private void btnHospitalInformation_Click(object sender, EventArgs e)
        {
            /*Information ds = new Information();
            ds.ShowDialog();*/
            openChildForm(new Information());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*payment ds = new payment();
            ds.ShowDialog();*/
            openChildForm(new payment());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*salary ds = new salary();
            ds.ShowDialog();*/
            openChildForm(new salary());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            /*channeling ds = new channeling();
            ds.ShowDialog();*/
            openChildForm(new channeling());
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            timer1.Start();
            label4.Text = DateTime.Now.ToLongTimeString();
            label6.Text = DateTime.Now.ToLongDateString();
            label7.Text = Form1.weluser.ToUpper();
        }

        private void btnAddNewPatientRecord_Click(object sender, EventArgs e)
        {
            openChildForm(new addmember());
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label4.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            openChildForm(new dimage());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 back = new Form1();
            this.Hide();
            back.Show();
        }
    }
}
