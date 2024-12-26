using Microsoft.AspNetCore.Mvc;
using TraversalCoreProject.CQRS.Handlers.DestinationHandlers;
using TraversalCoreProject.CQRS.Queries.DestinationQueries;

namespace TraversalCoreProject.Areas.Admin.Controllers
{

	[Area("Admin")]
	public class DestinationCQRSController : Controller
	{
		private readonly GetAllDestinationQueryHandler _getAllDestinationQueryHandler;
		private readonly GetDestionationByIDQueryHandler _getDestionationByIDQueryHandler;

        public DestinationCQRSController(GetAllDestinationQueryHandler getAllDestinationQueryHandler, GetDestionationByIDQueryHandler getDestionationByIDQueryHandler)
        {
            _getAllDestinationQueryHandler = getAllDestinationQueryHandler;
            _getDestionationByIDQueryHandler = getDestionationByIDQueryHandler;
        }

        public IActionResult Index()
		{
			var values = _getAllDestinationQueryHandler.Handle();
			return View(values);
		}
		[HttpGet]
		public IActionResult GetDestination(int id)
		{
			var values = _getDestionationByIDQueryHandler.Handle(new GetDestinationByIDQuery(id));
			return View(values);
		}

	}
}
