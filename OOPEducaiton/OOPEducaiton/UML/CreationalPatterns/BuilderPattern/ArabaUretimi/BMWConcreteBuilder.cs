using OOPEducaiton.UML.BuilderPattern;

namespace OOPEducaiton.UML.BuilderPattern.ArabaUretim
{
    internal class BMWConcreteBuilder : IArabaBuilder
    {
        public BMWConcreteBuilder()
        {
            araba = new Araba();
        }
        public override void SetKM() => araba.KM = 25;
        public override void SetMarka() => araba.Marka = "BMW";
        public override void SetModel() => araba.Model = "1995";
        public override void SetVites() => araba.Vites = false;
    }
}