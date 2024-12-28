using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.ViewComponents.Comment
{
    public class _CommentList : ViewComponent
    {
        CommentManager commetManager = new CommentManager(new EfCommentDal());
        public IViewComponentResult Invoke(int id)
        {
            
            var values = commetManager.TGetListCommentWithDestinationAndUser(id);
            ViewBag.commentCount = values.Count();
            return View(values);
        }
    }
}
