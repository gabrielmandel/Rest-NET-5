using RestNet5.Model;
using System.Collections.Generic;

namespace RestNet5.Business.Implementations
{
    public interface IPersonBusiness
    {
        Person Create(Person person);
        Person Update(Person person);
        Person FindById(long id);
        List<Person> FindAll();
        void Delete(long id);
    }
}
