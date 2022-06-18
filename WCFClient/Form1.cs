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
                }
                else
                {
                    lblMsg.Text = "Data not found";
                }
            }
           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            HTTP.Student student = new HTTP.Student()
            {
                Name = txtName.Text,
                Gender = txtGender.Text,
                City = txtCity.Text
            };
            client.SaveStudent(student);
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
    }
}
