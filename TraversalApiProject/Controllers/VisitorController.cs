using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TraversalApiProject.DAL.Context;
using TraversalApiProject.DAL.Entities;

namespace TraversalApiProject.Controllers
{
	[EnableCors]
	[Route("api/[controller]")]
	[ApiController]
	public class VisitorController : ControllerBase
	{
		[HttpGet]
		public IActionResult VisitorList()
		{
			using (var context = new Context())
			{
				var values = context.Visitors.ToList();
				return Ok(values);
			}
		}
		[HttpPost]
		public IActionResult VisitorAdd(Visitor visitor)
		{
			using (var context = new Context())
			{
				context.Add(visitor);
				context.SaveChanges();
				return Ok();
			}
		}
		[HttpGet("{id}")]
		public IActionResult VisitorGet(int id)
		{
			using (var context = new Context())
			{
				var values = context.Visitors.Find(id);
				if (values == null)
				{
					return NotFound();
				}
				else
				{
					return Ok(values);
				}

			}
		}
		[HttpDelete("{id}")]
		public IActionResult DeleteVisitor(int id)
		{
			using (var context = new Context())
			{
				var values = context.Visitors.Find(id);
				if (values == null)
				{
					return NotFound();
				}
				else
				{
					context.Remove(values);
					context.SaveChanges();
					return Ok();
				}

			}
		}
		[HttpPut]
		public IActionResult UpdateVisitor(Visitor visitor)
		{
			using (var context = new Context())
			{
				var values = context.Find<Visitor>(visitor.VisitorId);
				if (values == null)
				{
					return NotFound();
				}
				else
				{
					values.City = visitor.City;
					values.Country = visitor.Country;
					values.VisitorSurname = visitor.VisitorSurname;
					values.VisitorName = visitor.VisitorName;
					values.Mail= visitor.Mail;
					context.Update(values);
					context.SaveChanges();
					return Ok();
				}

			}
		}
	}
}
