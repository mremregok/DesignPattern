using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEducaiton.UML.LazyInitialize
{
    using System;

    public class HeavyResource
    {
        public HeavyResource()
        {
            Console.WriteLine("HeavyResource oluşturuldu");
        }

        public void PerformOperation()
        {
            Console.WriteLine("HeavyResource işlem gerçekleştiriyor");
        }
    }

    public class ResourceProvider
    {
        private Lazy<HeavyResource> _resource = new Lazy<HeavyResource>();

        public void DoOperation()
        {
            HeavyResource resource = _resource.Value;
            resource.PerformOperation();
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            ResourceProvider provider = new ResourceProvider();

            // HeavyResource nesnesi henüz oluşturulmamıştır.

            // İlk kullanımda HeavyResource oluşturulur. ve işlem gerçekleştirilir
            provider.DoOperation();

            // İkinci kullanımda daha önce oluşturulur HeavyResource kullanılır
            provider.DoOperation();
        }
    }

}
