using Pass_It_Out.Models;

namespace Pass_It_Out.Services.FriendServices
{
    public interface IFriend
    {
        bool Save(Friend friend);
        List<Friend> GetAllFriends(string UserId);

        Friend GetFriendById(string UserId, string Id);

        bool Update(string Id,Friend friend);

        List<Friend> GetAllSentRequests(string UserId);

        List<Friend> GetAllFriendRequests(string UserId);
    }
}
