using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEducaiton.DPI
{
    /*
     * Bu örnekte, ILogger arayüzü loglama işlemlerini tanımlar.
     * FileLogger ve ConsoleLogger sınıfları, bu arayüzü uygular ve kendi loglama işlemlerini gerçekleştirir.
     * DataManager sınıfı, ILogger arayüzüne bağımlıdır. 
     * Ancak, bağımlılığı enjeksiyon (dependency injection) ile tersine çevirir.
     * Yani DataManager sınıfının ILogger nesnesi, dışarıdan bir parametre olarak alınır.
     * Bu sayede DataManager sınıfı, hangi türde ILogger uygulaması kullanılacağına karar vermez, sadece ILogger arayüzüne bağımlı olur.
     * 
     * Bu şekilde DIP'yi uygulayarak, DataManager sınıfı loglama işlemlerini gerçekleştirirken 
     * hangi türde logger kullanıldığından bağımsız hale gelir. 
     * Bu da bileşenlerin daha esnek ve değiştirilebilir olmasını sağlar.
     */
    public interface ILogger
    {
        void Log(string message);
    }

    public class FileLogger : ILogger
    {
        public void Log(string message)
        {
            // Loglama işlemleri
            // Dosyaya log yazma
            Console.WriteLine("Dosyaya yazıldı.");
        }
    }

    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            // Loglama işlemleri
            // Konsola log yazma
            Console.WriteLine("Konsola yazıldı.");
        }
    }

    public class DatabaseLogger : ILogger
    {
        public void Log(string message)
        {
            // Loglama işlemleri
            // Konsola log yazma
            Console.WriteLine("Konsola yazıldı.");
        }
    }

    public class GrafanaLogger : ILogger
    {
        public void Log(string message)
        {
            // Loglama işlemleri
            // Konsola log yazma
            Console.WriteLine("Konsola yazıldı.");
        }
    }

    public class DataManager<T> where T : ILogger, new()
    {
        private ILogger _logger;

        public DataManager()
        {
            _logger = new T();
        }

        public void SaveData(string data)
        {
            try
            {
                // Veriyi kaydetme işlemleri
                _logger.Log("Veri kaydedildi.");
            }
            catch (Exception ex)
            {
                _logger.Log("Hata oluştu: " + ex.Message);
            }
        }
    }


    public class Test
    {

    }
}
