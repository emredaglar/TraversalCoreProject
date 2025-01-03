using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProject.Areas.Admin.Models;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class RoleController : Controller
	{
		private readonly RoleManager<AppRole> _roleManager;

		public RoleController(RoleManager<AppRole> roleManager)
		{
			_roleManager = roleManager;
		}

		public IActionResult Index()
		{
			var values = _roleManager.Roles.ToList();
			return View(values);
		}
		[HttpGet]
		public IActionResult CreateRole()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateRole(CreateRoleViewModel createRoleViewModel)
		{
			AppRole role = new AppRole()
			{
				Name = createRoleViewModel.RoleName,

				ConcurrencyStamp = Guid.NewGuid().ToString()
			};
			var result = await _roleManager.CreateAsync(role);
			if (result.Succeeded)
			{
				return RedirectToAction("Index");
			}
			else
			{
				return View();
			}
		}
		public async Task<IActionResult> DeleteRole(int id)
		{
			var value=_roleManager.Roles.FirstOrDefault(x => x.Id == id);
			await _roleManager.DeleteAsync(value);
			return RedirectToAction("Index");
		}
	}
}