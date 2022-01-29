using System;
using System.Collections.Generic;
using System.Linq;
using TeacherTools.Models;
using Microsoft.EntityFrameworkCore;

namespace TeacherTools.Data
{
    public partial class DatabaseLayer
    {
        public bool AddStudent(string firstName, string lastName, DateTime birthday, string login) {
            using (AppContext app = new AppContext()) {
                Account account = app.Accounts.FirstOrDefault(ac => ac.Login == login);
                var check = app.Students.Include(s => s.Account).FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName && s.Birthday == birthday && s.Account.Login == login);
                if (check != null)
                    return false;
                app.Students.Add(new Student() { FirstName = firstName, LastName = lastName, Birthday = birthday, Account = account});
                app.SaveChanges();
                return true;
            }
        }

        public IEnumerable<Student> GetStudents() {
            using (AppContext app = new AppContext()) {
                return app.Students.Include(s => s.Account).ToList();
            }
        }

        public bool DelStudent(string ids) {
            using (AppContext app = new AppContext()) {
                var check = app.Students.FirstOrDefault(s => s.Id == ids);
                if (check != null) {
                    app.Students.Remove(check);
                    app.SaveChanges();
                    return true;
                }
                return false;
            }
        }
    }
}
