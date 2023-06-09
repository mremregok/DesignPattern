using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEducaiton.UML.StructuralPatterns.AdapterPattern.Example2.ClassAdapterPattern
{
    public class ThirdPartyBillingSystem
    {
        //ThirdPartyBillingSystem, çalışanların bilgilerini işleyebilmek için çalışan listesi kabul etmektedir.
        public void ProcessSalary(List<Employee> listEmployee)
        {
            foreach (Employee employee in listEmployee)
            {
                Console.WriteLine("Rs." + employee.Salary + " Salary Credited to " + employee.Name + " Account");
            }
        }
    }
}
