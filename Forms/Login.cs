using __Subject_Loading_and_Room_Assignment_Monitoring_System.Core_Models;
using __Subject_Loading_and_Room_Assignment_Monitoring_System.Managers;
using __Subject_Loading_and_Room_Assignment_Monitoring_System.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace __Subject_Loading_and_Room_Assignment_Monitoring_System
{
    public partial class Login : Form
    {
        //private UserManager userManager = new UserManager();
        int count = 0;

        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            using (DataClasses1DataContext db = new DataClasses1DataContext())
            {
                try
                {
                    string password = txtPassword.Text;
                    string username = txtUsername.Text;



                    bool isValid = db.Admin_Login(username, password).Any();


                    if (isValid)
                    {
                        MessageBox.Show("Login successful!");
                        Main mn = new Main();
                        mn.Show();
                        this.Hide();

                    }
                    else if (!isValid)
                    {
                        count++;
                        if (count > 3)
                        {
                            MessageBox.Show("Too many failed login attempts. Application will close.", "Unsuccessful Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Application.Exit();
                            txtUsername.Enabled = false;
                            txtPassword.Enabled = false;
                        }
                        MessageBox.Show("Invalid username or password.");
                        return;
                    }
                }
                catch (Exception ex) {
                  
                    MessageBox.Show(ex.Message, "Unsuccessful Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                
                }
            }
        }

        private void lblRegisterHere_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.Show();
            this.Hide();
        }

        AuthService _authService = new AuthService();

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            try
            {
                UserManager user = _authService.Login(
                    txtUsername.Text,
                    txtPassword.Text
                );

                // Polymorphism decides the UI
                Form dashboard = user.GetForm();


                dashboard.Show();
                this.Hide();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Invalid login", "Unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (txtPassword.UseSystemPasswordChar)
            {
                txtPassword.UseSystemPasswordChar = false;
            
            }
        }

        private void txtPassword_KeyUp(object sender, KeyEventArgs e)
        {
            eye.Visible = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
    }

