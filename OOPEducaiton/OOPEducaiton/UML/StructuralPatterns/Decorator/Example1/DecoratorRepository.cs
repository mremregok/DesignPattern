using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEducaiton.UML.StructuralPatterns.Decorator.Example1
{
    //Decorator
    public class DecoratorRepository<T> : IRepository<T> where T : class
    {
        readonly IRepository<T> _repository;
        public DecoratorRepository(IRepository<T> repository)
        {
            _repository = repository;
        }
        virtual public void Add(T model)
        {
            _repository.Add(model);
        }
        virtual public void Delete(T model)
        {
            _repository.Delete(model);
        }
        virtual public T Get(int id)
        {
            return _repository.Get(id);
        }
        virtual public T GetAll()
        {
            return _repository.GetAll();
        }
        virtual public void Update(T model)
        {
            _repository.Update(model);
        }
    }
}
