using RestNet5.Model;
using RestNet5.Repository.Generic;
using System.Collections.Generic;

namespace RestNet5.Repository
{
    public interface IPersonRepository : IRepository<Person>
    {
        Person Disable(long id);
        List<Person> FindByName(string firstName, string lastName);
    }
}
