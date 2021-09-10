using RestNet5.Data.Converter.Contract;
using RestNet5.Data.VO;
using RestNet5.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestNet5.Data.Converter.Implementations
{
    public class PersonConverter : IParser<VO.PersonVO, Model.Person>, IParser<Model.Person, VO.PersonVO>
    {
        public Model.Person Parse(VO.PersonVO origin)
        {
            if (origin == null)
            {
                return null;
            }

            return new Model.Person
            {
                Id = origin.Id,
                FirstName = origin.FirstName,
                LastName = origin.LastName,
                Address = origin.Address,
                Gender = origin.Gender
            };
        }

        public VO.PersonVO Parse(Model.Person origin)
        {
            if (origin == null)
            {
                return null;
            }

            return new VO.PersonVO
            {
                Id = origin.Id,
                FirstName = origin.FirstName,
                LastName = origin.LastName,
                Address = origin.Address,
                Gender = origin.Gender
            };
        }

        public List<Model.Person> Parse(List<VO.PersonVO> origin)
        {
            if (origin == null)
            {
                return null;
            }

            return origin.Select(item => Parse(item)).ToList();
        }

        public List<VO.PersonVO> Parse(List<Model.Person> origin)
        {
            if (origin == null)
            {
                return null;
            }

            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
