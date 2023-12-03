using Pass_It_Out.Context;
using Pass_It_Out.Models;

namespace Pass_It_Out.Services
{
    public class Pass_It_Out_Service : IPass_It_Out
    {
        private Pass_It_Out_CTX ctx;

        public Pass_It_Out_Service(Pass_It_Out_CTX ctx)
        {
            this.ctx = ctx;
        }
        public bool Save(User user)
        {
            try
            {
                User user1 = new User();
                user1.UserId = user.UserId;
                user1.FirstName = user.FirstName;
                user1.LastName = user.LastName;
                user1.Password = user.Password;
                ctx.Users.Add(user1);
                int rowsimpacted=ctx.SaveChanges();
                return rowsimpacted > 0;
            }
            catch (Exception ex) 
            { 
                
            }
           
            return false;
        }
    }
}
