using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace __Subject_Loading_and_Room_Assignment_Monitoring_System.Managers.OOMDemo.Managers
{
    public abstract class BaseManager
    {
        // 1. Database-level Filtering Logic
        // This takes any list and filters it based on the properties you choose
        public List<T> FilterList<T>(List<T> source, string term, params Func<T, string>[] properties)
        {
            if (string.IsNullOrWhiteSpace(term)) return source;

            string lowerTerm = term.Trim().ToLower();

            return source.Where(item => properties.Any(prop =>
                prop(item) != null && prop(item).ToLower().Contains(lowerTerm)
            )).ToList();
        }

        // 2. Visual Highlighting Logic
        public bool PerformVisualSearch(DataGridView dgv, string term)
        {
            bool matchFound = false;
            string lowerTerm = term.Trim().ToLower();

            foreach (DataGridViewRow row in dgv.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (!string.IsNullOrEmpty(lowerTerm) &&
                        cell.Value != null &&
                        cell.Value.ToString().ToLower().Contains(lowerTerm))
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

        protected void EnsureNotNull(string value, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new Exception($"{fieldName} cannot be empty.");
        }
    }
}