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

        public void DeleteMovie(int id)
        {
            _movieRepository.DeleteMovie(id);
            _movieRepository.Save();
        }

        public List<MovieDto> GetAllMovies()
        {
            var movies = _movieRepository.GetAllMovies();

            return _movieAdapter.GetDtos(movies);
        }

        public MovieDto GetMovieById(int id)
        {
            var movie = _movieRepository.GetMovieById(id);
            return _movieAdapter.GetDto(movie);
        }

        public List<MovieDto> GetMoviesByName(string name)
        {
            var movies = _movieRepository.GetMoviesByName(name);
            if (movies != null)
            {
                return _movieAdapter.GetDtos(movies);
            }

            List<MovieDto> movieDtos = new List<MovieDto>();
            movieDtos.Add(new MovieDto());


            return movieDtos;
        }

        public void UpdateMovie(MovieDto movieDto)
        {
            var movie = _movieAdapter.GetMovie(movieDto);
            _movieRepository.UpdateMovie(movie);
            _movieRepository.Save();
        }

        public void AddMovieToDatabase(MovieDto movieDto)
        {
            var movie = _movieAdapter.GetMovie(movieDto);
            _movieRepository.AddMovie(movie);
            _movieRepository.Save();
        }
    }
}
