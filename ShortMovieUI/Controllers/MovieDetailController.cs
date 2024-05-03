using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace ShortMovieUI.Controllers
{
	public class MovieDetailController : Controller
	{
		private readonly IMovieService _movieService;
		private readonly ICommentService _commentService;

		public MovieDetailController(IMovieService movieService, ICommentService commentService)
		{
			_movieService = movieService;
			_commentService = commentService;
		}



		public IActionResult Movie(int id)
		{
			var movie = _movieService.TGetByID(id);
			ViewBag.MovieId = id;
			return View(movie);
		}

		[HttpGet]
		public PartialViewResult AddComment(int movieId)
		{
			var comment = new Comment { MovieID = movieId };
			return PartialView("_CommentFormPartial", comment);
		}

		[HttpPost]
		public IActionResult AddComment(Comment comment)
		{
			
			comment.CommentDate = DateTime.Now;
			_commentService.TAdd(comment);
			return RedirectToAction("Movie", "MovieDetail", new { id = comment.MovieID });

		}


	}
}
