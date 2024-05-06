using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace ShortMovieUI.Controllers
{
    public class MovieMood : Controller
    {
        private readonly IMovieService _movieService;

        public MovieMood(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public IActionResult Mood()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Mood(string mood)
        {
            int id = _movieService.TGetMovieId(mood);
            // AJAX isteği ile alınan id değeri JavaScript tarafına döndürülüyor
            return Json(new { id = id });
        }


    }
}
