using System;
using System.Windows.Forms;

namespace WCFClient
{
    public partial class Form1 : Form
    {
        HTTP.StudentInfoClient client = new HTTP.StudentInfoClient();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
           HTTP.Student student= client.GetStudent(Convert.ToInt32( txtId.Text));
            txtName.Text = student.Name;
            txtGender.Text = student.Gender;
            txtCity.Text = student.City;
        }
    }
}
