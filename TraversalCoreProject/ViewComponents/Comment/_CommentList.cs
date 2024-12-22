using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.ViewComponents.Comment
{
    public class _CommentList : ViewComponent
    {
        CommetManager commetManager = new CommetManager(new EfCommentDal());
        public IViewComponentResult Invoke(int id)
        {
            var values = commetManager.TGetDestinationById(id);
            return View(values);
        }
    }
}
