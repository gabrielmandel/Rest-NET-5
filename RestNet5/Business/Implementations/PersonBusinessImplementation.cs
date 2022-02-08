using RestNet5.Data.Converter.Implementations;
using RestNet5.Data.VO;
using RestNet5.Hypermedia.Utils;
using RestNet5.Repository;
using System.Collections.Generic;

namespace RestNet5.Business.Implementations
{
    public class PersonBusinessImplementation : IPersonBusiness
    {
        private readonly IPersonRepository _repository;

        private readonly PersonConverter _converter;


        public PersonBusinessImplementation(IPersonRepository repository)
        {
            _repository = repository;
            _converter = new PersonConverter();
        }

        public PersonVO Create(PersonVO person)
        {
            var personEntity = _converter.Parse(person);
            personEntity = _repository.Create(personEntity);

            return _converter.Parse(personEntity);
        }

        public PersonVO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }
        public List<PersonVO> FindByName(string firstName, string lastName)
        {
            return _converter.Parse(_repository.FindByName(firstName, lastName));
        }

        public List<PersonVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        public PagedSearchVO<PersonVO> FindWithPagedSearch(string name, string sortDirection, int pageSize, int currentPage)
        {
            var sort = (!string.IsNullOrEmpty(sortDirection) && !sortDirection.Equals("desc")) ? "asc" : "desc";
            var size = (pageSize < 1) ? 10 : pageSize;
            var offset = currentPage > 0 ? (currentPage - 1) * size: 0;

            string countQuery = "select count(*) from person p where 1=1 ";
            if (!string.IsNullOrEmpty(name)) countQuery += $" and p.first_name like '%{name}%' ";

            string query = "select * from person p where 1=1 ";
            if (!string.IsNullOrEmpty(name)) query += $" and p.first_name like '%{name}%' ";

            query += $" order by p.first_name {sort} limit {size} offset {offset}";
            
            var people = _repository.FindWithPagedSearch(query);
            int totalResults = _repository.GetCount(countQuery);

            return new PagedSearchVO<PersonVO>
            {
                CurrentPage = currentPage,
                List = _converter.Parse(people),
                PageSize = size,
                SortDirections = sort,
                TotalResults = totalResults
            };
        }

        public PersonVO Update(PersonVO person)
        {
            var personEntity = _converter.Parse(person);
            personEntity = _repository.Update(personEntity);

            return _converter.Parse(personEntity);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public PersonVO Disable(long id)
        {
            var person = _repository.Disable(id);

            return _converter.Parse(person);
        }

    }
}
