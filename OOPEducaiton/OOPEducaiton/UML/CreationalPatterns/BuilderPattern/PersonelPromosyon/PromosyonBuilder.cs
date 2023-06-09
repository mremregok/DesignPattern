namespace OOPEducaiton.UML.BuilderPattern.PersonelPromosyon
{
    public abstract class PromosyonBuilder
    {
        protected Promosyon promosyon = default(Promosyon);
        public Promosyon Promosyon => promosyon;
        public abstract void SetUrunAdi();
        public abstract void SetPromosyonNumarasi();
        public abstract void SetCalisanProfili();
        public override string ToString()
        {
            return $"{Promosyon.CalisanProfili}, {Promosyon.UrunAdi}, {Promosyon.PromosyonNumarasi}";
        }
    }
}