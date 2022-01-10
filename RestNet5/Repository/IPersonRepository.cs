using RestNet5.Model;
using RestNet5.Repository.Generic;

namespace RestNet5.Repository
{
    public interface IPersonRepository : IPersonRepository<Person>
    {
        Person Disable(long id);
    }
}
