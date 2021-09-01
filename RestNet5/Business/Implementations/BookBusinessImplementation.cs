using RestNet5.Model;
using RestNet5.Repository.Generic;
using System.Collections.Generic;

namespace RestNet5.Business.Implementations
{
    public class BookBusinessImplementation : IBookBusiness
    {
        private readonly IRepository<BookVO> _repository;

        public BookBusinessImplementation(IRepository<BookVO> repository)
        {
            _repository = repository;
        }

        public BookVO Create(BookVO book)
        {
            return _repository.Create(book);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<BookVO> FindAll()
        {
           return _repository.FindAll();
        }

        public BookVO FindById(long id)
        {
            return _repository.FindById(id);
        }

        public BookVO Update(BookVO book)
        {
            return _repository.Update(book);
        }
    }
}
