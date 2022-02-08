using RestNet5.Data.VO;
using RestNet5.Hypermedia.Utils;
using System.Collections.Generic;

namespace RestNet5.Business.Implementations
{
    public interface IPersonBusiness
    {
        PersonVO Create(PersonVO person);
        PersonVO Update(PersonVO person);
        PersonVO FindById(long id);
        List<PersonVO> FindAll();
        List<PersonVO> FindByName(string firstName, string lastName);
        PagedSearchVO<PersonVO> FindWithPagedSearch(string name, string sortDirection, int pageSize, int currentPage);
        public PersonVO Disable(long id);
        void Delete(long id);
    }
}
