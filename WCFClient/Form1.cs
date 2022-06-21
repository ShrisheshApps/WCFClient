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
            if (!string.IsNullOrEmpty(txtId.Text))
            {
                HTTP.Student student = client.GetStudent(Convert.ToInt32(txtId.Text));
                if (student != null)
                {
                    txtName.Text = student.Name;
                    txtGender.Text = student.Gender;
                    txtCity.Text = student.City;
                    
                    if ( student.Type == HTTP.StudentType.Regular)
                    {
                        cboType.SelectedIndex = 0;
                        txtRegularFees.Text = ((HTTP.RegularStudent)student).TotalFees.ToString();
                    }
                    if (student.Type == HTTP.StudentType.Open)
                    {
                        cboType.SelectedIndex = 1;
                        txtHours.Text = ((HTTP.OpenStudent)student).Hours.ToString();
                        txtRate.Text = ((HTTP.OpenStudent)student).HourlyRate.ToString();
                    }
                }
                else
                {
                    lblMsg.Text = "Data not found";
                }
            }
           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            HTTP.Student student = null;
            if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtGender.Text) || string.IsNullOrEmpty(txtCity.Text))
            {
                lblMsg.Text = "Please fill all the data.";
            }
            else
            {
                if (cboType.SelectedIndex ==0)
                {
                    student = new HTTP.RegularStudent()
                    {
                        Name = txtName.Text,
                        Gender = txtGender.Text,
                        City = txtCity.Text,
                        TotalFees = Convert.ToInt32(txtRegularFees.Text),
                        Type = HTTP.StudentType.Regular
                    };
                }
                if (cboType.SelectedIndex == 1)
                {
                    student = new HTTP.OpenStudent()
                    {
                        Type = HTTP.StudentType.Open,
                        Name = txtName.Text,
                        Gender = txtGender.Text,
                        City = txtCity.Text,
                        HourlyRate = Convert.ToInt32(txtRate.Text),
                        Hours = Convert.ToInt32(txtHours.Text)
                    };
                }
                client.SaveStudent(student);
                lblMsg.Text = "Saved the data.";
            }
        }

        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboType.SelectedIndex == 0)
            {
                foreach (Control c in this.Controls)
                {
                    if (c.Tag != null)
                    {
                        c.Visible = false;
                    }
                    if (c.Tag != null && (string)c.Tag=="regular")
                    {
                        c.Visible = true;
                    }
                }

            }
            if (cboType.SelectedIndex==1)
            {
                foreach (Control c in this.Controls)
                {
                    if (c.Tag != null)
                    {
                        c.Visible = false;
                    }
                    if (c.Tag != null && (string)c.Tag == "open")
                    {
                        c.Visible = true;
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
