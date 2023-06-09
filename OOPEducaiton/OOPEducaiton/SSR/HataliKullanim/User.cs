using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEducaiton.SSR.HataliKullanim
{
    /*
     Bu örnekte, User sınıfı hem veritabanı işlemlerini (Save, Load, Delete) 
     hem de e-posta gönderme işlemlerini (SendEmail) gerçekleştirmektedir. 
     Bu durumda SRP ihlal edilmektedir çünkü sınıfın birden fazla sorumluluğu vardır.
     */
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Save()
        {
            // Veritabanına kullanıcıyı kaydetme işlemleri
        }

        public void Load(int userId)
        {
            // Veritabanından kullanıcıyı yükleme işlemleri
        }

        public void Delete()
        {
            // Veritabanından kullanıcıyı silme işlemleri
        }

        public void SendEmail(string message)
        {
            // E-posta gönderme işlemleri
        }
    }
}
