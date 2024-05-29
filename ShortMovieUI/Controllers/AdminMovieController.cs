using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;
using System.Linq;
using X.PagedList;

namespace ShortMovieUI.Controllers
{
    [Authorize]
    public class AdminMovieController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly ICategoryService _categoryService;
        private readonly IDirectorService _directorService;

        public AdminMovieController(IMovieService movieService, ICategoryService categoryService, IDirectorService directorService)
        {
            _movieService = movieService;
            _categoryService = categoryService;
            _directorService = directorService;
        }

        public IActionResult Index(string searchString, int page = 1)
        {
            int pageSize = 10;
            var movies = _movieService.TMovieWithCategoryAndDirector();

            if (!string.IsNullOrEmpty(searchString))
            {
                searchString = searchString.ToLower();
                movies = movies.Where(m => m.MovieName.ToLower().Contains(searchString)).ToList();
            }

            var pagedMovies = movies.ToPagedList(page, pageSize);

            ViewBag.SearchString = searchString;
            return View(pagedMovies);
        }

        [HttpGet]
        public IActionResult AddMovie()
        {
            List<SelectListItem> categoryList = _categoryService.TGetList().Select(x => new SelectListItem { Text = x.CategoryName, Value = x.CategoryID.ToString() }).ToList();
            ViewBag.Categories = categoryList;

            List<SelectListItem> directorList = _directorService.TGetList().Select(x => new SelectListItem { Text = x.DirectorNameSurname, Value = x.DirectorID.ToString() }).ToList();
            ViewBag.Directors = directorList;

            return View();

        }

        [HttpPost]
        public IActionResult AddMovie(Movie movie, IFormFile MovieImage)
        {
            try
            {
                if (MovieImage != null && MovieImage.Length > 0)
                {
                    var fileName = Path.GetFileName(MovieImage.FileName);
                    var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/movies");

                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    var filePath = Path.Combine(uploadsFolder, fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        MovieImage.CopyTo(stream);
                    }

                    movie.MovieImage = "/images/movies/" + fileName;
                }

                _movieService.TAdd(movie);
                return RedirectToAction("Index", "AdminMovie");
            }
            catch (Exception ex)
            {
                return BadRequest("Film eklenirken bir hata oluştu: " + ex.Message);
            }
        }




        public IActionResult DeleteMovie(int id)
        {
            var movie = _movieService.TGetByID(id);
            if (movie != null)
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", movie.MovieImage.TrimStart('/'));
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }

                _movieService.TDelete(movie);
            }
            return RedirectToAction("Index", "AdminMovie");
        }
        [HttpGet]
        public IActionResult UpdateMovie(int id)
        {
            var movie = _movieService.TGetByID(id);
            if (movie == null)
            {
                // Hata mesajı veya başka bir işlem ekleyebilirsiniz
                return NotFound();
            }

            var categoryList = _categoryService.TGetList()
                .Select(x => new SelectListItem
                {
                    Text = x.CategoryName,
                    Value = x.CategoryID.ToString(),
                    Selected = x.CategoryID == movie.CategoryID
                })
                .ToList();

            var directorList = _directorService.TGetList()
                .Select(x => new SelectListItem
                {
                    Text = x.DirectorNameSurname,
                    Value = x.DirectorID.ToString(),
                    Selected = x.DirectorID == movie.DirectorID
                })
                .ToList();

            ViewBag.Categories = categoryList;
            ViewBag.Directors = directorList;

            return View(movie);
        }



        [HttpPost]
        public IActionResult UpdateMovie(Movie movie, IFormFile MovieImage)
        {
            var existingMovie = _movieService.TGetByID(movie.MovieID);

            try
            {
                if (MovieImage != null && MovieImage.Length > 0)
                {
                    var fileName = Path.GetFileName(MovieImage.FileName);
                    var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/movies");

                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    var filePath = Path.Combine(uploadsFolder, fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        MovieImage.CopyTo(stream);
                    }

                    // Eski dosyayı sil
                    var oldFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", existingMovie.MovieImage.TrimStart('/'));
                    if (System.IO.File.Exists(oldFilePath))
                    {
                        System.IO.File.Delete(oldFilePath);
                    }

                    movie.MovieImage = "/images/movies/" + fileName;
                }
                else
                {
                    movie.MovieImage = existingMovie.MovieImage;
                }

                _movieService.TUpdate(movie);
                return RedirectToAction("Index", "AdminMovie");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Film güncellenirken bir hata oluştu: " + ex.Message);

                var categoryList = _categoryService.TGetList()
                    .Select(x => new SelectListItem { Text = x.CategoryName, Value = x.CategoryID.ToString() })
                    .ToList();
                var directorList = _directorService.TGetList()
                    .Select(x => new SelectListItem { Text = x.DirectorNameSurname, Value = x.DirectorID.ToString() })
                    .ToList();

                foreach (var category in categoryList)
                {
                    if (category.Value == movie.CategoryID.ToString())
                    {
                        category.Selected = true;
                        break;
                    }
                }

                foreach (var director in directorList)
                {
                    if (director.Value == movie.DirectorID.ToString())
                    {
                        director.Selected = true;
                        break;
                    }
                }

                ViewBag.Categories = categoryList;
                ViewBag.Directors = directorList;

                return View(movie);
            }
        }

    }

}
