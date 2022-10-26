using WebApplication1.Adapter;
using WebApplication1.Models;
using WebApplication1.Models.ViewModel;
using WebApplication1.Repository;
using WebApplication1.Service.Contract;

namespace WebApplication1.Service
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMovieAdapter _movieAdapter;

        public MovieService(IMovieRepository movieRepository, IMovieAdapter movieAdapter)
        {
            _movieRepository = movieRepository;
            _movieAdapter = movieAdapter;
        }

        public bool DeleteMovie(int id)
        {
            var movie_is_deleted = _movieRepository.DeleteMovie(id);
            if (movie_is_deleted)
            {
                _movieRepository.Save();
                return true;
            }
            return false;
            
        }

        public List<MovieDto> GetAllMovies()
        {
            var movies = _movieRepository.GetAllMovies();
            if (movies.Any() == false)
            {
               return new List<MovieDto>{ new MovieDto()};
            }
            return _movieAdapter.GetDtos(movies);
        }

        public MovieDto GetMovieById(int id)
        {
            var movie = _movieRepository.GetMovieById(id);
            if (movie == null)
            {
                return new MovieDto();
            }
            return _movieAdapter.GetDto(movie);
        }

        public List<MovieDto> GetMoviesByName(string name)
        {
            var movies = _movieRepository.GetMoviesByName(name);
            if (movies == null)
            {
                return new List<MovieDto> { new MovieDto()};
            }

            return _movieAdapter.GetDtos(movies);
        }

        public bool UpdateMovie(MovieDto movieDto)
        {
            var movie = _movieAdapter.GetMovie(movieDto);
            var movie_is_update = _movieRepository.UpdateMovie(movie);

            if (movie_is_update == false) return false;

            _movieRepository.Save();
            return true;
        }

        public bool AddMovie(MovieDto movieDto)
        {
            var movie = _movieAdapter.GetMovie(movieDto);

            var is_movie_added = _movieRepository.AddMovie(movie);
            if(is_movie_added == false) return false;

            _movieRepository.Save();
            return true;
        }

        public void Save()
        {
            _movieRepository.Save();
        }
    }
}
