using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMovieService:IGenericService<Movie>
    {
        List<Movie> TMovieWithCategoryAndDirector();
		List<Movie> TGetMoviesAdvices();
		List<Movie> TGetMoviesPrizes();
		List<Movie> TGetMoviesLikes();
		List<Movie> TGetMoviesRandom();
		List<Movie> TGetMoviesLast();
		List<Movie> TGetMoviesNew();
		List<Movie> TGetMoviesShort();
		List<Movie> TGetMoviesLong();
		List<Movie> TGetLast5Movie();

		List<Movie> TGetChooseCategoryMovies(int id);

        int TGetMovieId(string mood);
		List<Movie> TDirectorsMovies(int id);




	}
}
