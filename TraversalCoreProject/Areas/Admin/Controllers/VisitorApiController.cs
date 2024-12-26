using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
	public class VisitorApiController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public VisitorApiController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public IActionResult Index()
		{

			return View();
		}
	}
}
