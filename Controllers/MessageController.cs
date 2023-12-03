using Microsoft.AspNetCore.Mvc;
using Pass_It_Out.Authentication;
using Pass_It_Out.Models;
using Pass_It_Out.Services.MessageServices;
using Pass_It_Out.ViewModels;

namespace Pass_It_Out.Controllers
{
    [UserAuthentication]
    public class MessageController : Controller
    {
        private IMessage service;

        public MessageController(IMessage service)
        {
            this.service = service;
        }
        public IActionResult Index(string PostOwnerId)
        {
            ViewBag.PostOwnerId = PostOwnerId;
            //List<Message> messages = service.GetAllMessages();
            return View();
        }
        public IActionResult MyMessages() 
        {
            string CurrentUserId = HttpContext.Session.GetString("UserId");
            List<Message> messages = service.GetAllMessages(CurrentUserId);
            ViewBag.Messages = messages;
            return View();
        }

        public IActionResult Save(MessagesVM messagesVM) 
        { 
            Message message=new Message();
            message.To = messagesVM.To;
            message.Msg = messagesVM.Msg;
            message.UserId = HttpContext.Session.GetString("UserId");
            service.Save(message);
            return RedirectToAction("Index","DashBoard");
        }
    }
}
