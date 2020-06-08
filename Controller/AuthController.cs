using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class AuthController
    {
        public static int authId;
        private CourseWorkDbContext context;
        private readonly EncryptionController service;
        public string result = "Неверный логин или пароль";
        public AuthController(CourseWorkDbContext context, EncryptionController service)
        {
            this.context = context;
            this.service = service;
        }

        //регистрация нового пользователя
        public void AddElement(User model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    User element = context.Users.FirstOrDefault(rec =>
                   rec.Login == model.Login);
                    if (element != null)
                    {
                        throw new Exception("Уже есть пользователь с таким логином");
                    }
                    string encryptedPass = service.Encrypt("Login", model.Password);
                    element = new User
                    {
                        FIO = model.FIO,
                        CompanyName = model.CompanyName,
                        Login = model.Login,
                        Password = encryptedPass,
                        Email = model.Email,
                        PhoneNumber = model.PhoneNumber,
                        Role = model.Role
                    };
                    context.Users.Add(element);
                    context.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        //проверка совпадения логина и пароля с учетом шифрования
        public string CheckAuthInfo(string login, string password)
        {
            string pass = service.Encrypt("Login", password);
            User element = context.Users.FirstOrDefault(rec => rec.Login ==
          login && rec.Password == pass);
            if (element != null)
            {
                authId = element.Id;
                result = element.Role;                
            }
            else
            {
                result = "Неверный логин или пароль";
            }
            return result;
        }

    }

}
