using RestNet5.Data.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestNet5.Business
{
    public interface ILoginBusiness
    {
        TokenVO ValidateCredentials(UserVO user);
        TokenVO ValidateCredentials(TokenVO token);
    }
}
