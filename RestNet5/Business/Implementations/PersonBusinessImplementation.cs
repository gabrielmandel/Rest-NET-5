using RestNet5.Model;
using RestNet5.Model.Context;
using RestNet5.Repository.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestNet5.Business.Implementations
{
    public class PersonBusinessImplementation : IPersonBusiness
    {
        private readonly IPersonRepository  _repository;

        public PersonBusinessImplementation(IPersonRepository repository)
        {
            _repository = repository;
        }

        public Person Create(Person person)
        {
            return _repository.Create(person);
        }

        public Person FindById(long id)
        {
            return _repository.FindById(id);
        }

        public List<Person> FindAll()
        {
            return _repository.FindAll();
        }

        public Person Update(Person person)
        {
            return _repository.Update(person);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
