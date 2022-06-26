using System;
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
            HTTP.StudentRequest request = new HTTP.StudentRequest();
            request.StudentId = Convert.ToInt32(textBoxID.Text);
            request.StudentKey = "ABJ-KEY";
            // the out parameters are properties of StudentResponse
            int Id = client.GetStudent(request.StudentKey, request.StudentId, out string Name, out string Gender, out string City, out HTTP.StudentType Type,out int RegularFees, out int CourseHours, out int HourlyRate);

            string data =   "\nID: " + Id + "\nName: " + Name +
                            "\nGender: " + Gender + "\nCity: " + City +
                            "\nType: " + Type + "\nRegularFees: " + RegularFees +
                            "\nCourseHours: " + CourseHours + "\nHourlyRate: " + HourlyRate;
            label1.Text = data;
        }
    }
}
