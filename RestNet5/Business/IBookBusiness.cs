using RestNet5.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestNet5.Business
{
    public interface IBookBusiness
    {
        BookVO Create(BookVO book);
        BookVO Update(BookVO book);
        BookVO FindById(long id);
        List<BookVO> FindAll();
        void Delete(long id);

    }
}
