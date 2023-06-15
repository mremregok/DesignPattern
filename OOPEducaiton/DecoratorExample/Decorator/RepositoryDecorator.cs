using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecoratorExample.Interface;
using DecoratorExample.Models;

namespace DecoratorExample.Decorator
{
	public abstract class RepositoryDecorator<T> : IRepository<T> where T : class
	{
		protected IRepository<T> repository;
		protected TutorialContext context;
		public RepositoryDecorator(IRepository<T> repository)
		{
			this.repository = repository;
			this.context = new TutorialContext();
		}
		public virtual T Add(T entity)
		{
			return repository.Add(entity);
		}

		public virtual List<T> GetAll()
		{
			return repository.GetAll();
		}

		public virtual T GetById(int id)
		{
			return repository.GetById(id);
		}

		public virtual bool Remove(T entity)
		{
			return repository.Remove(entity);
		}

		public virtual T Update(T entity)
		{
			return repository.Update(entity);
		}
	}
}
