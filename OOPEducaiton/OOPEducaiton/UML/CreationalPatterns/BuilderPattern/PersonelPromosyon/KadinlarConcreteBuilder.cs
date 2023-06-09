namespace OOPEducaiton.UML.BuilderPattern.PersonelPromosyon
{
    public class KadinlarConcreteBuilder : PromosyonBuilder
    {
        public KadinlarConcreteBuilder()
        {
            promosyon = new Promosyon();
        }
        public override void SetCalisanProfili() => promosyon.CalisanProfili = "Kadınlar";
        public override void SetPromosyonNumarasi() => promosyon.PromosyonNumarasi = 125;
        public override void SetUrunAdi() => promosyon.UrunAdi = "Çanta";
    }


}