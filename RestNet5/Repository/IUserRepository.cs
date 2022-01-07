using RestNet5.Data.VO;
using RestNet5.Model;

namespace RestNet5.Repository
{
    public interface IUserRepository
    {
        User ValidadeCredentials(UserVO user);
        User ValidadeCredentials(string userName);
        User RefreshUserInfo(User user);

    }
}
