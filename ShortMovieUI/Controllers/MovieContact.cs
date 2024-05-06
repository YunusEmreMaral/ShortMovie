using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace ShortMovieUI.Controllers
{
	public class MovieContact : Controller
	{
		private readonly IContactService _contactService;

		public MovieContact(IContactService contactService)
		{
			_contactService = contactService;
		}

		[HttpGet]
		public IActionResult ContactUs()
		{
			return View();
		}

		[HttpPost]
		public IActionResult ContactUs(Contact contact)
		{
			_contactService.TAdd(contact);
			return View();
		}
	}
}
