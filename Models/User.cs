using Microsoft.Extensions.Hosting;

namespace Pass_It_Out.Models
{
    public class User
    {
        public String UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public string Email { get; set; }
        public string Location { get; set; }
        public string Password { get; set; }

        public ICollection<Post> Posts { get; set; }
        public ICollection<Message> Messages { set; get; }
        public ICollection<Friend> Friends { get; set; }
    }
}
