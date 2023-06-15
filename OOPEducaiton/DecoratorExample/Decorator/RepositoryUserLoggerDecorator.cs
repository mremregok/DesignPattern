using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecoratorExample.Interface;
using DecoratorExample.Models;
using Microsoft.EntityFrameworkCore;

namespace DecoratorExample.Decorator
{
	public class RepositoryUserLoggerDecorator<T> : RepositoryDecorator<T> where T : User
	{
		private readonly DbSet<Log> logs;
		public RepositoryUserLoggerDecorator(IRepository<T> repository) : base(repository)
		{
			logs = context.Set<Log>();
		}

		public override T Add(T entity)
		{
			string logMessage = $"Eklenen kişinin bilgileri: {entity.Name} {entity.Surname}";

			logs.Add(new Log
			{
				Message = logMessage,
				LogTarihi = DateTime.Now
			});

			context.SaveChanges();

			return base.Add(entity);
		}

		public override List<T> GetAll()
		{
			string logMessage = "Tüm veriler listelendi.";

			logs.Add(new Log
			{
				Message = logMessage,
				LogTarihi = DateTime.Now
			});

			context.SaveChanges();

			return base.GetAll();
		}
	}
}
