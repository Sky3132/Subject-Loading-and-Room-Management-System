using __Subject_Loading_and_Room_Assignment_Monitoring_System.Interfaces;
using __Subject_Loading_and_Room_Assignment_Monitoring_System.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace __Subject_Loading_and_Room_Assignment_Monitoring_System.Core_Models
{
    internal class AdminModel : UserManager
    {
        public string UserRole { get; set; }

        public AdminModel(int userId, int roleId)
           : base(userId, roleId) { }

        public override Form GetForm()
        {
            //admin dashboard form
            return new Main();
        }  


        }


    }

