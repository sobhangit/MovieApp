using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public interface IMovieRepository
    {
        List<Movie> GetAllMovies();
        Movie GetMovieById(int id);
        List<Movie> GetMoviesByName(string name);
        void AddMovie(Movie movie);
        void UpdateMovie(Movie movie);
        void DeleteMovie(int id);
        void Save();
    }
}
