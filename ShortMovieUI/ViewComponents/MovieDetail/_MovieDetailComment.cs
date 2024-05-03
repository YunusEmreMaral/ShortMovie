using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace ShortMovieUI.ViewComponents.MovieDetail
{
	public class _MovieDetailComment:ViewComponent
	{
		private readonly ICommentService _commentService;

		public _MovieDetailComment(ICommentService commentService)
		{
			_commentService = commentService;
		}
	
		public IViewComponentResult Invoke(int movieID)
		{
			var comments = _commentService.TCommentListThisMovie(movieID);
			return View(comments);
		} 
	}
}
