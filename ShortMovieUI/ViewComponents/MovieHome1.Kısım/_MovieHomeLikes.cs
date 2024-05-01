using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace ShortMovieUI.ViewComponents.MovieHome1.Kısım
{
    public class _MovieHomeLikes : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            MovieManager mm = new MovieManager(new EfMovieRepository());
            var likes = mm.TGetMoviesLikes();
            return View(likes);
        }
    }
}
