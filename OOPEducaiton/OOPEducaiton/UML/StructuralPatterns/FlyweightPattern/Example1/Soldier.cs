using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEducaiton.UML.StructuralPatterns.FlyweightPattern.Example1
{
    // FlyWeight Class
    public abstract class Soldier
    {

        #region Intrinsic Fields

        // Bütün FlyWeight nesne örnekleri tarafından ortak olan ve paylaşılan veriler
        protected string UnitName;
        protected string Guns;
        protected string Health;

        #endregion


        #region Extrinsic Fields

        // İstemci tarafından değerlendirilip hesaplanan ve MoveTo operasyonuna
        // gönderilerek FlyWeight nesne örnekleri tarafından değerlendirilen veriler
        protected int X;
        protected int Y;

        #endregion


        public abstract void MoveTo(int x, int y);
    }
}
