using Cinema.Business.Abstract;
using Cinema.DataAccess.Abstract;
using Cinema.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Business.Concrete
{
    public class MovieManager:IMovieService
    {
        private readonly IMovieDal _movieDal;
        public MovieManager(IMovieDal movieDal)
        {
            _movieDal = movieDal;
        }

        public async Task Add(Movie movie)
        {
            var name = await _movieDal.Get(x=>x.Name == movie.Name);
            if (name == null)
            {
                await _movieDal.Add(movie);
            }
            
        }

        public async Task AddRange(List<Movie> movieList)
        {
            if (movieList.Count>0)
            {
                await _movieDal.AddRange(movieList);
            }
        }

        public async Task Delete(int id)
        {
            Movie movie = await GetMovieById(id);
            if (movie != null)
            {
                movie.Status = false;
                await Update(movie);
            }
            
        }

        public async Task<IList<Movie>> GetListByMovieName(string name)
        {
            return await _movieDal.GetAll(x=>x.Name.Contains(name));
        }

        public async Task<Movie> GetMovieById(int id)
        {
            return await _movieDal.Get(x=>x.Id == id);
        }

        public async Task<IList<Movie>> GetMovieList()
        {
            return await _movieDal.GetAll();
        }

        public async Task<IList<Movie>> MoviesWithCategoryAsync()
        {
            return await _movieDal.MoviesWithCategoryAsync();
        }

        public async Task Update(Movie movie)
        {
            await _movieDal.Update(movie);
        }
    }
}
