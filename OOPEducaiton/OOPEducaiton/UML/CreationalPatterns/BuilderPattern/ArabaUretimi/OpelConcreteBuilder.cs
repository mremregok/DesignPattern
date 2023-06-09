using OOPEducaiton.UML.BuilderPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPEducaiton.UML.BuilderPattern.ArabaUretim
{
    internal class OpelConcreteBuilder : IArabaBuilder
    {
        public OpelConcreteBuilder()
        {
            araba = new Araba();
        }
        public override void SetKM() => araba.KM = 100;
        public override void SetMarka() => araba.Marka = "Opel";
        public override void SetModel() => araba.Model = "Astra";
        public override void SetVites() => araba.Vites = true;
    }
}