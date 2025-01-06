using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;


namespace TraversalCoreProject.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ReservationController : Controller
	{
		private readonly IReservationService _reservationService;
		private readonly IAppUserService _appUserService;
		private readonly IDestinationService _destinationService;

		public ReservationController(IReservationService reservationService, IAppUserService appUserService, IDestinationService destinationService)
		{
			_reservationService = reservationService;
			_appUserService = appUserService;
			_destinationService = destinationService;
		}

		public IActionResult Index()
		{
			var values = _reservationService.TGetReservations();
			return View(values);
		}
		public IActionResult ApproveReservation(int id)
		{
			_reservationService.TSetReservationStatus(id,"Onaylandı");
			return RedirectToAction("Index");
		}
		public IActionResult PendingReservation(string status, int id)
		{
			_reservationService.TSetReservationStatus(id, "Onay Bekliyor");
			return RedirectToAction("Index");
		}
		public IActionResult CancelReservation(string status, int id)
		{
			_reservationService.TSetReservationStatus(id, "İptal Edildi");
			return RedirectToAction("Index");
		}
		public IActionResult OldReservation(string status, int id)
		{
			_reservationService.TSetReservationStatus(id, "Geçmiş Rezervasyon");
			return RedirectToAction("Index");
		}
		[HttpGet]
		public IActionResult AddReservation()
		{
			var guests = _appUserService.TGetList();
			var destinations = _destinationService.TGetList(); 

			// ViewBag için Dropdown Verileri
			ViewBag.Guests = guests.Select(x => new SelectListItem
			{
				Text = x.Name + " " + x.Surname,
				Value = x.Id.ToString()
			}).ToList();

			ViewBag.Destinations = destinations.Select(x => new SelectListItem
			{
				Text = x.City,
				Value = x.DestinationId.ToString()
			}).ToList();

			// İlk destinasyon detayını gösterelim
			var firstDestination = destinations.FirstOrDefault();
			ViewBag.FirstDestination = firstDestination;

			return View();
		}

		[HttpPost]
		public IActionResult AddReservation(Reservation reservation)
		{
			
			if (reservation.DestinationId == 0 || reservation.AppUserId == 0)
			{
				
				TempData["Error"] = "Lütfen tüm alanları doldurun!";
				return RedirectToAction("AddReservation");
			}

			reservation.Status = "Yeni Rezervasyon";
			reservation.ReservationDate = reservation.ReservationDate.Date;
			_reservationService.TAdd(reservation);
			return RedirectToAction("Index");
		}

	}
}
