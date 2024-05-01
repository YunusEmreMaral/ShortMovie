using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace ShortMovieUI.ViewComponents.MovieHome2.Kısım
{
	public class _MovieHomeShort : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			MovieManager mm = new MovieManager(new EfMovieRepository());
			var movies = mm.TGetMoviesShort();
			return View(movies);
		}

	}
}
