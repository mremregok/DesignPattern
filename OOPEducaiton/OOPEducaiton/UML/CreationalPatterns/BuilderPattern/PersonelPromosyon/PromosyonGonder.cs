namespace OOPEducaiton.UML.BuilderPattern.PersonelPromosyon
{
    public class PromosyonGonder<T> where T : PromosyonBuilder, new()
    {
        private T builder;
        public PromosyonGonder()
        {
            builder = new T();
        }
        public void Gonder()
        {
            builder.SetCalisanProfili();
            builder.SetPromosyonNumarasi();
            builder.SetUrunAdi();

            Console.WriteLine(builder.ToString()); ;
        }
    }
}