using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace ShortMovieUI.ViewComponents.MovieHome
{
	public class _MovieHomeSlider : ViewComponent
	{
		MovieManager mm = new MovieManager(new EfMovieRepository());
		public IViewComponentResult Invoke()
		{
			var movies=mm.TGetList();
			return View(movies);
		}
	}
}
