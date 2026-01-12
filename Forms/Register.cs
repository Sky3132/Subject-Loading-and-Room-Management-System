using __Subject_Loading_and_Room_Assignment_Monitoring_System.Managers;
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

namespace __Subject_Loading_and_Room_Assignment_Monitoring_System
{
    public partial class Register : Form
    {
        //private UserManager userManager = new UserManager();
        public Register()
        {
            InitializeComponent();

        }



        private void btnRegister_Click(object sender, EventArgs e)
        {
           
        }

        private void imgBackToLogin_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtConfirmPassRegister_KeyUp(object sender, KeyEventArgs e)
        {
            string password = txtPassRegister.Text;
            string confirm = txtConfirmPassRegister.Text;


            if (password != confirm)
            {
                lblError.Visible = true;
            }
            else
            {
                lblError.Visible = false;
            }
        }

        private void btnRegister_Click_1(object sender, EventArgs e)
        {

            string username = txtUsernameRegister.Text;
            string password = txtPassRegister.Text;
            string confirm = txtConfirmPassRegister.Text;




            DataClasses1DataContext db = new DataClasses1DataContext();
            string hashedPassword = PassHash.ComputeSha256Hash(password);



            db.Register_Procedure(username, hashedPassword);


            if (username != "" || password != "")
            {
                MessageBox.Show("Registration Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Login login = new Login();
                login.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Username already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
