using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;
using System.Linq;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;

namespace ShortMovieUI.Controllers
{
    [Authorize]
    public class AdminCommentController : Controller
    {
        private readonly ICommentService _commentService;

        public AdminCommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IActionResult Index(string searchString, int page = 1)
        {
            int pageSize = 10;
            var comments = _commentService.TGetList();

            if (!string.IsNullOrEmpty(searchString))
            {
                searchString = searchString.ToLower();
                comments = comments.Where(c => c.CommentNameSurname.ToLower().Contains(searchString)).ToList();
            }

            var pagedComments = comments.ToPagedList(page, pageSize);

            ViewBag.SearchString = searchString;
            return View(pagedComments);
        }


        public IActionResult Details(int id)
        {
            var comment = _commentService.TGetByID(id);
            if (comment == null)
            {
                return NotFound();
            }
            return View(comment);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var comment = _commentService.TGetByID(id);
            if (comment == null)
            {
                return NotFound();
            }

            _commentService.TDelete(comment);
            return RedirectToAction("Index");
        }
    }
}
