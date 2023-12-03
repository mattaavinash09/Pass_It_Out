using Pass_It_Out.Context;
using Pass_It_Out.Models;

namespace Pass_It_Out.Services.UserServices
{
    public class UserService : IUser
    {
        private Pass_It_Out_CTX ctx;

        public UserService(Pass_It_Out_CTX ctx)
        {
            this.ctx = ctx;
        }
        public User GetUserById(string id)
        {
            return ctx.Users.Where(val => val.UserId == id).FirstOrDefault();
        }

        public bool IsUserExit(User user)
        {
            return ctx.Users.Any(val => val.UserId == user.UserId);
        }

        public bool Login(User user)
        {
            return true;
        }

        public bool Registration(User user)
        {
            try
            {
                ctx.Users.Add(user);
                int rowsupdated = ctx.SaveChanges();
                return rowsupdated > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
