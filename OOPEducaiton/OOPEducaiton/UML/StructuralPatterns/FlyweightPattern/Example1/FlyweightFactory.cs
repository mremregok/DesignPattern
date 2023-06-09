using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEducaiton.UML.StructuralPatterns.FlyweightPattern.Example1
{
    // FlyWeight Factory
    class SoldierFactory
    {

        // Depolama alanı(Havuz).
        // Uygulama ortamında tekrar edecek olan FlyWeight nesne
        // örnekleri depolama alanında basit birer Key ile ifade edilir
        private Dictionary<SoldierType, Soldier> _soldiers;

        public SoldierFactory()
        {
            _soldiers = new Dictionary<SoldierType, Soldier>();
        }

        public Soldier GetSoldier(SoldierType sType)
        {
            Soldier soldier = null;

            // Eğer depolama alanında, parametre olarak gelen Key ile eşleşen bir
            // FlyWeight nesnesi var ise onu çek
            if (_soldiers.ContainsKey(sType))
                soldier = _soldiers[sType];
            else
            {
                // Yoksa Key tipine bakarak uygun FlyWeight nesne örneğini oluştur
                // ve depolama alanına(havuz) ekle
                if (sType == SoldierType.Private)
                    soldier = new Private();
                if (sType == SoldierType.Sergeant)
                    soldier = new Sergeant();

                _soldiers.Add(sType, soldier);
            }

            // Elde edilen FlyWeight nesnesini geri döndür
            return soldier;

        }

    }
}
