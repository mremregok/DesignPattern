using Microsoft.Extensions.ObjectPool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEducaiton.UML.ObjectPool
{
    internal class MicrosoftPoolProvider
    {
        void test()
        {

            //Microsoft.Extensions.ObjectPool NuGet paketi indirilmeli.
            DefaultObjectPoolProvider objectPoolProvider = new DefaultObjectPoolProvider();

            //Constructor parametresiz olmalı.
            ObjectPool<PooledObject> objectPool 
                = objectPoolProvider.Create(new DefaultPooledObjectPolicy<PooledObject>());
            PooledObject object1 = objectPool.Get();
            var cstr1 = object1.ConnectionString;
            objectPool.Return(object1);

            PooledObject object2 = objectPool.Get();
            var cstr2 = object2.ConnectionString;
            objectPool.Return(object2);
        }
    }
}
