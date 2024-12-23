using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProject.Areas.Member.Models;

namespace TraversalCoreProject.Areas.Member.Controllers
{
	[Area("Member")]
	[Route("Member/[controller]/[action]")]
	public class ProfileController : Controller
	{
		private readonly UserManager<AppUser> _userManager;

		public ProfileController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}
		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var values = await _userManager.FindByNameAsync(User.Identity.Name);
			UserEditViewModel userEditViewModel = new UserEditViewModel();
			userEditViewModel.Name = values.Name;
			userEditViewModel.Surname = values.Surname;
			userEditViewModel.PhoneNumber = values.PhoneNumber;
			userEditViewModel.Mail = values.Email;
			return View(userEditViewModel);
		}
		[HttpPost]
		public async Task<IActionResult> Index(UserEditViewModel model)
		{
			var user = await _userManager.FindByNameAsync(User.Identity.Name);
			if (model.Image != null)
			{
				var resource = Directory.GetCurrentDirectory();
				var extension = Path.GetExtension(model.Image.FileName);
				var imagename = Guid.NewGuid() + extension;
				var savelocation = resource + "/wwwroot/userimages/" + imagename;
				var stream = new FileStream(savelocation, FileMode.Create);
				await model.Image.CopyToAsync(stream);
				user.ImageUrl = imagename;
			}
			user.Name = model.Name;
			user.Surname = model.Surname;
			user.PhoneNumber = model.PhoneNumber;
			user.Email = model.Mail;
			user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, model.Password);
			
			var result = await _userManager.UpdateAsync(user);
			if (result.Succeeded)
			{
				return RedirectToAction("SignIn", "Login");
			}
			return View();
		}
	}
}