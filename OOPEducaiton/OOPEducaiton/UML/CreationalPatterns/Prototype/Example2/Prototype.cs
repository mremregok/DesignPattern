using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEducaiton.UML.CreationalPatterns.Prototype.Example2
{
	public class Prototype : IPrototype
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public Prototype Clone()
		{
			return MemberwiseClone() as Prototype;
		}

		public void SetName(string name, string surname)
		{
			Name = name;
			Surname = surname;
		}

		public override string ToString()
		{
			return $"İsim: {Name}, Soyisim: {Surname}";
		}
	}
}
