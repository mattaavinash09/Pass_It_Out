using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Pass_It_Out.Authentication;
using Pass_It_Out.Models;
using Pass_It_Out.Services.PostServices;
using Pass_It_Out.ViewModels;
using System.Drawing;

namespace Pass_It_Out.Controllers
{
    [UserAuthentication]
    public class PostController : Controller
    {
        private IPost service;

        public PostController(IPost service)
        {
            this.service = service;
        }

        public ActionResult MakePostActive(int id)
        {
            Post post = service.GetPostById(id);
            post.Status = true;
            service.Update(post, id);
            return RedirectToAction("Index");
        }
        public ActionResult MakePostInActive(int id)
        {
            Post post = service.GetPostById(id);
            post.Status = false;
            service.Update(post,id);
            return RedirectToAction("Index");
        }

        public IActionResult FriendsPosts()
        {
            List<Post> posts = service.GetAllFriendsPosts();
            return View(posts);
        }
        public IActionResult AllPosts()
        {
            string UserId = HttpContext.Session.GetString("UserId");
            List<Post> allposts = service.GetAllPosts(UserId);
            return View(allposts);  
        }
        public IActionResult Index()
        {
            string CurrentUserId = HttpContext.Session.GetString("UserId");
            List<Post> posts = service.MyPosts(CurrentUserId);
            List<Category> categories= service.GetAllCategories();

            foreach(var post in posts)
            {
                foreach(var category in categories)
                {
                    if(post.CategoryId==category.CategoryId)
                    {
                        ViewBag.CategoryName = category.Name;
                    }
                }
            }
           
            return View(posts);
        }

        [HttpPost]
                
        public IActionResult Save(UserPostVM postVM)
        {
            if (ModelState.IsValid)
            {
                Post post = new Post();
                if (HttpContext.Session.Id != null)
                {
                    post.UserId = HttpContext.Session.GetString("UserId");
                }
                post.Title = postVM.Title;
                post.CategoryId = postVM.CategoryId;
                post.Description = postVM.Description;
                post.Location = postVM.Location;
                post.PostTo = postVM.PostTo;
                post.CreatedBy = postVM.CreatedBy;
                post.CreatedDate = DateTime.Now.ToString();
                post.Upload_Images = GetImage(postVM.Upload_Images);
                post.Status = true;
                bool success=service.Save(post);
                if(success)
                {
                    TempData["Message"] = "Data Saved Succesfully!!!";
                }
                else
                {
                    TempData["Message"] = "Data not Saved!!!";
                }
                return RedirectToAction("Index","DashBoard");
            }
            return View("Index");
        }


        [NonAction]
        public byte[] GetImage(IFormFile Photo)
        {
            byte[] data = null;
            if (Photo!=null && Photo.Length>0)
            {
                using (var stream=Photo.OpenReadStream())
                {
                    data=new byte[stream.Length];
                    stream.Read(data, 0, data.Length);
                }
            }
            return data;
        }

        [UserAuthentication]
        public IActionResult AddPost()
        {
            List<Category> categories = service.GetAllCategories();
            ViewBag.CatogriesList = categories;
            return View();
        }

        [HttpGet]
        public ActionResult EditPost(int id) 
        {
            List<Category> categories = service.GetAllCategories();
            ViewBag.CatogriesList = categories;
            Post post = service.GetPostById(id);
            return View(post);
        }

        [HttpPost]
        public ActionResult EditPost(UserPostVM postVM,int Id) 
        {
            if (ModelState.IsValid)
            {
                Post post = service.GetPostById(Id);
                if (HttpContext.Session.Id != null)
                {
                    post.UserId = HttpContext.Session.GetString("UserId");
                }
                post.Title = postVM.Title;
                post.CategoryId = postVM.CategoryId;
                post.Description = postVM.Description;
                post.Location = postVM.Location;
                post.PostTo = postVM.PostTo;
                post.CreatedBy = postVM.CreatedBy;
                post.CreatedDate = DateTime.Now.ToString();
                post.Upload_Images = GetImage(postVM.Upload_Images);
                post.Status = true;
                bool success = service.Update(post);
                if (success)
                {
                    TempData["Message"] = "Data Updated Succesfully!!!";
                }
                else
                {
                    TempData["Message"] = "Data not Updated!!";
                }
                return RedirectToAction("Index", "Post");
            }
            return View();

        }
    }
}
