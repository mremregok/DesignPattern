using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEducaiton.UML.StructuralPatterns.AdapterPattern.Example2.ObjectAdapterPattern
{
    public class APExample2Runner
    {
        public APExample2Runner()
        {
            string[,] employeesArray = new string[5, 4]
            {
                {"101","John","SE","10000"},
                {"102","Smith","SE","20000"},
                {"103","Dev","SSE","30000"},
                {"104","Pam","SE","40000"},
                {"105","Sara","SSE","50000"}
            };
            //EmployeeAdapter sınıfı birbiriyle uyumsuz iki arayüzün çalışmasına olanak sağlar.
            Console.WriteLine("HR system passes employee string array to Adapter\n");
            ITarget target = new EmployeeAdapter();
            target.ProcessCompanySalary(employeesArray);
            Console.Read();
        }
    }
}
