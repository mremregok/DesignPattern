using DecoratorExample.Decorator;
using DecoratorExample.Models;
using DecoratorExample.Repository;

namespace DecoratorExample
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Repository<User> repository = new Repository<User>();

			var emre = repository.Add(new User
			{
				Name = "Emre",
				Surname = "Gök",
				Salary = 15000
			});

			RepositoryDecorator<User> decorator = new RepositoryUserLoggerDecorator<User>(repository);

			var cihan = decorator.Add(new User
			{
				Name = "Cihan",
				Surname = "Dürmüş",
				Salary = 55000
			});

			var users = decorator.GetAll();

			var umut = decorator.Add(new User
			{
				Name = "Umut",
				Surname = "Akter",
				Salary = 20000
			});

			decorator.Remove(emre);

			var cihan2 = decorator.GetById(cihan.Id);

			decorator.Remove(cihan2);

			umut.Salary = 100000;

			decorator.Update(umut);
		}
	}
}