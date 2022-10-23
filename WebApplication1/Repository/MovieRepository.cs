using WebApplication1.DAL;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ApplicationDbContext _context;

        public MovieRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddMovie(Movie movie)
        {
            _context.Movies.Add(movie);
        }

        public void DeleteMovie(int id)
        {
            if(GetMovieById(id) != null)
            {
                _context.Movies.Remove(GetMovieById(id));
                _context.SaveChanges();
            }
        }

        public List<Movie> GetAllMovies()
        {
            return _context.Movies.ToList();
        }

        public Movie GetMovieById(int id)
        {
            return _context.Movies.FirstOrDefault(x => x.Id == id);
        }

        public List<Movie> GetMoviesByName(string name)
        {
            return _context.Movies.Where(x => x.Title!.Contains(name)).ToList();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateMovie(Movie movie)
        {
            _context.Movies.Update(movie);
        }
    }
}
