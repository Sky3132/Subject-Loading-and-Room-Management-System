using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace __Subject_Loading_and_Room_Assignment_Monitoring_System
{
    internal class ConnectionString
    {
        //ENCAPSULATION
        public string connection { get; set; }
     
        public ConnectionString() //CONSTRUCTOR
        {
            this.connection = "Data Source=DESKTOP-CL62R53;Initial Catalog=Schooldb;Integrated Security=True;";
        }
    }
}
