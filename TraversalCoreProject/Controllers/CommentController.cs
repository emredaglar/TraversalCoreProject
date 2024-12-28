using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Controllers
{
    [AllowAnonymous]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly UserManager<AppUser> _userManager;

		public CommentController(ICommentService commentService, UserManager<AppUser> userManager)
		{
			_commentService = commentService;
			_userManager = userManager;
		}
		[HttpGet]
        public async Task<PartialViewResult> AddComment()
        {
           
			//ViewBag.destId = id;
   //         var value = await _userManager.FindByNameAsync(User.Identity.Name);
			//ViewBag.UserId = id;
			return PartialView();
        }
        [HttpPost]
        public IActionResult AddComment(Comment comment)
        {
			comment.CommentDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
			comment.CommantState = true;
			_commentService.TAdd(comment);
            return RedirectToAction("Index", "Destination");
        }
    }
}
