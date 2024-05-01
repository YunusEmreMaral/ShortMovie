﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace ShortMovieUI.ViewComponents.MovieHome1.Kısım
{
    public class _MovieHomePrizes : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            MovieManager mm = new MovieManager(new EfMovieRepository());
            var prizes = mm.TGetMoviesPrizes();
            return View(prizes);
        }
    }
}
