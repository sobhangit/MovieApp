using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public interface IMovieRepository
    {
        List<Movie> GetAllMovies();
        Movie GetMovieById(int id);
        List<Movie> GetMoviesByName(string name);
        bool AddMovie(Movie movie);
        bool UpdateMovie(Movie movie);
        bool DeleteMovie(int id);
        void Save();
    }
}
