using RestNet5.Model;
using System.Collections.Generic;

namespace RestNet5.Repository.Implementations
{
    public interface IPersonRepository
    {
        Person Create(Person person);
        Person Update(Person person);
        Person FindById(long id);
        List<Person> FindAll();
        void Delete(long id);
        bool Exists(long id);
        
    }
}
