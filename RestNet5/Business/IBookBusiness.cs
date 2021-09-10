using RestNet5.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestNet5.Business
{
    public interface IBookBusiness
    {
        Book Create(Book book);
        Book Update(Book book);
        Book FindById(long id);
        List<Book> FindAll();
        void Delete(long id);

    }
}
