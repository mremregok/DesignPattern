using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecoratorExample.Models;

namespace DecoratorExample.Interface
{
    public interface IRepository<T> where T : class
	{
        public T GetById(int id);
        public List<T> GetAll();
        public bool Remove(T entity);
        public T Add(T entity);
        public T Update(T entity);
    }
}
