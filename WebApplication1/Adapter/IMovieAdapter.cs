using WebApplication1.Models;
using WebApplication1.Models.ViewModel;

namespace WebApplication1.Adapter
{
    public interface IMovieAdapter
    {
        MovieDto GetDto(Movie movie);
        List<MovieDto> GetDtos(List<Movie> movies);
        Movie GetMovie(MovieDto movieDto);
        List<Movie> GetMovies(List<MovieDto> movieDtos);
    }
}
