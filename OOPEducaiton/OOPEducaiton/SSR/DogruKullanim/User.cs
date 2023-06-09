using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEducaiton.SSR.DogruKullanim
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class UserRepository
    {
        public void Save(User user)
        {
            // Veritabanına kullanıcıyı kaydetme işlemleri
            throw new NotImplementedException();
        }

        public User Load(int userId)
        {
            // Veritabanından kullanıcıyı yükleme işlemleri
            throw new NotImplementedException();
        }

        public void Delete(User user)
        {
            // Veritabanından kullanıcıyı silme işlemleri
            throw new NotImplementedException();
        }
    }

    public class EmailService
    {
        public void SendEmail(User user, string message)
        {
            // E-posta gönderme işlemleri
            throw new NotImplementedException();
        }
    }

}
