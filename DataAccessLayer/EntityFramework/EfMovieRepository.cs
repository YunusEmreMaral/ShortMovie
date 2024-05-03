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
		public List<Movie> GetLast5Movie()
		{
			using (var c = new Context())
			{
				return c.Movies.OrderByDescending(x => x.MovieID).Take(5).ToList();
			}
		}

		//SIRALAMALARA BAKILACAK TEKRARDAN DÜŞÜNÜLECEK

		public List<Movie> GetMoviesAdvices()
		{
			using (var c = new Context())
			{
				return c.Movies.Where(x=>x.MovieAdvice==true).Include(x => x.Category).Include(x => x.Director).ToList();
			}
		}

		public List<Movie> GetMoviesLast()
		{
			using (var c = new Context())
			{
				return c.Movies.OrderBy(x=>x.MovieDate).Include(x => x.Category).Include(x => x.Director).Take(5).ToList();
			}
		}

		public List<Movie> GetMoviesLikes()
		{
			using (var c = new Context())
			{
				return c.Movies.OrderByDescending(x=>x.MovieLike).Include(x => x.Category).Include(x => x.Director).ToList();
			}
		}

		public List<Movie> GetMoviesLong()
		{
			using (var c = new Context())
			{
				return c.Movies.OrderByDescending(x => x.MovieTime).Include(x => x.Category).Include(x => x.Director).Take(5).ToList();
			}
		}

		public List<Movie> GetMoviesNew()
		{
			using (var c = new Context())
			{
				return c.Movies.OrderByDescending(x => x.MovieDate).Include(x => x.Category).Include(x => x.Director).Take(5).ToList();
			}
		}

		public List<Movie> GetMoviesPrizes()
		{
			using (var context = new Context())
			{
				return context.Movies.Where(x=>x.MoviePrize==true).Include(x=>x.Category).Include(x=>x.Director).Take(5).ToList();
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

		public List<Movie> GetMoviesShort()
		{
			using (var c = new Context())
			{
				return c.Movies.OrderBy(x => x.MovieTime).Include(x => x.Category).Include(x => x.Director).Take(5).ToList();
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
