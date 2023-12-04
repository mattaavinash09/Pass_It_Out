using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.EntityFrameworkCore;
using Pass_It_Out.Context;
using Pass_It_Out.Models;
using Pass_It_Out.Common;
namespace Pass_It_Out.Services.FriendServices
{
    public class FriendService : IFriend
    {
        private Pass_It_Out_CTX ctx;

        public FriendService(Pass_It_Out_CTX ctx)
        {
            this.ctx = ctx;
        }

        public List<Friend> GetAllSentRequests(string UserId)
        {
            List<Friend> sentfriendsrequests = ctx.Friends
                .Where(val => val.UserId == UserId)
                .Select(val => new Friend
                {
                    FriendId = val.FriendId,
                    RequestDate = val.RequestDate,
                    Status = val.Status,
                    ConfirmDate = val.ConfirmDate,

                }).ToList();
            return sentfriendsrequests;
                
        }

        public List<Friend> GetAllFriendRequests(string UserId)
        {
            List<Friend> friendrequests = ctx.Friends.Where(val=>val.FriendId == UserId).ToList();
            return friendrequests;
        }
        public List<Friend> GetAllFriends(string UserId)
        {
            List<Friend> friends = ctx.Friends.Where(val => val.UserId == UserId  
             ||( val.FriendId == UserId && (val.Status == Constants.FriendStatus.Active || val.Status == Constants.FriendStatus.Block))).ToList(); 
            return friends;
        }

        public Friend GetFriendById(string UserId,string Id)
        {
            Friend friend= ctx.Friends.Where(val=>val.UserId==Id && val.FriendId==UserId).FirstOrDefault();
            return friend; 
        }

        public bool Save(Friend friend)
        {
            ctx.Friends.Add(friend);
            int rowsimpacted = ctx.SaveChanges();
            return rowsimpacted > 0;
        }

        public bool Update(string Id,Friend friend)
        {
            int rowsimpacted = 0;
            ctx.Friends.Update(friend);
            rowsimpacted=ctx.SaveChanges();
            return rowsimpacted > 0;
        }

    }
}
