using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace ShortMovieUI.ViewComponents.MovieHomeDirectors
{
	public class _MovieHomeDirectors : ViewComponent
	{
		DirectorManager dm = new DirectorManager(new EfDirectorRepository());
		public IViewComponentResult Invoke()
		{
			var directors = dm.TGetList();
			return View(directors);
		}
	}
}