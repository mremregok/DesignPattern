using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEducaiton.UML.CreationalPatterns.Prototype.Example2
{
	public class PrototypeExample2Runner<T> where T : IPrototype, new()
	{
        IPrototype _prototype;
        public PrototypeExample2Runner()
        {
            _prototype = new T();

            _prototype.SetName("Emre", "Gök");

			List<IPrototype> prototypes = new List<IPrototype>();

            for(int i = 0; i < 10; i++)
            {
                Prototype newPrototype = _prototype.Clone();
				newPrototype.SetName($"{i + 1}. İsim", $"{i+1}. Soyisim");
                prototypes.Add(newPrototype);
            }

            foreach(var prototype in prototypes)
            {
                Console.WriteLine(prototype.ToString());
            }
		}
    }
}
