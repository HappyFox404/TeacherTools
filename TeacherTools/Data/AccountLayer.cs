using TeacherTools.Models;
using System.Linq;

namespace TeacherTools.Data
{
    public partial class DatabaseLayer
    {
        public enum AccountFindStatus { 
            Found = 0,
            NotFound,
            Incorrect
        }

        public bool AddAccount(Account acc) {
            using (AppContext app = new AppContext()) {
                if (app.Accounts.FirstOrDefault(a => a.Login == acc.Login) == null)
                {
                    app.Accounts.Add(acc);
                    app.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public AccountFindStatus EqualsAccount(Account acc) {
            using (AppContext app = new AppContext()) {
                if (app.Accounts.FirstOrDefault(a => a.Login == acc.Login && a.Password == acc.Password) != null)
                    return AccountFindStatus.Found;
                else if (app.Accounts.FirstOrDefault(a => a.Login == acc.Login) == null)
                    return AccountFindStatus.NotFound;
                else
                    return AccountFindStatus.Incorrect;
            }
        }
    }
}
