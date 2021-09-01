using RestNet5.Data.Converter.Contract;
using RestNet5.Data.VO;
using RestNet5.Model;

using System.Collections.Generic;
using System.Linq;

namespace RestNet5.Data.Converter.Implementations
{
    public class BookConverter : IParser<Book, BookVO>, IParser<BookVO, Book >
    {
        public Book Parse(BookVO origin)
        {
            if (origin == null)
            {
                return null;
            }

            return new Book
            {
                Id = origin.Id,
                Author = origin.Author,
                LaunchDate = origin.LaunchDate,
                Price = origin.Price,
                Title = origin.Title
            };
        }

        public BookVO Parse(Book origin)
        {
            if (origin == null)
            {
                return null;
            }

            return new BookVO
            {
                Id = origin.Id,
                Author = origin.Author,
                LaunchDate = origin.LaunchDate,
                Price = origin.Price,
                Title = origin.Title
            };
        }

        public List<Book> Parse(List<BookVO> origin)
        {
            if (origin == null)
            {
                return null;
            }

            return origin.Select(item => Parse(item)).ToList();
        }

        public List<BookVO> Parse(List<Book> origin)
        {
            if (origin == null)
            {
                return null;
            }

            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
