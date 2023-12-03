using Pass_It_Out.Models;

namespace Pass_It_Out.Services.UserServices
{
    public interface IUser
    {
        bool Login(User user);
        bool Registration(User user);
        User GetUserById(string id);
        bool IsUserExit(User user);
    }
}
