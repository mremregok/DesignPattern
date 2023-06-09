using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEducaiton.UML.StructuralPatterns.Decorator.Example1
{
    public interface IRepository<T> where T : class
    {
        public T Get(int id);
        public T GetAll();
        public void Add(T model);
        public void Delete(T model);
        public void Update(T model);
    }
}
