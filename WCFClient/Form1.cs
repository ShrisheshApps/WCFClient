using System;
using System.Windows.Forms;

namespace WCFClient
{
    public partial class Form1 : Form
    {
        HTTP.CalculateClient client = new HTTP.CalculateClient("BasicHttpBinding_ICalculate");
        //TCP.CalculateClient client = new TCP.CalculateClient("NetTcpBinding_ICalculate");

        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if ((!string.IsNullOrWhiteSpace(txtNumber1.Text)) && (!string.IsNullOrWhiteSpace(txtNumber2.Text)))
            {
                double sum = client.Add(Convert.ToDouble(txtNumber1.Text), Convert.ToDouble(txtNumber2.Text));
                lblMessage.Text = client.GetMessage("The sum of numbers is " + sum.ToString());
            }

        }

        private void btnSubtract_Click(object sender, EventArgs e)
        {
            if ((!string.IsNullOrWhiteSpace(txtNumber1.Text)) && (!string.IsNullOrWhiteSpace(txtNumber2.Text)))
            {
                double subtract = client.Subtract(Convert.ToDouble(txtNumber1.Text), Convert.ToDouble(txtNumber2.Text));
                lblMessage.Text = client.GetMessage("The difference of numbers is " + subtract.ToString());
            }

        }
    }
}
