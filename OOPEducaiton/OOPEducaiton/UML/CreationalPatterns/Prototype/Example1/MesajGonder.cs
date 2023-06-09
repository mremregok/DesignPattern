namespace OOPEducaiton.UML.CreationalPatterns.Prototype.Example1
{
    public class MesajGonder
    {
        private ToplantiMesaj prototype;
        private Personel[] liste;

        public MesajGonder(Personel[] liste, ToplantiMesaj prototype)
        {
            this.prototype = prototype;
            this.liste = liste;
        }

        public void MesajlariGonder()
        {
            foreach (var p in liste)
            {
                ToplantiMesaj tMesaj = prototype.Clone();
                tMesaj.DavetliAdiSoyadi = p.AdiSoyadi;

                var mesaj = tMesaj.MesajMetni();
                // mail.send(mesaj);
            }
        }
    }
}
