using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEducaiton.UML.StructuralPatterns.AdapterPattern.Example2.ClassAdapterPattern
{
	// EmployeeAdapter, iki uyumsuz arayüzü veya sistemi birlikte çalıştıran sınıftır.
	// Adaptör, Adapte edilenin arayüzünü Hedefin arayüzü ile uyumlu hale getirir.
	// Class Adapter Pattern'i kullanabilmek için, Adaptör sınıfını Adapte edilen sınıftan kalıtmamız gerekmektedir.
    // Buradaki püf nokta, arayüzlerin ve sınıfların aynı sistem içerisinde yer almasıdır.
	public class EmployeeAdapter : ThirdPartyBillingSystem, ITarget
    {
        // Aşağıdaki method, çalışanları string dizisi biçiminde kabul edecektir.
        // Ardından, çalışanlar dizisini listeye dönüştürecektir.
        // Dönüştürme sonrasında adapte edilen methodu çağırarak beraber maaşları hesaplayacaktır.
        public void ProcessCompanySalary(string[,] employeesArray)
        {
            string Id = null;
            string Name = null;
            string Designation = null;
            string Salary = null;
            List<Employee> listEmployee = new List<Employee>();
            for (int i = 0; i < employeesArray.GetLength(0); i++)
            {
                for (int j = 0; j < employeesArray.GetLength(1); j++)
                {
                    if (j == 0)
                    {
                        Id = employeesArray[i, j];
                    }
                    else if (j == 1)
                    {
                        Name = employeesArray[i, j];
                    }
                    else if (j == 2)
                    {
                        Designation = employeesArray[i, j];
                    }
                    else
                    {
                        Salary = employeesArray[i, j];
                    }
                }
                listEmployee.Add(new Employee(Convert.ToInt32(Id), Name, Designation, Convert.ToDecimal(Salary)));
            }
            Console.WriteLine("Adapter converted Array of Employee to List of Employee");
            Console.WriteLine("Then delegate to the ThirdPartyBillingSystem for processing the employee salary\n");
            ProcessSalary(listEmployee);
        }
    }
}
