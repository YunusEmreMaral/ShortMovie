using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IMovieDal:IGenericDal<Movie>
    {
        List<Movie> GetMoviesWithCategoryandDirector();
        List<Movie> GetMoviesAdvices();
        List<Movie> GetMoviesPrizes();
        List<Movie> GetMoviesLikes();
        List<Movie> GetMoviesRandom();
        List<Movie> GetMoviesLast();
        List<Movie> GetMoviesNew();
        List<Movie> GetMoviesShort();
        List<Movie> GetMoviesLong();
        List<Movie> GetLast5Movie();

        List<Movie> GetChooseCategoryMovies(int id);


        int  GetMovieId(string mood);


            }
}
