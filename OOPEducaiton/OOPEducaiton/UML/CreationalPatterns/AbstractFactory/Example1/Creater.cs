using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOPEducaiton.UML.CreationalPatterns.AbstractFactory.Example1.Abstracts;

namespace OOPEducaiton.UML.CreationalPatterns.AbstractFactory.Example1
{
	public class Creater
	{
		DatabaseFactory _databaseFactory;
		Connection _connection;
		Command _command;
		public Creater(DatabaseFactory databaseFactory)
		{
			_databaseFactory = databaseFactory;
			_connection = _databaseFactory.CreateConnection();
			_command = _databaseFactory.CreateCommand();

			Start();
		}

		public void Start()
		{
			if (_connection.State == "Open")
			{
				_connection.Connect();
				_command.Execute("Select * from...");
				_connection.DisConnect();
			}
		}
	}

	public class Creater<T> where T : DatabaseFactory, new()
	{
		DatabaseFactory _databaseFactory;
		Connection _connection;
		Command _command;
		public Creater()
		{
			_databaseFactory = new T();
			_connection = _databaseFactory.CreateConnection();
			_command = _databaseFactory.CreateCommand();

			Start();
		}

		public void Start()
		{
			if (_connection.State == "Open")
			{
				_connection.Connect();
				_command.Execute("Select * from...");
				_connection.DisConnect();
			}
		}
	}
}
