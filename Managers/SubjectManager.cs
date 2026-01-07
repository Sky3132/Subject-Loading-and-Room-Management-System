using __Subject_Loading_and_Room_Assignment_Monitoring_System.Managers.OOMDemo.Managers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace __Subject_Loading_and_Room_Assignment_Monitoring_System.Managers
{
    // Inherit from BaseManager AND implement ISubjectManager
    public class SubjectManager : BaseManager, Interfaces.ISubjectManager
    {
        public void Validate(Core_Models.SubjectModel sub)
        {
            // Using the encapsulated helper from the BaseManager
            EnsureNotNull(sub.Title, "Subject Title");
            EnsureNotNull(sub.DepartmentName, "Department");
            EnsureNotNull(sub.ProgramName, "Program");

            if (sub.Code <= 0) throw new Exception("Subject Code must be a valid number.");
        }

        public void ValidateDelete(int subjectId)
        {
            using (DataClasses1DataContext db = new DataClasses1DataContext())
            {
                bool isUsed = db.tblsubjectOfferings.Any(o => o.subjectId == subjectId);
                if (isUsed) throw new Exception("Subject is currently assigned to a schedule.");
            }
        }
        // Inside SubjectManager.cs
        public int GetCount()
        {
            // This uses your DataContext to count the subjects in the database
            using (DataClasses1DataContext db = new DataClasses1DataContext())
            {
                return db.tblsubjects.Count();
            }
        }
    }
}
