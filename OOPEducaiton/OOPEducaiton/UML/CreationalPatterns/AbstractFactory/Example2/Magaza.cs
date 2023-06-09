using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPEducaiton.UML.CreationalPatterns.AbstractFactory.Example2
{
    public class Magaza<T> where T : UretimBandi, new()
	{
        UretimBandi _bant;
        public Magaza(int adet)
        {
            _bant = new T();
            _bant.UretimMiktari = adet;
        }

        public void UretimiBaslat(int adet)
        {
            _bant.Uret();
        }
    }
}