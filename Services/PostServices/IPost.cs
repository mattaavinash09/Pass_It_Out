using Pass_It_Out.Models;

namespace Pass_It_Out.Services.PostServices
{
    public interface IPost
    {
        bool Save(Post post);
        List<Post> GetAllPosts();
        List<Post> GetAllPosts(string UserId);
        List<Post> MyPosts(string UserId);

        List<Category> GetAllCategories();

        Post GetPostById(int id);

        bool Update(Post post);
        bool Update(Post post,int id);


        List<Post> GetAllFriendsPosts();
    }
}
