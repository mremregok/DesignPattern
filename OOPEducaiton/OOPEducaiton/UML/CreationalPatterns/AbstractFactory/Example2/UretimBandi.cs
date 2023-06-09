using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPEducaiton.UML.CreationalPatterns.AbstractFactory.Example2
{
    public abstract class UretimBandi
    {
        public abstract int UretimMiktari { get; set; }
        public abstract void Uret();
    }
}