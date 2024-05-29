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
		public List<Movie> DirectorsMovies(int id)
		{
			using (var c = new Context())
			{
				return c.Movies.Where(x => x.DirectorID == id).OrderByDescending(x => x.MovieID).ToList();
			}
		}

		public List<Movie> GetChooseCategoryMovies(int id)
		{
			using (var c = new Context())
			{
				return c.Movies.Where(x=>x.CategoryID==id).OrderByDescending(x => x.MovieID).ToList();
			}
		}

		public List<Movie> GetLast5Movie()
		{
			using (var c = new Context())
			{
				return c.Movies.OrderByDescending(x => x.MovieID).Take(5).ToList();
			}
		}

        public int GetMovieId(string mood)
        {
			using (var _context = new Context())
			{
				var random = new Random();
				int movieId = 0;

				// Belirli bir mood'a göre filmleri seçme
				IQueryable<Movie> selectedMoviesQuery = mood switch
				{
					"Heyecan" => _context.Movies.Where(m => m.Category.CategoryName == "Korku" || m.Category.CategoryName == "Aksiyon"),
					"Eğlence" => _context.Movies.Where(m => m.Category.CategoryName == "Komedi"),
					"Mutlu" => _context.Movies.Where(m => m.Category.CategoryName == "Romantik" || m.Category.CategoryName == "Komedi" || m.Category.CategoryName == "Animasyon"),
					"Üzgün" => _context.Movies.Where(m => m.Category.CategoryName == "Dram"),
					_ => throw new ArgumentException("Geçersiz duygu durumu", nameof(mood))
				};

				// Seçilen filmler arasından rastgele bir film seçme
				var selectedMovies = selectedMoviesQuery.ToList();
				if (selectedMovies.Any())
				{
					int randomIndex = random.Next(0, selectedMovies.Count);
					movieId = selectedMovies[randomIndex].MovieID;
				}

				return movieId;

			
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
