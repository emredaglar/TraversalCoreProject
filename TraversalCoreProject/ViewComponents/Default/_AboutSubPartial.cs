using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.ViewComponents.Default
{
    public class _AboutSubPartial:ViewComponent
    {
        AboutSubManager aboutSubManager = new AboutSubManager(new EfAboutSubDal());
        public IViewComponentResult Invoke()
        {
            var values = aboutSubManager.TGetList();
            return View(values);
        }
    }
}
