using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace ShortMovieUI.ViewComponents.MovieHome
{
	public class _MovieHomeAdvice : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			MovieManager mm = new MovieManager(new EfMovieRepository());
			var advices = mm.TGetMoviesAdvices();
			return View(advices);
		}
	}
}
