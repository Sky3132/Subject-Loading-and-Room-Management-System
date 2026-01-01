using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace __Subject_Loading_and_Room_Assignment_Monitoring_System.Managers
{
    namespace OOMDemo.Managers
    {
        public abstract class BaseManager
        {
            // Shared Search Logic
            public bool PerformVisualSearch(DataGridView dgv, string term)
            {
                bool matchFound = false;
                // Convert once here to save memory/speed
                string lowerTerm = term.Trim().ToLower();

                foreach (DataGridViewRow row in dgv.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Value != null && cell.Value.ToString().ToLower().Contains(lowerTerm))
                        {
                            cell.Style.BackColor = Color.Yellow;
                            matchFound = true;
                        }
                        else
                        {
                            cell.Style.BackColor = Color.White;
                        }
                    }
                }
                return matchFound;
            }

            // Shared Validation Helper (Encapsulation)
            protected void EnsureNotNull(string value, string fieldName)
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception($"{fieldName} cannot be empty.");
            }
        }
    }
}
