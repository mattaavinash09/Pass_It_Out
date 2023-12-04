using Microsoft.AspNetCore.Mvc;
using Pass_It_Out.Authentication;
using Pass_It_Out.Models;
using Pass_It_Out.Services.FriendServices;
using Pass_It_Out.ViewModels;

namespace Pass_It_Out.Controllers
{
    [UserAuthentication]
    public class FriendController : Controller
    {
        private IFriend service;

        public FriendController(IFriend service)
        {
            this.service = service;
        }
        public IActionResult Index()
        {
            return View("Index");
        }
        public IActionResult Save(string FriendId)
        {
            if(ModelState.IsValid)
            {
                Friend friend=new Friend();
                friend.UserId = HttpContext.Session.GetString("UserId");
                friend.FriendId = FriendId;
                friend.Status = "Pending";
                friend.RequestDate=DateTime.Now;
                friend.ConfirmDate = null;
                bool success= service.Save(friend);
                if(success)
                {
                    TempData["Message"] = "Data Saved Successfully!!!";
                    return RedirectToAction("SentRequests");
                }
                else
                {
                    TempData["Message"] = "Data Not Saved!!!";
                }
            }
            return RedirectToAction("SentRequests");
        }

        [HttpGet]
        public IActionResult AcceptFriend(string Id)
        {
            string UserId = HttpContext.Session.GetString("UserId");
            Friend friendid =service.GetFriendById(UserId,Id);
            friendid.Status = "Active";
            friendid.ConfirmDate= DateTime.Now;
            bool success = service.Update(Id, friendid);
            return RedirectToAction("AllFriends");
        }

        public IActionResult BlockFriend(string Id)
        {
            string UserId = HttpContext.Session.GetString("UserId");
            Friend friend = service.GetFriendById(UserId,Id);
            friend.Status = Common.Constants.FriendStatus.Block;
            friend.ConfirmDate = DateTime.Now;
            bool success = service.Update(Id, friend);
            return RedirectToAction("AllFriends");
        }
        public IActionResult SentRequests()
        {
            string UserId = HttpContext.Session.GetString("UserId");
            List<Friend> SentRequests = service.GetAllSentRequests(UserId);
            ViewBag.SentRequests = SentRequests;
            return View();
        }
        public IActionResult FriendsRequests()
        {
            string UserId = HttpContext.Session.GetString("UserId");
            List<Friend> friends = service.GetAllFriendRequests(UserId);
            ViewBag.FriendsList = friends;
            return View(friends);
        }

        public IActionResult AllFriends()
        {
            string UserId = HttpContext.Session.GetString("UserId");
            ViewBag.UserId=UserId;
            List<Friend> AllFriends = service.GetAllFriends(UserId);
            ViewBag.AllFriends = AllFriends;
            return View() ;
        }
    }
}
