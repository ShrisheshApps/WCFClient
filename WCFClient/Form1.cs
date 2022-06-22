using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WCFClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            HTTP.StudentServiceClient client = new HTTP.StudentServiceClient();
            HTTP.StudentRequest studentRequest = new HTTP.StudentRequest();
            studentRequest.Id = 102;
            HTTP.Student student = client.GetStudent(studentRequest.Id);
            string result = "Name: " + student.Name + "\nGender: " + student.Gender + "\nCity: " + student.City;
            label1.Text = result;
        }
    }
}
