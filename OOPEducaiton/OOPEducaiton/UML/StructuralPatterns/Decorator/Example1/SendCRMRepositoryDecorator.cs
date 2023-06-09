using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPEducaiton.UML.StructuralPatterns.Decorator.Example1
{
    //ConcreteDecorator
    //Herhangi bir kayıt silindiğinde veya güncellendiğinde CRM veritabanına
    //API’lar aracılığıyla bağlanılarak aynı değişiklikler oraya da yansıtılsın
    public class SendCRMRepositoryDecorator<T> : DecoratorRepository<T> where T : class
    {
        readonly IRepository<T> _repository;
        public SendCRMRepositoryDecorator(IRepository<T> repository) : base(repository)
        {
            _repository = repository;
        }
        public override void Delete(T model)
        {
            base.Delete(model);
            Console.WriteLine("Kaydın silinmesi CRM veritabanına işlendi.");
        }
        public override void Update(T model)
        {
            base.Update(model);
            Console.WriteLine("Kaydın güncellenmesi CRM veritabanına işlendi.");
        }
    }
}
