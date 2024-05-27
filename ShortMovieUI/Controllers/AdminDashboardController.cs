﻿using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace ShortMovieUI.Controllers
{
    public class AdminDashboardController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly ICategoryService _categoryService;
        private readonly IDirectorService _directorService;

        public AdminDashboardController(IMovieService movieService, ICategoryService categoryService, IDirectorService directorService)
        {
            _movieService = movieService;
            _categoryService = categoryService;
            _directorService = directorService;
        }

        public IActionResult Index()
        {
            ViewBag.moviecount = _movieService.TGetList().Count.ToString();
            ViewBag.categorycount = _categoryService.TGetList().Count.ToString();
            ViewBag.directorcount = _directorService.TGetList().Count.ToString();
            return View();
        }
    }
}