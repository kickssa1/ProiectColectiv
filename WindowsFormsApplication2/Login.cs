﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication2
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            userField.Clear();
            passwordField.Clear();
        }
        
        private void LoginButton_Click(object sender, EventArgs e)
        {
             SqlConnection con = new SqlConnection(@"Data Source=TUDOR;Initial Catalog=LoginData;Integrated Security=True");
            

            if (typeComboBox.Text == "Admin")
            {
                SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) From Login Where username='"
                + userField.Text + "' and password='" + passwordField.Text + "' and admin=1", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows[0][0].ToString() == "1")
                {
                    Hide();
                    AdminForm ss = new AdminForm();
                    ss.Show();
                }

                else
                {
                    MessageBox.Show("Incorrect username or password, or there might not exist an Admin account with these credentials!");
                }
            }

            else if (typeComboBox.Text == "HR")
            {
                SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) From Login Where username='"
               + userField.Text + "' and password='" + passwordField.Text + "' and hr=1", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows[0][0].ToString() == "1")
                {
                    this.Hide();
                    HRForm ss = new HRForm();
                    ss.Show();
                }

                else
                {
                    MessageBox.Show("Incorrect username or password, or there might not exist a HR account with these credentials!");
                }
            }

            else
            {
                SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) From Login Where username='"
               + userField.Text + "' and password='" + passwordField.Text + "' and employee=1", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows[0][0].ToString() == "1")
                {
                    this.Hide();
                    EmployeeForm ss = new EmployeeForm(userField.Text);
                    ss.Show();
                }

                else
                {
                    MessageBox.Show("Incorrect username or password, or there might not exist an Employee account with these credentials!");
                }
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
