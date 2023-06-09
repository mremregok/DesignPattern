using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEducaiton.UML.BuilderPattern.ArabaUretim
{
    internal abstract class IArabaBuilder
    {
        protected Araba araba= default(Araba);

        public Araba Araba => araba;

        public abstract void SetKM();
        public abstract void SetMarka();
        public abstract void SetModel();
        public abstract void SetVites();
    }

 
}
