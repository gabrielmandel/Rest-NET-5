using RestNet5.Model;
using RestNet5.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestNet5.Repository.Implementations
{
    public class PersonRepositoryImplementation : IPersonRepository
    {
        private MySqlContext  _context;

        public PersonRepositoryImplementation(MySqlContext context)
        {
            _context = context;
        }
        
        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
            return person;
        }

        public Person FindById(long id)
        {
            return _context.People.SingleOrDefault(p => p.Id.Equals(id));
        }

        public List<Person> FindAll()
        {
            return _context.People.ToList();
        }

        public Person Update(Person person)
        {
            if (!Exists(person.Id)) return new Person();

            var result = _context.People.SingleOrDefault(p => p.Id.Equals(person.Id));

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(person);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw;
                }

            }
            return person;
        }

        public void Delete(long id)
        {
            var result = _context.People.SingleOrDefault(p => p.Id.Equals(id));

            if (result != null)
            {
                try
                {
                    _context.People.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
        public bool Exists(long id)
        {
            return _context.People.Any(prop => prop.Id.Equals(id));
        }
    }
}
