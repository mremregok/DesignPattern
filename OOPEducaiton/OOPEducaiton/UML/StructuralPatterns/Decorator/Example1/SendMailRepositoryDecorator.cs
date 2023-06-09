using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEducaiton.UML.StructuralPatterns.Decorator.Example1
{
    //ConcreteDecorator
    //Herhangi bir kayıt güncellendiğinde kim tarafından hangi
    //tarihte yapıldığına dair yöneticiye mail gönderilsin
    class SendMailRepositoryDecorator<T> : DecoratorRepository<T> where T : class
    {
        readonly IRepository<T> _repository;
        public SendMailRepositoryDecorator(IRepository<T> repository) : base(repository)
        {
            _repository = repository;
        }
        public override void Update(T model)
        {
            base.Update(model);
            Console.WriteLine($"{DateTime.Now} | Yöneticiye mail gönderildi...");
        }
    }
}
