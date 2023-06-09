using OOPEducaiton.UML.BuilderPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPEducaiton.UML.BuilderPattern.ArabaUretim
{
    internal class ToyotaConcreteBuilder : IArabaBuilder
    {
        public ToyotaConcreteBuilder()
        {
            araba = new Araba();
        }
        public override void SetKM() => araba.KM = 150;
        public override void SetMarka() => araba.Marka = "Toyota";
        public override void SetModel() => araba.Model = "Corolla";
        public override void SetVites() => araba.Vites = true;
    }
}