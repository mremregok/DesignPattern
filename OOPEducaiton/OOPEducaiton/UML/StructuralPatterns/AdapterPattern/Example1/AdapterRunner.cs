using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEducaiton.UML.StructuralPatterns.AdapterPattern.Example1
{
    internal class AdapterRunner
    {
        public AdapterRunner()
        {
            Fax fax = new Fax { FaxErrorCode = 4000, ErrorDescription = "Cevap gelmiyor" };


            IError[] errors = {
                          new DbError{ErrorNumber=100,Description="Baglanti saglanamadi" },
                             new DbError{ErrorNumber=101,Description="sorgulama saglanamadi" },
                                new ServiceError{ErrorNumber=300,Description="yetki saglanamadi" },
                                   new FaxAdapter(fax)
                                };

            foreach (IError error in errors)
                error.SendMail();

            Console.ReadKey();
        }
    }
}
