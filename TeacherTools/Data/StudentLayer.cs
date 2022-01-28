using System.Collections.Generic;
using System.Linq;
using TeacherTools.Models;

namespace TeacherTools.Data
{
    public partial class DatabaseLayer
    {
        public static bool AddStudent(Student st) {
            using (AppContext app = new AppContext()) {
                var check = app.Students.FirstOrDefault(s => s.FirstName == st.FirstName && s.LastName == st.LastName && s.Birthday == st.Birthday);
                if (check == null) { 
                    app.Students.Add(st);
                    app.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public static bool DelStudent(Student st) {
            using (AppContext app = new AppContext()) {
                var check = app.Students.FirstOrDefault(s => s.FirstName == st.FirstName && s.LastName == st.LastName && s.Birthday == st.Birthday);
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
