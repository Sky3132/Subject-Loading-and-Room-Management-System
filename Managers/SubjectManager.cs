using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace __Subject_Loading_and_Room_Assignment_Monitoring_System.Managers
{
    public class SubjectManager : Interfaces.ISubjectManager //IMPLEMENTATION
    {
        public void Validate(Core_Models.SubjectModel sub)
        {
            if (sub.Code <= 0) throw new Exception("Subject Code must be a valid number.");
            if (string.IsNullOrWhiteSpace(sub.Title)) throw new Exception("Subject Title cannot be empty.");
            if (string.IsNullOrWhiteSpace(sub.DepartmentName)) throw new Exception("Please select a Department.");
            if (string.IsNullOrWhiteSpace(sub.ProgramName)) throw new Exception("Please select a Program.");
        }
        public void ValidateDelete(int subjectId)
        {
            using (DataClasses1DataContext db = new DataClasses1DataContext())
            {
                // Check if the subject is currently assigned to a room or faculty (Feature 5)
                bool isUsed = db.tblsubjectOfferings.Any(o => o.subjectId == subjectId);

                if (isUsed)
                {
                    throw new Exception("Cannot delete this subject because it is currently assigned to a class schedule.");
                }
            }
        }
        public bool PerformVisualSearch(DataGridView dgv, string term)
        {
            bool matchFound = false;
            foreach (DataGridViewRow row in dgv.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null && cell.Value.ToString().ToLower().Contains(term))
                    {
                        cell.Style.BackColor = Color.Yellow; // Keep your highlighting
                        matchFound = true;
                    }
                }
            }
            return matchFound;
        }
    }
}
