using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace ShortMovieUI.ViewComponents.MovieDetail
{
	public class _MovieDetailsCategories:ViewComponent
	{
		private readonly ICategoryService _categoryService;

		public _MovieDetailsCategories(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}

		public IViewComponentResult Invoke()
		{
			var categories=_categoryService.TGetList();
			return View(categories);
		}
	}
}
