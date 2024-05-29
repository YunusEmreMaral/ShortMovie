using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ShortMovieUI.ViewComponents.AdminDashboard
{
    public class _AdminDashboardGrafik : ViewComponent
    {
        private readonly IMovieService _movieService;

        public _AdminDashboardGrafik(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public IViewComponentResult Invoke()
        {
            var moviesWithCategoryAndDirector = _movieService.TMovieWithCategoryAndDirector();

            // Her bir kategorinin film sayısını hesaplamak için bir sözlük oluşturun
            var categoryMovieCounts = new Dictionary<string, int>();
            foreach (var movie in moviesWithCategoryAndDirector)
            {
                string categoryName = movie.Category.CategoryName;

                if (!categoryMovieCounts.ContainsKey(categoryName))
                {
                    categoryMovieCounts[categoryName] = 0;
                }

                categoryMovieCounts[categoryName]++;
            }

            return View(categoryMovieCounts);
        }




    }
}
