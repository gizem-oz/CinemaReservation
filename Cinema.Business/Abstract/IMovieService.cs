using Cinema.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Business.Abstract
{
    public interface IMovieService
    {
        Task<IList<Movie>> MoviesWithCategoryAsync();



        Task<Movie> GetMovieById(int id);
        Task<IList<Movie>> GetMovieList();
        Task<IList<Movie>> GetListByMovieName(string name);
        Task Add(Movie movie);
        Task AddRange(List<Movie> movieList);
        Task Update(Movie movie);
        Task Delete(int id);
    }
}
