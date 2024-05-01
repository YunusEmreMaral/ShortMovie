using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MovieManager : IMovieService
    {
        IMovieDal _movieDal;

        public MovieManager(IMovieDal movieDal)
        {
            _movieDal = movieDal;
        }

        public void TAdd(Movie t)
        {
            _movieDal.Insert(t);
        }

        public void TDelete(Movie t)
        {
            _movieDal.Delete(t);
        }

        public Movie TGetByID(int id)
        {
            return _movieDal.GetByID(id);
        }

        public List<Movie> TGetList()
        {
            return _movieDal.GetList();
        }

		public List<Movie> TGetMoviesAdvices()
		{
			return _movieDal.GetMoviesAdvices();
		}

		public List<Movie> TGetMoviesLast()
		{
			return _movieDal.GetMoviesLast();
		}

		public List<Movie> TGetMoviesLikes()
		{
			return _movieDal.GetMoviesLikes();
		}

		public List<Movie> TGetMoviesLong()
		{
			return _movieDal.GetMoviesLong();
		}

		public List<Movie> TGetMoviesNew()
		{
			return _movieDal.GetMoviesNew();
		}

		public List<Movie> TGetMoviesPrizes()
		{
			return _movieDal.GetMoviesPrizes(); 
		}

		public List<Movie> TGetMoviesRandom()
		{
			return _movieDal.GetMoviesRandom();
		}

		public List<Movie> TGetMoviesShort()
		{
			return _movieDal.GetMoviesShort();
		}

		public List<Movie> TMovieWithCategoryAndDirector()
		{
            return _movieDal.GetMoviesWithCategoryandDirector();
		}

		public void TUpdate(Movie t)
        {
            _movieDal.Update(t);
        }
    }
}
