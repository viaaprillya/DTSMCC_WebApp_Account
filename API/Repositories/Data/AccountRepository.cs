using API.ViewModel;
using API.Models;
using API.Context;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace API.Repositories.Data
{
    public class AccountRepository
    {
        MyContext myContext;

        public AccountRepository(MyContext myContext)
        {
            this.myContext = myContext;
        }

        public ResponseLogin Login (Login login)
        {
            var data = myContext.UserRole
                .Include(x => x.Role)
                .Include(x => x.User)
                .Include(x => x.User.Employee)
                .FirstOrDefault(x =>
                    x.User.Employee.Email.Equals(login.Email));

            if (data != null)
            {
                bool verifiedPassword = Hashing.ValidatePassword(login.Password, data.User.Password);
                if (verifiedPassword == true){
                    ResponseLogin responseLogin = new ResponseLogin()
                    {
                        Id = data.User.Id,
                        FullName = data.User.Employee.FullName,
                        Email = data.User.Employee.Email,
                        Role = data.Role.Name
                    };
                    return responseLogin;
                }
            }
            return null;
        }

        [HttpPost]
        public int Register(Register register)
        {
            string passwordHash = Hashing.HashPassword(register.Password);
            Employee employee = new Employee();
            employee.FullName = register.FullName;
            employee.Email = register.Email;

            User user = new User();
            user.Employee = employee;
            user.Password = passwordHash;
            myContext.Add(user);
            myContext.SaveChanges();

            UserRole userRole = new UserRole();
            userRole.UserId = user.Id;
            userRole.RoleId = 2;
            myContext.Add(userRole);
            var result = myContext.SaveChanges();
            return result;
        }

        public int ChangePassword(ChangePassword changePassword)
        {
            var data = myContext.User
                .FirstOrDefault(x =>
                    x.Employee.Email.Equals(changePassword.Email));
            string newPasswordHash = Hashing.HashPassword(changePassword.NewPassword);
            data.Password = newPasswordHash;
            myContext.User.Update(data);
            var result = myContext.SaveChanges();
            return result;
        }

    }

    public class Hashing
    {
        private static string GetRandomSalt()
        {
            return BCrypt.Net.BCrypt.GenerateSalt(12);
        }

        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, GetRandomSalt());
        }

        public static bool ValidatePassword(string password, string correctHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, correctHash);
        }
    }
}
