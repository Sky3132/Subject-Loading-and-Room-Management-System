using __Subject_Loading_and_Room_Assignment_Monitoring_System.Models;
using __Subject_Loading_and_Room_Assignment_Monitoring_System.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace __Subject_Loading_and_Room_Assignment_Monitoring_System.Managers
{
    public class FacultyManager : OOMDemo.Managers.BaseManager, IFacultyManager
    {
        public void Validate(FacultyMember faculty)
        {
            // Reusing BaseManager helpers
            EnsureNotNull(faculty.FirstName, "First Name");
            EnsureNotNull(faculty.LastName, "Last Name");

            if (faculty.DepartmentID <= 0)
                throw new Exception("Please select a valid Department.");
        }

        public object GetFacultyGridData()
        {
            using (DataClasses1DataContext db = new DataClasses1DataContext())
            {
                var list = from f in db.tblFaculties
                           join d in db.tblDepartments on f.DepartmentID equals d.DepartmentID
                           let totalUnits = db.tblFacultyLoadings
                               .Where(l => l.FacultyID == f.FacultyID)
                               .Sum(l => (int?)(l.tblsubjectOffering.tblsubject.LectureUnits +
                                                l.tblsubjectOffering.tblsubject.LaboratoryUnits)) ?? 0
                           select new
                           {
                               ID = f.FacultyID,
                               f.FirstName,
                               f.LastName,
                               Department = d.DepartmentName,
                               CurrentLoad = totalUnits,
                               Hours = totalUnits,
                               MaxLoad = f.MaxLoad,
                               RemainingUnits = f.MaxLoad - totalUnits,
                               f.DepartmentID
                           };
                return list.ToList();
            }
        }

        public void AddFaculty(FacultyMember model)
        {
            using (DataClasses1DataContext db = new DataClasses1DataContext())
            {
                // Duplicate check
                if (db.tblFaculties.Any(f => f.FirstName == model.FirstName && f.LastName == model.LastName))
                    throw new Exception("This faculty member already exists.");

                tblFaculty dbEntry = new tblFaculty
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    DepartmentID = model.DepartmentID,
                    MaxLoad = model.MaxLoad
                };
                db.tblFaculties.InsertOnSubmit(dbEntry);
                db.SubmitChanges();
            }
        }

        public void UpdateFaculty(FacultyMember model)
        {
            using (DataClasses1DataContext db = new DataClasses1DataContext())
            {
                var faculty = db.tblFaculties.First(f => f.FacultyID == model.FacultyID);
                faculty.FirstName = model.FirstName;
                faculty.LastName = model.LastName;
                faculty.DepartmentID = model.DepartmentID;
                db.SubmitChanges();
            }
        }

        public void DeleteFaculty(int id)
        {
            using (DataClasses1DataContext db = new DataClasses1DataContext())
            {
                var faculty = db.tblFaculties.First(f => f.FacultyID == id);
                db.tblFaculties.DeleteOnSubmit(faculty);
                db.SubmitChanges();
            }
        }

        public bool IsOverloaded(int facultyId, int newUnits)
        {
            using (DataClasses1DataContext db = new DataClasses1DataContext())
            {
                var faculty = db.tblFaculties.FirstOrDefault(f => f.FacultyID == facultyId);
                if (faculty == null) return false;

                int currentLoad = db.tblFacultyLoadings
                    .Where(l => l.FacultyID == facultyId)
                    .Sum(l => (int?)(l.tblsubjectOffering.tblsubject.LectureUnits +
                                     l.tblsubjectOffering.tblsubject.LaboratoryUnits)) ?? 0;

                return (currentLoad + newUnits) > faculty.MaxLoad;
            }
        }
    }
}