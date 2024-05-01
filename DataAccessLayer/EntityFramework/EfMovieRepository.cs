using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
	public class EfMovieRepository : GenericRepository<Movie>, IMovieDal
	{
		//SIRALAMALARA BAKILACAK TEKRARDAN DÜŞÜNÜLECEK

		public List<Movie> GetMoviesAdvices()
		{
			using (var c = new Context())
			{
				return c.Movies.Include(x => x.Category).Include(x => x.Director).ToList();
			}
		}

		public List<Movie> GetMoviesLikes()
		{
			using (var c = new Context())
			{
				return c.Movies.Include(x => x.Category).Include(x => x.Director).ToList();
			}
		}

		public List<Movie> GetMoviesPrizes()
		{
			using (var context = new Context())
			{
				return context.Movies.Where(x=>x.MoviePrize==true).Include(x=>x.Category).Include(x=>x.Director).Take(10).ToList();
			}
		}
		public List<Movie> GetMoviesRandom()
		{
			using (var context = new Context())
			{
				var allMovies = context.Movies.Include(x => x.Category).Include(x => x.Director).ToList();
				var totalMoviesCount = allMovies.Count;
				var random = new Random();
				var selectedMovies = new List<Movie>();
				for (int i = 0; i < 10 && i < totalMoviesCount; i++)
				{	
					var randomIndex = random.Next(totalMoviesCount);
					var randomMovie = allMovies[randomIndex];
					selectedMovies.Add(randomMovie);
					allMovies.RemoveAt(randomIndex);
					totalMoviesCount--;
				}
				return selectedMovies;




			}
		}

		public List<Movie> GetMoviesWithCategoryandDirector()
		{
			using (var c = new Context())
			{
				return c.Movies.Include(x => x.Category).Include(x => x.Director).ToList();
			}

		}
	}
}
