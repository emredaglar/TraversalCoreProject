using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

using TraversalCoreProject.Models;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class MailController : Controller
	{
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Index(MailRequest mailRequest)
		{
			try
			{
				MimeMessage mimeMessage = new MimeMessage();

				MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin", "deneme@gmail.com");
				mimeMessage.From.Add(mailboxAddressFrom);

				MailboxAddress mailboxAddressTo = new MailboxAddress("User", mailRequest.ReceiverMail);
				mimeMessage.From.Add(mailboxAddressTo);

				var bodyBuilder = new BodyBuilder();
				bodyBuilder.TextBody = mailRequest.Body;

				mimeMessage.Subject = mailRequest.Subject;

				SmtpClient client = new SmtpClient();
				client.Connect("smtp.gmail.com", 587, false);
				client.Authenticate("deneme@gmail.com", "123456aA-");
				client.Send(mimeMessage);
				client.Disconnect(true);
				TempData["SuccessMessage"] = "Mail başarılı bir şekilde gönderildi.";
			}
			catch (Exception)
			{
				TempData["ErrorMessage"] = "Mail gönderimi sırasında bir hata oluştu.";
			}
			return View();
		}
	}
}
