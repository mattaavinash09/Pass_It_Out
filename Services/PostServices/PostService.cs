using Pass_It_Out.Context;
using Pass_It_Out.Models;
using System.Linq;

namespace Pass_It_Out.Services.PostServices
{
    public class PostService : IPost
    {
        private Pass_It_Out_CTX ctx;

        public PostService(Pass_It_Out_CTX ctx)
        {
            this.ctx = ctx;
        }

        public List<Post> GetAllPosts(string UserId)
        {
            var friends = ctx.Friends.Where(f => f.UserId == UserId).Select(f=>f.FriendId).ToList();

            var listOfAll = ctx.Posts.Where(p => p.PostTo == "2").ToList();
            
            var listOfOnlyFriends=ctx.Posts.Where(p=>p.PostTo=="1" && friends.Contains(p.UserId)).ToList();
            
            var totalList=new List<Post>();
            totalList.AddRange(listOfAll);
            totalList.AddRange(listOfOnlyFriends);

            return totalList;
        }


        public List<Post> GetAllPosts()
        {
            List<Post> AllPosts = ctx.Posts.Where(val => val.PostTo == "2").ToList();
            return AllPosts;



        }
        public List<Post> MyPosts(string UserId)
        {
            var posts = ctx.Posts.Where(p => p.UserId == UserId).ToList();
            return posts;   
        }
        public bool Save(Post post)
        {
            ctx.Posts.Add(post);
            int rowsimpacted=ctx.SaveChanges();
            return rowsimpacted > 0;
        }
        public List<Category> GetAllCategories() 
        { 
            return ctx.Categories.ToList();
        }
        public Post GetPostById(int id)
        {
            Post post= ctx.Posts.Where(val => val.Id == id).FirstOrDefault();
            return post;
        }

        public bool Update(Post post)
        {
            ctx.Posts.Update(post);
            int rowsupdated =ctx.SaveChanges();
            return rowsupdated > 0;
        }

      

        public List<Post> GetAllFriendsPosts()
        {
            List<Post> posts = ctx.Posts.Where(val => val.PostTo == "1").ToList();
            return posts;
        }

        public bool Update(Post post, int id)
        {
            int rowsimpacted=0;
            Post updatedpost = post;
            ctx.Update(post);
            rowsimpacted = ctx.SaveChanges();
            return rowsimpacted > 0;
        }
    }
}
