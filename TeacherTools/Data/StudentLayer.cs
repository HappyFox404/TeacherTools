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

        public ViewingModel GetStudents(string login) {
            using (AppContext app = new AppContext()) {
                ViewingModel model = new ViewingModel()
                {
                    Students = app.Students.Include(s => s.Account).Where(s => s.Account.Login == login).ToList(),
                    Groups = app.Groups.Include(g => g.Account).Where(g => g.Account.Login == login).ToList()
                };
                return model;
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

        public bool AddGroup(string name, DateTime dateCreate, string login, string? about = null) {
            using (AppContext app = new AppContext()) {
                Account acc = app.Accounts.FirstOrDefault(ac => ac.Login == login);
                var check = app.Groups.Include(g => g.Account).FirstOrDefault(g => g.Name == name && g.DateCreate == dateCreate && g.Account.Login == login);
                if (check != null)
                    return false;
                app.Groups.Add(new Group() { Name = name, DateCreate = dateCreate, About = about, Account = acc });
                app.SaveChanges();
                return true;
            }
        }

        public bool DelGroup(string ids)
        {
            using (AppContext app = new AppContext())
            {
                var check = app.Groups.FirstOrDefault(s => s.Id == ids);
                if (check != null)
                {
                    app.Groups.Remove(check);
                    app.SaveChanges();
                    return true;
                }
                return false;
            }
        }
    }
}
