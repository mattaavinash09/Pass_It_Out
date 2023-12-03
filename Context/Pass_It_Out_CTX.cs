using Microsoft.EntityFrameworkCore;
using Pass_It_Out.Models;

namespace Pass_It_Out.Context
{
    public class Pass_It_Out_CTX : DbContext
    {
        public Pass_It_Out_CTX(DbContextOptions<Pass_It_Out_CTX> options):base(options) 
        { 
        
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Friend> Friends { get; set; }

        public DbSet<Category> Categories { get; set; }
    }
}
