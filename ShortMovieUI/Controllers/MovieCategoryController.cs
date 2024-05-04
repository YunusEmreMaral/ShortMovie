using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace ShortMovieUI.Controllers
{
	public class MovieCategoryController : Controller
	{
		private readonly IMovieService _movieService;
		private readonly ICategoryService _categoryService;

		public MovieCategoryController(IMovieService movieService, ICategoryService categoryService)
		{
			_movieService = movieService;
            _categoryService = categoryService;
        }

       

        [HttpGet]
		public IActionResult Category(int id)
		{
			 ViewBag.categoryname= _categoryService.TGetByID(id).CategoryName;
			var movies = _movieService.TGetChooseCategoryMovies(id);
			ViewBag.count = (movies.Count / 3) + 1; 
			return View(movies);
		}


		public IActionResult Categories()
		{
			var categories=_categoryService.TCategoriesWithMovies();
			return View(categories);
		}

		
	}
}
