using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecoratorExample.Interface;
using DecoratorExample.Models;
using Microsoft.EntityFrameworkCore;

namespace DecoratorExample.Repository
{
	public class Repository<T> : IRepository<T> where T : class
	{
		TutorialContext context;
		DbSet<T> _dbSet;
        public Repository()
        {
            context = new TutorialContext();
			_dbSet = context.Set<T>();
		}
        public T Add(T entity)
		{
			_dbSet.Add(entity);
			context.SaveChanges();
			return entity;
		}

		public List<T> GetAll()
		{
			return _dbSet.ToList();
		}

		public T GetById(int id)
		{
			return _dbSet.Find(id);
		}

		public bool Remove(T entity)
		{
			try
			{
				_dbSet.Remove(entity);
				context.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public T Update(T entity)
		{
			_dbSet.Update(entity);
			context.SaveChanges();
			return entity;
		}
	}
}
