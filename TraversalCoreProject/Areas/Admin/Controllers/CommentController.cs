using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class CommentController : Controller
	{
		//CommentManager commetManager=new CommentManager(new EfCommentDal()); 
		//efbağımlılığı var ondan kurtulduk.
		private readonly ICommentService _commentService;

		public CommentController(ICommentService commentService)
		{
			_commentService = commentService;
		}

		public IActionResult Index()
		{
			var values = _commentService.TGetListCommentWithDestination();
			return View(values);
		}
		public IActionResult DeleteComment(int id)
		{
			var values = _commentService.TGetById(id);
			_commentService.TDelete(values);
			return RedirectToAction("Index", "Comment", new { Areas = "Admin" });
		}
	}
}
