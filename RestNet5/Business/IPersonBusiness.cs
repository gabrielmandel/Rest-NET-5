using RestNet5.Data.VO;
using System.Collections.Generic;

namespace RestNet5.Business.Implementations
{
    public interface IPersonBusiness
    {
        PersonVO Create(PersonVO person);
        PersonVO Update(PersonVO person);
        PersonVO FindById(long id);
        List<PersonVO> FindAll();
        public PersonVO Disable(long id);
        void Delete(long id);
    }
}
