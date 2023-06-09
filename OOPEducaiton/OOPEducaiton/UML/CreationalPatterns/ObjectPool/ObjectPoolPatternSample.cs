using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEducaiton.UML.ObjectPool
{
    using System;
    using System.Collections.Generic;

    // PooledObject sınıfı, havuzda saklanacak olan nesneleri temsil eder
    public class PooledObject
    {
        // Nesnenin özellikleri
        public string ConnectionString { get; set; }
        public bool InUse { get; set; }

        // Nesneyi kullanıma alır
        public void Acquire()
        {
            lock(this) 
            InUse = true;
            Console.WriteLine("Nesne kullanıma alındı: " + ConnectionString);
        }

        // Nesneyi havuza geri verir
        public void Release()
        {
            InUse = false;
            Console.WriteLine("Nesne havuza geri verildi: " + ConnectionString);
        }
    }

    // ConnectionPool sınıfı, nesne havuzunu yönetir
    public class ConnectionPool
    {
        private List<PooledObject> pool;
        private int maxSize;

        public ConnectionPool(int maxSize)
        {
            this.maxSize = maxSize==0? int.MaxValue : maxSize;
            pool = new List<PooledObject>(maxSize);
        }

        // Nesne havuzuna yeni bir nesne ekler
        public void AddObject(PooledObject obj)
        {
            if (pool.Count < maxSize)
            {
                pool.Add(obj);
                Console.WriteLine("Yeni nesne havuza eklendi: " + obj.ConnectionString);
            }
            else
            {
                Console.WriteLine("Nesne havuzunun maksimum kapasitesine ulaşıldı.");
            }
        }

        // Havuzdan bir nesne ödünç alır
        public PooledObject AcquireObject()
        {
            foreach (var obj in pool)
            {
                if (!obj.InUse)
                {
                    obj.Acquire();
                    return obj;
                }
            }

            Console.WriteLine("Havuzda kullanılabilir nesne bulunamadı.");
            return null;
        }
    }

    // Kullanım örneği
    public class Program
    {
        public static void Main(string[] args)
        {
            // Nesne havuzu oluşturulur ve bazı nesneler havuza eklenir
            ConnectionPool pool = new ConnectionPool(3);
            pool.AddObject(new PooledObject { ConnectionString = "Connection 1" });
            pool.AddObject(new PooledObject { ConnectionString = "Connection 2" });
            pool.AddObject(new PooledObject { ConnectionString = "Connection 3" });

            // Nesne havuzundan nesneler ödünç alınır ve kullanılır
            PooledObject obj1 = pool.AcquireObject();
            PooledObject obj2 = pool.AcquireObject();

            // Nesneler kullanıldıktan sonra havuza geri verilir
            obj1.Release();
            obj2.Release();

            // Havuzdan yeni bir nesne ödünç alınır
            PooledObject obj3 = pool.AcquireObject();

            Console.ReadLine();


           
        }
    }

}
