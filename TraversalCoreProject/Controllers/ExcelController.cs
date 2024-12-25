using BusinessLayer.Abstract;
using ClosedXML.Excel;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using TraversalCoreProject.Models;

namespace TraversalCoreProject.Controllers
{
	public class ExcelController : Controller
	{
		private readonly IExcelService _excelService;

		public ExcelController(IExcelService excelService)
		{
			_excelService = excelService;
		}
		public IActionResult Index()
		{
			return View();

		}
		public List<DestinationModel> DestinationList()
		{
			List<DestinationModel> destinationModels = new List<DestinationModel>();
			using (var c = new Context())
			{
				destinationModels = c.Destinations.Select(x => new DestinationModel
				{
					City = x.City,
					DayNight = x.DayNight,
					Price = x.Price,
					Capacity = x.Capacity
				}).ToList();
			}
			return destinationModels;

		}
		public IActionResult StaticExcelReport()
		{
			return File(_excelService.ExcelList(DestinationList()), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "YeniExcel.xlsx");


			//ExcelPackage excel = new ExcelPackage();
			//var workSheet = excel.Workbook.Worksheets.Add("Sayfa1");
			//workSheet.Cells[1, 1].Value = "Rota";
			//workSheet.Cells[1, 2].Value = "Rehber";
			//workSheet.Cells[1, 3].Value = "Kontenjan";

			//workSheet.Cells[2, 1].Value = "Gürcistan Batum Turu";
			//workSheet.Cells[2, 2].Value = "Kadir Yıldız";
			//workSheet.Cells[2, 3].Value = "50";

			//workSheet.Cells[3, 1].Value = "Sırbistan-Makedonya Turu";
			//workSheet.Cells[3, 2].Value = "Zeynep Öztürk";
			//workSheet.Cells[3, 3].Value = "15";

			//var bytes = excel.GetAsByteArray();
			//return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "dosya2.xlsx");
		}
		public IActionResult DestinationExcelReport()
		{
			using (var workBook = new XLWorkbook())
			{
				var workSheets = workBook.Worksheets.Add("Tur Listesi");
				workSheets.Cell(1, 1).Value = "Şehir";
				workSheets.Cell(1, 2).Value = "Konaklama Süres";
				workSheets.Cell(1, 3).Value = "Fiyat";
				workSheets.Cell(1, 4).Value = "Kapasite";

				int rowCount = 2;
				foreach (var item in DestinationList())
				{
					workSheets.Cell(rowCount, 1).Value = item.City;
					workSheets.Cell(rowCount, 2).Value = item.DayNight;
					workSheets.Cell(rowCount, 3).Value = item.Price;
					workSheets.Cell(rowCount, 4).Value = item.Capacity;
					rowCount++;

				}
				using (var stream = new MemoryStream())
				{
					workBook.SaveAs(stream);
					var content = stream.ToArray();
					return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "YeniListe.xlsx");
				}
			}
		}
	}
}