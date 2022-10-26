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

        public bool AddMovie(Movie movie)
        {
            if (movie == null)
            {
                return false;
            }

            try
            {
                _context.Movies.Add(movie);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool DeleteMovie(int id)
        {
            
            var movie = GetMovieById(id);

            if (movie == null)
            {
                return false;
            }

            movie.Is_Deleted = true;

            try
            {
                _context.Movies.Update(movie);
            }
            catch (Exception)
            {
                return false;
            }
            

            return true;
        }

        public List<Movie> GetAllMovies()
        {
            return _context.Movies.ToList();
        }

        public Movie GetMovieById(int id)
        {
            var movie = _context.Movies.FirstOrDefault(x => x.Id == id);
            
            return movie;
 
        }

        public List<Movie> GetMoviesByName(string name)
        {
            return _context.Movies.Where(x => x.Title!.Contains(name)).ToList();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public bool UpdateMovie(Movie movie)
        {
            if (movie == null)
            {
                return false;
            }

            _context.Movies.Update(movie);

            return true;
        }
    }
}
