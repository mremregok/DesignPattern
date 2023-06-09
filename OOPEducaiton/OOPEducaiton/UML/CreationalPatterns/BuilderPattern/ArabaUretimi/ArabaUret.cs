using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPEducaiton.UML.BuilderPattern.ArabaUretim
{
    internal class ArabaUretDirector
    {
        public void Uret(IArabaBuilder arabaBuilder)
        {
			arabaBuilder.SetKM();
			arabaBuilder.SetMarka();
			arabaBuilder.SetModel();
			arabaBuilder.SetVites();

            Console.WriteLine(arabaBuilder.Araba.ToString());
        }
    }
}