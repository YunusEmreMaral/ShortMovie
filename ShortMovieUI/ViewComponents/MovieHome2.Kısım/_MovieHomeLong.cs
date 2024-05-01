using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace ShortMovieUI.ViewComponents.MovieHome2.Kısım
{
	public class _MovieHomeLong : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			MovieManager mm = new MovieManager(new EfMovieRepository());
			var movies = mm.TGetMoviesLong();
			return View(movies);
		}
	
	}
}
