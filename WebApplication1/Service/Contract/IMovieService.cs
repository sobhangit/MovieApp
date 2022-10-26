using WebApplication1.Models;
using WebApplication1.Models.ViewModel;

namespace WebApplication1.Service.Contract
{
    public interface IMovieService
    {
        List<MovieDto> GetAllMovies();
        MovieDto GetMovieById(int id);
        List<MovieDto> GetMoviesByName(string name);
        bool DeleteMovie(int id);
        bool UpdateMovie(MovieDto movieDto);
        bool AddMovie(MovieDto movieDto);
        void Save();
    }
}
